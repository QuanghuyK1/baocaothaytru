using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;
using System.Drawing;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using static QRCoder.PayloadGenerator;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace WEB_TTTN.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;
        private readonly IMapper _mapper;
        public ScheduleRepository(HospitalDatabaseContext context, IConfiguration configuration, EmailService emailService, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
            _mapper = mapper;
        }
        public async Task<ScheduleModels> GetscheduleId(int id)
        {
            var schedule = await _context.Schedules.SingleOrDefaultAsync(u=>u.Id == id);
            return _mapper.Map<ScheduleModels>(schedule);
        }

        public async Task InsertSchedule(InputSchedule model, string username)
        {
            string format = "yyyy-MM-dd HH:mm";
            DateTime startTime;
            
            // Chuyển đổi model.Starttime từ chuỗi thành đối tượng DateTime
            if (!DateTime.TryParseExact(model.Starttime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out startTime))
            {
                throw new ArgumentException("Invalid datetime format.");
            }

            Schedule schedule;

            if (username == null)
            {
                schedule = new Schedule
                {
                    Eventname = model.Eventname,
                    Starttime = startTime,
                    Description = model.Description,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Status = 0
                };
            }
            else
            {
                var patient = await _context.Patients.SingleOrDefaultAsync(u => u.Username == username);
                if (patient == null)
                {
                    throw new ArgumentException("Patient not found.");
                }

                schedule = new Schedule
                {
                    Eventname = model.Eventname,
                    Starttime = startTime,
                    Description = model.Description,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Patientid = patient.Id,
                    Status = 0
                };
            }

            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
            var schedules = await _context.Schedules!.Where(e => e.Name == model.Name && e.PhoneNumber == model.PhoneNumber && e.Email == model.Email && e.Eventname == model.Eventname && e.Description == model.Description && e.Starttime == startTime && e.Status == 0).FirstOrDefaultAsync();
            string s = $"{model.Name}-{model.PhoneNumber}-{model.Eventname}-{startTime}";
            string qrcode = $"{schedules.Id}";
            Console.WriteLine(qrcode);
            string encodedString = CryptoHelper.EncodeTo6DigitNumber(s);

            var subject = $"Hello {model.Name}";

            // Generate the QR code image
            Bitmap qrCodeImage = QrCodeHelper.GenerateQrCode(qrcode);
            string asciiArt = ConvertBitmapToAsciiArt(qrCodeImage);
            Console.WriteLine(asciiArt);
            // Construct the email message with the QR code image as an inline attachment
            var message = $"You have an appointment with ABC hospital at the hour {startTime}. <br> Please confirm phone number {model.PhoneNumber}. <br> Below is the appointment qr code please scan the code or read the medical record id: {encodedString}";

            // Send the email with the QR code attachment
            await _emailService.SendEmailWithQRCode(model.Email, subject, message, qrcode);
        }
        static string ConvertBitmapToAsciiArt(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            const string asciiChars = "@%#*+=-:. ";

            string asciiArt = "";

            for (int y = 0; y < height; y += 2)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    int index = grayValue * (asciiChars.Length - 1) / 255;
                    asciiArt += asciiChars[asciiChars.Length - index - 1];
                }
                asciiArt += "\n";
            }

            return asciiArt;
        }

        public async Task<List<ScheduleModels>> GetAllPatSchedule()
        {
            var list = await _context.Schedules
            .Where(u => u.Endtime == null) 
            .OrderBy(s => s.Starttime)     
            .ToListAsync();

            return _mapper.Map<List<ScheduleModels>>(list);

        }
        public async Task<List<ScheduleModels>> GetAllEmpSchedule(String username)
        {
            var emp = await _context.Employees.SingleOrDefaultAsync(u => u.Username == username);
            var list = await _context.Schedules
            .Where(u => u.Employeeid == emp.Id)
            .OrderBy(s => s.Starttime)
            
            .ToListAsync();
            List<ScheduleModels> listmodel = new List<ScheduleModels>();
            foreach (Schedule s in list)
            {
                ScheduleModels model = _mapper.Map<ScheduleModels>(s);
                var location = await _context.Locations.SingleOrDefaultAsync(u => u.Id == s.Locationid);
                model.Locationname = location.Name;
                listmodel.Add(model);
            }

            return listmodel;

        }
        public async Task<List<ScheduleModels>> GetAllEmp(String username)
        {
            var list = await _context.Schedules
             .Where(u => u.Employeeid != null)
            .OrderBy(s => s.Starttime)

            .ToListAsync();
            List<ScheduleModels> listmodel = new List<ScheduleModels>();
            foreach (Schedule s in list)
            {
                ScheduleModels model = _mapper.Map<ScheduleModels>(s);
                var location = await _context.Locations.SingleOrDefaultAsync(u => u.Id == s.Locationid);
                model.Locationname = location.Name;
                var emp = await _context.Employees.SingleOrDefaultAsync(u => u.Id == s.Employeeid);
                model.Empname = emp.Username;
                model.Name = emp.Name;
                listmodel.Add(model);
            }

            return listmodel;

        }
        public async Task InsertScheduleEmp(InputScheduleEmp model, string username)
        {
            try
            {
                var employee = await _context.Employees.SingleOrDefaultAsync(u => u.Username == username);
                var location = await _context.Locations.SingleOrDefaultAsync(u => u.Name== model.LocationName);
                DateTime formattedDateTime = Convert.ToDateTime(model.Starttime);
                var schedule = new Schedule
                {
                    Employeeid = employee.Id,
                    Eventname = model.Eventname, 
                    Starttime = formattedDateTime,
                    Endtime = formattedDateTime.AddHours(4),
                    Locationid = location.Id,
                    Description = model.Description
                };

                _context.Schedules.Add(schedule);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception or throw it further
                throw new Exception("Failed to insert employee schedule.", ex);
            }
        }

        
    }
}
