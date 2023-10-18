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
    public partial class ClassesDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string serid;
        private string flag;
        private string imgpath;
        private int flagbutton;
        public ClassesDialog()
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
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/Classes/GetAllClasses");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["classname"].DataPropertyName = "ClassName";
                dataGridView1.Columns["img"].DataPropertyName = "Img";

                try
                {
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/Classes/GetAllClassess");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<ClassesModel>>(apiResponse);
                        BindingList<ClassesModel> bindingCertiList = new BindingList<ClassesModel>(certiList);
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
                imgpath = selectedRow.Cells["Img"].Value.ToString();
                if (!string.IsNullOrEmpty(flag))
                {
                    nametext.Text = selectedRow.Cells["classname"].Value.ToString();

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
        private async Task InsertClassAsync(ClassesModel model)
        {
            string baseUrl = "https://localhost:7061/api/Classes/InsertClasses"; // Thay đổi URL API của bạn
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
                        MessageBox.Show("Class inserted successfully.");
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

        private async Task UpdateClassAsync(ClassesModel model, int id)
        {
            string baseUrl = $"https://localhost:7061/api/Classes/UpdateClasses/{id}"; // Thay đổi URL API của bạn
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
                        MessageBox.Show("Class updated successfully.");
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

        private async Task LoadAllClassesAsync()
        {
            string baseUrl = "https://localhost:7061/api/Classes/GetAllClasses"; // Thay đổi URL API của bạn
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
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var classes = JsonConvert.DeserializeObject<List<ClassesModel>>(apiResponse);
                        // Sử dụng danh sách classes tại đây

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

        private void image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.jpeg; *.gif)|*.jpg; *.png; *.jpeg; *.gif";
                openFileDialog.Title = "Chọn ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imgpath = openFileDialog.FileName; // Lưu đường dẫn ảnh đã chọn
                }
            }
        }

        private void ins_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = false;
            nametext.Text = "";
            flagbutton = 1;
            image.Visible = true;
            cancel.Visible = true;
            accept.Visible = true;
        }

        private void update_Click(object sender, EventArgs e)
        {
            flagbutton = 2;
            image.Visible = true;
            cancel.Visible = true;
            accept.Visible = true;
            nametext.ReadOnly = false;
        }

        private void accept_Click(object sender, EventArgs e)
        {
            var model = new ClassesModel
            {
                ClassName = nametext.Text,
                Img = imgpath,
            };
            if (flagbutton == 1)
            {
                InsertClassAsync(model);
            }
            else
            {
                int id = int.Parse(flag);
                UpdateClassAsync(model, id);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            image.Visible = false;
            cancel.Visible = false;
            accept.Visible = false;
            nametext.ReadOnly = true;
            nametext.Text = "";
        }
    }
}
