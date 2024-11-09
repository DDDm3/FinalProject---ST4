using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_KTMH
{
    public partial class ReportForm : Form
    {
        private System.Windows.Forms.TextBox txtWorkingHours;
        private System.Windows.Forms.TextBox txtAbsentDays;
        private System.Windows.Forms.TextBox txtLateDays;
        private System.Windows.Forms.Label lblLateDays;
        private System.Windows.Forms.Label lblAbsentDays;
        private System.Windows.Forms.Label lblWorkingHours;
        private System.Windows.Forms.Button btnBack;
        public ReportForm(Employee employee)
        {
            InitializeComponent();
            Report report = new Report();
            this.txtWorkingHours.Text = $"{report.GetTotalHours(employee)}";
            this.txtAbsentDays.Text = $"{report.GetAbsentDays(employee)}";
            this.txtLateDays.Text = $"{report.GetLateDays(employee)}";
        }
        private void InitializeComponent()
        {
            this.txtWorkingHours = new System.Windows.Forms.TextBox();
            this.txtAbsentDays = new System.Windows.Forms.TextBox();
            this.txtLateDays = new System.Windows.Forms.TextBox();
            this.lblWorkingHours = new System.Windows.Forms.Label();
            this.lblAbsentDays = new System.Windows.Forms.Label();
            this.lblLateDays = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtWorkingHours
            // 
            this.txtWorkingHours.Location = new System.Drawing.Point(148, 17);
            this.txtWorkingHours.Name = "txtWorkingHours";
            this.txtWorkingHours.Size = new System.Drawing.Size(174, 22);
            this.txtWorkingHours.TabIndex = 0;
            // 
            // txtAbsentDays
            // 
            this.txtAbsentDays.Location = new System.Drawing.Point(148, 57);
            this.txtAbsentDays.Name = "txtAbsentDays";
            this.txtAbsentDays.Size = new System.Drawing.Size(174, 22);
            this.txtAbsentDays.TabIndex = 1;

            // 
            // txtLateDays
            // 
            this.txtLateDays.Location = new System.Drawing.Point(148, 99);
            this.txtLateDays.Name = "txtLateDays";
            this.txtLateDays.Size = new System.Drawing.Size(174, 22);
            this.txtLateDays.TabIndex = 2;

            // 
            // lblWorkingHours
            // 
            this.lblWorkingHours.AutoSize = true;
            this.lblWorkingHours.Location = new System.Drawing.Point(21, 23);
            this.lblWorkingHours.Name = "lblWorkingHours";
            this.lblWorkingHours.Size = new System.Drawing.Size(74, 16);
            this.lblWorkingHours.TabIndex = 3;
            this.lblWorkingHours.Text = "Số giờ làm:";
            // 
            // lblAbsentDays
            // 
            this.lblAbsentDays.AutoSize = true;
            this.lblAbsentDays.Location = new System.Drawing.Point(21, 60);
            this.lblAbsentDays.Name = "lblAbsentDays";
            this.lblAbsentDays.Size = new System.Drawing.Size(88, 16);
            this.lblAbsentDays.TabIndex = 4;
            this.lblAbsentDays.Text = "Số ngày nghỉ:";
            // 
            // lblLateDays
            // 
            this.lblLateDays.AutoSize = true;
            this.lblLateDays.Location = new System.Drawing.Point(21, 99);
            this.lblLateDays.Name = "lblLateDays";
            this.lblLateDays.Size = new System.Drawing.Size(78, 16);
            this.lblLateDays.TabIndex = 5;
            this.lblLateDays.Text = "Số ngày trễ:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(187, 140);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(95, 30);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btn_Back);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 182);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblAbsentDays);
            this.Controls.Add(this.lblLateDays);
            this.Controls.Add(this.lblWorkingHours);
            this.Controls.Add(this.txtLateDays);
            this.Controls.Add(this.txtAbsentDays);
            this.Controls.Add(this.txtWorkingHours);
            this.Name = "ReportForm";
            this.Text = "Report Form";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void btn_Back(object sender, EventArgs e)
        {
            Employee e1 = UserManager.GetEmployee();
            MainForm mainform = new MainForm(e1);
            mainform.Show();
            this.Close();
        }
    }
}
