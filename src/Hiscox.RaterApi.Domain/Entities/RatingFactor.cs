// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class RatingFactor
{
    public decimal UWSelectedCreditDebit { get; set; }
    public decimal TechnicalPremium { get; set; }
    public short RiskTier { get; set; }
    public string RiskTierCorRange { get; set; } = string.Empty;
    public decimal RecommendedCor { get; set; }
    public string RecommendedConcern { get; set; } = string.Empty;
    public int ClaimHistoryQuestions { get; set; }
    public RatingFactorSectionDetails? ClaimHistoryRatingFactorDetails { get; set; }
    public Dictionary<int, bool?>? RiskProfileQuestions { get; set; }
    public RatingFactorSectionDetails? RiskProfileRatingFactorDetails { get; set; }
    public int ComplexityOfRiskQuestions { get; set; }
    public RatingFactorSectionDetails? ComplexityOfRiskRatingFactorDetails { get; set; }
}
