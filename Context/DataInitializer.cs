using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using nc2.Models;
using System.Reflection.Metadata;

namespace nc2.Context
{
    public static class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<User>().HasMany(a => a.notebooks).WithMany(a => a.users)
            //        .UsingEntity<NotebookUser>(
            //    l => l.HasOne<Notebook>().WithMany().HasForeignKey(e => e.notebooksId),
            //    r => r.HasOne<User>().WithMany().HasForeignKey(e => e.usersId));

            //    modelBuilder.Entity<Notebook>()
            //.HasMany(e => e.notes)
            //.WithOne(e => e.Notebook)
            //.HasForeignKey(e => e.notebookId)
            //.IsRequired();

            //modelBuilder.Entity<User>().HasData(
            //     new User()
            //     {
            //         id = 1,
            //         uid = "",
            //         displayName = "merve",
            //         createdDate = DateTime.Now,
            //         modifiedDate = DateTime.Now,
            //         email = "merve@merve.com",

            //     });
           

            //modelBuilder.Entity<Note>().HasData(
            //    new Note()
            //    {
            //        id = 1,
            //        createdDate = DateTime.Now,
            //        modifiedDate = DateTime.Now,
            //        notebookId=1,
            //        textNote="Sample"
            //    });



        }
    }
}
