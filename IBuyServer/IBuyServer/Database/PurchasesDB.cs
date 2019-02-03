using IBuyServer.Models;

namespace IBuyServer.Database
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PurchasesDB : DbContext
    {
        // Your context has been configured to use a 'PurchasesDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'IBuyServer.Database.PurchasesDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PurchasesDB' 
        // connection string in the application configuration file.
        public PurchasesDB()
            : base("name=PurchasesDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PurchasesDB>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PurchasesDB>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<PurchasedItem> PurchasedItems { get; set; }
        public virtual DbSet<PurchaseCategory> PurchaseCategories { get; set; }
    }

}