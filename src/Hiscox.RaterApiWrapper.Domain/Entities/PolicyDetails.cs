// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class PolicyDetails
{
    public required string Version { get; set; }
    public required int Id { get; set; }
    public string PUID { get; set; } = string.Empty;
    public string PolicyNo { get; set; } = string.Empty;
    public string NameDescr { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
    [NotMapped]
    public string MetroArea { get; set; } = string.Empty;
    [NotMapped]
    public decimal Revenue { get; set; }
    [NotMapped]
    public bool AlternativeExposureBase { get; set; }
    [NotMapped]
    public string UnderWriter { get; set; } = string.Empty;
    [NotMapped]
    public BusinessType BusinessType { get; set; }
    public DateTime TimestampEffectivePolicy { get; set; }
    public DateTime TimestampExpirationPolicy { get; set; }
    public decimal ExposureBase { get; set; }
    public decimal EO_GWP { get; set; }
    public decimal EO_Retention { get; set; }
    public decimal EO_OccLimit { get; set; }
    public decimal EO_AggLimit { get; set; }
    public decimal EO_2_GWP { get; set; }
    public decimal EO_2_Retention { get; set; }
    public decimal EO_2_OccLimit { get; set; }
    public decimal EO_2_AggLimit { get; set; }
    public decimal GL_GWP { get; set; }
    public decimal GL_Retention { get; set; }
    public decimal GL_OccLimit { get; set; }
    public decimal GL_AggLimit { get; set; }
    public decimal Cyb_GWP { get; set; }
    public decimal Cyb_Retention { get; set; }
    public decimal Cyb_OccLimit { get; set; }
    public decimal Cyb_AggLimit { get; set; }
    [NotMapped]
    public bool EO { get; set; }
    [NotMapped]
    public bool GL { get; set; }
    [NotMapped]
    public bool Cyber { get; set; }
    [NotMapped]
    public bool Crime { get; set; }

}
