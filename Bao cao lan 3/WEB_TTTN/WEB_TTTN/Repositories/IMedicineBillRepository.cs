using WEB_TTTN.Entities;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IMedicineBillRepository
    {
        public Task InsertBill(InputMedicineBill entity);
        public Task UpdateBill(InputMedicineBill entity,int id);
        public Task DeleteMedicineBill(int id);
        public Task<MedicineBillModels> FindMedBill(int id);

        public Task<List<MedicineBillModels>> GetAllByService(int id);
        public Task AcceptBill(List<MedicineBillModels> list);
        public Task<MedicineBillModels> FindMedBillbyCODE(String billcode);

        public Task AcceptBillBycode(List<MedicineBillModels> list);

    }
}
