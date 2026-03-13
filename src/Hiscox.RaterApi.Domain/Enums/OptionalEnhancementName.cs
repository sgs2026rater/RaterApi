// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Enums;

public enum OptionalEnhancementName
{
    CrisisManagement,
    MediaActivities,
    ContractorsPollution_ClaimsMade,
    ContractorsPollution_Occ,
    DefenseOutsideLimits,
    RectificationExpenses,
    AggregateLimitEndorsement,
    FirstDollarDefense,
    WaiverOfSubrogation,
    WorldwideCoverageTerritory,
    AdditionalInsured,
    BodilyInjury,
    PropertyDamage,
    PersonalAndAdvertisingInjury,
    ThirdPartyDiscrimination,
    ProtectiveIdemnity,
    PollutantsInTransit,
    NonOwnedDisposalSite,
    FailureToDisclosePollutants,
    PollutionLiability,
    TechnologyCoverageExtension,
    NetworkSecurityAndPrivacy,
    //The above values are from OptCov sheet(Column B67 and Q67 onwards) for Default perils which is displayed in the Dropdown under Other Coverage.
    //TODO:More values to be added from OptCov sheet(Column J) or Databse table need to be created for this.
}

