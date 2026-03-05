// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IStaticDatasets
{
    Dictionary<string, GeographicMod>? GeographiModDictionary { get; set; }
    List<IndustrySector>? IndustrySectorList { get; set; }
    List<IndustrySpecialty>? IndustrySpecialtyList { get; set; }
    List<IndustrySubSector>? IndustrySubSectorList { get; set; }
    List<PolicyDetails>? PolicyDetailsList { get; set; }
    List<RatingFactorMaster>? RatingFactorsList { get; set; }

    Task LoadStaticDatasets();
}