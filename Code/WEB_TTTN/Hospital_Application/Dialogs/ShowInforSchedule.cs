using Hospital_Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Application.Dialogs
{
    public partial class ShowInforSchedule : Form
    {
        private ScheduleModels _schedule;

        public ShowInforSchedule(ScheduleModels schedule)
        {
            InitializeComponent();
            _schedule = schedule;
            ShowScheduleInfoForm_Load(this, EventArgs.Empty);
        }
        private void ShowScheduleInfoForm_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin lịch trình trong các điều khiển
            eventname.Text = _schedule.Eventname;
            date.Text = _schedule.Starttime.ToString("dd/MM/yyyy HH:mm");
            name.Text = _schedule.Name;
            phone.Text = _schedule.PhoneNumber;
            emailText.Text = _schedule.Email;
            destext.Text = _schedule.Description;
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }
    }
}
