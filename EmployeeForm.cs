using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Project_KTMH
{
    public partial class EmployeeForm : Form
    {
        private EmployeeList employeeList;

        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private DateTimePicker dtpDOB;
        private TextBox txtPhone;
        private TextBox txtEmployeeID;
        private TextBox txtRoleID;
        private TextBox txtDepartmentID;
        private TextBox txtRoleName;
        private Button btnUpdate;
        private Button btnRemove;
        private Button btnBack;

        public EmployeeForm(EmployeeList employeeList)
        {
            InitializeComponent();
            this.employeeList = employeeList;
        }
        public Employee Selected_e()
        {
            foreach ((Employee,Payroll) e in EmployeeList.emp)
            {
                if(UserManager.getID() == e.Item1.EmployeeID1)
                {
                    return e.Item1;
                }
            }
            return null;
        }
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.lblRoleID = new System.Windows.Forms.Label();
            this.txtRoleID = new System.Windows.Forms.TextBox();
            this.lblDepartmentID = new System.Windows.Forms.Label();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(30, 54);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 19);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ và tên:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 54);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = Selected_e().Name;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(30, 84);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(75, 19);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(148, 85);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(180, 20);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text = Selected_e().Address;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(30, 156);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(75, 19);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(148, 154);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Text = Selected_e().Email;
            // 
            // lblDOB
            // 
            this.lblDOB.Location = new System.Drawing.Point(30, 24);
            this.lblDOB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(104, 19);
            this.lblDOB.TabIndex = 6;
            this.lblDOB.Text = "Sinh nhật:";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(148, 25);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(180, 20);
            this.dtpDOB.TabIndex = 7;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(30, 120);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(75, 19);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(148, 118);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(180, 20);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.Text = Selected_e().Phone_num;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.Location = new System.Drawing.Point(30, 189);
            this.lblEmployeeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(75, 19);
            this.lblEmployeeID.TabIndex = 10;
            this.lblEmployeeID.Text = "ID nhân viên:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(148, 187);
            this.txtEmployeeID.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(180, 20);
            this.txtEmployeeID.TabIndex = 11;
            this.txtEmployeeID.Text = Selected_e().EmployeeID1;
            // 
            // lblRoleID
            // 
            this.lblRoleID.Location = new System.Drawing.Point(30, 284);
            this.lblRoleID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoleID.Name = "lblRoleID";
            this.lblRoleID.Size = new System.Drawing.Size(75, 19);
            this.lblRoleID.TabIndex = 12;
            this.lblRoleID.Text = "ID Chức vụ:";
            // 
            // txtRoleID
            // 
            this.txtRoleID.Location = new System.Drawing.Point(148, 285);
            this.txtRoleID.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoleID.Name = "txtRoleID";
            this.txtRoleID.Size = new System.Drawing.Size(180, 20);
            this.txtRoleID.TabIndex = 13;
            this.txtRoleID.Text = Selected_e().RoleID1;
            // 
            // lblDepartmentID
            // 
            this.lblDepartmentID.Location = new System.Drawing.Point(30, 221);
            this.lblDepartmentID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartmentID.Name = "lblDepartmentID";
            this.lblDepartmentID.Size = new System.Drawing.Size(75, 19);
            this.lblDepartmentID.TabIndex = 14;
            this.lblDepartmentID.Text = "ID Phòng ban:";
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.Location = new System.Drawing.Point(148, 219);
            this.txtDepartmentID.Margin = new System.Windows.Forms.Padding(2);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.Size = new System.Drawing.Size(180, 20);
            this.txtDepartmentID.TabIndex = 15;
            this.txtDepartmentID.Text = Selected_e().DepartmentID1;
            // 
            // lblRoleName
            // 
            this.lblRoleName.Location = new System.Drawing.Point(30, 254);
            this.lblRoleName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(75, 19);
            this.lblRoleName.TabIndex = 0;
            this.lblRoleName.Text = "Chức vụ:";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(148, 254);
            this.txtRoleName.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(180, 20);
            this.txtRoleName.TabIndex = 0;
            this.txtRoleName.Text = Selected_e().RoleName;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(11, 318);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(82, 31);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "ADD";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(113, 318);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 31);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(213, 318);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 31);
            this.btnRemove.TabIndex = 18;
            this.btnRemove.Text = "REMOVE";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(310, 318);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(44, 31);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btn_Back);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 366);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.lblRoleID);
            this.Controls.Add(this.txtRoleID);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblDepartmentID);
            this.Controls.Add(this.txtDepartmentID);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRemove);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EmployeeForm";
            this.Text = "Employee Form";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddEmployee1(txtName.Text,
                txtAddress.Text,
                txtEmail.Text,
                dtpDOB.Value,
                txtPhone.Text,
                txtEmployeeID.Text,
                txtRoleID.Text,
                txtDepartmentID.Text,
                txtRoleName.Text
            );
        }

        private void AddEmployee1(string name, string address, string email, DateTime dob, string phone, string employeeID, string roleID, string departmentID, string roleName)
        {
            // Tạo một nhân viên mới và một bảng lương mới
            Employee newEmployee = new Employee(name, email, dob, phone, address, employeeID, roleID, departmentID, roleName);
            Payroll payroll = new Payroll(employeeID, departmentID, employeeID, name, 1, 1, 1, 1);

            // Thêm nhân viên và bảng lương vào danh sách employeeList
            employeeList.AddEmployee(newEmployee, payroll);

            // Lấy toàn bộ danh sách nhân viên và bảng lương
            List<Employee> employeeData = new List<Employee>();
            List<Payroll> payrollData = new List<Payroll>();

            // Phương thức để lấy toàn bộ danh sách (Employee, Payroll)
            List<(Employee, Payroll)> empCopy = new List<(Employee, Payroll)>();

            foreach ((Employee, Payroll) item in EmployeeList.emp)
            {
                empCopy.Add(item);
            } 

            foreach ((Employee, Payroll) entry in empCopy)
            {
                if (!employeeData.Contains(entry.Item1))
                {
                    // Thêm nhân viên vào danh sách Employee
                    employeeData.Add(entry.Item1);

                    // Thêm bảng lương vào danh sách Payroll
                    payrollData.Add(entry.Item2);
                }
            }

            // Serialize danh sách nhân viên
            string jsonEmployees = JsonSerializer.Serialize(employeeData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("employee.json", jsonEmployees);

            // Serialize danh sách bảng lương
            string jsonPayrolls = JsonSerializer.Serialize(payrollData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("payroll.json", jsonPayrolls);

            MessageBox.Show("Employee added successfully!");

            // Xóa các giá trị trong form
            ClearForm();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            foreach((Employee, Payroll) emp in EmployeeList.emp)
            {
                if(emp.Item1.EmployeeID1 == employeeID)
                {
                    UpdateEmployee1(txtEmployeeID.Text, txtName.Text, txtAddress.Text, txtEmail.Text, dtpDOB.Value, txtPhone.Text, txtRoleID.Text, txtDepartmentID.Text, txtRoleName.Text);
                    break;
                }    
            }

            List<Employee> employeeData = new List<Employee>();
            List<Payroll> payrollData = new List<Payroll>();

            // Phương thức để lấy toàn bộ danh sách (Employee, Payroll)
            List<(Employee, Payroll)> empCopy = new List<(Employee, Payroll)>();

            foreach ((Employee, Payroll) item in EmployeeList.emp)
            {
                empCopy.Add(item);
            }

            foreach ((Employee, Payroll) entry in empCopy)
            {
                if (!employeeData.Contains(entry.Item1))
                {
                    // Thêm nhân viên vào danh sách Employee
                    employeeData.Add(entry.Item1);

                    // Thêm bảng lương vào danh sách Payroll
                    payrollData.Add(entry.Item2);
                }
            }

            // Serialize danh sách nhân viên
            string jsonEmployees = JsonSerializer.Serialize(employeeData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("employee.json", jsonEmployees);

            // Serialize danh sách bảng lương
            string jsonPayrolls = JsonSerializer.Serialize(payrollData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("payroll.json", jsonPayrolls);


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            foreach ((Employee, Payroll) emp in EmployeeList.emp)
            {
                if (emp.Item1.EmployeeID1 == employeeID)
                {
                    RemoveEmployee(txtEmployeeID.Text);
                    break;
                }
            }
            List<Employee> employeeData = new List<Employee>();
            List<Payroll> payrollData = new List<Payroll>();

            // Phương thức để lấy toàn bộ danh sách (Employee, Payroll)
            List<(Employee, Payroll)> empCopy = new List<(Employee, Payroll)>();

            foreach ((Employee, Payroll) item in EmployeeList.emp)
            {
                empCopy.Add(item);
            }

            foreach ((Employee, Payroll) entry in empCopy)
            {
                if (!employeeData.Contains(entry.Item1))
                {
                    // Thêm nhân viên vào danh sách Employee
                    employeeData.Add(entry.Item1);

                    // Thêm bảng lương vào danh sách Payroll
                    payrollData.Add(entry.Item2);
                }
            }

            // Serialize danh sách nhân viên
            string jsonEmployees = JsonSerializer.Serialize(employeeData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("employee.json", jsonEmployees);

            // Serialize danh sách bảng lương
            string jsonPayrolls = JsonSerializer.Serialize(payrollData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("payroll.json", jsonPayrolls);
        }
        
        private void UpdateEmployee1(string employeeID, string name, string address, string email, DateTime dateofbirth, string phone, string roleID, string departmentID, string roleName)
        {
            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    e.Item1.UpdateEmployee(name, email, dateofbirth, phone, address, roleID, departmentID, roleName);
                    MessageBox.Show("Employee updated successfully!");
                    break;
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }
            }

            ClearForm();
        }

        private void RemoveEmployee(string employeeID)
        {
            bool removed = employeeList.RemoveEmployee(employeeID); // Adjust this method in EmployeeList class

            if (removed)
            {
                // Tạo bản sao của danh sách để tránh lỗi

                MessageBox.Show("Employee removed successfully!");

            }
            else
            {
                MessageBox.Show("Employee not found.");
            }

            ClearForm();
        }

        private void ClearForm()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    control.Text = "";
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btn_Back(object sender, EventArgs e)
        {
            Employee ee = UserManager.GetEmployee();
            MainForm mainform = new MainForm(ee);
            mainform.Show();
            this.Close();
        }
    }
}