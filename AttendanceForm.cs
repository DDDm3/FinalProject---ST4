using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;

namespace Project_KTMH
{
    partial class AttendanceForm : Form
    {
        private Attendance attendanceManager;
        private List<Employee> employees;

        public AttendanceForm(Employee employee)
        {
            InitializeComponent();
            attendanceManager = new Attendance(DateTime.Now, TimeSpan.Zero, false, "", TimeSpan.Zero, false, TimeSpan.Zero);
            this.txtEmployeeID.Text = employee.EmployeeID1;
        }

        private void InitializeComponent()
        {
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblWorkingDays = new System.Windows.Forms.Label();
            this.lstAttendanceHistory = new System.Windows.Forms.ListBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnSaveAttendance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(39, 28);
            this.lblEmployeeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(104, 20);
            this.lblEmployeeID.TabIndex = 0;
            this.lblEmployeeID.Text = "Employee ID:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(253, 20);
            this.txtEmployeeID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(186, 26);
            this.txtEmployeeID.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(39, 68);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // lblWorkingDays
            // 
            this.lblWorkingDays.AutoSize = true;
            this.lblWorkingDays.Location = new System.Drawing.Point(39, 108);
            this.lblWorkingDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWorkingDays.Name = "lblWorkingDays";
            this.lblWorkingDays.Size = new System.Drawing.Size(168, 20);
            this.lblWorkingDays.TabIndex = 3;
            this.lblWorkingDays.Text = "Working Days / Month:";
            //
            // Working Days TextBox
            //
            this.txtWorkingDays = new System.Windows.Forms.TextBox();
            this.txtWorkingDays.Location = new System.Drawing.Point(253, 108);
            this.txtWorkingDays.Margin = new System.Windows.Forms.Padding(4);
            this.txtWorkingDays.Name = "txtWorkingDays";
            this.txtWorkingDays.Size = new System.Drawing.Size(186, 26);
            this.txtWorkingDays.TabIndex = 10;
            // 
            // lstAttendanceHistory
            // 
            this.lstAttendanceHistory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstAttendanceHistory.FormattingEnabled = true;
            this.lstAttendanceHistory.ItemHeight = 30;
            this.lstAttendanceHistory.Location = new System.Drawing.Point(39, 148);
            this.lstAttendanceHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstAttendanceHistory.Name = "lstAttendanceHistory";
            this.lstAttendanceHistory.Size = new System.Drawing.Size(440, 244);
            this.lstAttendanceHistory.TabIndex = 4;
            this.lstAttendanceHistory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstAttendanceHistory_DrawItem);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(39, 440);
            this.btnCheckIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(107, 46);
            this.btnCheckIn.TabIndex = 5;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(154, 440);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(117, 46);
            this.btnCheckOut.TabIndex = 6;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 450);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 71);
            this.button1.TabIndex = 7;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(253, 68);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(186, 26);
            this.txtStatus.TabIndex = 8;
            // 
            // btnSaveAttendance
            // 
            this.btnSaveAttendance.Location = new System.Drawing.Point(279, 440);
            this.btnSaveAttendance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveAttendance.Name = "btnSaveAttendance";
            this.btnSaveAttendance.Size = new System.Drawing.Size(111, 46);
            this.btnSaveAttendance.TabIndex = 9;
            this.btnSaveAttendance.Text = "Save";
            this.btnSaveAttendance.Click += new System.EventHandler(this.btnSaveAttendance_Click);
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 532);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWorkingDays);
            this.Controls.Add(this.lstAttendanceHistory);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnSaveAttendance);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AttendanceForm";
            this.Text = "Attendance Form";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += new System.EventHandler(this.AttendanceForm_Load);

        }

        public void AttendanceForm_Load(string filepath)
        {

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            Attendance todayAttendance = null;

            // Duyệt qua tất cả các nhân viên
            foreach ((Employee, Payroll) employee in EmployeeList.emp)
            {
                if (employee.Item1.EmployeeID1 == employeeID)
                {
                    // Duyệt qua tất cả các bản ghi chấm công của nhân viên
                    foreach (Attendance attendance in employee.Item1.attendances)
                    {
                        if (attendance.Date.Date == DateTime.Today.Date)
                        {
                            attendance.UpdateRecord(employeeID, "CheckIn");
                            todayAttendance = attendance;
                            break; // Thoát vòng lặp nếu đã tìm thấy bản ghi ngày hôm nay
                        }
                    }

                    break; // Thoát vòng lặp ngoài khi đã xử lý xong cho nhân viên phù hợp
                }
            }


            if (todayAttendance != null)
            {
                txtStatus.Text = todayAttendance.Status;
            }
            else
            {
                txtStatus.Text = "Không tồn tại";
            }
            UpdateAttendanceHistory(employeeID, btnCheckIn.Text);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            Attendance todayAttendance = null;
            foreach ((Employee, Payroll) employee in EmployeeList.emp)
            {
                if (employee.Item1.EmployeeID1 == employeeID)
                {
                    foreach (Attendance attendance in employee.Item1.attendances)
                    {
                        if (attendance.Date.Date == DateTime.Today.Date)
                        {
                            attendance.UpdateRecord(employeeID, "CheckOut");
                       
                            todayAttendance = attendance;
                            break;
                        }
                    }
                    break;
                }
                
            }
            if (todayAttendance != null)
            {
                txtStatus.Text = todayAttendance.Status;
            }
            else
            {
                txtStatus.Text = "Không tồn tại";
            }
            UpdateAttendanceHistory(employeeID, btnCheckOut.Text);
        }
        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            string filePath = $"{employeeID}.json";
            CreateDailyRecord();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<string> attendanceRecords = JsonSerializer.Deserialize<List<string>>(json);

                // Populate the list box with previous records
                lstAttendanceHistory.Items.Clear();
                foreach (string record in attendanceRecords)
                {
                    lstAttendanceHistory.Items.Add(record);
                }
            }
        }

        private void lstAttendanceHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Ensure we have a valid index
            if (e.Index < 0) return;

            // Get the current item text
            string itemText = lstAttendanceHistory.Items[e.Index].ToString();

            // Set color based on content
            Color itemColor = itemText.Contains("Check In") ? Color.Green : Color.Red;

            // Draw the background
            e.DrawBackground();

            // Draw the item text with chosen color
            using (Brush brush = new SolidBrush(itemColor))
            {
                e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
            }

            // Draw focus rectangle if the item has focus
            e.DrawFocusRectangle();
        }

        private void UpdateAttendanceHistory(string employeeID, string action)
        {
            //lstAttendanceHistory.Items.Clear();
            Employee employee = null;

            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    employee = e.Item1;
                    foreach (Attendance attendance in e.Item1.attendances)
                    {
                        if (action == "Check In")
                        {
                            lstAttendanceHistory.Items.Add($"Check In Date: {attendance.Date}, Status: {attendance.Status}, OT: {attendance.OtTime}");
                        }
                        else
                        {
                            lstAttendanceHistory.Items.Add($"Check Out Date: {attendance.Date}, OT: {attendance.OtTime}");
                        }
                    }

                    int workingDays = attendanceManager.CountDay(employeeID);
                    txtWorkingDays.Text = workingDays.ToString();
                    break;
                }
                
            }
            
            if(employee == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên.");   
            }  
            
        }
        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            SaveAttendanceHistory(txtEmployeeID.Text);
        }

        private void SaveAttendanceHistory(string employeeID)
        {
            List<string> attendanceRecords = new List<string>();
            for (int i = 0; i < lstAttendanceHistory.Items.Count; i++)
            {
                string item = lstAttendanceHistory.Items[i].ToString();
                attendanceRecords.Add(item);
            }

            string json = JsonSerializer.Serialize(attendanceRecords, new JsonSerializerOptions { WriteIndented = true });
            string filePath = $"{employeeID}.json";
            File.WriteAllText(filePath, json);
            MessageBox.Show($"Attendance history saved to {filePath}");
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            UserForm user = new UserForm();
            user.Show();
            UserManager.loggedIn_User = null;
            this.Close();
        }

        public void CreateDailyRecord()
        {
            DateTime today = DateTime.Today;

            foreach ((Employee,Payroll) e in EmployeeList.emp)
            {
                bool hasrecord = false;

                for (int i = 0; i < e.Item1.attendances.Count; i++)
                {

                    if (e.Item1.attendances[i].Date.Date == today)
                    {
                        hasrecord = true;
                        break;
                    }
                }
                

                if (!hasrecord)
                {
                    Attendance attendance = new Attendance(DateTime.Now, TimeSpan.MinValue, false, "none", TimeSpan.MinValue, false, default);
                    attendance.CheckInTime = TimeSpan.MinValue;
                    attendance.CheckOutTime = TimeSpan.MinValue;
                    e.Item1.attendances.Add(attendance);
                }
            }
        }  
    }
}