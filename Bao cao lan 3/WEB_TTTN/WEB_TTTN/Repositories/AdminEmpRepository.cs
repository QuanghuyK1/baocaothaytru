using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Transactions;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class AdminEmpRepository : IAdminEmpRepository
    {
        private readonly HospitalDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly AutoIncre ae;

        public AdminEmpRepository(HospitalDatabaseContext dbContext, IMapper mapper, AutoIncre Ae)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            ae = Ae;
        }

        public async Task<List<EmpModels>> GetListEmp()
        {
            // Implement logic to retrieve list of employees
            // from the database and return it
            // For example:
            var empList = await _dbContext.Employees.Where(u=>u.Status == 1).ToListAsync();
            List<EmpModels> empModels = new List<EmpModels>();
            foreach (Employee emp in empList)
            {
                var model = _mapper.Map<EmpModels>(emp);
                var emprole = await _dbContext.EmployeeRoles.SingleOrDefaultAsync(u => u.Id == emp.EmployeeRoleId);
                var empclass = await _dbContext.Classes.SingleOrDefaultAsync(u => u.Id == emp.ClassId);
                if(empclass == null)
                {
                    model.Classname = "";
                }
                else
                {
                    model.Classname = empclass!.ClassName;
                }
                if (emprole == null)
                {
                    model.EmployeeRoleName = "";
                }
                else
                {
                    model.EmployeeRoleName = emprole!.RoleName;
                }
                empModels.Add(model);
            }
            return empModels;
        }

        public async Task UpdateEmp(InputEmp emp, string username)
        {
            // Implement logic to update employee information
            // based on the provided InputEmp object
            // For example:
            var existingEmp = await _dbContext.Employees.SingleOrDefaultAsync(u => u.Username == username);
            if (existingEmp != null)
            {
                 existingEmp.SalaryBasic = emp.SalaryBasic;
                 existingEmp.ClassId = emp.ClassId;
                 existingEmp.EmployeeRoleId = emp.EmployeeRoleId;
                 await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteEmp(string username)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var existingEmp = await _dbContext.Employees.SingleOrDefaultAsync(u => u.Username == username);
                    var acc = await _dbContext.Accounts.SingleOrDefaultAsync(u => u.Username == username);

                    if (existingEmp != null)
                    {
                        existingEmp.Status = 0;
                        acc.Status = 0;
                        await _dbContext.SaveChangesAsync();

                        // Hoàn thành giao dịch thành công
                        transactionScope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    // Giao dịch không thành công, xử lý lỗi hoặc rollback nếu cần
                    Console.WriteLine("Transaction failed: " + ex.Message);
                }
            }
        }


        public async Task InsertEmp(InsertEmpModel emp)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    
                    string us;
                    string ps;

                    if (emp.RoleId == 3)
                    {
                        us = await ae.GetNextIdEmpAsync();
                        ps = await ae.GetNextIdEmpAsync();
                    }
                    else
                    {
                        us = await ae.GetNextIdAdminAsync();
                        ps = await ae.GetNextIdAdminAsync();
                    }
                    Console.Write(us);
                    var newacc = new Account
                    {
                        Username = us,
                        Password = BCrypt.Net.BCrypt.HashPassword(ps),
                        RoleId = emp.RoleId,
                        CreateDate = DateTime.UtcNow,
                        Status = 1,
                    };
                    _dbContext.Accounts.Add(newacc);
                    var newEmp = new Employee
                    {
                        Name = emp.Name,
                        PhoneNumber = emp.PhoneNumber,
                        Email = emp.Email,
                        ClassId = emp.ClassId,
                        EmployeeRoleId = emp.EmployeeRoleId,
                        Username = us,
                        Status = 1,
                        SalaryBasic = emp.SalaryBasic
                    };
                    
                    _dbContext.Employees.Add(newEmp);
                    

                    await _dbContext.SaveChangesAsync();

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

    }
}
