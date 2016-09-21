using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace XSqlLiteAppMobile.Classes
{
    public class Employee
    {

        [PrimaryKey, AutoIncrement]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal Salary { get; set; }
        public bool Active { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public override int GetHashCode()
        {
            return EmployeeId;
        }
    }
}
