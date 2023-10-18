using Hospital_Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Application.Dialogs
{
    public partial class ScheduleEmp : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string patid;

        public ScheduleEmp()
        {
            InitializeComponent();
            Menu_Load(this, EventArgs.Empty);
        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/Schedule/GetAllPatSchedule");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["patevent"].DataPropertyName = "Eventname";
                dataGridView1.Columns["patname"].DataPropertyName = "Name";
                dataGridView1.Columns["patphone"].DataPropertyName = "PhoneNumber"; // Assuming the property name is "ImageUrl"
                dataGridView1.Columns["patdes"].DataPropertyName = "Description";
                dataGridView1.Columns["patime"].DataPropertyName = "Starttime";
                dataGridView1.Columns["status"].DataPropertyName = "Status";
                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/Schedule/GetAllPatSchedule");
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

        private void empschedule_Click(object sender, EventArgs e)
        {
            ScheduleEmpPerson scheduleEmpPerson = new ScheduleEmpPerson();
            scheduleEmpPerson.Show();

        }
    }
}
