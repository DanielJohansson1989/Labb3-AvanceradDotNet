using Labb3Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_AvanceradDotNet.Data
{
    public class Labb3DbContext : DbContext
    {
        public Labb3DbContext(DbContextOptions<Labb3DbContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonalInterest> PersonalInterest { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                FirstName = "Daniel",
                LastName = "Johansson",
                Phone = "0703157383",
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                FirstName = "Sara",
                LastName = "Larsson",
                Phone = "0702456700",
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                FirstName = "Victor",
                LastName = "Svensson",
                Phone = "0765438976",
            });

            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 1,
                Title = "Skiing",
                Description = "Skiing is a popular winter sport that involves sliding down snow-covered slopes on long, narrow boards called skis attached to boots." +
                " It's not just about gliding down the mountain; it's a dynamic blend of athleticism, technique, and connection with nature. " +
                "Skiers use a combination of gravity, momentum, and their own muscle power to navigate various terrains, from gentle slopes to steep mountainsides",               
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 2,
                Title = "Chess",
                Description = "Chess is played by two opponents on a square board divided into 64 smaller squares of alternating colors, typically black and white." +
                " Each player starts with an identical set of 16 pieces: one king, one queen, two rooks, two knights, two bishops, and eight pawns. " +
                "The objective of chess is to checkmate your opponent's king.",
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 3,
                Title = "Surfing",
                Description = "Surfing is a water sport where individuals ride waves on a specially designed board, known as a surfboard, typically while standing up." +
                " Surfers paddle out into the ocean, waiting for the right wave to catch, and then use their skills to balance and maneuver on the moving water. " +
                "It's a dynamic and exhilarating activity that requires coordination, strength, and a deep connection with the ocean. " +
                "Surfers often describe the experience as a unique blend of adrenaline, tranquility, and freedom, making it a beloved pastime for enthusiasts around the world.",
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 4,
                Title = "Sailing",
                Description = "Sailing is a recreational or competitive activity that involves navigating a watercraft, typically a sailboat," +
                " across bodies of water using the power of the wind. Sailboats are equipped with sails, which harness the wind's force to propel the vessel forward." +
                " Sailors adjust the sails and steer the boat to catch the wind effectively and control its direction.",
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 5,
                Title = "Programming",
                Description = "Programming is the art and science of instructing computers to perform specific tasks by writing sets of instructions, known as code, in various programming languages." +
                " It involves problem-solving, logical thinking, and creativity to design, develop, and debug software applications, websites, and digital systems." +
                " Programmers use their expertise to automate processes, create innovative solutions, and shape the digital world we interact with every day.",
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 6,
                Title = "Fishing",
                Description = "Fishing is a recreational or commercial activity involving the pursuit and capture of aquatic life, typically fish, using various techniques such as angling," +
                " netting, or trapping. Anglers often employ rods, reels, and bait to lure fish, while commercial fishermen use specialized equipment like trawlers or longlines to catch fish in larger quantities." +
                " It's a timeless pastime enjoyed for relaxation, challenge, and sustenance, connecting individuals with nature and the bounty of the sea or freshwater environments.",
            });

            modelBuilder.Entity<PersonalInterest>().HasData(new PersonalInterest
            {
                PersonalInterestId = 1,
                PersonId = 1,
                InterestId = 1
            });
            modelBuilder.Entity<PersonalInterest>().HasData(new PersonalInterest
            {
                PersonalInterestId = 2,
                PersonId = 1,
                InterestId = 2
            });
            modelBuilder.Entity<PersonalInterest>().HasData(new PersonalInterest
            {
                PersonalInterestId = 3,
                PersonId = 2,
                InterestId = 3
            });
            modelBuilder.Entity<PersonalInterest>().HasData(new PersonalInterest
            {
                PersonalInterestId = 4,
                PersonId = 2,
                InterestId = 4
            });
            modelBuilder.Entity<PersonalInterest>().HasData(new PersonalInterest
            {
                PersonalInterestId = 5,
                PersonId = 3,
                InterestId = 5
            });
            modelBuilder.Entity<PersonalInterest>().HasData(new PersonalInterest
            {
                PersonalInterestId = 6,
                PersonId = 3,
                InterestId = 6
            });

            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 1,
                URL = "skidresor.se",
                PersonalInterestId = 1,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 2,
                URL = "skistar.com",
                PersonalInterestId = 1,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 3,
                URL = "chess.com",
                PersonalInterestId = 2,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 4,
                URL = "surfers.se",
                PersonalInterestId = 3,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 5,
                URL = "surfskolan.se",
                PersonalInterestId = 3,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 6,
                URL = "varbergssegelsallskap.se",
                PersonalInterestId = 4,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 7,
                URL = "codecademy.com",
                PersonalInterestId = 5,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 8,
                URL = "w3schools.com",
                PersonalInterestId = 5,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 9,
                URL = "swedenfishing.com",
                PersonalInterestId = 6,
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 10,
                URL = "fladenfishing.se",
                PersonalInterestId = 6,
            });
        }
    }
}
