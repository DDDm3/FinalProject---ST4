using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Project_KTMH
{
    public class Employee : Person
    {
        [JsonInclude]
        public string EmployeeID1 { get; private set; }
        [JsonInclude]
        public string RoleID1 { get; private set; }
        [JsonInclude]
        public string DepartmentID1 { get; private set; }
        [JsonInclude]
        public string RoleName { get; private set; }

        public List<Attendance> attendances = new List<Attendance>();
        public List<Attendance> Attendances { get => attendances; set => attendances = value; }
        public Employee(string name, string email, DateTime dateofbirth, string phone_num, string address, string employeeID, string roleID, string departmentID, string roleName)
            : base(name, email, dateofbirth, phone_num, address)
        {
            this.EmployeeID1 = employeeID;
            this.RoleID1 = roleID;
            this.RoleName = roleName;
            this.DepartmentID1 = departmentID;
            this.Attendances = new List<Attendance>();
            CreateUser();
        }

        public Employee() : base()
        {
            this.Attendances = new List<Attendance>();
        }

        public void CreateUser()
        {
            string username = Trans(Name, EmployeeID1);
            string password = EmployeeID1;
            User user = new User(username, password);
            UserManager.Instance.AddUser(user);
        }

        private string Trans(string name, string employeeid)
        {
            string login = name.ToLower();
            login = Regex.Replace(login.Normalize(NormalizationForm.FormD), @"\p{Mn}", "");
            login = login.Replace(" ", "");
            return login + employeeid;
        }

        public double GetTotalWorkingHours(string employeeID)
        {
            int count = 0;
            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    foreach (Attendance a in e.Item1.Attendances)
                    {
                        if (a.CheckIn && a.CheckOut)
                        {
                            count += 8;
                        }

                    }
                    
                }
            }
            return count;
        }

        public int GetLateDaysCount(string employeeID)
        {
            int count = 0;
            foreach((Employee,Payroll) e in EmployeeList.emp)
            {
                if(e.Item1.EmployeeID1 == employeeID)
                {
                    foreach(Attendance a in e.Item1.Attendances)
                    {
                        if(a.Status == "late")
                        {
                            count++;
                            
                        } 
                        
                    }  
                    
                }    
            }    
            return count;
        }

        public int GetAbsentDaysCount( string employeeID)
        {
            int count = 0;
            foreach ((Employee,Payroll) e in EmployeeList.emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    foreach(Attendance a in e.Item1.Attendances)
                    {
                        if(!a.CheckIn)
                        {
                            count ++;
                        } 
                        
                    }
                    
                }         
            }
            return count;
        }

        public override void UpdatePersonalDetails(string name, string email, DateTime dateOfBirth, string phone_num, string address)
        {
            base.UpdatePersonalDetails(name, email, dateOfBirth, phone_num, address);
        }

        public void UpdateEmployee(string name, string email, DateTime dateOfBirth, string phoneNum, string address, string roleID, string departmentID, string roleName)
        {
            UpdatePersonalDetails(name, email, dateOfBirth, phoneNum, address);
            this.RoleID1 = roleID;
            this.RoleName = roleName;
            this.DepartmentID1 = departmentID;
        }
    }
}