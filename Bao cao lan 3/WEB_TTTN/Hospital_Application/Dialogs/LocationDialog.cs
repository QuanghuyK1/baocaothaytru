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

    public partial class LocationDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private int flagimg;
        private string flag;
        private string imgpath;
        public LocationDialog()
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
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/Location/GetAll");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["locationname"].DataPropertyName = "Name";
                dataGridView1.Columns["des"].DataPropertyName = "Description";
                dataGridView1.Columns["img"].DataPropertyName = "Img"; // Assuming the property name is "ImageUrl"
                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/Location/GetAll");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<LocationModel>>(apiResponse);

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
                flag = selectedRow.Cells["Id"].Value.ToString();
                imgpath = selectedRow.Cells["img"].Value.ToString();
                if (!string.IsNullOrEmpty(flag))
                {
                    nametext.Text = selectedRow.Cells["locationname"].Value.ToString();
                    destext.Text = selectedRow.Cells["des"].Value.ToString();
                    update.Visible = true;
                    string baseUrl = "https://localhost:7061";
                    string imageUrl = baseUrl + "/images/" + System.IO.Path.GetFileName(imgpath);

                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageData = webClient.DownloadData(imageUrl);
                        using (var ms = new System.IO.MemoryStream(imageData))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }
        private async Task<List<LocationModel>> GetAllLocationsAsync()
        {
            string baseUrl = "https://localhost:7061/api/Location/GetAll"; // Điều chỉnh URL API của bạn
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
                        List<LocationModel> locations = JsonConvert.DeserializeObject<List<LocationModel>>(jsonResponse);
                        return locations;
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

        private async Task InsertLocationAsync(LocationModel location)
        {
            string baseUrl = "https://localhost:7061/api/Location/InsLocation"; // Điều chỉnh URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = JsonConvert.SerializeObject(location);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Location inserted successfully.");
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

        private async Task UpdateLocationAsync(LocationModel location, int id)
        {
            string baseUrl = $"https://localhost:7061/api/Location/UpLocation/{id}"; // Điều chỉnh URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = JsonConvert.SerializeObject(location);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Location updated successfully.");
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

        private void image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.jpeg; *.gif)|*.jpg; *.png; *.jpeg; *.gif";
                openFileDialog.Title = "Chọn ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName; // Lưu đường dẫn ảnh đã chọn
                }
            }
        }

        private void ins_Click(object sender, EventArgs e)
        {
            nametext.Text = "";
            nametext.ReadOnly = false;
            destext.Text = "";
            destext.ReadOnly = false;
            flagimg = 1;
            accept.Visible = true;
            cancel.Visible = true;
        }

        private void update_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = false;
            destext.ReadOnly = false;
            flagimg = 2;
            accept.Visible = true;
            cancel.Visible = true;
        }

        private void accept_Click(object sender, EventArgs e)
        {

            var model = new LocationModel
            {
                Name = nametext.Text,
                Description = destext.Text,
                Img = selectedImagePath
            };
            if (flagimg == 1)
            {
                InsertLocationAsync(model);
            }
            else
            {
                int id = int.Parse(flag);
                UpdateLocationAsync(model, id);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = true;
            destext.ReadOnly = true;
            accept.Visible = false;
            cancel.Visible = false;
        }
    }
}
