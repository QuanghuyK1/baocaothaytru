using Hospital_Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Application.Dialogs
{
    public partial class TypeServiceDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private int flagimg;
        private string flag;
        private string imgpath;
        public TypeServiceDialog()
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
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/TypeService/ListTypeServices");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["sername"].DataPropertyName = "ServiceName";
                dataGridView1.Columns["serprice"].DataPropertyName = "Price";
                dataGridView1.Columns["status"].DataPropertyName = "Status"; // Assuming the property name is "ImageUrl"
                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/TypeService/ListTypeServices");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<TypeServiceModel>>(apiResponse);
                        BindingList<TypeServiceModel> bindingCertiList = new BindingList<TypeServiceModel>(certiList);
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
                if (!string.IsNullOrEmpty(flag))
                {
                    nametext.Text = selectedRow.Cells["sername"].Value.ToString();
                    pricetext.Text = selectedRow.Cells["serprice"].Value.ToString();
                    tt.Text = selectedRow.Cells["serprice"].Value.ToString();
                    update.Visible = true;

                }
            }
        }
        private void ins_Click(object sender, EventArgs e)
        {
            nametext.Text = "";
            nametext.ReadOnly = false;
            pricetext.Text = "";
            pricetext.ReadOnly = false;
            flagimg = 1;
            accept.Visible = true;
            cancel.Visible = true;
        }
        private async Task<List<TypeServiceModel>> GetAllTypeServicesAsync()
        {
            string baseUrl = "https://localhost:7061/api/TypeService/ListTypeServices"; // Điều chỉnh URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(baseUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<TypeServiceModel> typeServices = JsonConvert.DeserializeObject<List<TypeServiceModel>>(jsonResponse);
                        return typeServices;
                    }
                    else
                    {
                        MessageBox.Show("API call failed. Status code: " + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return null;
                }
            }
        }

        private async Task InsertTypeServiceAsync(TypeServiceModel model)
        {
            string baseUrl = "https://localhost:7061/api/TypeService/InsertTypeService"; // Điều chỉnh URL API của bạn
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
                        MessageBox.Show("TypeService inserted successfully.");
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

        private async Task UpdateTypeServiceAsync(TypeServiceModel model, int id)
        {
            string baseUrl = $"https://localhost:7061/api/TypeService/UpdateTypeService/{id}"; // Điều chỉnh URL API của bạn
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
                        MessageBox.Show("TypeService updated successfully.");
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

        private async Task DeleteTypeServiceAsync(int id)
        {
            string baseUrl = $"https://localhost:7061/api/TypeService/DelTypeService/{id}"; // Điều chỉnh URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, null);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("TypeService deleted successfully.");
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

        private void update_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = false;
            pricetext.ReadOnly = false;
            flagimg = 2;
            accept.Visible = true;
            cancel.Visible = true;
        }

        private void accept_Click(object sender, EventArgs e)
        {

            var model = new TypeServiceModel
            {
                ServiceName = nametext.Text,
                Price = int.Parse(pricetext.Text),
                Status = 1
            };
            if (flagimg == 1)
            {
                InsertTypeServiceAsync(model);
            }
            else if (flagimg == 2)
            {
                int id = int.Parse(flag);
                UpdateTypeServiceAsync(model, id);
            }
            else
            {
                int id = int.Parse(flag);
                DeleteTypeServiceAsync(id);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = true;
            pricetext.ReadOnly = true;
            accept.Visible = false;
            cancel.Visible = false;
        }

        private void del_Click(object sender, EventArgs e)
        {
            flagimg = 3;
            accept.Visible = true;
            cancel.Visible = false;
        }

        private void update_Click_1(object sender, EventArgs e)
        {
            accept.Visible = true;
            cancel.Visible = true;
            nametext.ReadOnly = false;
            pricetext.ReadOnly = false;
        }
    }
}
