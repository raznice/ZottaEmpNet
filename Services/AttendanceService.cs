namespace ZottaEmpNet.Services
{
    using System;
    using System.Collections.Generic;
    using ZottaEmpNet.Models;
    using System.Linq;

    public class AttendanceService
    {
        private List<AttendanceRecord> _attendanceRecords = new List<AttendanceRecord>();
        private Dictionary<string, decimal> _employeeWageRates = new Dictionary<string, decimal>(); // Add this dictionary

        public void AddRecord(AttendanceRecord record)
        {
            _attendanceRecords.Add(record);
        }

        public List<AttendanceRecord> GetRecordsByEmployee(string employeeUsername)
        {
            return _attendanceRecords.Where(r => r.EmployeeUsername == employeeUsername).ToList();
        }

        public List<AttendanceRecord> GetAllRecords()
        {
            return _attendanceRecords.ToList();
        }

        // Add this method to set employee wage rates
        public void SetEmployeeWage(string employeeUsername, decimal wageRate)
        {
            if (_employeeWageRates.ContainsKey(employeeUsername))
            {
                _employeeWageRates[employeeUsername] = wageRate;
            }
            else
            {
                _employeeWageRates.Add(employeeUsername, wageRate);
            }
        }

        // Add a method to get employee wage rate (optional, but helpful)
        public decimal GetEmployeeWage(string employeeUsername)
        {
            if (_employeeWageRates.TryGetValue(employeeUsername, out decimal wageRate))
            {
                return wageRate;
            }
            return 0; // Return a default value if wage rate is not set
        }
    }
}
