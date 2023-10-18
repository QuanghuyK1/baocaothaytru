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
    public partial class BlogDialog : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private string flag;
        private int flagbutton = 0;
        public BlogDialog()
        {
            InitializeComponent();
            ServiceDialog_Load(this, EventArgs.Empty);
        }

        private void nametext_TextChanged(object sender, EventArgs e)
        {

        }

        private void destext_Click(object sender, EventArgs e)
        {

        }

        private void ins_Click(object sender, EventArgs e)
        {
            cancel.Visible = true;
            accept.Visible = true;
            update.Visible = false;
            del.Visible = false;
            nametext.Text = "";
            blogdescription.Text = "";
            date.Value = DateTime.Now;
            nametext.ReadOnly = false;
            blogdescription.ReadOnly = false;
            flagbutton = 1;
        }
        private async void ServiceDialog_Load(object sender, EventArgs e)
        {
            accessToken = _cache["AccessToken"] as string;
            dataGridView1.CellClick += dataGridView1_CellClick;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7061/api/Blog/GetAllBlogByUsername");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns["ID"].DataPropertyName = "Id";
                dataGridView1.Columns["blogname"].DataPropertyName = "Name";
                dataGridView1.Columns["blogdes"].DataPropertyName = "Description";
                dataGridView1.Columns["blogdate"].DataPropertyName = "Date";

                try
                {
                    var response = await httpClient.GetAsync("https://localhost:7061/api/Blog/GetAllBlogByUsername");
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var certiList = JsonConvert.DeserializeObject<List<BlogModel>>(apiResponse);
                        BindingList<BlogModel> bindingCertiList = new BindingList<BlogModel>(certiList);
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
                        string url = $"https://localhost:7061/api/BLog/GetBlog/{flag}";
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                        try
                        {
                            var response = await httpClient.GetAsync(url);
                            if (response.IsSuccessStatusCode)
                            {
                                var apiResponse = await response.Content.ReadAsStringAsync();
                                var hhs = JsonConvert.DeserializeObject<BlogModel>(apiResponse);
                                blogdescription.Text = hhs.Description;
                                nametext.Text = hhs.Name;
                                date.Value = hhs.Date;
                                update.Visible = true;
                                del.Visible = true;

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

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            cancel.Visible = false;
            accept.Visible = false;
            nametext.Text = "";
            blogdescription.Text = "";
            date.Value = DateTime.Now;
            nametext.ReadOnly = true;
            blogdescription.ReadOnly = true;
            update.Visible = false;
            del.Visible = false;
        }

        private void update_Click(object sender, EventArgs e)
        {
            cancel.Visible = true;
            accept.Visible = true;
            nametext.ReadOnly = false;
            blogdescription.ReadOnly = false;
            flagbutton = 2;
        }

        private void del_Click(object sender, EventArgs e)
        {
            cancel.Visible = true;
            accept.Visible = true;
            flagbutton = 3;
        }
        private async Task DeleteBlogAsync(int id)
        {
            string baseUrl = "https://localhost:7061/api/Blog/DelBlog/" + id;
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
                        MessageBox.Show("Blog deleted successfully.");
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
        private async Task UpdateBlogAsync(int id, BlogModel input)
        {
            string baseUrl = "https://localhost:7061/api/Blog/UpBlog/" + id;
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Blog updated successfully.");
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
        private async Task InsertBlogAsync(BlogModel input)
        {
            string baseUrl = "https://localhost:7061/api/Blog/InsBlog";
            accessToken = _cache["AccessToken"] as string;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(baseUrl, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Blog inserted successfully.");
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

        private void accept_Click(object sender, EventArgs e)
        {
            var blog = new BlogModel
            {
                Name = nametext.Text,
                Description = blogdescription.Text,
                Date = DateTime.Now,
            };
            
            if (flagbutton == 1)
            {
                InsertBlogAsync(blog);
                flagbutton = 0;
                ServiceDialog_Load(this, EventArgs.Empty);
            }
            else if(flagbutton == 2)
            {
                int id = int.Parse(flag);
                UpdateBlogAsync(id, blog);
                flagbutton = 0;
                ServiceDialog_Load(this, EventArgs.Empty);
            }
            else
            {
                int id = int.Parse(flag);
                DeleteBlogAsync(id);
                flagbutton = 0;
                ServiceDialog_Load(this, EventArgs.Empty);
            }
            cancel.Visible = false;
            accept.Visible = false;
            nametext.Text = "";
            blogdescription.Text = "";
            date.Value = DateTime.Now;
            nametext.ReadOnly = true;
            blogdescription.ReadOnly = true;
            update.Visible = false;
            del.Visible = false;
            ServiceDialog_Load(this, EventArgs.Empty);
        }
    }
}
