﻿using ShopDatabaseAdvanced.Model;
using ShopDatabaseAdvanced.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced.ShopAdvancedDbContext
{
	class AdvancedShopDatabaseContext : DbContext
	{
		public AdvancedShopDatabaseContext() : base("AdvancedShopDatabase")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<AdvancedShopDatabaseContext, Migrations.Configuration>());
		}

		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

		public DbSet<Food> Foods { get; set; }
        public DbSet<Client> Clients{ get;  set; }
    }
}
