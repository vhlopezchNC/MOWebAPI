using Microsoft.EntityFrameworkCore;
using MOWebAPIVicLop.Models;
using System.Diagnostics;

namespace MOWebAPIVicLop.Data
{
    public static class MOInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            MedicalOfficeContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<MedicalOfficeContext>();
            try
            {
                //Delete the database if you need to apply a new Migration
                context.Database.EnsureDeleted();
                //Create the database if it does not exist and apply the Migration
                context.Database.Migrate();
                // Look for any Doctors.  Since we can't have patients without Doctors.
                if (!context.Doctors.Any())
                {
                    context.Doctors.AddRange(
                     new Doctor
                     {
                         FirstName = "Gregory",
                         MiddleName = "A",
                         LastName = "House"
                     },
                     new Doctor
                     {
                        FirstName = "Doogie",
                        MiddleName = "R",
                        LastName = "Houser"
                     },
                     new Doctor
                     {
                         FirstName = "Charles",
                         LastName = "Xavier"
                     },
                     new Doctor
                     {
                         FirstName = "John",
                         LastName = "Smith"
                     },
                     new Doctor
                     {
                         FirstName = "Michael",
                         MiddleName = "J.",
                         LastName = "Peterson"
                     },
                     new Doctor
                     {
                         FirstName = "Steve",
                         MiddleName = "A",
                         LastName = "Padock"
                     });
                    context.SaveChanges();
                }
                if (!context.Patients.Any())
                {
                    context.Patients.AddRange(
                    new Patient
                    {
                        FirstName = "Fred",
                        MiddleName = "Reginald",
                        LastName = "Flintstone",
                        OHIP = "1231231234",
                        DOB = DateTime.Parse("1955-09-01"),
                        ExpYrVisits = 6,
                        DoctorID = context.Doctors.FirstOrDefault(d => d.FirstName == "Gregory" && d.LastName == "House").ID
                    },
                    new Patient
                    {
                        FirstName = "Wilma",
                        MiddleName = "Jane",
                        LastName = "Flintstone",
                        OHIP = "1321321324",
                        DOB = DateTime.Parse("1964-04-23"),
                        ExpYrVisits = 2,
                        DoctorID = context.Doctors.FirstOrDefault(d => d.FirstName == "Gregory" && d.LastName == "House").ID
                    },
                    new Patient
                    {
                        FirstName = "Barney",
                        LastName = "Rubble",
                        OHIP = "3213213214",
                        DOB = DateTime.Parse("1964-02-22"),
                        ExpYrVisits = 2,
                        DoctorID = context.Doctors.FirstOrDefault(d => d.FirstName == "Doogie" && d.LastName == "Houser").ID
                    },
                    new Patient
                    {
                        FirstName = "Jane",
                        MiddleName = "Samantha",
                        LastName = "Doe",
                        OHIP = "4124124123",
                        ExpYrVisits = 2,
                        DoctorID = context.Doctors.FirstOrDefault(d => d.FirstName == "Charles" && d.LastName == "Xavier").ID
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
    }

}
