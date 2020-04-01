using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Models
{
    public partial class DBContextUser : DbContext
    {
        public DBContextUser(DbContextOptions<DBContextUser> options) : base(options)
        {

        }
        public virtual DbSet<TB_EB_EMPL_DEP> TB_EB_EMPL_DEP { get; set; }
        public virtual DbSet<TB_EB_GROUP> TB_EB_GROUP { get; set; }
        public virtual DbSet<TB_EB_USER> TB_EB_USER { get; set; }
        public virtual DbSet<VW_USER_Dept> VW_USER_Dept { get; set; }
        public virtual DbSet<TB_EB_DOMAIN> TB_EB_DOMAIN { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TB_EB_USER>()
                .HasKey(k => new {k.USER_GUID});
            builder.Entity<TB_EB_EMPL_DEP>()
                .HasKey(k => new {k.USER_GUID, k.GROUP_ID});
            builder.Entity<TB_EB_GROUP>()
                .HasKey(k => new {k.GROUP_ID});
            builder.Entity<VW_USER_Dept>()
                .HasNoKey();
            builder.Entity<TB_EB_DOMAIN>()
                .HasKey(k => new {k.DOMAIN_GUID});
        }
    }
}