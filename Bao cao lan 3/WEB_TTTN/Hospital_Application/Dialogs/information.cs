using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.Caching;
using Hospital_Application.Models;
using System.Globalization;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Hospital_Application.Dialogs
{
    public partial class information : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private int flag = 0;
        public information()
        {
            InitializeComponent();
            Menu_Load(this, EventArgs.Empty);
        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/Profile/GetProfileEmp");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var response = await httpClient.GetAsync("GetProfileEmp");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var emp = JsonConvert.DeserializeObject<EmpModels>(apiResponse);
                        nametext.Text = emp.Name;
                        emailtext.Text = emp.Email;
                        phonetext.Text = emp.PhoneNumber;
                        if (emp.Birthday != null)
                        {
                            DateTime dateTime = (DateTime)emp.Birthday;
                            datetext.Value = dateTime;
                        }
                        
                        cccdtext.Text = emp.Identification;
                        roletext.Text = emp.EmployeeRoleName;
                        classtext.Text = emp.Classname;
                        destext.Text = emp.Description;
                        addresstext.Text = emp.Address;
                        salarytext.Text = emp.SalaryBasic.ToString();
                    }
                    else
                    {
                        MessageBox.Show("API call failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void classname_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = false;
            emailtext.ReadOnly = false;
            phonetext.ReadOnly = false;
            cccdtext.ReadOnly = false;
            destext.ReadOnly = false;
            addresstext.ReadOnly = false;
            accept.Visible = true;
            cancel.Visible = true;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Menu_Load(this, EventArgs.Empty);
            nametext.ReadOnly = true;
            emailtext.ReadOnly = true;
            phonetext.ReadOnly = true;
            cccdtext.ReadOnly = true;
            destext.ReadOnly = true;
            addresstext.ReadOnly = true;
            accept.Visible = false;
            cancel.Visible = false;
        }

        private async void accept_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                // Đặt base address của API
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/Profile/GetProfileEmp/Update"); // Thay đổi địa chỉ API tùy theo yêu cầu
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                // Tạo nội dung JSON
                DateTime selectedDate = datetext.Value; // Get the selected date from the DateTimePicker
                string serializedDate = selectedDate.ToString("yyyy-MM-dd");
                var name = nametext.Text;
                var phone = phonetext.Text;
                var email = emailtext.Text;
                var des = destext.Text;
                var cccd = cccdtext.Text;
                var add = addresstext.Text;
                var data = new
                {
                    name = name,
                    phoneNumber = phone,
                    email = email,
                    birthday = serializedDate,
                    description = des,
                    identification = cccd,
                    address = add
                };
                var jsonContent = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    // Gửi yêu cầu POST đến API và lấy phản hồi
                    var response = await httpClient.PostAsync("Update", content);

                    // Kiểm tra phản hồi từ API
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        // Phản hồi không thành công, xử lý lỗi nếu cần
                        // Ví dụ: Hiển thị thông báo lỗi lên màn hình
                        MessageBox.Show("Cập nhật không thành công. Vui lòng thử lại!");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi kết nối hoặc lỗi từ phía API
                    MessageBox.Show("Đã xảy ra lỗi " + ex.Message);
                }
            }
        }


        private async void UpImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.jpeg; *.gif)|*.jpg; *.png; *.jpeg; *.gif";
                openFileDialog.Title = "Chọn ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName; // Lưu đường dẫn ảnh đã chọn

                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri("https://localhost:7061/api/Profile/UploadImg"); // Đổi thành địa chỉ API thích hợp
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                        using (var content = new MultipartFormDataContent())
                        {
                            // Thêm dữ liệu vào content
                            content.Add(new StringContent("Employee"), "userType"); // Thay bằng "User" nếu bạn đang gửi cho Patient
                            using (var imageStream = File.OpenRead(selectedImagePath))
                            {
                                var imageContent = new StreamContent(imageStream);
                                imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); // Đổi thành loại ảnh thích hợp
                                content.Add(imageContent, "image", Path.GetFileName(selectedImagePath));

                                try
                                {
                                    var response = await httpClient.PostAsync("UploadImg", content);

                                    if (response.IsSuccessStatusCode)
                                    {
                                        var result = await response.Content.ReadAsStringAsync();
                                        var imageResponse = JsonConvert.DeserializeAnonymousType(result, new { imagePath = "" });
                                        Menu_Load(this, EventArgs.Empty);
                                        MessageBox.Show("Tải ảnh lên thành công. Đường dẫn ảnh: " + imageResponse.imagePath);

                                    }
                                    else
                                    {
                                        MessageBox.Show("Tải ảnh lên không thành công. Vui lòng thử lại!");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Đã xảy ra lỗi " + ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }


    }
}
