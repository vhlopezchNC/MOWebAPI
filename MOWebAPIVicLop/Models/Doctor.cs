﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MOWebAPIVicLop.Models
{
    public class Doctor
    {
        public int ID { get; set; }

        [JsonIgnore]
        [Display(Name = "Doctor")]
        public string Summary
        {
            get
            {
                return "Dr. " + FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? " " :
                        (" " + (char?)MiddleName[0] + ". ").ToUpper())
                    + LastName;
            }
        }

        [JsonIgnore]
        public string FormalName
        {
            get
            {
                return LastName + ", " + FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? "" :
                        (" " + (char?)MiddleName[0] + ".").ToUpper());
            }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The Doctor's first name cannot be left blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters long.")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The Doctor's last name is required.")]
        [StringLength(100, ErrorMessage = "Last name cannot be more than 100 characters long.")]
        public string LastName { get; set; }
        [Timestamp]

        [JsonIgnore]
        public Byte[] RowVersion { get; set; }

        [JsonIgnore]
        public ICollection<Patient> Patients { get; set; }
    }

}
