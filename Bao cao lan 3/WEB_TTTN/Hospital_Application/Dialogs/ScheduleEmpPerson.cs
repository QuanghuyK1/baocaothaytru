using Hospital_Application.Models;
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

namespace Hospital_Application.Dialogs
{
    public partial class ScheduleEmpPerson : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string patid;
        public ScheduleEmpPerson()
        {
            InitializeComponent();
            Menu_Load(this, EventArgs.Empty);
        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/Schedule/GetAllEmpSchedule");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["empevent"].DataPropertyName = "Eventname";
                dataGridView1.Columns["locationname"].DataPropertyName = "LocationName";
                dataGridView1.Columns["empdes"].DataPropertyName = "Description";
                dataGridView1.Columns["emptime"].DataPropertyName = "Starttime";
                dataGridView1.Columns["status"].DataPropertyName = "Status";
                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/Schedule/GetAllEmpSchedule");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<ScheduleModels>>(apiResponse);
                        BindingList<ScheduleModels> bindingCertiList = new BindingList<ScheduleModels>(certiList);
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
        private async Task LoadLocation()
        {
            accessToken = _cache["AccessToken"] as string;
            using (var httpClient = new HttpClient())
            {
                string url = "https://localhost:7061/api/Location/GetAll";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                try
                {
                    httpClient.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<LocationModel>>(apiResponse);
                        diadiem.DataSource = list;
                        diadiem.DisplayMember = "Name";
                        diadiem.ValueMember = "Name";
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
        private async Task InsertScheduleEmpAsync(ScheduleModels model)
        {
            string baseUrl = "https://localhost:7061/api/Schedule/InsertScheduleEmp"; // Điều chỉnh URL API của bạn
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
                        MessageBox.Show("Employee schedule inserted successfully.");
                        Menu_Load(this, EventArgs.Empty);
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


        private void ins_Click(object sender, EventArgs e)
        {
            des.Text = "";
            des.ReadOnly = false;
            cancel.Visible = true;
            accept.Visible = true;
            LoadLocation();
        }

        private async void accept_Click(object sender, EventArgs e)
        {

            ScheduleModels schedule = new ScheduleModels
            {
                Eventname = eventname.Text,
                Starttime = starttime.Value, // Định dạng ngày giờ
                Description = des.Text,
                LocationName = diadiem.Text
            };
            InsertScheduleEmpAsync(schedule);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            des.Text = "";
            des.ReadOnly = true;
            cancel.Visible = false;
            accept.Visible = false;
        }
    }
}
