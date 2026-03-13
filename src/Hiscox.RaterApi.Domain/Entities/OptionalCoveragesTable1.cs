// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class OptionalCoveragesTable1
{
    //Table from C7 to M65 in Optional_Coverages sheet.

    public required string Version { get; set; }
    public int Id { get; set; }
    public string? OptionalAdditionalCoverage { get; set; }
    public decimal ValueOfInsurance { get; set; }
    public decimal Premium { get; set; }
}
