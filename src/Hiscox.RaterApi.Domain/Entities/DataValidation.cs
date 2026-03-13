// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class DataValidation // Excel location - OptCov!AW7:AX58
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public required string Peril { get; set; }  // Excel Column AW
    public required string DataValidationToUse { get; set; }    // Excel Column AX
}