using JWTAuthLesson.Entities;
using JWTAuthLesson.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWTAuthLesson.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(TableNames.Roles);                                                                              

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Permissions)
                .WithMany();

            builder.HasMany(x => x.Members) 
                .WithMany();

            // rollar massivi qaytadi
            // buni davom ettiramiz
            //builder.HasData(Role.GetValues());
        }
    }
}
