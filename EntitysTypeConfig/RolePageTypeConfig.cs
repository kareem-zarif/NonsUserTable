using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NonsUserTable.Entites;
using NonsUserTable.Enums;

namespace NonsUserTable.EntitysTypeConfig
{
    public class RolePageTypeConfig : IEntityTypeConfiguration<RolePage>
    {
        public void Configure(EntityTypeBuilder<RolePage> builder)
        {
            builder.ToTable("RolePages");
            builder.HasKey(x => new
            {
                x.RoleId,
                x.PageId
            });

            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.AccessType).HasConversion(new EnumToStringConverter<AccessTypeEnum>());

            configRelations(builder);

        }

        private void configRelations(EntityTypeBuilder<RolePage> builder)
        {
            builder.HasOne(x => x.Page)
                .WithMany(x => x.RolePages)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.RolePages)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
