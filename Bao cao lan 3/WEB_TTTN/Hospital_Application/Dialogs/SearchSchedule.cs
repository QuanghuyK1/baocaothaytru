using Hospital_Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Application.Dialogs
{
    public partial class SearchSchedule : Form
    {
        private int temp=0;
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        public SearchSchedule()
        {
            InitializeComponent();
        }

        private async void searchclick_Click(object sender, EventArgs e)
        {
            string baseUrl = "https://localhost:7061/api/Schedule/SearchSchedule"; // Thay thế bằng URL của API của bạn
            accessToken = _cache["AccessToken"] as string;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken); // Thay thế bằng access token của bạn

                var date = datesearch.Value; // Ngày bạn muốn tìm kiếm
                var name = namesearch.Text; // Tên bạn muốn tìm kiếm
                var phone = phoneSearch.Text; // Số điện thoại bạn muốn tìm kiếm
                string formattedDate = date.ToString("yyyy-MM-dd HH:mm");
                var parameters = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("date", formattedDate),
                    new KeyValuePair<string, string>("name", name),
                    new KeyValuePair<string, string>("phone", phone)
                });

                HttpResponseMessage response = await httpClient.PostAsync(baseUrl, parameters);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    ScheduleModels schedule = JsonConvert.DeserializeObject<ScheduleModels>(jsonResponse);
                    if(schedule == null)
                    {
                        MessageBox.Show("Lich khám khong tồn tại");

                    }
                    else
                    {
                        /*temp = schedule.Id;*/
                        Console.WriteLine(schedule.Eventname);
                        eventname.Text = schedule.Eventname;
                        nameschedule.Text = schedule.Name;
                        string formattedDateTime = schedule.Starttime.ToString("dd/MM/yyyy HH:mm");
                        dateschedule.Value = DateTime.ParseExact(formattedDateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        phoneschedule.Text = schedule.PhoneNumber;
                        emailText.Text = schedule.Email;
                        textBox1.Text = schedule.Description;
                        MessageBox.Show("Success");
                    }
                    
                    if(schedule.Status == 0)
                    {
                        active.Visible = true;
                    }
                    else if(schedule.Status == 1)
                    {
                        MessageBox.Show("Khách hẹn đến đúng lịch! Lịch hẹn đã kết thúc");
                    }
                    else
                    {
                        MessageBox.Show("Lịch hẹn đã bị bỏ lỡ");
                    }
                    

                }
                else
                {
                    MessageBox.Show("API call failed. Status code: " + response.StatusCode);
                }
            }
        }

        private async void active_Click(object sender, EventArgs e)
        {
            await ActivateScheduleAsync(temp);
        }
        private async Task ActivateScheduleAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/"); // Thay đổi URL API của bạn

                var formData = new Dictionary<string, string>
                        {
                            { "id", id.ToString() }
                        };

                var content = new FormUrlEncodedContent(formData);

                var response = await httpClient.PostAsync("Schedule/ActiveSchedule", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    ScheduleModels schedule = JsonConvert.DeserializeObject<ScheduleModels>(responseBody);

                    temp = schedule.Id;
                    Console.WriteLine(schedule.Eventname);
                    eventname.Text = schedule.Eventname;
                    nameschedule.Text = schedule.Name;
                    string formattedDateTime = schedule.Starttime.ToString("dd/MM/yyyy HH:mm");
                    dateschedule.Value = DateTime.ParseExact(formattedDateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    phoneschedule.Text = schedule.PhoneNumber;
                    emailText.Text = schedule.Email;
                    textBox1.Text = schedule.Description;
                    MessageBox.Show("Success");
                    if (schedule.Status == 0)
                    {
                        active.Visible = true;
                    }
                    else if (schedule.Status == 1)
                    {
                        MessageBox.Show("Khách hẹn đến đúng lịch! Lịch hẹn đã kết thúc");
                    }
                    else
                    {
                        MessageBox.Show("Lịch hẹn đã bị bỏ lỡ");
                    }
                }
                else
                {
                    // Xử lý lỗi khi gọi API không thành công
                }
            }
        }
    }
}
