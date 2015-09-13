namespace Phonebook.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class PhonebookEntities : DbContext
    {
        // Your context has been configured to use a 'PhonebookEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Phonebook.Data.PhonebookEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhonebookEntities' 
        // connection string in the application configuration file.
        public PhonebookEntities()
            : base("name=PhonebookEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookEntities, Configuration>());
        }

        public virtual IDbSet<Contact> Contacts { get; set; }

        public virtual IDbSet<Email> Emails { get; set; }

        public virtual IDbSet<Phone> Phones { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}