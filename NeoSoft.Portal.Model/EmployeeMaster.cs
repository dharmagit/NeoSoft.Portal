using System;
using System.Collections.Generic;
using System.Text;

namespace NeoSoft.Portal.Model
{

    public class EmployeeMaster
    {
        public int Row_Id { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int CityId { get; set; } 
        public int StateId { get; set; }
        public int CountryId { get; set; }

        public string CountryName { get; set; } = string.Empty;

        public string StateName { get; set; } = string.Empty;

        public string CityName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string PanNumber { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
        public int Gender { get; set; } = default(int);
        public DateTime DateOfBirth { get; set; } 
        public DateTime DateOfJoinee { get; set; } 
   
    }

    public class Employee
    {
        public object Row_Id { get; set; }
        public object EmployeeCode { get; set; } = string.Empty;
        public object FirstName { get; set; } = string.Empty;
        public object LastName { get; set; } = string.Empty;
        public object CityId { get; set; }
        public object StateId { get; set; }
        public object CountryId { get; set; }

        public object EmailAddress { get; set; } = string.Empty;
        public object MobileNumber { get; set; } = string.Empty;
        public object PanNumber { get; set; } = string.Empty;
        public object PassportNumber { get; set; } = string.Empty;
        public object ProfileImage { get; set; } = string.Empty;
        public object Gender { get; set; } = default(int);
        public object DateOfBirth { get; set; }
        public object DateOfJoinee { get; set; }

    }



}
