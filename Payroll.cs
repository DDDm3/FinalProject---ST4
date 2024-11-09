using System;
using System.Collections.Generic;

namespace Project_KTMH
{
    public class Payroll
    {
        public string PayrollID { get; private set; }
        public string DepartmentID { get; private set; }
        public string EmployeeID { get; private set; }
        public string EmployeeName { get; private set; }
        public double SalaryCoefficient { get; private set; }
        public double SalaryCoefficientDepartment { get; private set; }
        public double SalaryCoefficientPosition { get; private set; }
        public decimal BaseSalary { get; set; }
        public decimal OvertimeSalary { get; private set; }
        public decimal TotalSalary { get; private set; }
        public int AttendanceDay { get; set; }
        public List<Attendance> AttendanceList { get; set; }
        public decimal BHXH { get; private set; }
        public decimal BHYT { get; private set; }

        public decimal Bonus { get; private set; }
        public decimal Tax { get; private set; }
        public decimal TotalDeductions { get; private set; }

        public DateTime CalculationDate { get; private set; }

        public Payroll(string payrollID, string departmentID, string employeeID, string employeeName,
                      double salaryCoefficient, double salaryCoefficientDepartment, double salaryCoefficientPosition,
                      decimal baseSalary)
        {
            PayrollID = payrollID;
            DepartmentID = departmentID;
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            SalaryCoefficient = salaryCoefficient;
            SalaryCoefficientDepartment = salaryCoefficientDepartment;
            SalaryCoefficientPosition = salaryCoefficientPosition;
            BaseSalary = baseSalary;
            OvertimeSalary = 0;
            Bonus = 0;
            Tax = 20;
            TotalDeductions = 0;
            TotalSalary = 0;
            AttendanceList = this.AddAttendance();
            CalculationDate = DateTime.Now;
        }

        public void CalculateOvertimePay(decimal overtimeHours, decimal overtimeRate)
        {
            OvertimeSalary = overtimeHours * overtimeRate;
        }

        public void CalculateTotalSalary()
        {
            decimal baseSalaryCalculated = BaseSalary * (decimal)SalaryCoefficient * (decimal)SalaryCoefficientDepartment * (decimal)SalaryCoefficientPosition * AttendanceList.Count;
            decimal totalBeforeDeductions = baseSalaryCalculated + OvertimeSalary + Bonus;
            TotalDeductions = BHXH + BHYT + (totalBeforeDeductions * Tax / 100);
            TotalSalary = totalBeforeDeductions - TotalDeductions;
        }

        public List<Attendance> AddAttendance()
        {
            if (AttendanceList == null)
            {
                AttendanceList = new List<Attendance>();
            }

            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {
                if (this.EmployeeID == e.Item1.EmployeeID1)
                {

                    if (e.Item1.attendances != null)
                    {
                        foreach (Attendance attendance in e.Item1.attendances)
                        {
                            if (attendance.CheckIn && attendance.CheckOut)
                            {
                                AttendanceList.Add(attendance);
                            }
                        }
                    }
                }
            }
            return AttendanceList;
        }

        public decimal CalculateTotalOvertimeHours()
        {
            decimal totalOvertime = 0;
            foreach (Attendance attendance in AttendanceList)
            {
                totalOvertime += (decimal)attendance.OtTime.TotalHours;
            }
            return totalOvertime;
        }

        public void AddDeductions(decimal bhxh, decimal bhyt, decimal tax)
        {
            BHXH = bhxh;
            BHYT = bhyt;
            Tax = tax;
        }
        public void AddBonus(decimal bonus)
        {
            Bonus = bonus;
        }
    }
}