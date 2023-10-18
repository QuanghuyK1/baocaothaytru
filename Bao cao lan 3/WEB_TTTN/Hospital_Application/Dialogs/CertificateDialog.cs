using Hospital_Application.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hospital_Application.Dialogs
{

    public partial class CertificateDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private int flag = 0;
        private int temp = 0;
        public CertificateDialog()
        {
            InitializeComponent();
            datetext.MinDate = DateTime.Today;
            Menu_Load(this, EventArgs.Empty);
        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/Certificate/GetAllCertiByUsername");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["ID"].DataPropertyName = "Id";
                dataGridView1.Columns["CertificateName"].DataPropertyName = "CertificateName";
                dataGridView1.Columns["Description"].DataPropertyName = "Description";
                dataGridView1.Columns["Usedate"].DataPropertyName = "Usedate";
                dataGridView1.Columns["Image"].DataPropertyName = "Img"; // Assuming the property name is "ImageUrl"

                try
                {
                    var response = await httpClient.GetAsync("GetAllCertiByUsername");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<CertiModel>>(apiResponse);
                        BindingList<CertiModel> bindingCertiList = new BindingList<CertiModel>(certiList);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if any row is selected
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                flag = int.Parse(selectedRow.Cells["ID"].Value.ToString());
                nametext.Text = selectedRow.Cells["CertificateName"].Value.ToString();
                destext.Text = selectedRow.Cells["Description"].Value.ToString();
                string dateString = selectedRow.Cells["Usedate"].Value.ToString();
                datetext.Value = DateTime.Parse(dateString);
                upimg.Visible = true;
                btnUps.Visible = true;
                btnDel.Visible = true;
                if (selectedRow.Cells["Image"].Value != null)
                {
                    string imageUrl = selectedRow.Cells["Image"].Value.ToString();
                    string baseUrl = "https://localhost:7061";
                    string fullImageUrl = baseUrl + "/images/" + System.IO.Path.GetFileName(imageUrl);
                    pictureBox1.Load(fullImageUrl);
                }
                else
                {
                    // Handle the case where Image cell value is null (e.g., no image available)
                    pictureBox1.Image = null;
                }
            }
        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = false;
            destext.ReadOnly = false;
            accept.Visible = true;
            cancel.Visible = true;
            nametext.Text = "";
            destext.Text = "";
            btnUps.Visible = false;
            btnDel.Visible = false;
            upimg.Visible = true;
            temp = 1;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = true;
            destext.ReadOnly = true;
            accept.Visible = false;
            cancel.Visible = false;
            Menu_Load(this, EventArgs.Empty);
        }

        private void btnUps_Click(object sender, EventArgs e)
        {
            nametext.ReadOnly = false;
            destext.ReadOnly = false;
            accept.Visible = true;
            cancel.Visible = true;
            temp = 2;
        }

        private async void accept_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = datetext.Value; // Get the selected date from the DateTimePicker
            string serializedDate = selectedDate.ToString("yyyy-MM-dd");
            var name = nametext.Text;
            var des = destext.Text;
            var usedate = serializedDate;
            var data = new
            {
                certificateName = name,
                usedate = serializedDate,
                description = des,
                img = selectedImagePath
            };
            if (temp == 1)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:7061/api/Certificate/InsCerti");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var formData = new MultipartFormDataContent();

                    // Thêm dữ liệu vào formData
                    formData.Add(new StringContent(name), "name");
                    formData.Add(new StringContent(des), "des");
                    formData.Add(new StringContent(usedate.ToString()), "usedate");

                    // Thêm ảnh vào formData
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        byte[] imageData = File.ReadAllBytes(selectedImagePath);
                        var imageContent = new ByteArrayContent(imageData);
                        imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); // Thay đổi loại ảnh tùy theo yêu cầu
                        formData.Add(imageContent, "image", Path.GetFileName(selectedImagePath));
                    }

                    try
                    {
                        var response = await httpClient.PostAsync("InsCerti", formData);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Thành công!");
                            Menu_Load(this, EventArgs.Empty);
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
            else
            {
                using (var httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7061/api/Certificate/UpCerti/{flag}";
                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var formData = new MultipartFormDataContent();

                    // Add data to formData
                    formData.Add(new StringContent(name), "name");
                    formData.Add(new StringContent(des), "des");
                    formData.Add(new StringContent(usedate.ToString()), "usedate");

                    // Add image to formData
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        byte[] imageData = File.ReadAllBytes(selectedImagePath);
                        var imageContent = new ByteArrayContent(imageData);
                        imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                        formData.Add(imageContent, "image", Path.GetFileName(selectedImagePath));
                    }

                    try
                    {
                        var response = await httpClient.PostAsync(url, formData);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Thành công!");
                            Menu_Load(this, EventArgs.Empty);
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
        private void up_Click(object sender, EventArgs e)
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

        private void birthday_Click(object sender, EventArgs e)
        {

        }

        private void Email_Click(object sender, EventArgs e)
        {

        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"https://localhost:7061/api/Certificate/DelCerti/{flag}";
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var response = await httpClient.PostAsync(url, null);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Thành công!");
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
