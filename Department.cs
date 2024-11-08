using System;
using System.Collections.Generic;

namespace Project_KTMH
{
    public class Department
    {
        private string departmentID;
        private string departmentName;
        private string description;

        public string DepartmentID { get => departmentID; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
        public string Description { get => description; set => description = value; }

        public static List<Department> Departments = new List<Department>();

        public Department(string departmentID)
        {
            this.departmentID = departmentID;
        }

        public Department FindDepartment(string departmentID)
        {
            foreach (Department department in Departments)
            {
                if (string.Equals(department.departmentID, departmentID, StringComparison.OrdinalIgnoreCase))
                {
                    return department;
                }
            }
            return null;
        }

        public void DisplayEmployeeInDepartment(List<Employee> employees, string departmentID)
        {
            Department department = FindDepartment(departmentID);
            if (department == null)
            {
                Console.WriteLine("Khong tim thay phong ban voi ten nay.");
                return;
            }

            Console.WriteLine($"Nhan vien trong phong ban: {department.departmentName}");

            List<Employee> employeesInDepartment = new List<Employee>();

            foreach (Employee emp in employees)
            {
                if (emp.DepartmentID1 == department.DepartmentID)
                {
                    employeesInDepartment.Add(emp);
                }
            }

            if (employeesInDepartment.Count == 0)
            {
                Console.WriteLine("Khong co nhan vien nao trong phong ban nay.");
            }
            else
            {
                foreach (Employee emp in employeesInDepartment)
                {
                    Console.WriteLine($"- {emp.EmployeeID1}: {emp.Name}");
                }
            }
        }
    }
}