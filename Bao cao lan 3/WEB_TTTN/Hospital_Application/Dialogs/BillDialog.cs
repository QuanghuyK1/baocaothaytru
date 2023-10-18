using Hospital_Application.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Application.Dialogs
{
    public partial class BillDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string serid;
        private string flag;
        private int flagbutton;
        private string medid;
        private List<MedicineBillModel> billModels;
        public BillDialog(string s)
        {
            InitializeComponent();
            serid = s;
            Menu_Load(this, EventArgs.Empty);
        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://localhost:7061/api/MedicineBill/GetAllByService/{serid}");
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
                    var response = await httpClient.GetAsync($"https://localhost:7061/api/MedicineBill/GetAllByService/{serid}");
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
                            if (lastBill.Status == 1)
                            {
                                ins.Visible = false;
                                printbill.Visible = false;
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
        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                flag = selectedRow.Cells["Id"].Value.ToString();

                if (!string.IsNullOrEmpty(flag))
                {
                    using (var httpClient = new HttpClient())
                    {
                        string url = $"https://localhost:7061/api/MedicineBill/Get/{flag}";
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                        try
                        {
                            var response = await httpClient.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var apiResponse = await response.Content.ReadAsStringAsync();
                                var hhs = JsonConvert.DeserializeObject<MedicineBillModel>(apiResponse);


                                medicine.Text = hhs.MedicineName;
                                count.Text = selectedRow.Cells["medcount"].Value.ToString();
                                price.Text = hhs.PriceMed.ToString();
                                string baseUrl = "https://localhost:7061";
                                string imageUrl = baseUrl + "/images/" + System.IO.Path.GetFileName(hhs.Img);

                                using (WebClient webClient = new WebClient())
                                {
                                    byte[] imageData = webClient.DownloadData(imageUrl);
                                    using (var ms = new System.IO.MemoryStream(imageData))
                                    {
                                        pictureBox1.Image = Image.FromStream(ms);
                                    }
                                }
                                if (hhs.Status == 0)
                                {
                                    update.Visible = true;
                                    del.Visible = true;
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
            }
        }
        private async Task LoadMedicineListAsync()
        {
            medicine.SelectedIndexChanged += MedicineComboBox_SelectedIndexChanged;
            using (var httpClient = new HttpClient())
            {
                string url = "https://localhost:7061/api/Medicine/GetListStatus";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                try
                {
                    httpClient.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<MedicineModal>>(apiResponse);
                        medicine.DataSource = list;
                        medicine.DisplayMember = "Name";
                        medicine.ValueMember = "Id";
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

        private async void MedicineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (medicine.SelectedItem != null && medicine.SelectedItem is MedicineModal selectedMedicine)
            {

                using (var httpClient = new HttpClient())
                {
                    string url = $"https://localhost:7061/api/Medicine/Get/{selectedMedicine.Id}";
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    try
                    {
                        var response = await httpClient.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            var hhs = JsonConvert.DeserializeObject<MedicineModal>(apiResponse);

                            medicine.Text = hhs.Name;
                            price.Text = hhs.Price.ToString();
                            string baseUrl = "https://localhost:7061";
                            string imageUrl = baseUrl + "/images/" + System.IO.Path.GetFileName(hhs.Img);

                            using (WebClient webClient = new WebClient())
                            {
                                byte[] imageData = webClient.DownloadData(imageUrl);
                                using (var ms = new System.IO.MemoryStream(imageData))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
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
        }

        private void ins_Click(object sender, EventArgs e)
        {
            count.ReadOnly = false;
            count.Text = "";
            flagbutton = 1;
            accept.Visible = true;
            cancel.Visible = true;
            LoadMedicineListAsync();

        }

        private void accept_Click(object sender, EventArgs e)
        {
            var model = new InputMedicineBill
            {
                MedName = medicine.Text,
                ServiceId = int.Parse(serid),
                Price = int.Parse(price.Text),
                Count = int.Parse(count.Text),
                TotalPrice = int.Parse(count.Text) * int.Parse(price.Text),
                Status = 0
            };
            if (flagbutton == 1)
            {
                InsertBillAsync(model);
                
            }
            else if (flagbutton == 2)
            {
                UpdateBillAsync(int.Parse(flag), model);
                Menu_Load(this, EventArgs.Empty);
            }
            else
            {
                DeleteBillAsync(int.Parse(flag));
                Menu_Load(this, EventArgs.Empty);
            }
        }
        private async Task InsertBillAsync(InputMedicineBill input)
        {
            string baseUrl = "https://localhost:7061/api/MedicineBill/InsertBill"; // Thay đổi URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = JsonConvert.SerializeObject(input);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("MedicineBill inserted successfully.");
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

        private async Task UpdateBillAsync(int id, InputMedicineBill input)
        {
            string baseUrl = $"https://localhost:7061/api/MedicineBill/UpdateBill/{id}"; // Thay đổi URL API của bạn
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = JsonConvert.SerializeObject(input);
                    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, httpContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("MedicineBill updated successfully.");
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

        private async Task DeleteBillAsync(int id)
        {
            string baseUrl = $"https://localhost:7061/api/MedicineBill/DeleteBill/{id}"; // Thay đổi URL API của bạn
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
                        MessageBox.Show("MedicineBill deleted successfully.");
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

        private async Task<List<MedicineBillModel>> GetAllByServiceAsync(int id)
        {
            string baseUrl = $"https://localhost:7061/api/MedicineBill/GetAllByService/{id}"; // Thay đổi URL API của bạn
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
                        List<MedicineBillModel> medicineBills = JsonConvert.DeserializeObject<List<MedicineBillModel>>(jsonResponse);
                        return medicineBills;
                    }
                    else
                    {
                        MessageBox.Show("API call failed. Status code: " + response.StatusCode);
                        return new List<MedicineBillModel>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return new List<MedicineBillModel>();
                }
            }
        }

        private async Task AcceptBillAsync(List<MedicineBillModel> list)
        {
            string baseUrl = "https://localhost:7061/api/MedicineBill/AcceptBill"; // Thay đổi URL API của bạn
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
                        Menu_Load(this, EventArgs.Empty);
                        printbill.Visible = false;
                        update.Visible = false;
                        del.Visible = false;
                        cancel.Visible = false;
                        ins.Visible = false;
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

        private void update_Click(object sender, EventArgs e)
        {
            flagbutton = 2;
            count.ReadOnly = false;
            accept.Visible = true;
            cancel.Visible = true;
        }

        private void del_Click(object sender, EventArgs e)
        {
            flagbutton = 3;
            accept.Visible = true;
            cancel.Visible = true;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            accept.Visible = false;
            cancel.Visible = false;
            count.ReadOnly = true;
        }

        private void printbill_Click(object sender, EventArgs e)
        {
            AcceptBillAsync(billModels);
            Menu_Load(this, EventArgs.Empty);
        }
    }
}
