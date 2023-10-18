using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IMedicineRepository
    {
        public Task<List<MedicineModels>> ListMedicine();
        public Task<List<MedicineModels>> ListMedicineStartus();
        public Task<MedicineModels> GetMedicineById(int id);
        public Task InsertMedicine(MedicineModels model);
        public Task UpdateMedicine(MedicineModels model, int id);
        public Task DeleteMedicine(int id);
    }
}
