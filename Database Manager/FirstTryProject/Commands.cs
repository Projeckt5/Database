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
                return db.Database.EnsureCreated();
            }
        }

        public static void SeedDatabase()
        {
            using (var db = new AppDbContext())
            {

                var udlejerBesked = new UdlejerBesked()
                {
                    ErBlevetAfvist = false,
                    ErBlevetSet = true,
                    Kommentar = "Det kan du godt, skriv på min Email",
                    UdlejetStartSlut = "2019;8,6;2019;8;10"
                };

                var lejerBesked = new LejerBesked()
                {
                    Kontaktinformation = "40091812",
                    ErBlevetSet = false,
                    Kommentar = "Må jeg leje din Toyota",
                    UdlejetStartSlut = "2019;8,6;2019;8;10"

                };

                var lejer = new Lejer()
                {
                    Kontaktinformation = "48781920",
                    Navn = "Kasten",
                    Kørekortnummer = "12938171",
                    Biler = new List<Bil>(),
                    LejerBeskeder = new List<LejerBesked>(),
                };

                var udlejer = new Udlejer
                {
                    Kontaktinformation = "MyEmail@Host.com",
                    Navn = "Svend Jokumsen",
                    Kørekortnummer = "2",
                    Registreringsnummer = "53210",
                    Biler = new List<Bil>(),
                    UdlejerBeskeder = new List<UdlejerBesked>(),
                };
                var bil = new Bil
                {
                    Nummerplade = "AB123421",
                    Billede = "asgmsa72u23p0i9isadfj2u2n7efmj",
                    Anhænger = false,
                    Tilstand = "Havde en ridse til i foreste højre dør",
                    Reserveret = false,
                    Vægt = 420,
                    Højde = 170,
                    Bredte = 230,
                    Type = "Varevogn",
                    Område = "Aarhus",
                    KanUdlejesDatoer = new List<KanUdlejesDato>(),
                    UdlejetDage = new List<UdlejetDag>(),
                };
                List<KanUdlejesDato> kanUdlejesDatoer = new List<KanUdlejesDato>();
                for (int i = 0; i < 20; i++)
                {
                    var kanUdlejesDato = new KanUdlejesDato()
                    {
                        Dato = new DateTime(2019, 4, 8+i),
                        Bil = bil,
                    };
                    kanUdlejesDatoer.Add(kanUdlejesDato);
                }
                List<UdlejetDag> udlejetDage = new List<UdlejetDag>();
                for (int i = 0; i < 5; i++)
                {
                    var udlejetDag = new UdlejetDag()
                    {
                        Dato = new DateTime(2019, 4, 8 + i),
                        Bil = bil,
                        Lejer = lejer,
                    };

                    udlejetDage.Add(udlejetDag);
                }

                udlejerBesked.Bil = bil;
                udlejerBesked.Udlejer = udlejer;

                lejerBesked.Bil = bil;
                lejerBesked.Lejer = lejer;

                lejer.Biler.Add(bil);
                lejer.LejerBeskeder.Add(lejerBesked);

                udlejer.Biler.Add(bil);
                udlejer.UdlejerBeskeder.Add(udlejerBesked);

                bil.Udlejer = udlejer;
                bil.Lejer = lejer;



                foreach (var VARIABLE in udlejetDage)
                {
                    bil.UdlejetDage.Add(VARIABLE);
                    db.UdlejedeDage.Add(VARIABLE);
                }
                foreach (var VARIABLE in kanUdlejesDatoer)
                {
                    bil.KanUdlejesDatoer.Add(VARIABLE);
                    db.KanUdlejesDatoer.Add(VARIABLE);
                }
                db.UdlejerBeskeder.Add(udlejerBesked);
                db.LejerBeskeder.Add(lejerBesked);
                db.Lejere.Add(lejer);
                db.Udlejere.Add(udlejer);
                db.Biler.Add(bil);


                db.SaveChanges();
            }
        }

        internal static void SeedDatabaseWrong()
        {
            using (var db = new AppDbContext())
            {
                var bil = new Bil
                {
                    Nummerplade = "AB123421",
                    Billede = "asgmsa72u23p0i9isadfj2u2n7efmj",
                    Anhænger = false,
                    Tilstand = "Havde en ridse til i foreste højre dør",
                    Reserveret = false,
                    Vægt = 420,
                    Højde = 170,
                    Bredte = 230,
                    Type = "Varevogn",
                    Område = "Aarhus",
                };
                db.Biler.Add(bil);

                db.SaveChanges();

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
                foreach (var VARIABLE in db.Biler)
                {
                    db.Biler.Remove(VARIABLE);
                }

                foreach (var VARIABLE in db.KanUdlejesDatoer)
                {
                    db.KanUdlejesDatoer.Remove(VARIABLE);
                }

                foreach (var VARIABLE in db.Lejere)
                {
                    db.Lejere.Remove(VARIABLE);
                }

                foreach (var VARIABLE in db.LejerBeskeder)
                {
                    db.LejerBeskeder.Remove(VARIABLE);
                }

                foreach (var VARIABLE in db.Udlejere)
                {
                    db.Udlejere.Remove(VARIABLE);
                }

                foreach (var VARIABLE in db.UdlejerBeskeder)
                {
                    db.UdlejerBeskeder.Remove(VARIABLE);
                }

                foreach (var VARIABLE in db.UdlejedeDage)
                {
                    db.UdlejedeDage.Remove(VARIABLE);
                }


                db.SaveChanges();

            }
        }
    }
}
