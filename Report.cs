using System;

namespace Project_KTMH
{
    public class Report
    {
        private string reportID;
        private DateTime reportDate;

        public string ReportID { get => reportID;}
        public DateTime ReportDate { get => reportDate; }

        public void GenerateReport(EmployeeList employees)
        {
            Console.WriteLine("Báo cáo chuyên cần của nhân viên:");
            Console.WriteLine("----------------------------------");

            foreach ((Employee, Payroll) employee in EmployeeList.emp)
            {
                double totalHours = employee.Item1.GetTotalWorkingHours(employee.Item1.EmployeeID1);
                int lateDays = employee.Item1.GetLateDaysCount(employee.Item1.EmployeeID1);
                int absentDays = employee.Item1.GetAbsentDaysCount(employee.Item1.EmployeeID1);

                Console.WriteLine($"Nhân viên: {employee.Item1.Name} (ID: {employee.Item1.EmployeeID1})");
                Console.WriteLine($"Phòng ban: {employee.Item1.DepartmentID1}");
                Console.WriteLine($"Tổng số giờ làm: {totalHours} giờ");
                Console.WriteLine($"Số ngày đi muộn: {lateDays}");
                Console.WriteLine($"Số ngày nghỉ không phép: {absentDays}");
                Console.WriteLine("----------------------------------");
            }
        }

        public double GetTotalHours(Employee employee)
        {
            
                double totalHours = employee.GetTotalWorkingHours(employee.EmployeeID1);
                return totalHours;
            
            return 0;
        }

        public int GetLateDays(Employee employee)
        {

            int lateDays = employee.GetLateDaysCount(employee.EmployeeID1);
            return lateDays;


        }

        public int GetAbsentDays(Employee employee)
        {

            int absentDays = employee.GetAbsentDaysCount(employee.EmployeeID1);
            return absentDays;

        }
    }
}
