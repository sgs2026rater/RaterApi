// Copyright (c) Hiscox Insurance. All rights reserved.

using System.Runtime.CompilerServices;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class GeographicMod
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public required string Zip { get; set; }
    public required string MsaNumber { get; set; }
    public required string State { get; set; }
    public required string Fips { get; set; }
    public required string CountyNumber { get; set; }
    public required string MsaName { get; set; }
    public required string Name { get; set; }
    public required decimal Tech { get; set; }
    public required decimal Ahc { get; set; }
    public required decimal Mpl { get; set; }
    public required decimal AE { get; set; }
    public required decimal GlPremOps { get; set; }
    public required decimal GlProducts { get; set; }
    public required decimal Med { get; set; }
    public required decimal Cyber { get; set; }

}
