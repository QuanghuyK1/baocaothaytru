using Hospital_Application.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Application.Dialogs
{
    public partial class PatientDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string flag;
        private int flagbutton = 0;
        public PatientDialog()
        {
            InitializeComponent();
            ServiceDialog_Load(this, EventArgs.Empty);
        }

        private async void ServiceDialog_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/Patient/All");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["ID"].DataPropertyName = "Id";
                dataGridView1.Columns["patname"].DataPropertyName = "Name";
                dataGridView1.Columns["patphone"].DataPropertyName = "PhoneNumber";
                dataGridView1.Columns["patemail"].DataPropertyName = "Email";
                dataGridView1.Columns["patinsurance"].DataPropertyName = "InsuranceId"; // Assuming the property name is "ImageUrl"
                dataGridView1.Columns["pataddress"].DataPropertyName = "Address";

                try
                {
                    var response = await httpClient.GetAsync("https://localhost:7061/api/Patient/All");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<PatientModel>>(apiResponse);
                        BindingList<PatientModel> bindingCertiList = new BindingList<PatientModel>(certiList);
                        dataGridView1.DataSource = bindingCertiList;
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
                flag = selectedRow.Cells["ID"].Value.ToString();
                if (!string.IsNullOrEmpty(flag))
                {
                    using (var httpClient = new HttpClient())
                    {
                        string url = $"https://localhost:7061/api/Patient/{flag}";
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                        try
                        {
                            var response = await httpClient.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var apiResponse = await response.Content.ReadAsStringAsync();
                                var hhs = JsonConvert.DeserializeObject<PatientModel>(apiResponse);


                                nametext.Text = hhs.Name;
                                phone.Text = hhs.PhoneNumber;
                                email.Text = hhs.Email;
                                address.Text = hhs.Address;
                                BHYT.Text = hhs.InsuranceId;
                                search.Visible = true;
                                service.Visible = true;
                                update.Visible = true;
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
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            accept.Visible = true;
            cancel.Visible = true;
            nametext.ReadOnly = false;
            phone.ReadOnly = false;
            nametext.Text = "";
            phone.Text = "";
            flagbutton = 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            accept.Visible = true;
            cancel.Visible = true;
            nametext.ReadOnly = false;
            phone.ReadOnly = false;
            email.ReadOnly = false;
            address.ReadOnly = false;
            BHYT.ReadOnly = false;
            flagbutton = 2;
        }

        private void accept_Click(object sender, EventArgs e)
        {
            var patient = new PatientModel
            {
                Name = nametext.Text,
                PhoneNumber = phone.Text,
                Email = email.Text,
                Address = address.Text,
                InsuranceId = BHYT.Text
            };
            if (flagbutton == 3)
            {
                InsertPatientAsync(patient);
                ServiceDialog_Load(this, EventArgs.Empty);
            }
            else if (flagbutton == 2)
            {
                int id = int.Parse(flag);
                UpdatePatientAsync(id, patient);
                ServiceDialog_Load(this, EventArgs.Empty);
            }
            else
            {
                SearchPatientsAsync(nametext.Text, phone.Text);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            accept.Visible = false;
            cancel.Visible = false;
            update.Visible = false;
            search.Visible = false;
            service.Visible = false;
            nametext.Text = "";
            phone.Text = "";
            email.Text = "";
            address.Text = "";
            BHYT.Text = "";
            nametext.ReadOnly = true;
            phone.ReadOnly = true;
            email.ReadOnly = true;
            address.ReadOnly = true;
            BHYT.ReadOnly = true;
        }

        private void ins_Click(object sender, EventArgs e)
        {
            accept.Visible = true;
            cancel.Visible = true;
            update.Visible = false;
            search.Visible = false;
            service.Visible = false;
            nametext.Text = "";
            phone.Text = "";
            email.Text = "";
            address.Text = "";
            BHYT.Text = "";
            nametext.ReadOnly = false;
            phone.ReadOnly = false;
            email.ReadOnly = true;
            address.ReadOnly = false;
            BHYT.ReadOnly = true;
            flagbutton = 3;
        }

        private void service_Click(object sender, EventArgs e)
        {
            ServicePatientDialog sp = new ServicePatientDialog(flag);
            sp.Show();
        }
        private async Task InsertPatientAsync(PatientModel input)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/Patient/Ins"); // Thay đổi URL API của bạn
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var jsonContent = JsonConvert.SerializeObject(input);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://localhost:7061/api/Patient/Ins", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("success"); // In ra dữ liệu trả về từ API sau khi thêm bệnh nhân
                }
                else
                {
                    MessageBox.Show("API call failed.");
                }
            }
        }
        private async Task UpdatePatientAsync(int id, PatientModel input)
        {
            string baseUrl = "https://localhost:7061/api/Patient/Update/" + id;
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = JsonConvert.SerializeObject(input);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Patient updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("API call failed. Status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private async Task SearchPatientsAsync(string name, string phonenumber)
        {
            string baseUrl = "https://localhost:7061/api/Patient/Search";
            accessToken = _cache["AccessToken"] as string;

            string fullUrl = baseUrl + "?name=" + Uri.EscapeDataString(name) + "&phonenumber=" + Uri.EscapeDataString(phonenumber);
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns["ID"].DataPropertyName = "Id";
            dataGridView1.Columns["patname"].DataPropertyName = "Name";
            dataGridView1.Columns["patphone"].DataPropertyName = "PhoneNumber";
            dataGridView1.Columns["patemail"].DataPropertyName = "Email";
            dataGridView1.Columns["patinsurance"].DataPropertyName = "InsuranceId"; // Assuming the property name is "ImageUrl"
            dataGridView1.Columns["pataddress"].DataPropertyName = "Address";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(fullUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<PatientModel> searchedPatients = JsonConvert.DeserializeObject<List<PatientModel>>(jsonResponse);
                        BindingList<PatientModel> bindingCertiList = new BindingList<PatientModel>(searchedPatients);
                        dataGridView1.DataSource = bindingCertiList;
                    }
                    else
                    {
                        MessageBox.Show("API call failed. Status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

    }
}
