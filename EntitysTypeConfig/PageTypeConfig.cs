using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NonsUserTable.Entites;

namespace NonsUserTable.EntitysTypeConfig
{
    public class PageTypeConfig : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("Pages");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired(true);
            builder.Property(x => x.PageUrl).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.PageNumber).IsRequired(true);

            builder.HasIndex(x => new { x.Name, x.PageNumber }).IsUnique(); //made by BasrRepo overriding => but use this for more ensurring in db

            configRelations(builder);
        }

        private void configRelations(EntityTypeBuilder<Page> builder)
        {
            builder.HasMany(x => x.RolePages)
                .WithOne(x => x.Page)
                .HasForeignKey(x => x.PageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
