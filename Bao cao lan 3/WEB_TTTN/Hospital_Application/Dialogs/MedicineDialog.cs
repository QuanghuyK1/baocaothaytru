using Hospital_Application.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Application.Dialogs
{
    public partial class MedicineDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string flag;
        private int temp = 0;
        private int flagUps = 0;
        private string imgpath;
        public MedicineDialog()
        {
            InitializeComponent();
            Menu_Load(this, EventArgs.Empty);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private async void Menu_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["ID"].DataPropertyName = "Id";
                dataGridView1.Columns["MedName"].DataPropertyName = "Name";
                dataGridView1.Columns["Count"].DataPropertyName = "Count";
                dataGridView1.Columns["HSD"].DataPropertyName = "Usedate";
                dataGridView1.Columns["MedicinePrice"].DataPropertyName = "Price"; // Assuming the property name is "ImageUrl"
                dataGridView1.Columns["nationname"].DataPropertyName = "nationname";
                dataGridView1.Columns["TT"].DataPropertyName = "Startus"; // If Status is nullable


                dataGridView1.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == dataGridView1.Columns["TT"].Index && e.Value != null)
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
                        else if(statusValue == "0")
                        {
                            e.Value = "●"; // Larger dot character (Unicode black circle)
                            e.CellStyle.ForeColor = Color.Red;
                        }

                        // Apply the custom font
                        e.CellStyle.Font = customFont;

                        // Center-align the dot character within the cell
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        // Add padding to the cell to visually center the character
                        e.CellStyle.Padding = new Padding(0, 0, 20, 0); // Adjust the padding as needed

                        e.FormattingApplied = true;
                    }
                };
                try
                {
                    var response = await httpClient.GetAsync("Medicine/GetList");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<MedicineModal>>(apiResponse);
                        BindingList<MedicineModal> bindingCertiList = new BindingList<MedicineModal>(certiList);
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
                flag = selectedRow.Cells["ID"].Value.ToString();
                if (!string.IsNullOrEmpty(flag))
                {
                    using (var httpClient = new HttpClient())
                    {
                        string url = $"https://localhost:7061/api/Medicine/Get/{flag}";
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                        try
                        {
                            var response = await httpClient.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var apiResponse = await response.Content.ReadAsStringAsync();
                                var hhs = JsonConvert.DeserializeObject<MedicineModal>(apiResponse);


                                medicinename.Text = hhs.Name;
                                date.Value = hhs.Usedate;
                                sl.Text = hhs.Count.ToString();
                                price.Text = hhs.Price.ToString();
                                handleprice.Text = hhs.HandlePrice.ToString();
                                credate.Text = hhs.Getdate.ToString();
                                if (hhs.Startus == 1)
                                {
                                    status.Text = "Còn sử dụng";
                                    del.Visible = true;
                                    update.Visible = true;
                                    img.Visible = true;
                                }
                                else
                                {
                                    status.Text = "Hết sử dụng";
                                }
                                nation.Text = hhs.nationname;
                                des.Text = hhs.Description;
                                imgpath = hhs.Img;
                                selectedImagePath = hhs.Img;
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


        private void img_Click(object sender, EventArgs e)
        {
            if (flagUps == 0)
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

                    imageForm.Text = "Image Medicine";
                    imageForm.Size = new Size(formWidth, formHeight);

                    pictureBox.Location = new Point((formWidth - pictureBox.Image.Width) / 2, (formHeight - pictureBox.Image.Height) / 2);
                    pictureBox.Size = new Size(pictureBox.Image.Width, pictureBox.Image.Height);

                    imageForm.Controls.Add(pictureBox);
                    imageForm.StartPosition = FormStartPosition.CenterScreen;

                    imageForm.ShowDialog();
                }
            }
            else
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
        }
        private async Task LoadNationsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"https://localhost:7061/api/Nation/GetAll";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                try
                {
                    httpClient.BaseAddress = new Uri(url);
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<NationModel>>(apiResponse);
                        nation.DataSource = list;
                        nation.DisplayMember = "Name";
                        nation.ValueMember = "Name";
                    }
                    else
                    {
                        // Xử lý lỗi khi gọi API không thành công
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi có lỗi trong quá trình thực hiện
                }
            }
        }

        private async Task<bool> InsertMedicineAsync(MedicineModal input)
        {
            using (var httpClient = new HttpClient())
            {
                string url = "https://localhost:7061/api/Medicine/Ins"; // Thay đổi URL API của bạn
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        // Thêm các thông tin vào form data
                        formData.Add(new StringContent(input.Name), "MedName");
                        formData.Add(new StringContent(input.Usedate.ToString("yyyy-MM-dd")), "Usedate");
                        formData.Add(new StringContent(input.HandlePrice.ToString()), "HandlePrice");
                        formData.Add(new StringContent(input.Price.ToString()), "Price");
                        formData.Add(new StringContent(input.Description), "Description");
                        formData.Add(new StringContent(input.Count.ToString()), "Count");
                        formData.Add(new StringContent(input.Startus.ToString()), "Startus");
                        formData.Add(new StringContent(input.Getdate.ToString("yyyy-MM-dd")), "Getdate");
                        formData.Add(new StringContent(input.nationname), "nationname");

                        // Thêm file ảnh vào form data
                        if (!string.IsNullOrEmpty(selectedImagePath))
                        {
                            byte[] imageData = File.ReadAllBytes(selectedImagePath);
                            var imageContent = new ByteArrayContent(imageData);
                            imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); // Thay đổi loại ảnh tùy theo yêu cầu
                            formData.Add(imageContent, "image", Path.GetFileName(selectedImagePath));
                        }

                        // Gửi POST request
                        var response = await httpClient.PostAsync(url, formData);

                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        private async void ins_Click(object sender, EventArgs e)
        {
            if (temp == 0)
            {
                medicinename.ReadOnly = false;
                status.Text = "Còn sử dụng";
                sl.ReadOnly = false;
                price.ReadOnly = false;
                handleprice.ReadOnly = false;
                des.ReadOnly = false;
                des.Text = "";
                sl.Text = "";
                price.Text = "";
                medicinename.Text = "";
                handleprice.Text = "";
                credate.Value = DateTime.Today;
                LoadNationsAsync();
                flagUps = 1;
                img.Visible = true;
                temp = 1;
                cancel.Visible = true;

            }
            else
            {
                NationModel selectedNation = (NationModel)nation.SelectedItem;
                MedicineModal input = new MedicineModal
                {
                    Name = medicinename.Text,
                    Usedate = date.Value,
                    HandlePrice = (int)decimal.Parse(handleprice.Text),
                    Price = (int)decimal.Parse(price.Text),
                    Description = des.Text,
                    Count = int.Parse(sl.Text),
                    Startus = 1,
                    Getdate = credate.Value,
                    nationname = selectedNation.Name

                };

                bool insertResult = await InsertMedicineAsync(input);
                if (insertResult)
                {
                    MessageBox.Show("Thêm dữ liệu thành công.");

                    Menu_Load(this, EventArgs.Empty);

                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại.");
                }
                temp = 0;
                flagUps = 0;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            del.Visible = false;
            update.Visible = false;
            img.Visible = false;
            medicinename.ReadOnly = true;
            status.Text = "Còn sử dụng";
            sl.ReadOnly = true;
            price.ReadOnly = true;
            handleprice.ReadOnly = true;
            des.ReadOnly = true;
            des.Text = "";
            sl.Text = "";
            price.Text = "";
            handleprice.Text = "";

        }

        private async void update_Click(object sender, EventArgs e)
        {
            if (flagUps == 0)
            {
                medicinename.ReadOnly = false;
                sl.ReadOnly = false;
                price.ReadOnly = false;
                handleprice.ReadOnly = false;
                des.ReadOnly = false;
                flagUps = 1;
                LoadNationsAsync();
                img.Visible = true;
            }
            else
            {
                NationModel selectedNation = (NationModel)nation.SelectedItem;
                MedicineModal input = new MedicineModal
                {
                    Name = medicinename.Text,
                    Usedate = date.Value,
                    HandlePrice = (int)decimal.Parse(handleprice.Text),
                    Price = (int)decimal.Parse(price.Text),
                    Description = des.Text,
                    Count = int.Parse(sl.Text),
                    Startus = 1,
                    Getdate = credate.Value,
                    nationname = selectedNation.Name

                };
                int id = int.Parse(flag);
                bool insertResult = await UpdateMedicineAsync(id, input);
                if (insertResult)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công.");
                    flagUps = 0;
                    Menu_Load(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại.");
                }
                flagUps = 0;
                medicinename.ReadOnly = true;
                sl.ReadOnly = true;
                price.ReadOnly = true;
                handleprice.ReadOnly = true;
                des.ReadOnly = true;
            }
        }
        private async Task<bool> UpdateMedicineAsync(int id, MedicineModal input)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"https://localhost:7061/api/Medicine/Up/{id}"; // Thay đổi URL API của bạn
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        // Thêm các thông tin vào form data
                        formData.Add(new StringContent(input.Name), "MedName");
                        formData.Add(new StringContent(input.Usedate.ToString("yyyy-MM-dd")), "Usedate");
                        formData.Add(new StringContent(input.HandlePrice.ToString()), "HandlePrice");
                        formData.Add(new StringContent(input.Price.ToString()), "Price");
                        formData.Add(new StringContent(input.Description), "Description");
                        formData.Add(new StringContent(input.Count.ToString()), "Count");
                        formData.Add(new StringContent(input.Getdate.ToString("yyyy-MM-dd")), "Getdate");
                        formData.Add(new StringContent(input.nationname), "nationname");

                        // Thêm file ảnh vào form data
                        // Thêm file ảnh vào form data
                        if (!string.IsNullOrEmpty(selectedImagePath))
                        {
                            byte[] imageData = File.ReadAllBytes(selectedImagePath);
                            var imageContent = new ByteArrayContent(imageData);
                            imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); // Thay đổi loại ảnh tùy theo yêu cầu
                            formData.Add(imageContent, "image", Path.GetFileName(selectedImagePath));
                        }

                        // Gửi POST request
                        var response = await httpClient.PostAsync(url, formData);

                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            Console.Write(response.Content.ToString());
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return false;
                }
            }
        }

        private async void del_Click(object sender, EventArgs e)
        {
            int id = int.Parse(flag);
            bool deleteResult = await DeleteMedicineAsync(id); // Thay đổi id của medicine cần xóa
            if (deleteResult)
            {
                MessageBox.Show("Xóa dữ liệu thành công.");
            }
            else
            {
                MessageBox.Show("Xóa dữ liệu không thành công. Vui lòng kiểm tra lại.");
            }
            Menu_Load(this, EventArgs.Empty);
        }
        private async Task<bool> DeleteMedicineAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                string url = $"https://localhost:7061/api/Medicine/Del/{id}"; // Thay đổi URL API của bạn
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var response = await httpClient.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        Console.Write(response.Content.ToString());
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return false;
                }
            }
        }

    }
}
