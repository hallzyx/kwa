using casokohler.crm.Domain.Models.Aggregates;
using casokohler.crm.Domain.Models.ValueObjects;
using casokohler.Shared.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace casokohler.crm.Infrastructure.Persistence.EFC.Configuration;

public static class ModelBuilderExtensions
{
    public static void ApplyPreSetConfiguration(this ModelBuilder builder)
    {
        builder.Entity<PreSet>().HasKey(c => c.Id);
        builder.Entity<PreSet>().Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Entity<PreSet>().Property(c => c.MiraCustomerId).HasConversion(
            p => p.Id.ToString(),
            value => new MiraCustomerId(Guid.Parse(value))
        ).IsRequired();
        builder.Entity<PreSet>().Property(c => c.ProductId).HasConversion(
            p => p.Id.ToString(),
            value => new ProductId(Guid.Parse(value))
        ).IsRequired();
        builder.Entity<PreSet>().Property(c => c.PreferredFlow).HasConversion(
            p=> p.Value,
            value => new WaterFlow(value)
            ).IsRequired();
        builder.Entity<PreSet>().Property(c => c.ShortName).IsRequired().HasMaxLength(60);
        builder.Entity<PreSet>().Property(c => c.PreferredTemperature).HasConversion(
            p => p.Value,
            value => new Temperature(value)
        ).IsRequired();
        builder.Entity<PreSet>().Property(c => c.PreferredDuration).HasConversion(
            p => p.Value,
            value => new Duration(value)
        ).IsRequired();
        builder.Entity<PreSet>().Property(c => c.PreferredFlow).HasConversion(
            p => p.Value,
            value => new WaterFlow(value)
        ).IsRequired();
        
    }

}