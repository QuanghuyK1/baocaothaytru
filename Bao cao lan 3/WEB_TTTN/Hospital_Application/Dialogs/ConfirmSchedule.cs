using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing.QrCode;
using Hospital_Application.Models;
using Newtonsoft.Json;
using Xceed.Wpf.Toolkit;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Runtime.Caching;

namespace Hospital_Application.Dialogs
{
    public partial class ConfirmSchedule : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        private string selectedImagePath;
        private string accessToken;
        private readonly object imageLock = new object();
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private bool isScanning = false;
        public ConfirmSchedule()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*string apiUrl = $"https://localhost:7061/api/Schedule/SearchSchedule";
            accessToken = _cache["AccessToken"] as string;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var formData = new List<KeyValuePair<string, string>>();
                    formData.Add(new KeyValuePair<string, string>("eventname", eventname.Text));
                    formData.Add(new KeyValuePair<string, string>("date", date.Value.ToString("yyyy-MM-dd HH:mm:ss")));
                    formData.Add(new KeyValuePair<string, string>("name", name.Text));
                    formData.Add(new KeyValuePair<string, string>("phone", phone.Text));

                    var content = new FormUrlEncodedContent(formData);
                    httpClient.BaseAddress = new Uri(apiUrl);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        ScheduleModels schedule = JsonConvert.DeserializeObject<ScheduleModels>(apiResponse);

                        ShowInforSchedule(schedule);
                    }
                    else
                    {
                        Console.WriteLine($"API call failed: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                }
            }*/

        }

        private void ShowInforSchedule(ScheduleModels? schedule)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
                pictureBox.Image = null;
                return;
            }

            // Mở webcam
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Không tìm thấy webcam.");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
            isScanning = true; // Bắt đầu quét khi mở webcam
            StartScanningThread();
        }

        private void StartScanningThread()
        {
            Thread scanningThread = new Thread(() =>
            {
                BarcodeReader barcodeReader = new BarcodeReader
                {
                    Options = new ZXing.Common.DecodingOptions
                    {
                        TryHarder = true
                    },
                    AutoRotate = true
                };

                while (isScanning)
                {
                    if (videoSource != null && videoSource.IsRunning)
                    {
                        try
                        {
                            Bitmap currentFrame = null;
                            lock (imageLock)
                            {
                                if (pictureBox.Image != null)
                                {
                                    currentFrame = new Bitmap(pictureBox.Image);
                                }
                            }

                            if (currentFrame != null)
                            {
                                Result result = barcodeReader.Decode(currentFrame);
                                if (result != null)
                                {
                                    UpdateUIWithQRResult(result.Text);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi khi quét mã QR: " + ex.Message);
                        }
                    }

                    Thread.Sleep(100); // Đợi một khoảng thời gian ngắn trước khi quét lại
                }
            });

            scanningThread.Start();
        }


        private void UpdateUIWithQRResult(string qrResult)
        {
            accessToken = _cache["AccessToken"] as string;
            // Sử dụng BeginInvoke thay vì Invoke để cập nhật giao diện người dùng từ luồng khác
            BeginInvoke(new Action(async () =>
            {
                string apiUrl = $"https://localhost:7061/api/Schedule/GetSchedule/{qrResult}";


                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            var schedule = JsonConvert.DeserializeObject<ScheduleModels>(apiResponse);

                            eventname.Text = schedule.Eventname;
                            name.Text = schedule.Name;
                            string formattedDateTime = schedule.Starttime.ToString("dd/MM/yyyy HH:mm");
                            date.Value = DateTime.ParseExact(formattedDateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                            phone.Text = schedule.PhoneNumber;
                            emailText.Text = schedule.Email;
                            textBox1.Text = schedule.Description;
                        }
                        else
                        {
                            Console.WriteLine($"API call failed: {response.StatusCode}");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
                    }
                }

            }));
        }


        private void ConfirmSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            isScanning = false;
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            lock (imageLock)
            {
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                }

                pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
            }
        }



        private string DecodeFrom6DigitNumber(string s)
        {
            int sum = int.Parse(s);
            byte[] bytes = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                bytes[5 - i] = (byte)(sum % 256);
                sum /= 256;
            }
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        private void ConfirmSchedule_Load(object sender, EventArgs e)
        {

        }
    }
}
