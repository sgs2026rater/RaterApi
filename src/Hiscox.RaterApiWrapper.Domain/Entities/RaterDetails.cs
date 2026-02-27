// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record RaterDetails
{
    public PolicyDetails? Profile { get; set; }
    public decimal Revenue {  get; set; }
    public decimal RevenueAdjusted { get; set; }
    public List<IndustryClassification>? IndustryClassifications { get; set; }
    public IndustryClassification? PrimaryIndustryClassification { get; set; }

    #region Additional UW(Tab4)

    public bool TangibleGoodsOrProductOwnerFlag { get; set; }//This is to control if Q3 is visible.
    public bool ProjectTier4Ans { get; set; } = false;
    public bool ProjectTier5Ans { get; set; } = false; 
    public bool UITrigDesignprof3MRevFlag{ get; set; }//refer ui_control B195 value 
    public bool LimitationOfLiabilityQuestionFlag { get; set; }
    public bool UITrigAnEFlag { get; set; }

    #endregion Additional UW(Tab4)

}
