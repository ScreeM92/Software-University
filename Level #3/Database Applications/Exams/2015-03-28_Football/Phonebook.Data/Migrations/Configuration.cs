namespace Phonebook.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Phonebook.Data.PhonebookEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "Phonebook.Data.PhonebookEntities";
        }

        protected override void Seed(Phonebook.Data.PhonebookEntities context)
        {
            if (!context.Contacts.Any())
            {
                context.Contacts.AddOrUpdate(
                    new Contact
                    {
                        Name = "Peter Ivanov",
                        Position = "CTO",
                        Company = "Smart Ideas",
                        Emails =
                        {
                            new Email {EmailAddress = "peter@gmail.com"},
                            new Email {EmailAddress = "peter_ivanov@yahoo.com"}
                        },
                        Phones =
                        {
                            new Phone {PhoneNumber = "+359 2 22 22 22"},
                            new Phone {PhoneNumber = "+359 88 77 88 99"}
                        },
                        Url = "http://blog.peter.com",
                        Notes = "Friend from school"
                    },
                    new Contact
                    {
                        Name = "Maria",
                        Phones =
                        {
                            new Phone {PhoneNumber = "+359 22 33 44 55"}
                        }
                    },
                    new Contact
                    {
                        Name = "Angie Stanton",
                        Emails =
                        {
                            new Email {EmailAddress = "info@angiestanton.com"}
                        },
                        Url = "http://angiestanton.com"
                    });
            }
        }
    }
}