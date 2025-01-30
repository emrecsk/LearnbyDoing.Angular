using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskApp.Core.Enums;
using TaskApp.Core.Models;

namespace TaskApp.Infrastructure.Data.Configurations
{
    class VocationConfiguration : IEntityTypeConfiguration<Vocation>
    {
        public void Configure(EntityTypeBuilder<Vocation> builder)
        {
            builder.Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(v => v.Status)
                .IsRequired()
                .HasDefaultValue(Status.Pending);
        }
    }
}
