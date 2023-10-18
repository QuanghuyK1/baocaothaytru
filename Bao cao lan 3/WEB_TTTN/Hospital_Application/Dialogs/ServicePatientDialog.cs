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
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hospital_Application.Dialogs
{
    public partial class ServicePatientDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string patid;
        private string flag;
        private int flagbutton = 0;
        private int flagUps = 0;
        private string imgpath;
        public string serid;
        public ServicePatientDialog(string s)
        {
            InitializeComponent();
            patid = s;
            Menu_Load(this, EventArgs.Empty);
        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/Patient/{patid}/Services");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["servicename"].DataPropertyName = "TypeServiceName";
                dataGridView1.Columns["empname"].DataPropertyName = "EmployeeName";
                dataGridView1.Columns["getdate"].DataPropertyName = "GetDate"; // Assuming the property name is "ImageUrl"
                dataGridView1.Columns["empid"].DataPropertyName = "EmpUsername";
                dataGridView1.Columns["servicedes"].DataPropertyName = "Decription";
                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/Patient/{patid}/Services");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<ServiceModel>>(apiResponse);
                        BindingList<ServiceModel> bindingCertiList = new BindingList<ServiceModel>(certiList);
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
                flag = selectedRow.Cells["Id"].Value.ToString();
                serid = selectedRow.Cells["Id"].Value.ToString();
                if (!string.IsNullOrEmpty(flag))
                {
                    using (var httpClient = new HttpClient())
                    {
                        string url = $"https://localhost:7061/api/Service/Get/{flag}";
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                        try
                        {
                            var response = await httpClient.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var apiResponse = await response.Content.ReadAsStringAsync();
                                var hhs = JsonConvert.DeserializeObject<ServiceModel>(apiResponse);


                                credate.Value = hhs.GetDate;
                                des.Text = hhs.Decription;
                                manvtext.Text = hhs.EmpUsername;
                                nametext.Text = hhs.EmployeeName;
                                type.Text = hhs.TypeServiceName;
                                search.Visible = true;
                                bill.Visible = true;
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
        private async Task LoadTypeServiceAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string url = "https://localhost:7061/api/TypeService/ListTypeServices";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                try
                {
                    httpClient.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<TypeServiceModel>>(apiResponse);
                        type.DataSource = list;
                        type.DisplayMember = "ServiceName";
                        type.ValueMember = "Id";
                    }
                    else
                    {
                        MessageBox.Show("API call failed.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi có lỗi trong quá trình thực hiện
                }
            }
        }
        private void ins_Click(object sender, EventArgs e)
        {
            flagbutton = 1;
            manvtext.Text = _cache["Username"] as string;
            nametext.Text = _cache["NVName"] as string;
            des.ReadOnly = false;
            accept.Visible = true;
            cancel.Visible = true;
            LoadTypeServiceAsync();
        }

        private void search_Click(object sender, EventArgs e)
        {
            accept.Visible = true;
            cancel.Visible = true;
            LoadTypeServiceAsync();
            manvtext.Text = "";
            nametext.Text = "";
            des.Text = "";
            flagbutton = 2;
        }

        private void accept_Click(object sender, EventArgs e)
        {

            if (flagbutton == 2)
            {
                TypeServiceModel typeservice = (TypeServiceModel)type.SelectedItem;
                SearchServicesAsync(credate.Value, typeservice.Id);
            }
            else
            {
                TypeServiceModel typeservice = (TypeServiceModel)type.SelectedItem;
                int id = int.Parse(patid);
                var service = new ServiceModel
                {
                    PatientId = id,
                    EmployeeName = nametext.Text,
                    TypeServiceId = typeservice.Id,
                    TypeServiceName = typeservice.ServiceName,
                    EmpUsername = manvtext.Text,
                    Decription = des.Text,
                    GetDate = DateTime.Now
                };
                InsertServiceAsync(service);
                Menu_Load(this, EventArgs.Empty);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            des.Text = "";
            des.ReadOnly = true;
            accept.Visible = false;
            cancel.Visible = false;
        }
        private async Task InsertServiceAsync(ServiceModel model)
        {
            string baseUrl = "https://localhost:7061/api/Service/Ins"; // Thay đổi URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = JsonConvert.SerializeObject(model);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Service inserted successfully.");
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
        private async Task SearchServicesAsync(DateTime date, int typeId)
        {
            string baseUrl = "https://localhost:7061/api/Service/Search"; // Thay đổi URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["servicename"].DataPropertyName = "TypeServiceName";
                dataGridView1.Columns["empname"].DataPropertyName = "EmployeeName";
                dataGridView1.Columns["getdate"].DataPropertyName = "GetDate"; // Assuming the property name is "ImageUrl"
                dataGridView1.Columns["empid"].DataPropertyName = "EmpUsername";
                dataGridView1.Columns["servicedes"].DataPropertyName = "Decription";
                try
                {
                    var parameters = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("date", date.ToString("yyyy-MM-dd HH:mm:ss")),
                        new KeyValuePair<string, string>("typeid", typeId.ToString())
                    });

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, parameters);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<ServiceModel> searchResults = JsonConvert.DeserializeObject<List<ServiceModel>>(jsonResponse);
                        BindingList<ServiceModel> bindingCertiList = new BindingList<ServiceModel>(searchResults);
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

        private void bill_Click(object sender, EventArgs e)
        {     
            BillDialog bill = new BillDialog(serid);
            bill.ShowDialog();
        }
    }
}
