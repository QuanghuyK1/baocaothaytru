using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;
using WEB_TTTN.Helpers;
using System.Transactions;
using System.Text.RegularExpressions;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly HospitalDatabaseContext _context;
    private readonly IConfiguration _configuration;
    private readonly EmailService _emailService;
    private readonly validate validate;
    public AuthController(HospitalDatabaseContext context, IConfiguration configuration, EmailService emailService)
    {
        _context = context;
        _configuration = configuration;
        _emailService = emailService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(SignInModels model)
    {
        // Kiểm tra xem người dùng có tồn tại trong cơ sở dữ liệu hay không
        var user = await _context.Accounts.SingleOrDefaultAsync(u => u.Username == model.Username);
        if (user == null || BCrypt.Net.BCrypt.Verify(model.Password, user.Password) == false)
        {
            return Unauthorized(validate.ProcessString("validate_login_err_2"));
        }
        if(user.Status == 0)
        {
            return Unauthorized("Please active your email");
        }
        if (model.Username == null)
        {
            return BadRequest(validate.ProcessString("validate_blank"));
        }
        if (model.Password == null)
        {
            return BadRequest(validate.ProcessString("validate_blank"));
        }
        // Tạo token và trả về cho người dùng
        var token = GenerateJwtToken(user);
        var role = await _context.Roles.SingleOrDefaultAsync(u => u.Id == user.RoleId);
        var response = new AuthResponse
        {
            Username = user.Username,
            Token = token,
            /*RoleName = user.Role.RoleName*/
            RoleName = role.RoleName

        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        // Lấy giá trị thời gian hết hạn từ token
        var exp = jwtToken.ValidTo;
        Console.WriteLine(exp);
        return Ok(response);
    }
    [HttpPost("EmpLogin")]
    public async Task<IActionResult> EmpLogin(SignInModels model)
    {
        // Kiểm tra xem người dùng có tồn tại trong cơ sở dữ liệu hay không
        var user = await _context.Accounts.SingleOrDefaultAsync(u => u.Username == model.Username && u.Status !=0);
        if (user == null || BCrypt.Net.BCrypt.Verify(model.Password, user.Password) == false)
        {
            return Unauthorized("Invalid username or password");
        }

        // Tạo token và trả về cho người dùng
        var token = GenerateJwtToken(user);
        var role = await _context.Roles.SingleOrDefaultAsync(u => u.Id == user.RoleId);
        if(role.RoleName == "User") {
            return BadRequest();
        }
        var response = new AuthResponse
        {
            Username = user.Username,
            Token = token,
            /*RoleName = user.Role.RoleName*/
            RoleName = role.RoleName

        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        // Lấy giá trị thời gian hết hạn từ token
        var exp = jwtToken.ValidTo;
        Console.WriteLine(exp);
        return Ok(response);
    }
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpModels model)
    {
        // Kiểm tra xem tên người dùng đã tồn tại trong cơ sở dữ liệu hay chưa
        var existingUser = await _context.Accounts.SingleOrDefaultAsync(u => u.Username == model.Username);
        if (existingUser != null)
        {
            return BadRequest(validate.ProcessString("validate_regis_err_1"));
        }
        
        // Mã hóa mật khẩu bằng BCrypt.Net
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
        string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
        if(Regex.IsMatch(model.Email, pattern))
        {
            return BadRequest(validate.ProcessString("validate_email_err"));
        }
        if(model.ConPassword == null) {
            return BadRequest(validate.ProcessString("validate_blank"));
        }
        if (model.Password == null)
        {
            return BadRequest(validate.ProcessString("validate_blank"));
        }
        if (model.Email == null)
        {
            return BadRequest(validate.ProcessString("validate_blank"));
        }
        if (model.Username == null)
        {
            return BadRequest(validate.ProcessString("validate_blank"));
        }
        if (model.ConPassword != model.Password)
        {
            return BadRequest(validate.ProcessString("validate_regis_err_2"));
        }
        using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                var newUser = new Account
                {
                    Username = model.Username,
                    Password = hashedPassword,
                    // Các thông tin người dùng khác nếu cần
                    CreateDate = DateTime.UtcNow,
                    RoleId = model.RoleId,
                    Status = 0
                };
                _context.Accounts.Add(newUser);

                // Tạo mới bản ghi 'Patient' và gán 'Username' từ model.Username
                if (model.RoleId == 2)
                {
                    var patient = new Patient
                    {
                        Username = model.Username,
                        Email = model.Email,
                        // Thêm các thông tin khác của bảng Patient nếu có
                    };
                    _context.Patients.Add(patient);
                }
                else
                {
                    var employee = new Employee
                    {
                        Username = model.Username,
                        Email = model.Email
                        // Thêm các thông tin khác của bảng Patient nếu có
                    };
                    _context.Employees.Add(employee);
                }

                await _context.SaveChangesAsync();
                var subject = "Password Reset";
                var user = await _context.Patients.SingleOrDefaultAsync(u => u.Username == newUser.Username);

                var link = $"http://localhost/TTTN/activeEmail.html?p={user.Id}";

                var message = $"Please active your email: Click this link to active <a href='{link}'>Link active your email</a>";
                await _emailService.SendEmailAsync(model.Email, subject, message);
                // Tạo token và trả về cho người dùng
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

        
       

        return Ok();
    }
    [HttpPost("/verify/{id}")]
    public async Task<IActionResult> Verify([FromRoute] int id)
    {

        var user = await _context.Patients.SingleOrDefaultAsync(u => u.Id == id);
        var acc = await _context.Accounts.SingleOrDefaultAsync(u => u.Username == user.Username);

        if (user == null)
        {
            // Return an error response or handle the case when the user is not found
            return NotFound("User not found");
        }

        acc.Status = 1;
        await _context.SaveChangesAsync();

        return Ok(new { message = "Email verified successfully" });
    }

    private string GenerateJwtToken(Account user)
    {
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.UtcNow.AddDays(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authenKey,
            SecurityAlgorithms.HmacSha512Signature)
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    [HttpPost("forgotpassword")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
    {
        // Kiểm tra xem email có tồn tại trong cơ sở dữ liệu hay không
        var patient = await _context.Patients.SingleOrDefaultAsync(u => u.Email == model.Email);
        var employee = await _context.Employees.SingleOrDefaultAsync(u => u.Email == model.Email);
        if (patient == null && employee == null)
        {
            return Ok();
        }

        // Tạo mã đặt lại mật khẩu
        string resetCode = Guid.NewGuid().ToString("N").Substring(0, 8);
        if(patient  != null)
        {
            var acc = await _context.Accounts.SingleOrDefaultAsync(u => u.Username == patient.Username);
            acc.Password = BCrypt.Net.BCrypt.HashPassword(resetCode);
            _context.Accounts!.Update(acc);
        }
        else if(employee != null)
        {
            var acc = await _context.Accounts.SingleOrDefaultAsync(u => u.Username == employee.Username);
            acc.Password = BCrypt.Net.BCrypt.HashPassword(resetCode);
            _context.Accounts!.Update(acc);
        }
       
        await _context.SaveChangesAsync();

        // Gửi email chứa liên kết đến trang đặt lại mật khẩu kèm theo mã resetCode
        var subject = "Password Reset";
        var message = $"News password:{resetCode}";
        await _emailService.SendEmailAsync(model.Email, subject, message);

        // Trả về kết quả thành công cho người dùng
        return Ok();
    }

    
}

