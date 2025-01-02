using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NonsUserTable.Entites;

namespace NonsUserTable.EntitysTypeConfig
{
    public class UserTypeConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(128);
            builder.Property(x => x.UserEmail)
                .IsRequired()
            .HasAnnotation("Regex", @"^(?=.*[A-Z])(?=.*[\W_])[a-zA-Z\d\W_]{9,16}$");
            builder.Property(x => x.UserPassword)
                .IsRequired()
            .HasAnnotation("Regex", @"^01[0|1|2]\d{8}$");
            builder.Property(x => x.UserAddress).IsRequired(false).HasMaxLength(256).HasDefaultValue("");
            builder.Property(x => x.UserPhone).IsRequired(false).HasMaxLength(128).HasDefaultValue("");

            configRelation(builder);
        }

        private void configRelation(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
