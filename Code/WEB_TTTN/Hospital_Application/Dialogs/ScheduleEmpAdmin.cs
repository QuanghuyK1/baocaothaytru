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

    public partial class ScheduleEmpAdmin : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        public ScheduleEmpAdmin()
        {
            InitializeComponent();
            Menu_Load(this, EventArgs.Empty);
        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/Schedule/GetAllEmpScheduleByAdmin");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                
                dataGridView1.Columns["empevent"].DataPropertyName = "Eventname";
                dataGridView1.Columns["locationname"].DataPropertyName = "LocationName";
                dataGridView1.Columns["empdes"].DataPropertyName = "Description";
                dataGridView1.Columns["username"].DataPropertyName = "Empname";
                dataGridView1.Columns["empname"].DataPropertyName = "Name";
                dataGridView1.Columns["emptime"].DataPropertyName = "Starttime";
                dataGridView1.Columns["status"].DataPropertyName = "Status";
                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/Schedule/GetAllEmpScheduleByAdmin");
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
    }
}
