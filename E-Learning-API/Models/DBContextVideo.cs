using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Models
{
    public partial class DBContextVideo : DbContext
    {
        public DBContextVideo(DbContextOptions<DBContextVideo> options) : base(options)
        {

        }        
        public virtual DbSet<TB_EL_System_Role> TB_EL_System_Role { get; set; }
        public virtual DbSet<TB_EL_Video> TB_EL_Video { get; set; }
        public virtual DbSet<TB_EL_View_Record> TB_EL_View_Record { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TB_EL_System_Role>()
                .HasKey(k => new {k.SID});
            builder.Entity<TB_EL_Video>()
                .HasKey(k => new {k.SID});
            builder.Entity<TB_EL_View_Record>()
                .HasKey(k => new {k.SID});
        }
    }
}