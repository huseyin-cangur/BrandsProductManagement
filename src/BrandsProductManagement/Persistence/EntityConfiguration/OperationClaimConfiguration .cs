using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);
        
        builder.HasData(GetSeeds());


    }

    private static IEnumerable<OperationClaim> GetSeeds()
    {
        DateTime createdDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc);

        return new List<OperationClaim>
    {
        new OperationClaim
        {
            Id = Guid.Parse("5bd69544-46b6-4513-9fc8-6e4d6a197792"),
            Name = "Admin",
            CreatedDate = createdDate
        },
        new OperationClaim
        {
            Id = Guid.Parse("2081e9a9-0d1f-4535-a5e5-28f9d71da9d0"),
            Name = "Category.User",
            CreatedDate = createdDate
        },
        new OperationClaim
        {
            Id = Guid.Parse("9b893c6b-7abf-4649-a93f-271ce8515910"),
            Name = "Product.User",
            CreatedDate = createdDate
        },
        new OperationClaim
        {
            Id = Guid.Parse("e1e1554e-851b-4e08-8d27-0d1dbf2dc6fc"),
            Name = "Standard.User",
            CreatedDate = createdDate
        }
    };
    }




}