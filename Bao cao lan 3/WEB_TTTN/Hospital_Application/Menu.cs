using Hospital_Application.Dialogs;
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

namespace Hospital_Application
{
    public partial class Menu : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string accessToken;
        private Form currentFormChild;
        public Menu()
        {
            InitializeComponent();
            Menu_Load(this, EventArgs.Empty);
        }

        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/Profile/GetProfileEmp");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var response = await httpClient.GetAsync("GetProfileEmp");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var emp = JsonConvert.DeserializeObject<EmpModels>(apiResponse);
                        manv.Text = _cache["Username"] as string;
                        NVName.Text = emp.Name;
                        _cache["NVName"] = emp.Name;
                        string baseUrl = "https://localhost:7061";
                        string imageUrl = baseUrl + "/images/" + System.IO.Path.GetFileName(emp.Img);

                        using (WebClient webClient = new WebClient())
                        {
                            byte[] imageData = webClient.DownloadData(imageUrl);
                            using (var ms = new System.IO.MemoryStream(imageData))
                            {
                                pictureBox2.Image = Image.FromStream(ms);
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

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new information());
            Menu_Load(this, EventArgs.Empty);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            _cache.Remove("AccessToken");
            _cache.Remove("Username");
            this.Close();

            // Display the LoginForm
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void manv_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CertificateDialog());
            Menu_Load(this, EventArgs.Empty);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InsuranceDialog());
            Menu_Load(this, EventArgs.Empty);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConfirmSchedule());
            Menu_Load(this, EventArgs.Empty);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChangePass());
            Menu_Load(this, EventArgs.Empty);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MedicineDialog());
            Menu_Load(this, EventArgs.Empty);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SearchSchedule());
            Menu_Load(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ScheduleEmp());
            Menu_Load(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PatientDialog());
            Menu_Load(this, EventArgs.Empty);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BlogDialog());
            Menu_Load(this, EventArgs.Empty);
        }
    }
}
