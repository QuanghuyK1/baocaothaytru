using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using Hospital_Application.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Runtime.Caching;
using System.Runtime.Intrinsics.X86;
using Hospital_Application.Dialogs;

namespace Hospital_Application
{
    public partial class Login : Form
    {
        private readonly MemoryCache _cache = MemoryCache.Default;
        public Login()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các trường nhập liệu
            string username = UsernameInput.Text;
            string password = maskedTextBox1.Text;

            // Thực hiện cuộc gọi API
            using (var httpClient = new HttpClient())
            {
                // Đặt base address của API
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/Auth/EmpLogin"); // Thay đổi địa chỉ API tùy theo yêu cầu

                // Tạo nội dung JSON
                var data = new { username = username, password = password };
                var jsonContent = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    // Gửi yêu cầu POST đến API và lấy phản hồi
                    var response = await httpClient.PostAsync("EmpLogin", content);

                    // Kiểm tra phản hồi từ API
                    if (response.IsSuccessStatusCode)
                    {
                        // Phản hồi thành công, xử lý dữ liệu trả về nếu cần
                        var result = await response.Content.ReadAsStringAsync();
                        var tokenInfo = JsonConvert.DeserializeObject<TokenInfo>(result);
                        Console.WriteLine(tokenInfo.Username);
                        MessageBox.Show("Đăng nhập thành công" + tokenInfo.Username);
                        _cache["AccessToken"] = tokenInfo.Token;
                        _cache["Username"] = tokenInfo.Username;
                        if(tokenInfo.RoleName == "Admin")
                        {
                            this.Hide();
                            AdminMenu m2 = new AdminMenu();
                            m2.Show();
                            
                        }
                        else
                        {
                            this.Hide();
                            Menu m1 = new Menu();
                            m1.Show();
                        }
                        // Xử lý dữ liệu trả về ở đây (nếu có)
                    }
                    else
                    {
                        // Phản hồi không thành công, xử lý lỗi nếu cần
                        // Ví dụ: Hiển thị thông báo lỗi lên màn hình
                        var result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(result);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi kết nối hoặc lỗi từ phía API
                    MessageBox.Show("Đã xảy ra lỗi " + ex.Message);
                }
            }
        }
    }
}
