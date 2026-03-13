// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class ProjectTypeFactor
{

    public required string Version { get; set; }
    public int Id { get; set; }
    public string ProjectType { get; set; } = string.Empty;
    public decimal Factor { get; set; }
}
