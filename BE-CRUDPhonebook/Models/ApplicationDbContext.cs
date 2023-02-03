using Microsoft.EntityFrameworkCore;


namespace BE_CRUDPhonebook.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Phonebook> Phonebook { get; set; }
    }
}
