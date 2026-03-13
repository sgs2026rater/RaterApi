// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class OptCovTable1
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public required string OptionalCoverage { get; set; }//Column B in OptCov Sheet
    public required string ApplicableToCoverageOrGTC { get; set; }//Column E in OptCov Sheet
    public required string ApplicableToFormOrEndorsement { get; set; }//Column Q in OptCov Sheet
    public required string ENumber { get; set; }//Column R in OptCov Sheet

}
