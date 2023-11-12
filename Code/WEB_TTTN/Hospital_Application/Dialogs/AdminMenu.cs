using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Application.Dialogs
{
    public partial class AdminMenu : Form
    {
        private MemoryCache _cache = MemoryCache.Default;
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LocationDialog dialog = new LocationDialog();
            dialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TypeServiceDialog dialog = new TypeServiceDialog();
            dialog.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClassesDialog dialog = new ClassesDialog();
            dialog.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ScheduleEmpAdmin dialog = new ScheduleEmpAdmin();
            dialog.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminEmp adminEmp = new AdminEmp();
            adminEmp.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _cache.Remove("AccessToken");
            _cache.Remove("Username");
            this.Close();

            // Display the LoginForm
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
