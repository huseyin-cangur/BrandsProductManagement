

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description");

            builder.HasMany(b => b.Products);

            // builder.HasIndex(indexExpression: b => b.Name, name: "UK_Category_Name").IsUnique();


            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }
}