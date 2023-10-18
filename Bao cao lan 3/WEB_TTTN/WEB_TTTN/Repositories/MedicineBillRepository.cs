using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QRCode;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Transactions;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class MedicineBillRepository : IMedicineBillRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly AutoIncre _ae;

        public MedicineBillRepository(HospitalDatabaseContext context, IMapper mapper, AutoIncre ae)
        {
            _context = context;
            _mapper = mapper;
            _ae = ae;
        }

        public async Task InsertBill(InputMedicineBill entity)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var existingMed = await _context.Medicines.SingleOrDefaultAsync(e => e.Name == entity.MedName);
                    if (existingMed != null)
                    {
                        existingMed.Count -= entity.Count;

                        var medicinebill = new MedicineBill
                        {
                            Medicineid = existingMed.Id,
                            Serviceid = entity.ServiceId,
                            BillCode = await _ae.GetNextBillCode(),
                            Count = entity.Count,
                            TotalPrice = entity.TotalPrice,
                            Status = entity.Status
                        };
                        _context.MedicineBills.Add(medicinebill);

                        await _context.SaveChangesAsync();

                        // Hoàn thành giao dịch thành công
                        transactionScope.Complete();
                    }
                    else
                    {
                        // Không tìm thấy thuốc, xử lý lỗi hoặc rollback nếu cần
                        Console.WriteLine("Medicine not found.");
                    }
                }
                catch (Exception ex)
                {
                    // Giao dịch không thành công, xử lý lỗi hoặc rollback nếu cần
                    Console.WriteLine("Transaction failed: " + ex.Message);
                }
            }

        }

        public async Task UpdateBill(InputMedicineBill entity, int id)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var existingBill = await _context.MedicineBills.FindAsync(id);
                    var existingMed = await _context.Medicines.SingleOrDefaultAsync(e => e.Name == entity.MedName);

                    if (existingBill == null)
                    {
                        throw new Exception("MedicineBill not found");
                    }

                    int temp = existingMed.Count;
                    existingMed.Count = temp + existingBill.Count - entity.Count;
                    existingBill.Count = entity.Count;

                    await _context.SaveChangesAsync();

                    // Hoàn thành giao dịch thành công
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    // Giao dịch không thành công, xử lý lỗi hoặc rollback nếu cần
                    Console.WriteLine("Transaction failed: " + ex.Message);
                }
            }

        }

        public async Task DeleteMedicineBill(int id)
        {
            var existingBill = await _context.MedicineBills.FindAsync(id);
            if (existingBill != null)
            {
                _context.MedicineBills.Remove(existingBill);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<MedicineBillModels>> GetAllByService(int id)
        {
            var listbill = await _context.MedicineBills.Where(b => b.Serviceid == id).ToListAsync();
            List<MedicineBillModels> listmodel = new List<MedicineBillModels>();
            foreach (var bill in listbill)
            {
                MedicineBillModels model = new MedicineBillModels();
                var med = await _context.Medicines.SingleOrDefaultAsync(s => s.Id == bill.Medicineid);
                model.PriceMed = med.Price;
                model.MedicineName = med.Name;
                model.Count = bill.Count;
                model.TotalPrice = bill.TotalPrice;
                model.Status = bill.Status;
                model.Id = bill.Id;
                model.Serviceid = bill.Serviceid;
                listmodel.Add(model);
            }
            return listmodel;
        }

        public async Task AcceptBill(List<MedicineBillModels> list)
        {
            foreach (var bill in list)
            {
                var existingBill = await _context.MedicineBills.FindAsync(bill.Id);
                if (existingBill != null)
                {
                    existingBill.Status = 1;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<MedicineBillModels> FindMedBill(int id)
        {
            var entity = await _context.MedicineBills.FindAsync(id);
            var model = _mapper.Map<MedicineBillModels>(entity);
            var med = await _context.Medicines.SingleOrDefaultAsync(s => s.Id == entity.Medicineid);
            model.PriceMed = med.Price;
            model.MedicineName = med.Name;
            model.Count = med.Count;
            model.Img = med.Img;
            return model;
        }

        public async Task<MedicineBillModels> FindMedBillbyCODE(string billcode)
        {
            var entity = await _context.MedicineBills.FirstOrDefaultAsync(bill => bill.BillCode == billcode);

            if (entity != null)
            {
                var model = _mapper.Map<MedicineBillModels>(entity);

                var med = await _context.Medicines.SingleOrDefaultAsync(medicine => medicine.Id == entity.Medicineid);

                if (med != null)
                {
                    model.PriceMed = med.Price;
                    model.MedicineName = med.Name;
                    model.Count = med.Count;
                    model.Img = med.Img;
                    model.BillCode = entity.BillCode;
                }

                return model;
            }
            else{
                return null;
            }

        }

        public async Task AcceptBillBycode(List<MedicineBillModels> list)
        {
            foreach (var bill in list)
            {
                var existingBill = await _context.MedicineBills.FirstOrDefaultAsync(b => b.BillCode == bill.BillCode);
                if (existingBill != null)
                {
                    existingBill.Status = 2; //2 la trang thai da thanh toan
                }
            }

            await _context.SaveChangesAsync();
        }

    }
}
