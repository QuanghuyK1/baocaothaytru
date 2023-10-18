using Hospital_Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Application.Dialogs
{
    public partial class ChangePass : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        public ChangePass()
        {
            InitializeComponent();
        }

        private async void doipass_Click(object sender, EventArgs e)
        {

            var apiUrl = "https://localhost:7061/api/Profile/ChangePassword"; // Thay thế bằng URL thực tế của API
            var token = _cache["AccessToken"] as string; ; // Thay thế bằng access token của bạn

            // Tạo đối tượng ChangePasswordModels để gửi trong yêu cầu POST
            var changePasswordModel = new ChangePassModel
            {
                OldPass = oldpass.Text,
                NewPass = newpass.Text,
                ConfirmPassword = conpass.Text
            };

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiUrl);
                // Đặt thông tin Header của yêu cầu (Bearer token)
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Chuyển đối tượng ChangePasswordModels sang dạng chuỗi JSON
                var jsonContent = JsonConvert.SerializeObject(changePasswordModel);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                try
                {
                    // Thực hiện yêu cầu POST và lấy kết quả trả về
                    var response = await httpClient.PostAsync(apiUrl, content);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Password changed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to change password: " + responseContent);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("An error occurred while making the API request: " + ex.Message);
                }
            }
        }
    }
}
