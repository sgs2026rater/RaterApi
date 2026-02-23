// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Presentation.Api.Contracts;

public class RaterResponse
{
    public required string RaterVersion { get; set; }
    public DateTime RaterVersionDate { get; set; }
    public decimal OccuranceLimit { get; set; }
    public decimal AggregateLimit { get; set; }
    public decimal Retention { get; set; }
    public decimal ExpiringPremium { get; set; }
    public decimal RenewalPremium { get; set; }
    public decimal RevenueChange { get; set; }
    public decimal PremiumChange { get; set; }
    public decimal RateChange { get; set; }
}

