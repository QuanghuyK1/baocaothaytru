namespace Hospital_Application.Dialogs
{
    partial class AdminMenu
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(163, 51);
            label1.Name = "label1";
            label1.Size = new Size(187, 37);
            label1.TabIndex = 0;
            label1.Text = "Admin Handle";
            // 
            // button1
            // 
            button1.Location = new Point(45, 133);
            button1.Name = "button1";
            button1.Size = new Size(158, 41);
            button1.TabIndex = 1;
            button1.Text = "Location";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(45, 212);
            button2.Name = "button2";
            button2.Size = new Size(158, 41);
            button2.TabIndex = 2;
            button2.Text = "Type Service";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(301, 133);
            button3.Name = "button3";
            button3.Size = new Size(158, 41);
            button3.TabIndex = 3;
            button3.Text = "Classes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(301, 212);
            button4.Name = "button4";
            button4.Size = new Size(158, 41);
            button4.TabIndex = 4;
            button4.Text = "Schedule Employee";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(45, 287);
            button5.Name = "button5";
            button5.Size = new Size(158, 41);
            button5.TabIndex = 5;
            button5.Text = "Account Employee";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(301, 287);
            button6.Name = "button6";
            button6.Size = new Size(158, 41);
            button6.TabIndex = 6;
            button6.Text = "Employee";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(163, 349);
            button7.Name = "button7";
            button7.Size = new Size(158, 41);
            button7.TabIndex = 7;
            button7.Text = "logout";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(546, 413);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "AdminMenu";
            Text = "AdminMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}