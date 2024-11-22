using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Models
{
    public static class Seeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!context.AgeBands.Any())
            {
                var ageBands = new List<RefAgeBand>
                {
                    new RefAgeBand { AgeBandCode = "YOUTH", AgeBandDescription = "Youth (18-25)" },
                    new RefAgeBand { AgeBandCode = "ADULT", AgeBandDescription = "Adult (26-45)" },
                    new RefAgeBand { AgeBandCode = "SENIOR", AgeBandDescription = "Senior (46+)" }
                };

                await context.AgeBands.AddRangeAsync(ageBands);
                await context.SaveChangesAsync();
            }

            if (!context.Genders.Any())
            {
                var genders = new List<RefGender>
                {
                    new RefGender { GenderCode = "M", GenderDescription = "Male" },
                    new RefGender { GenderCode = "F", GenderDescription = "Female" },
                    new RefGender { GenderCode = "O", GenderDescription = "Other" }
                };

                await context.Genders.AddRangeAsync(genders);
                await context.SaveChangesAsync();
            }

            if (!context.StaffJobTitles.Any())
            {
                var jobTitles = new List<RefStaffJobTitle>
                {
                    new RefStaffJobTitle { JobCode = "STYLIST", JobDescription = "Hair Stylist" },
                    new RefStaffJobTitle { JobCode = "MANAGER", JobDescription = "Salon Manager" },
                    new RefStaffJobTitle { JobCode = "ASSISTANT", JobDescription = "Salon Assistant" }
                };

                await context.StaffJobTitles.AddRangeAsync(jobTitles);
                await context.SaveChangesAsync();
            }

            if (!context.Staff.Any())
            {
                var staff = new List<Staff>
                {
                    new Staff { StaffName = "Alice Johnson", JobCode = "STYLIST", StaffDetails = "Expert in modern styles", DateJoined = DateTime.UtcNow },
                    new Staff { StaffName = "Bob Smith", JobCode = "MANAGER", StaffDetails = "Experienced manager", DateJoined = DateTime.UtcNow },
                    new Staff { StaffName = "Charlie Brown", JobCode = "ASSISTANT", StaffDetails = "Assists in daily operations", DateJoined = DateTime.UtcNow }
                };

                await context.Staff.AddRangeAsync(staff);
                await context.SaveChangesAsync();
            }

            if (!context.Clients.Any())
            {
                var clients = new List<ClientEntity>
                {
                    new ClientEntity { FirstName = "John", LastName = "Doe", AgeBandCode = "ADULT", GenderCode = "M", CellPhone = "1234567890", EmailAddress = "john.doe@example.com" },
                    new ClientEntity { FirstName = "Jane", LastName = "Doe", AgeBandCode = "YOUTH", GenderCode = "F", CellPhone = "0987654321", EmailAddress = "jane.doe@example.com" }
                };

                await context.Clients.AddRangeAsync(clients);
                await context.SaveChangesAsync();
            }

            if (!context.HairStyles.Any())
            {
                var hairStyles = new List<RefHairStyle>
                {
                    new RefHairStyle { HairStyleCode = "SHORT", HairStyleDescription = "Short Style" },
                    new RefHairStyle { HairStyleCode = "LONG", HairStyleDescription = "Long Style" },
                    new RefHairStyle { HairStyleCode = "CURLY", HairStyleDescription = "Curly Style" }
                };

                await context.HairStyles.AddRangeAsync(hairStyles);
                await context.SaveChangesAsync();
            }

            if (!context.Appointments.Any())
            {
                var appointments = new List<Appointment>
                {
                    new Appointment
                    {
                        ClientId = 1,
                        StaffId = 1,
                        AppointmentDate = DateTime.UtcNow.AddDays(1),
                        AppointmentTime = TimeSpan.FromHours(10),
                        HairStyleCode = "SHORT",
                        ColourUsed = "Black"
                    },
                    new Appointment
                    {
                        ClientId = 2,
                        StaffId = 2,
                        AppointmentDate = DateTime.UtcNow.AddDays(2),
                        AppointmentTime = TimeSpan.FromHours(14),
                        HairStyleCode = "CURLY",
                        ColourUsed = "Blonde"
                    }
                };

                await context.Appointments.AddRangeAsync(appointments);
                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { ProductCode = "SHAMPOO", ProductName = "Shampoo", ProductDescription = "Hair cleaning product", OtherDetails = "For all hair types" },
                    new Product { ProductCode = "CONDITIONER", ProductName = "Conditioner", ProductDescription = "Hair smoothing product", OtherDetails = "For dry hair" }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

            if (!context.PaymentDetails.Any())
            {
                var paymentDetails = new List<PaymentDetail>
                {
                    new PaymentDetail { ClientId = 1, DateOfPayment = DateTime.UtcNow, AmountDue = 100m, AmountPaid = 100m, Balance = 0m },
                    new PaymentDetail { ClientId = 2, DateOfPayment = DateTime.UtcNow, AmountDue = 150m, AmountPaid = 150m, Balance = 0m }
                };

                await context.PaymentDetails.AddRangeAsync(paymentDetails);
                await context.SaveChangesAsync();
            }
        }
    }
}
