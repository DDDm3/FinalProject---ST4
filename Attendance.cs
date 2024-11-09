using System;
using System.Collections.Generic;

namespace Project_KTMH
{
    public class Attendance
    {

        private TimeSpan checkInTime;
        private TimeSpan checkOutTime;
        private string status;
        private TimeSpan otTime;
        private DateTime date;
        private int workingDay;

        private TimeSpan defaultTimeIn = new TimeSpan(9, 0, 0);
        private TimeSpan defaultTimeOut = new TimeSpan(17, 0, 0);
        private bool checkIn = false;
        private bool checkOut = false;
       
        //string đại diện cho employeeId

        public TimeSpan OtTime { get => otTime; }
        public bool CheckIn { get => checkIn;  set => checkIn = value; }
        public bool CheckOut { get => checkOut;  set => checkOut = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Date { get => date; set => date = value; }
        public TimeSpan CheckInTime { get => checkInTime; set => checkInTime = value; }
        public TimeSpan CheckOutTime { get => checkOutTime; set => checkOutTime = value; }

        public Attendance(DateTime date, TimeSpan checkintime, bool checkin, string status, TimeSpan checkouttime, bool checkout, TimeSpan otTime)
        {
            this.Date = date.Date;
            this.CheckInTime = checkintime;
            this.CheckIn = checkin;
            this.Status = status;
            this.CheckOutTime = checkouttime;
            this.CheckOut = checkout;
            this.otTime = otTime;
        }

        public string TimeIn(TimeSpan checkInTime)
        {
            if (checkInTime >= defaultTimeIn && checkInTime <= new TimeSpan(9, 15, 0))
            {
                status = "normal";
            }
            else if (checkInTime > new TimeSpan(9, 15, 0))
            {
                status = "late";
            }
            else
            {
                status = "error";
            }    
            return status;
        }

        public void TimeOut(TimeSpan checkOutTime)
        {
            if (checkOutTime >= defaultTimeOut && checkOutTime <= new TimeSpan(18, 0, 0))
            {
                checkOut = true;
            }
            else if (checkOutTime > new TimeSpan(18, 30, 0))
            {
                TimeSpan newOtTime = new TimeSpan(0, 0, 0);
                checkOut = true;
                TimeSpan otduration = checkOutTime - new TimeSpan(18, 30, 0);

                if (otduration > newOtTime)
                {
                    otTime += new TimeSpan(otduration.Hours, 0, 0);
                }
            }
        }

        public int CountDay(string employeeID)
        {
            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {

                if (e.Item1.EmployeeID1 == employeeID)
                {
                    List<Attendance> attendances = e.Item1.attendances;

                    foreach (Attendance attendance in attendances)
                    {
                        if (attendance.checkOut && attendance.checkIn)
                        {
                            attendance.workingDay++;
                        }
                    }
                }
            }
            return workingDay;
        }
       

        //update khi người dùng checkin và checkout
        //kiểm tra mã nhân viên khi người dùng nhập vào 
        public void UpdateRecord(string employeeID, string action)
        {
            //List<Attendance> attendances = attendanceRecords[employeeID];
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            foreach ((Employee, Payroll) e in EmployeeList.emp)
            {
                if (e.Item1.EmployeeID1 == employeeID)
                {
                    foreach (Attendance attendance in e.Item1.attendances)
                    {
                            if (action == "CheckIn")
                            {
                                attendance.CheckInTime = now.TimeOfDay;                              
                                attendance.status = attendance.TimeIn(attendance.CheckInTime);
                                attendance.Date = DateTime.Now;
                                attendance.checkIn = true;
                            }

                            if (action == "CheckOut")
                            {
                                attendance.CheckOutTime = now.TimeOfDay;
                                attendance.TimeOut(attendance.CheckOutTime);
                                attendance.Date = DateTime.Now;
                                attendance.checkOut = true;
                            }
                    }
                }
            }
        }
    }
}