using Microsoft.EntityFrameworkCore;
using BE_CRUDPhonebook.Models;

namespace BE_CRUDPhonebook.Data
{ 
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Phonebook> Phonebooks => Set<Phonebook>();

       // public object Phonebook { get; internal set; }
    }
}
