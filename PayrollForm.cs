﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Project_KTMH
{
    public partial class PayrollForm : Form
    {
        private List<(Employee,Payroll)> employees = EmployeeList.emp;
        private List<Payroll> payrolls;
        private string payrollFilePath = "payrolls.json"; // Đổi tên file lưu trữ thành JSON
        private DataGridView dgvPayrolls;
        private ComboBox cmbEmployees;

        private TextBox txtBaseSalary;
        private TextBox txtAttendanceDay;
        private Button btnUpdatePayroll;
        private Button btnDeletePayroll;
        private Button btnAddPayroll;

        public PayrollForm()
        {
            InitializeComponent();
            LoadData();
            LoadEmployees();
            LoadPayrolls();
        }

        // Phương thức tải dữ liệu từ file
        public void LoadData()
        {
            List<Employee>  employeesList = LoadEmployeesFromFile("employees.json"); // Sử dụng JSON cho employees
            payrolls = LoadPayrollsFromFile(payrollFilePath);

            employees = new List<(Employee, Payroll)>();
            
            foreach(Employee employee in employeesList)
            {
                Payroll current_p = null;
                foreach(Payroll payroll in payrolls)
                {
                    if(payroll.PayrollID == employee.EmployeeID1)
                    {
                        current_p = payroll;
                        break;
                    }
                }
                employees.Add((employee, current_p));
            }
        }

        // Phương thức tải danh sách nhân viên từ file JSON
        public List<Employee> LoadEmployeesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Employee>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Employee>>(json);
        }

        // Phương thức tải danh sách lương từ file JSON
        public List<Payroll> LoadPayrollsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Payroll>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Payroll>>(json);
        }

        // Phương thức lưu danh sách lương vào file JSON
        public void SavePayrollsToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(payrolls, options);
            File.WriteAllText(payrollFilePath, json);
        }

        // Phương thức tải danh sách nhân viên vào ComboBox
        public void LoadEmployees()
        {
            List<Employee> employeesList = new List<Employee>();
            foreach ((Employee,Payroll) employee in employees)
            {
                employeesList.Add(employee.Item1);
            }

            cmbEmployees.DataSource = employeesList;
            cmbEmployees.DisplayMember = "Name";
            cmbEmployees.ValueMember = "EmployeeID";
            cmbEmployees.SelectedIndex = -1;
        }

        // Phương thức tải danh sách bảng lương vào DataGridView
        public void LoadPayrolls()
        {
            dgvPayrolls.DataSource = null;
            dgvPayrolls.DataSource = payrolls.Select(p => new
            {
                p.PayrollID,
                p.EmployeeID,
                p.EmployeeName,
                p.DepartmentID,
                p.SalaryCoefficient,
                p.SalaryCoefficientDepartment,
                p.SalaryCoefficientPosition,
                p.BaseSalary,
                p.OvertimeSalary,
                p.TotalSalary,
                p.AttendanceDay,
                p.BHXH,
                p.BHYT,
                p.Bonus,
                p.Tax,
                p.TotalDeductions,
                p.CalculationDate
            }).ToList();
        }

        // Sự kiện thêm bảng lương
        private void btnAddPayroll_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ giao diện người dùng
            string employeeID = (string)cmbEmployees.SelectedValue;
            string payrollID = employeeID; 
            decimal baseSalary = decimal.Parse(txtBaseSalary.Text);
            int attendanceDay = int.Parse(txtAttendanceDay.Text);

            (Employee, Payroll) employee_tuple = (null, null);

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Item1.EmployeeID1 == employeeID)
                {
                    employee_tuple = employees[i];
                    break;
                }
            }

            if (employee_tuple.Item1 != null)
            {
                string departmentID = employee_tuple.Item1.DepartmentID1;
                string employeeName = employee_tuple.Item1.Name;
                double salaryCoefficient = (employee_tuple.Item2 != null) ? employee_tuple.Item2.SalaryCoefficient : 1; 
                double salaryCoefficientDepartment = (employee_tuple.Item2 != null) ? employee_tuple.Item2.SalaryCoefficientDepartment : 1;
                double salaryCoefficientPosition = (employee_tuple.Item2 != null) ? employee_tuple.Item2.SalaryCoefficientPosition : 1;

                Payroll newPayroll = new Payroll(payrollID, departmentID, employeeID, employeeName,
                                                 salaryCoefficient, salaryCoefficientDepartment, salaryCoefficientPosition,
                                                 baseSalary, attendanceDay);

                payrolls.Add(newPayroll);
                SavePayrollsToFile();
                LoadPayrolls(); // Tải lại dữ liệu bảng lương
            }
        }


        // Sự kiện cập nhật bảng lương
        private void btnUpdatePayroll_Click(object sender, EventArgs e)
        {
            // Cập nhật bảng lương đã chọn
            if (dgvPayrolls.CurrentRow != null)
            {
                var selectedPayroll = (Payroll)dgvPayrolls.CurrentRow.DataBoundItem;
                selectedPayroll.BaseSalary = decimal.Parse(txtBaseSalary.Text);
                selectedPayroll.AttendanceDay = int.Parse(txtAttendanceDay.Text);
                SavePayrollsToFile();
                LoadPayrolls(); // Tải lại dữ liệu bảng lương
            }
        }

        // Sự kiện xóa bảng lương
        private void btnDeletePayroll_Click(object sender, EventArgs e)
        {
            if (dgvPayrolls.CurrentRow != null)
            {
                var selectedPayroll = (Payroll)dgvPayrolls.CurrentRow.DataBoundItem;
                payrolls.Remove(selectedPayroll);
                SavePayrollsToFile();
                LoadPayrolls(); // Tải lại dữ liệu bảng lương
            }
        }

        // Sự kiện khi thay đổi lựa chọn trong DataGridView
        private void dgvPayrolls_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPayrolls.CurrentRow != null)
            {
                var selectedPayroll = (Payroll)dgvPayrolls.CurrentRow.DataBoundItem;
                txtBaseSalary.Text = selectedPayroll.BaseSalary.ToString();
                txtAttendanceDay.Text = selectedPayroll.AttendanceDay.ToString();
            }
        }

        private void InitializeComponent()
        {
            this.dgvPayrolls = new DataGridView();
            this.cmbEmployees = new ComboBox();
            this.txtBaseSalary = new TextBox();
            this.txtAttendanceDay = new TextBox();
            this.btnAddPayroll = new Button();
            this.btnUpdatePayroll = new Button();
            this.btnDeletePayroll = new Button();

            this.SuspendLayout();

            // 
            // dgvPayrolls
            // 
            this.dgvPayrolls.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayrolls.Location = new System.Drawing.Point(12, 12);
            this.dgvPayrolls.Name = "dgvPayrolls";
            this.dgvPayrolls.Size = new System.Drawing.Size(800, 300);
            this.dgvPayrolls.SelectionChanged += new EventHandler(this.dgvPayrolls_SelectionChanged);

            // 
            // cmbEmployees
            // 
            this.cmbEmployees.Location = new System.Drawing.Point(12, 320);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(200, 21);

            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Location = new System.Drawing.Point(12, 350);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(100, 20);

            // 
            // txtAttendanceDay
            // 
            this.txtAttendanceDay.Location = new System.Drawing.Point(12, 380);
            this.txtAttendanceDay.Name = "txtAttendanceDay";
            this.txtAttendanceDay.Size = new System.Drawing.Size(100, 20);

            // 
            // btnAddPayroll
            // 
            this.btnAddPayroll.Location = new System.Drawing.Point(12, 410);
            this.btnAddPayroll.Name = "btnAddPayroll";
            this.btnAddPayroll.Size = new System.Drawing.Size(75, 23);
            this.btnAddPayroll.Text = "Add Payroll";
            this.btnAddPayroll.Click += new EventHandler(this.btnAddPayroll_Click);

            // 
            // btnUpdatePayroll
            // 
            this.btnUpdatePayroll.Location = new System.Drawing.Point(100, 410);
            this.btnUpdatePayroll.Name = "btnUpdatePayroll";
            this.btnUpdatePayroll.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatePayroll.Text = "Update Payroll";
            this.btnUpdatePayroll.Click += new EventHandler(this.btnUpdatePayroll_Click);

            // 
            // btnDeletePayroll
            // 
            this.btnDeletePayroll.Location = new System.Drawing.Point(200, 410);
            this.btnDeletePayroll.Name = "btnDeletePayroll";
            this.btnDeletePayroll.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePayroll.Text = "Delete Payroll";
            this.btnDeletePayroll.Click += new EventHandler(this.btnDeletePayroll_Click);

            // 
            // PayrollForm
            // 
            this.ClientSize = new System.Drawing.Size(911, 504);
            this.Controls.Add(this.dgvPayrolls);
            this.Controls.Add(this.cmbEmployees);
            this.Controls.Add(this.txtBaseSalary);
            this.Controls.Add(this.txtAttendanceDay);
            this.Controls.Add(this.btnAddPayroll);
            this.Controls.Add(this.btnUpdatePayroll);
            this.Controls.Add(this.btnDeletePayroll);
            this.Name = "PayrollForm";
            this.ResumeLayout(false);
        }

        // Phương thức để làm sạch các input
        private void ClearInputs()
        {
            txtBaseSalary.Clear();
            txtAttendanceDay.Clear();
        }
    }
}
