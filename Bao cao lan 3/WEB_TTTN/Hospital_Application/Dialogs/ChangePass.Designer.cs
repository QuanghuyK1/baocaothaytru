namespace Hospital_Application.Dialogs
{
    partial class ChangePass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            oldpass = new TextBox();
            newpass = new TextBox();
            label2 = new Label();
            conpass = new TextBox();
            label3 = new Label();
            doipass = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(56, 75);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 0;
            label1.Text = "Mật khẩu cũ";
            // 
            // oldpass
            // 
            oldpass.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            oldpass.Location = new Point(327, 75);
            oldpass.Name = "oldpass";
            oldpass.Size = new Size(322, 32);
            oldpass.TabIndex = 1;
            // 
            // newpass
            // 
            newpass.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            newpass.Location = new Point(327, 171);
            newpass.Name = "newpass";
            newpass.Size = new Size(322, 32);
            newpass.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(56, 171);
            label2.Name = "label2";
            label2.Size = new Size(128, 25);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu mới";
            // 
            // conpass
            // 
            conpass.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            conpass.Location = new Point(327, 259);
            conpass.Name = "conpass";
            conpass.Size = new Size(322, 32);
            conpass.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(56, 266);
            label3.Name = "label3";
            label3.Size = new Size(210, 25);
            label3.TabIndex = 4;
            label3.Text = "Xác nhận mật khẩu mới";
            // 
            // doipass
            // 
            doipass.BackColor = Color.DarkTurquoise;
            doipass.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            doipass.ForeColor = SystemColors.ButtonFace;
            doipass.Location = new Point(216, 348);
            doipass.Name = "doipass";
            doipass.Size = new Size(286, 62);
            doipass.TabIndex = 6;
            doipass.Text = "Cập nhật";
            doipass.UseVisualStyleBackColor = false;
            doipass.Click += doipass_Click;
            // 
            // ChangePass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(doipass);
            Controls.Add(conpass);
            Controls.Add(label3);
            Controls.Add(newpass);
            Controls.Add(label2);
            Controls.Add(oldpass);
            Controls.Add(label1);
            Name = "ChangePass";
            Text = "ChangePass";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox oldpass;
        private TextBox newpass;
        private Label label2;
        private TextBox conpass;
        private Label label3;
        private Button doipass;
    }
}