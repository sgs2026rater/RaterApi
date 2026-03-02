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
    public List<int>? ClaimHistoryQuestions { get; set; }
    public List<RatingFactorSectionDetails>? ClaimHistoryRatingFactorDetails { get; set; }
    public List<int>? RiskProfileQuestions { get; set; }
    public List<RatingFactorSectionDetails>? RiskProfileRatingFactorDetails { get; set; }
    public int ComplexityOfRiskQuestions { get; set; }
    public List<RatingFactorSectionDetails>? ComplexityOfRiskRatingFactorDetails { get; set; }
}
