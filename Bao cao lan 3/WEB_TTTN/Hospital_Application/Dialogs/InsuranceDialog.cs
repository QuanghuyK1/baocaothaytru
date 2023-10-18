using Hospital_Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Hospital_Application.Dialogs
{
    public partial class InsuranceDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string flag;
        private int temp = 0;
        private string imgpath;
        public InsuranceDialog()
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
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/"); // Notice the change here
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["InsuranceId"].DataPropertyName = "InsuranceId";
                dataGridView1.Columns["HospitalName"].DataPropertyName = "HospitalName";
                dataGridView1.Columns["FirstName"].DataPropertyName = "FirstName";
                dataGridView1.Columns["LastName"].DataPropertyName = "LastName";
                dataGridView1.Columns["Usedate"].DataPropertyName = "Usedate"; // Assuming the property name is "Usedate"
                dataGridView1.Columns["Birthday"].DataPropertyName = "Birthday";
                dataGridView1.Columns["Status"].DataPropertyName = "Startus"; // If Status is nullable

                dataGridView1.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == dataGridView1.Columns["Status"].Index && e.Value != null)
                    {
                        string statusValue = e.Value.ToString();

                        // Create a custom font with larger size
                        Font customFont = new Font("Arial", 14, FontStyle.Bold);

                        // Set the dot character and font based on status value
                        if (statusValue == "1")
                        {
                            e.Value = "●"; // Larger dot character (Unicode black circle)
                            e.CellStyle.ForeColor = Color.Green;
                        }
                        else
                        {
                            e.Value = "●"; // Larger dot character (Unicode black circle)
                            e.CellStyle.ForeColor = Color.Red;
                        }

                        // Apply the custom font
                        e.CellStyle.Font = customFont;

                        // Center-align the dot character within the cell
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        // Add padding to the cell to visually center the character
                        e.CellStyle.Padding = new Padding(0, 0, 50, 0); // Adjust the padding as needed

                        e.FormattingApplied = true;
                    }
                };



                try
                {
                    var response = await httpClient.GetAsync("HHS/GetAllHHS"); // Adjust the URL here
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<HHSModel>>(apiResponse);
                        BindingList<HHSModel> bindingCertiList = new BindingList<HHSModel>(list);
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
                flag = selectedRow.Cells["InsuranceId"].Value.ToString();
                if (!string.IsNullOrEmpty(flag))
                {
                    using (var httpClient = new HttpClient())
                    {
                        string url = $"https://localhost:7061/api/HHS/GetHHS/{flag}";
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                        try
                        {
                            var response = await httpClient.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var apiResponse = await response.Content.ReadAsStringAsync();
                                var hhs = JsonConvert.DeserializeObject<HHSModel>(apiResponse);

                                id.Text = hhs.InsuranceId;
                                hosname.Text = hhs.HospitalName;
                                hansd.Text = hhs.Usedate.ToString();
                                nametext1.Text = hhs.FirstName;
                                nametext2.Text = hhs.LastName;
                                ngaysinh.Text = hhs.Birthday.ToString();
                                if (hhs.Startus == 1)
                                {
                                    trangthai.Text = "Đã kích hoạt";
                                }
                                else
                                {
                                    trangthai.Text = "Chưa kích hoạt";
                                }
                                ngaytao.Text = hhs.Createday.ToString();
                                btnActive.Visible = true;
                                btnshow.Visible = true;

                                imgpath = hhs.Img;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void InsuranceDialog_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private async void btnActive_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(flag))
            {
                using (var httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7061/api/HHS/Active/{flag}";
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    try
                    {
                        var response = await httpClient.PostAsync(url, null);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Health insurance activated successfully.");
                            Menu_Load(this, EventArgs.Empty);
                        }
                        else if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            MessageBox.Show("Health insurance not found.");
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
                MessageBox.Show("Please select a health insurance first.");
            }
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            string imageUrl = imgpath;
            string baseUrl = "https://localhost:7061";
            string fullImageUrl = baseUrl + "/images/" + System.IO.Path.GetFileName(imageUrl);

            using (Form imageForm = new Form())
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Load(fullImageUrl);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                // Calculate the new form size
                int formWidth = Math.Min(pictureBox.Image.Width + 20, Screen.PrimaryScreen.WorkingArea.Width - 40);
                int formHeight = Math.Min(pictureBox.Image.Height + 60, Screen.PrimaryScreen.WorkingArea.Height - 80);

                imageForm.Text = "Health Insurance Image";
                imageForm.Size = new Size(formWidth, formHeight);

                pictureBox.Location = new Point((formWidth - pictureBox.Image.Width) / 2, (formHeight - pictureBox.Image.Height) / 2);
                pictureBox.Size = new Size(pictureBox.Image.Width, pictureBox.Image.Height);

                imageForm.Controls.Add(pictureBox);
                imageForm.StartPosition = FormStartPosition.CenterScreen;

                imageForm.ShowDialog();
            }

        }
        private DateTime ParseDateString(string dateString)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }
            else
            {
                // Handle parsing error, such as returning a default date
                return DateTime.MinValue;
            }
        }
        private async void btnIns_Click(object sender, EventArgs e)
        {

            if (temp == 1)
            {
                InputHHS input = new InputHHS
                {
                    FirstName = nametext1.Text,
                    LastName = nametext2.Text,
                    Birthday = ParseDateString(ngaysinh.Text)
                };

                using (var httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7061/api/HHS/PatientAskHHS";
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var jsonContent = JsonConvert.SerializeObject(input);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    try
                    {
                        var response = await httpClient.PostAsync(url, content);
                        if (response.IsSuccessStatusCode)
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            if (apiResponse == "success")
                            {
                                MessageBox.Show("Health insurance requested successfully.");
                                temp = 0;
                                Menu_Load(this, EventArgs.Empty);
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
            else
            {
                id.Visible = false;
                hosname.Visible = false;
                hansd.Visible = false;
                trangthai.Visible = false;
                nametext1.ReadOnly = false;
                nametext2.ReadOnly = false;
                ngaytao.Visible = false;
                Cancel.Visible = true;
                nametext1.Text = "";
                nametext2.Text = "";

                temp = 1;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            id.Visible = true;
            hosname.Visible = true;
            hansd.Visible = true;
            trangthai.Visible = true;
            nametext1.ReadOnly = true;
            nametext2.ReadOnly = true;
            ngaytao.Visible = true;
            Cancel.Visible = false;
        }
    }
}
