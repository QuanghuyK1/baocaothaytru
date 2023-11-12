using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using System.Linq;
using System.Threading.Tasks; // Add this namespace for asynchronous operations

namespace WEB_TTTN.Helpers
{
    public class AutoIncre
    {
        private readonly HospitalDatabaseContext _context;

        public AutoIncre(HospitalDatabaseContext context)
        {
            _context = context;
        }

        public async Task<string> GetNextIdAsync() // Mark it as async and return Task<string>
        {
            var matchingIds = await _context.HospitalHealthInsurances
                .Select(entity => entity.InsuranceId)
                .ToListAsync(); // Remove the extra dots here

            var highestId = matchingIds
                .Where(id => id.StartsWith("ABC-"))
                .DefaultIfEmpty("ABC-000000")
                .Max();

            var nextId = IncrementId(highestId);

            return nextId;
        }

        public string IncrementId(string id)
        {
            // Assuming the format is always "ABC-XXXXXX"
            int numericPart = int.Parse(id.Substring(4));
            int nextNumericPart = numericPart + 1;

            // Make sure the nextNumericPart stays within the range of 0 to 999999
            nextNumericPart %= 1000000;

            string nextId = $"ABC-{nextNumericPart:D6}";

            return nextId;
        }
        public async Task<string> GetNextIdEmpAsync() // Mark it as async and return Task<string>
        {
            var matchingIds = await _context.HospitalHealthInsurances
                .Select(entity => entity.InsuranceId)
                .ToListAsync(); // Remove the extra dots here

            var highestId = matchingIds
                .Where(id => id.StartsWith("Emp-"))
                .DefaultIfEmpty("Emp-000000")
                .Max();

            var nextId = IncrementIdEmp(highestId);

            return nextId;
        }

        public string IncrementIdEmp(string id)
        {
            // Assuming the format is always "ABC-XXXXXX"
            int numericPart = int.Parse(id.Substring(4));
            int nextNumericPart = numericPart + 1;

            // Make sure the nextNumericPart stays within the range of 0 to 999999
            nextNumericPart %= 1000000;

            string nextId = $"Emp-{nextNumericPart:D6}";

            return nextId;
        }
        public async Task<string> GetNextIdAdminAsync() // Mark it as async and return Task<string>
        {
            var matchingIds = await _context.HospitalHealthInsurances
                .Select(entity => entity.InsuranceId)
                .ToListAsync(); // Remove the extra dots here

            var highestId = matchingIds
                .Where(id => id.StartsWith("Admin-"))
                .DefaultIfEmpty("Admin-000000")
                .Max();

            var nextId = IncrementIdAdmin(highestId);

            return nextId;
        }

        public string IncrementIdAdmin(string id)
        {
            // Assuming the format is always "ABC-XXXXXX"
            int numericPart = int.Parse(id.Substring(5));
            int nextNumericPart = numericPart + 1;

            // Make sure the nextNumericPart stays within the range of 0 to 999999
            nextNumericPart %= 1000000;

            string nextId = $"Admin-{nextNumericPart:D6}";

            return nextId;
        }
        public async Task<string> GetNextIdCTVAsync() // Mark it as async and return Task<string>
        {
            var matchingIds = await _context.HospitalHealthInsurances
                .Select(entity => entity.InsuranceId)
                .ToListAsync(); // Remove the extra dots here

            var highestId = matchingIds
                .Where(id => id.StartsWith("CTV-"))
                .DefaultIfEmpty("CTV-000000")
                .Max();

            var nextId = IncrementIdCTV(highestId);

            return nextId;
        }

        public string IncrementIdCTV(string id)
        {
            // Assuming the format is always "ABC-XXXXXX"
            int numericPart = int.Parse(id.Substring(5));
            int nextNumericPart = numericPart + 1;

            // Make sure the nextNumericPart stays within the range of 0 to 999999
            nextNumericPart %= 1000000;

            string nextId = $"CTV-{nextNumericPart:D6}";

            return nextId;
        }
        public async Task<string> GetNextBillCode() // Mark it as async and return Task<string>
        {
            var matchingIds = await _context.HospitalHealthInsurances
                .Select(entity => entity.InsuranceId)
                .ToListAsync(); // Remove the extra dots here

            var highestId = matchingIds
                .Where(id => id.StartsWith("Bill-"))
                .DefaultIfEmpty("Bill-000000")
                .Max();

            var nextId = IncrementBillCode(highestId);

            return nextId;
        }

        public string IncrementBillCode(string id)
        {
            // Assuming the format is always "ABC-XXXXXX"
            int numericPart = int.Parse(id.Substring(5));
            int nextNumericPart = numericPart + 1;

            // Make sure the nextNumericPart stays within the range of 0 to 999999
            nextNumericPart %= 1000000;

            string nextId = $"Bill-{nextNumericPart:D6}";

            return nextId;
        }
    }
}
