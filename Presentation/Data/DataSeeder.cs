using Business.Managers;
using Data;
using Data.Other;
using Data.Models;
using Presentation.Interfaces;
using Data.Models.Equipment;

namespace Presentation.Data
{
    public class DataSeeder : IDataSeeder
    {
        public RentalContext Context { get; }

        public DataSeeder(RentalContext context)
        {
            Context = context;
        }

        public void SeedData()
        {
            SeedCustomers();
            SeedShop();
        }

        private void SeedCustomers()
        {
            var manager = new CustomerManager(Context);
            var customer = new Customer
            {
                FirstName = "Petro",
                LastName = "Petrenko",
                PhoneNumber = "+380682777777",
                Tariff = Tariff.Preferential,
            };
            customer.Roles.Add(Role.Admin);
            manager.Add(customer, "admin111");
            customer = new Customer
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "+380682555555",
                Tariff = Tariff.Standard
            };
            manager.Add(customer, "user1111");
        }

        private void SeedShop()
        {
            var brand = new Make { Name = "SKIF" };
            var shop = Context.Shop;
            shop.ConcreteMixers = new List<ConcreteMixer>
            {
                new ConcreteMixer
                {
                    Make = brand,
                    Model = "BSM-250",
                    PricePerDay = 350,
                    Volume = 250
                },
                new ConcreteMixer
                {
                    Make = brand,
                    Model = "BSM-200P",
                    PricePerDay = 300,
                    Volume = 200
                },
            };
            brand = new Make { Name = "Forte" };
            shop.ConcreteMixers.Add(new ConcreteMixer
            {
                Make = brand,
                Model = "EW7150",
                PricePerDay = 250,
                Volume = 150
            });
            brand = new Make { Name = "Road" };
            shop.RoadRollerCars = new List<RoadRollerCar>
            {
                new RoadRollerCar
                {
                    Make = brand,
                    Model = "1700",
                    PricePerDay = 1600,
                    MaxSpeed = 8,
                    Roller = new Roller
                    {
                        Diameter = 560,
                        Width = 900
                    }
                },
                new RoadRollerCar
                {
                    Make = brand,
                    Model = "880",
                    PricePerDay = 1200,
                    MaxSpeed = 3.6,
                    Roller = new Roller
                    {
                        Diameter = 350,
                        Width = 680
                    }
                }
            };
            brand = new Make { Name = "BOSCH" };
            shop.ScrewDrivers = new List<ScrewDriver>
            {
                new ScrewDriver
                {
                    Make = brand,
                    Model = "13 RE",
                    PricePerDay = 200,
                    MaxRotationSpeed = 2800,
                    Power = 600
                },
                new ScrewDriver
                {
                    Make = brand,
                    Model = "16 RE",
                    PricePerDay = 190,
                    MaxRotationSpeed = 2800,
                    Power = 750
                }
            };
            brand = new Make { Name = "cayken" };
            shop.ScrewDrivers.Add(new ScrewDriver
            {
                Make = brand,
                Model = "17/80",
                PricePerDay = 350,
                MaxRotationSpeed = 3900,
                Power = 1900
            });
        }
    }
}
