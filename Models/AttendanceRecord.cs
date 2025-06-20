using System;

namespace ZottaEmpNet.Models
{
    public class AttendanceRecord
    {
        public required string EmployeeUsername { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public required string ActivityDescription { get; set; }
        public required string PhotoPath { get; set; } // Add required modifier

    }
}
