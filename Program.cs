using System;
using System.Text.Json;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Project_KTMH
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Attendance attendance = new Attendance(DateTime.Now, TimeSpan.Zero, false,"", TimeSpan.Zero, false, TimeSpan.Zero);

            try
            {
                string employeeFilePath = "employee.json";
                string payrollFilePath = "payroll.json";

                string employeeJson = File.ReadAllText(employeeFilePath);
                List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(employeeJson);

                List<Payroll> payrolls = new List<Payroll>();
                string payrollJson = File.ReadAllText(payrollFilePath);
                payrolls = JsonSerializer.Deserialize<List<Payroll>>(payrollJson);

                EmployeeList employeeList = new EmployeeList();

                foreach (Employee employee in employees)
                {
                    employee.CreateUser();
                    Payroll matchedPayroll = null;
                    foreach (Payroll payroll in payrolls)
                    {
                        if (payroll.EmployeeID == employee.EmployeeID1)
                        {
                            matchedPayroll = payroll;
                            break;
                        }
                    }

                    if (matchedPayroll != null)
                    {
                        employeeList.AddEmployee(employee, matchedPayroll);
                    }
                    else
                    {
                        Console.WriteLine($"No payroll found for employee {employee.Name}");
                    }
                }
            }
            catch (FileNotFoundException) 
            {
                Employee nv1 = new Employee("bot", "bot.cty@ueh.edu", new DateTime(), "00000000", "123 ABC", "bot001", "bot001b", "bot", "bot");
                Payroll payroll = new Payroll("bot1", "bot", "bot001", "Bot", 0, 0, 0, 0);
                EmployeeList employeeList = new EmployeeList();
                nv1.CreateUser();

                employeeList.AddEmployee(nv1, payroll);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserForm());
        }
    }
}
