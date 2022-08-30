using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Models.Models;

namespace TestEntityFrameWorkCore.Data.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }


        // One To Many Relationship Between Book and Author
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
            .HasOne(a => a.Author)
            .WithMany(ba => ba.Book_Authors)
            .HasForeignKey(ai => ai.AuthorId);
                
        }


       public DbSet<Book> Books { get; set; }
       public DbSet<Author> Authors { get; set; }
       public DbSet<Publisher> Publishers { get; set; }
       public DbSet<Book_Author> Books_Authors { get; set; }

    }
}
