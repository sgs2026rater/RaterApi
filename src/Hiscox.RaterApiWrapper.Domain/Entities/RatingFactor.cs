// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class RatingFactor
{
    public decimal UWSelectedCreditDebit { get; set; }
    public decimal TechnicalPremium { get; set; }
    public short RiskTier { get; set; }
    public string RiskTierCorRange { get; set; } = string.Empty;
    public decimal RecommendedCor { get; set; }
    public string RecommendedConcern { get; set; } = string.Empty;
    public List<int>? ClaimHistoryQuestions { get; set; }
    public List<RatingFactorSectionDetails>? ClaimHistoryRatingFactorDetails { get; set; }
    public Dictionary<int, bool?>? RiskProfileQuestions { get; set; }
    public List<RatingFactorSectionDetails>? RiskProfileRatingFactorDetails { get; set; }
    public int ComplexityOfRiskQuestions { get; set; }
    public List<RatingFactorSectionDetails>? ComplexityOfRiskRatingFactorDetails { get; set; }
}
