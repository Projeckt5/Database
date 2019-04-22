using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using FirstTryProject.Data;
using FirstTryProject.Model;
using FirstTryProject.Migrations;
using Microsoft.EntityFrameworkCore.Internal;

namespace FirstTryProject
{
    class Commands
    {
        public static bool CreateDatabase()
        {
            using (var db = new AppDbContext())
            {
#if DEBUG
                db.Database.EnsureDeleted();
#endif


                return db.Database.EnsureCreated();
            }
        }

        public static void SeedDatabase()
        {
            using (var db = new AppDbContext())
            {

                var udlejerBesked = new CarOwnerMessage()
                {
                    HaveBeenRejected = false,
                    HaveBeenSeen = true,
                    Commentary = "Det kan du godt, skriv på min Email",
                    RentedFromTo = "2019;8,6;2019;8;10"
                };

                var lejerBesked = new CarRenterMessage()
                {
                    ContactInfo = "40091812",
                    HaveBeenSeen = false,
                    Commentary = "Må jeg leje din Toyota",
                    RentedFromTo = "2019;8,6;2019;8;10"

                };

                var lejer = new CarRenter()
                {
                    ContactInfo = "48781920",
                    Name = "Kasten",
                    DrivingLicenceNumber = "12938171",
                    Cars = new List<Car>(),
                    CarRenterMessages = new List<CarRenterMessage>(),
                };

                var udlejer = new CarOwner
                {
                    KontactInfo = "MyEmail@Host.com",
                    Name = "Svend Jokumsen",
                    DrivingLicenceNumber = "2",
                    CarRegistrationNumber = "53210",
                    Cars = new List<Car>(),
                    CarOwnerMessages = new List<CarOwnerMessage>(),
                };
                var bil = new Car
                {
                    LicenceplateNumber = "AB123421",
                    Picture = "asgmsa72u23p0i9isadfj2u2n7efmj",
                    HaveTowbar = false,
                    Condition = "Havde en ridse til i foreste højre dør",
                    IsReserved = false,
                    Weight = 420,
                    Hight = 170,
                    Width = 230,
                    Type = "Varevogn",
                    Area = "Aarhus",
                    PossibleToRentDays = new List<PossibleToRentDay>(),
                    DaysThatIsRented = new List<DayThatIsRented>(),
                };
                List<PossibleToRentDay> PossibleToRentDayer = new List<PossibleToRentDay>();
                for (int i = 0; i < 20; i++)
                { 
                    var PossibleToRentDay = new PossibleToRentDay()
                    {
                        Date = new DateTime(2019, 4, 8+i),
                        Car = bil,
                    };
                    PossibleToRentDayer.Add(PossibleToRentDay);
                }
                List<DayThatIsRented> udlejetDage = new List<DayThatIsRented>();
                for (int i = 0; i < 5; i++)
                {
                    var udlejetDag = new DayThatIsRented()
                    {
                        Date = new DateTime(2019, 4, 8 + i),
                        Car = bil,
                        CarRenter = lejer,
                    };

                    udlejetDage.Add(udlejetDag);
                }

                udlejerBesked.Car = bil;
                udlejerBesked.CarOwner = udlejer;

                lejerBesked.Car = bil;
                lejerBesked.CarRenter = lejer;

                lejer.Cars.Add(bil);
                lejer.CarRenterMessages.Add(lejerBesked);

                udlejer.Cars.Add(bil);
                udlejer.CarOwnerMessages.Add(udlejerBesked);

                bil.CarOwner = udlejer;
                bil.CarRenter = lejer;



                foreach (var VARIABLE in udlejetDage)
                {
                    
                    bil.DaysThatIsRented.Add(VARIABLE);
                    //db.AddDayThatIsRented(VARIABLE);
                }
                foreach (var VARIABLE in PossibleToRentDayer)
                {
                    bil.PossibleToRentDays.Add(VARIABLE);
                    //db.AddPossibleToRentDay(VARIABLE);
                }

                //db.AddCarOwnerMessage(udlejerBesked);
                //db.AddCarRenterMessage(lejerBesked);
                //db.AddCarRenter(lejer);
                //db.AddCarOwner(udlejer);
                //db.AddCar(bil);

            }
        }

        internal static void SeedDatabaseWrong()
        {
            using (var db = new AppDbContext())
            {
                var bil = new Car
                {
                    LicenceplateNumber = "AB123421",
                    Picture = "asgmsa72u23p0i9isadfj2u2n7efmj",
                    HaveTowbar = false,
                    Condition = "Havde en ridse til i foreste højre dør",
                    IsReserved = false,
                    Weight = 420,
                    Hight = 170,
                    Width = 230,
                    Type = "Varevogn",
                    Area = "Aarhus",
                };
                //db.AddCar(bil);


            }
        }


        public static bool PullDummyData()
        {
            return true;
        }


        public static void EmptyDatabase()
        {
            using (var db = new AppDbContext())
            {
                //foreach (var VARIABLE in db.Cars)
                {
                    //db.Cars.Remove(VARIABLE);
                }

                //foreach (var VARIABLE in db.PossibleToRentDays)
                {
                    //db.PossibleToRentDays.Remove(VARIABLE);
                }

                //foreach (var VARIABLE in db.CarRenters)
                {
                    //db.CarRenters.Remove(VARIABLE);
                }

                //foreach (var VARIABLE in db.CarRenterMessages)
                {
                    //db.CarRenterMessages.Remove(VARIABLE);
                }

                //foreach (var VARIABLE in db.CarOwners)
                {
                    //db.CarOwners.Remove(VARIABLE);
                }

                //foreach (var VARIABLE in db.CarOwnerMessages)
                {
                    //db.CarOwnerMessages.Remove(VARIABLE);
                }

                //foreach (var VARIABLE in db.DaysThatIsRented)
                {
                    //db.DaysThatIsRented.Remove(VARIABLE);
                }


                db.SaveChanges();

            }
        }
    }
}
