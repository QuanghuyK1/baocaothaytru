using Hospital_Application.Models;
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
using System.Runtime.Caching;
using Microsoft.VisualBasic;
using System.Threading.Channels;

namespace Hospital_Application.Dialogs
{
    public partial class CTVForm : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string serid;
        private string flag;
        private int flagbutton;
        private string medid;
        private List<MedicineBillModel> billModels;
        public CTVForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //click search
        private async void del_Click(object sender, EventArgs e)
        {
            string s = billcode.Text;
            accessToken = _cache["AccessToken"] as string;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/MedicineBill/GetAllByService/{s}");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["medname"].DataPropertyName = "MedicineName";
                dataGridView1.Columns["medprice"].DataPropertyName = "PriceMed";
                dataGridView1.Columns["medcount"].DataPropertyName = "Count"; // Assuming the property name is "ImageUrl"
                dataGridView1.Columns["medtotalprice"].DataPropertyName = "TotalPrice";
                dataGridView1.Columns["status"].DataPropertyName = "Status";
                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/MedicineBill/GetAllByService/{s}");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<MedicineBillModel>>(apiResponse);
                        billModels = certiList.ToList();
                        BindingList<MedicineBillModel> bindingCertiList = new BindingList<MedicineBillModel>(certiList);
                        dataGridView1.DataSource = bindingCertiList;
                        if (billModels != null && billModels.Count > 0)
                        {
                            var lastBill = billModels[billModels.Count - 1];
                            if (lastBill.Status == 2)
                            {
                                accept.Visible = false;
                            }
                        }
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

        private void accept_Click(object sender, EventArgs e)
        {
            AcceptBillAsync(billModels);
        }
        private async Task AcceptBillAsync(List<MedicineBillModel> list)
        {
            string baseUrl = "https://localhost:7061/api/MedicineBill/AcceptBillByCode"; // Thay đổi URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = JsonConvert.SerializeObject(list);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("MedicineBills accepted successfully.");
                        accept.Visible = false;
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

        private void billcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            _cache.Remove("AccessToken");
            _cache.Remove("Username");
            this.Close();

            // Display the LoginForm
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
