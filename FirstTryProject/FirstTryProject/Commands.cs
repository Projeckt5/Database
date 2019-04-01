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

namespace FirstTryProject
{
    class Commands
    {
        public static void CreateDatabase()
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        public static bool DestroyDatabase()
        {
            using (var db = new AppDbContext())
            {
                return db.Database.EnsureDeleted();
            }
        }
    }
}
