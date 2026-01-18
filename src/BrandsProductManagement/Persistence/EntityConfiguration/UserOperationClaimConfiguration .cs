using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(uoc => uoc.Id);

        builder.Property(uoc => uoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(uoc => uoc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(uoc => uoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(uoc => uoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(uoc => uoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(uoc => uoc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(uoc => !uoc.DeletedDate.HasValue);

        builder.HasOne(uoc => uoc.User);
        builder.HasOne(uoc => uoc.OperationClaim);

        builder.HasData(getSeeds());


    }

    private IEnumerable<UserOperationClaim> getSeeds()
    {
        List<UserOperationClaim> userOperationClaims = new();


        UserOperationClaim adminClaim =
            new()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse("7997e2a4-85bc-4928-8bce-88055f5f0569"),
                OperationClaimId = Guid.Parse("5bd69544-46b6-4513-9fc8-6e4d6a197792")
            };
        userOperationClaims.Add(adminClaim);


        return userOperationClaims.ToArray();
    }



}