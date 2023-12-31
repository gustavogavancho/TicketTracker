﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketTracker.Shared.Entities;

public class Ticket
{
    public int Id { get; set; }
    public string TicketNumber { get; set; } = default!;
    public long? Nit { get; set; }
    public string Description { get; set; } = default!;
    public decimal? Amount { get; set; }
    public string ExpenseType { get; set; }
    public DateTime? DateIssued { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public byte[]? Image { get; set; }
    public string Owner { get; set; }
}

public class TicketConfig : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(x => x.TicketNumber).IsRequired();
        builder.Property(x => x.Nit).IsRequired();
        builder.Property(x => x.ExpenseType).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Amount).IsRequired();
        builder.Property(x => x.Owner).IsRequired();
        builder.Property(x => x.DateIssued).IsRequired();
    }
}