using Hospital_Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Application.Dialogs
{
    public partial class AdminEmp : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private readonly HttpClient _httpClient;
        private string flag;
        private int flagbutton;
        public AdminEmp()
        {
            InitializeComponent();
            Menu_Load(this, EventArgs.Empty);
        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/AdminEmp/GetListEmp");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["username"].DataPropertyName = "Username";
                dataGridView1.Columns["empname"].DataPropertyName = "Name";
                dataGridView1.Columns["empemail"].DataPropertyName = "Email";
                dataGridView1.Columns["empphone"].DataPropertyName = "PhoneNumber"; // Assuming the property name is "ImageUrl"
                dataGridView1.Columns["salary"].DataPropertyName = "SalaryBasic";
                dataGridView1.Columns["role"].DataPropertyName = "EmployeeRoleName";
                dataGridView1.Columns["classname"].DataPropertyName = "Classname";
                dataGridView1.Columns["status"].DataPropertyName = "Status";
                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/AdminEmp/GetListEmp");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<EmpModel>>(apiResponse);

                        dataGridView1.DataSource = certiList;

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
        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                flag = selectedRow.Cells["username"].Value.ToString();

                if (!string.IsNullOrEmpty(flag))
                {
                    nametext.Text = selectedRow.Cells["empname"].Value.ToString();
                    emailtext.Text = selectedRow.Cells["empemail"].Value.ToString();
                    phonetext.Text = selectedRow.Cells["empphone"].Value.ToString();
                    if (selectedRow.Cells["salary"].Value == null)
                    {
                        salarytext.Text = "";
                    }
                    else salarytext.Text = selectedRow.Cells["salary"].Value.ToString();
                    emproletext.Text = selectedRow.Cells["role"].Value.ToString();
                    classtext.Text = selectedRow.Cells["classname"].Value.ToString();
                }
                update.Visible = true;
                del.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public async Task<List<EmpModel>> GetListEmpAsync()
        {
            string baseUrl = $"https://localhost:7061/api/AdminEmp/GetListEmp"; // Thay đổi URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var response = await _httpClient.GetAsync(baseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<EmpModel>>(apiResponse);
                    }
                    return null; // Handle error response
                }
                catch
                {
                    return null; // Handle exception
                }
            }

        }

        private async Task UpdateEmployeeAsync(InputEmp emp, string username)
        {
            string baseUrl = $"https://localhost:7061/api/AdminEmp/UpdateEmp/{username}";
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonEmp = JsonConvert.SerializeObject(emp);
                    var content = new StringContent(jsonEmp, Encoding.UTF8, "application/json");

                    var response = await httpClient.PutAsync(baseUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Employee information updated successfully.");
                        Menu_Load(this, EventArgs.Empty);
                        // Perform any necessary actions after successful update
                    }
                    else
                    {
                        MessageBox.Show("Failed to update employee information.");
                        // Handle error response
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    // Handle exception
                }
            }
        }


        public async Task DeleteEmpAsync(string username)
        {
            string baseUrl = $"https://localhost:7061/api/AdminEmp/DeleteEmp/{username}"; // Thay đổi URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var response = await httpClient.DeleteAsync(baseUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Employee deleted successfully.");
                        Menu_Load(this, EventArgs.Empty);
                    }
                    else { MessageBox.Show("Failed to delete employee."); }// Handle error response
                }
                catch
                {
                    MessageBox.Show("Failed to delete employee."); // Handle exception
                }
            }

        }

        public async Task InsertEmpAsync(InsertEmpModel emp)
        {
            string baseUrl = "https://localhost:7061/api/AdminEmp/InsertEmp"; // Thay đổi URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonEmp = JsonConvert.SerializeObject(emp);
                    var content = new StringContent(jsonEmp, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7061/api/AdminEmp/InsertEmp", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Employee inserted successfully.");
                        Menu_Load(this, EventArgs.Empty);
                    }
                    else {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to update employee information. Response status code: {response.StatusCode}, Response body: {responseBody}");
                    } // Handle error response
                }
                catch
                {
                    MessageBox.Show("Failed to insert employee."); // Handle exception
                }
            }

        }
        private async Task LoadClassListAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string url = "https://localhost:7061/api/Classes/GetAllClasses";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                try
                {
                    httpClient.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<ClassesModel>>(apiResponse);
                        classtext.DataSource = list;
                        classtext.DisplayMember = "ClassName";
                        classtext.ValueMember = "Id";
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
        private async Task LoadrolenameListAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string url = "https://localhost:7061/api/AdminEmp/GetRolename";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                try
                {
                    httpClient.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<EmpRole>>(apiResponse);
                        emproletext.DataSource = list;
                        emproletext.DisplayMember = "RoleName";
                        emproletext.ValueMember = "Id";
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
        private async Task LoadroleListAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string url = "https://localhost:7061/api/AdminEmp/GetRole";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                try
                {
                    httpClient.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<RoleModel>>(apiResponse);
                        roletext.DataSource = list;
                        roletext.DisplayMember = "RoleName";
                        roletext.ValueMember = "Id";
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
        private void cancel_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = true;
            emailtext.ReadOnly = true;
            phonetext.ReadOnly = true;
            salarytext.ReadOnly = true;
            accept.Visible = false;
            cancel.Visible = false;
            nametext.Text = "";
            emailtext.Text = "";
            phonetext.Text = "";
            salarytext.Text = "";
        }

        private void ins_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = false;
            emailtext.ReadOnly = false;
            phonetext.ReadOnly = false;
            salarytext.ReadOnly = false;
            accept.Visible = true;
            cancel.Visible = true;
            nametext.Text = "";
            emailtext.Text = "";
            phonetext.Text = "";
            salarytext.Text = "";
            flagbutton = 1;
            LoadClassListAsync();
            LoadroleListAsync();
            LoadrolenameListAsync();
        }

        private void del_Click(object sender, EventArgs e)
        {
            flagbutton = 3;
            accept.Visible = true;
            cancel.Visible = true;
        }

        private void update_Click(object sender, EventArgs e)
        {

            salarytext.ReadOnly = false;
            accept.Visible = true;
            cancel.Visible = true;
            flagbutton = 2;
            LoadClassListAsync();
            LoadrolenameListAsync();
        }

        private async Task accept_ClickAsync(object sender, EventArgs e)
        {
            var valid = 0;
            string email = emailtext.Text.Trim();

            // Biểu thức chính quy kiểm tra định dạng email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            if (Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Email is valid.", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Email is not valid.", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = 1;
            }
            string phoneNumber = phonetext.Text.Trim();

            // Biểu thức chính quy kiểm tra số điện thoại (chỉ chứa chữ số)
            string phonePattern = @"^\d+$";

            if (Regex.IsMatch(phoneNumber, phonePattern))
            {
                MessageBox.Show("Phone number is valid.", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phone number is not valid.", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(valid == 0) {
                var model = new InsertEmpModel
                {
                    Name = nametext.Text,
                    PhoneNumber = phonetext.Text,
                    Email = emailtext.Text,
                    ClassId = (int)classtext.SelectedValue,
                    EmployeeRoleId = (int)emproletext.SelectedValue,
                    Status = 1,
                    SalaryBasic = int.Parse(salarytext.Text),
                    RoleId = (int)roletext.SelectedValue,
                };
                var empmodel = new InputEmp
                {
                    ClassId = (int)classtext.SelectedValue,
                    EmployeeRoleId = (int)emproletext.SelectedValue,
                    SalaryBasic = int.Parse(salarytext.Text),

                };
                if (flagbutton == 1)
                {
                    InsertEmpAsync(model);
                }
                else if (flagbutton == 2)
                {
                    UpdateEmployeeAsync(empmodel, flag);
                }
                else
                {
                    DeleteEmpAsync(flag);
                }
            }  
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void accept_Click(object sender, EventArgs e)
        {
            
            if (flagbutton == 1)
            {
                var model = new InsertEmpModel
                {
                    Name = nametext.Text,
                    PhoneNumber = phonetext.Text,
                    Email = emailtext.Text,
                    ClassId = (int)classtext.SelectedValue,
                    EmployeeRoleId = (int)emproletext.SelectedValue,
                    Status = 1,
                    SalaryBasic = int.Parse(salarytext.Text),
                    RoleId = (int)roletext.SelectedValue,
                };
                InsertEmpAsync(model);
            }
            else if (flagbutton == 2)
            {
                var empmodel = new InputEmp
                {
                    ClassId = (int)classtext.SelectedValue,
                    EmployeeRoleId = (int)emproletext.SelectedValue,
                    SalaryBasic = int.Parse(salarytext.Text),

                };
                UpdateEmployeeAsync(empmodel, flag);
            }
            else
            {
                DeleteEmpAsync(flag);
            }
        }
    }
}
