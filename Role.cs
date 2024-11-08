using System;
using System.Collections.Generic;

namespace Project_KTMH
{
    public class Role
    {
        private string roleID;
        private string roleName;
        private string permission;
        public bool checkExist = false;

        public string RoleID { get => roleID; }
        public string RoleName { get => roleName; set => roleName = value; }

        public Role(string roleID, string roleName)
        {
            this.roleID = roleID;
            this.roleName = roleName;
        }

        public string CheckRoleID(List<Employee> employee, List<Role> role)
        {
            Console.Write("Nhap ma chuc vu ");
            string x = Console.ReadLine();
            foreach (Employee emp in employee)
            {
                foreach (Role role1 in role)
                {
                    if (emp.EmployeeID1 == role1.roleID)
                    {
                        return role1.roleName;
                    }
                }
            }
            return "Mã chức vụ không tồn tại";
        }

        public void AddPermission()
        {

        }

        public void RemovePermission()
        {

        }

        public void UpdatePermission()
        {

        }
    }
}
