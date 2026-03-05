// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data;

public class StaticDatasets : IStaticDatasets
{
    private readonly ILogger _logger;

    public StaticDatasets(ILogger<StaticDatasets> logger)
    {
        _logger = logger;
    }

    public List<IndustrySector>? IndustrySectorList { get; set; }
    public List<IndustrySubSector>? IndustrySubSectorList { get; set; }
    public List<IndustrySpecialty>? IndustrySpecialtyList { get; set; }
    public Dictionary<string, GeographicMod>? GeographiModDictionary { get; set; }
    public List<RatingFactorMaster>? RatingFactorsList { get; set; }
    public List<PolicyDetails>? PolicyDetailsList { get; set; }

    public async Task LoadStaticDatasets()
    {
        LoadIndustrySectors();
        LoadIndustrySubSectors();
        LoadIndustrySpecialties();
        await LoadGeographicMods();
        LoadPolicyDetails();
        await LoadRatingFactors();
    }

    private void LoadIndustrySectors()
    {
        this.IndustrySectorList = new();
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 1, Name = "Alternative Health & Wellness" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 2, Name = "Consultants" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 3, Name = "Contractors" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 4, Name = "Creative Services" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 5, Name = "Design Professionals" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 6, Name = "Financial Services" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 7, Name = "Healthcare Residential Services" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 8, Name = "Miscellaneous" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 9, Name = "Outpatient Healthcare" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 10, Name = "Real Estate" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 11, Name = "Security Services" });
        this.IndustrySectorList.Add(new IndustrySector() { Version = "v2.0.101", Id = 12, Name = "Technology" });
    }

    private void LoadIndustrySubSectors()
    {
        this.IndustrySubSectorList = new();
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 1, IndustrySectorId = 1, Name = "Acupuncture" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 2, IndustrySectorId = 1, Name = "Athletic Trainers" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 3, IndustrySectorId = 1, Name = "Biofeedback " });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 4, IndustrySectorId = 1, Name = "Chiropractor" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 5, IndustrySectorId = 1, Name = "Cryotherapy" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 6, IndustrySectorId = 1, Name = "Doula" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 7, IndustrySectorId = 1, Name = "Holistic healthcare " });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 8, IndustrySectorId = 1, Name = "Naturopathic Physician" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 9, IndustrySectorId = 1, Name = "Personal Trainers/ Yoga" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 10, IndustrySectorId = 1, Name = "Spa" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 11, IndustrySectorId = 1, Name = "Tattoo/body piercing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 12, IndustrySectorId = 2, Name = "A&E Technical Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 13, IndustrySectorId = 2, Name = "Environmental Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 14, IndustrySectorId = 2, Name = "Financial Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 15, IndustrySectorId = 2, Name = "Management Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 16, IndustrySectorId = 2, Name = "Media / Branding Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 17, IndustrySectorId = 2, Name = "Medical Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 18, IndustrySectorId = 2, Name = "Other Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 19, IndustrySectorId = 2, Name = "Real Estate Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 20, IndustrySectorId = 2, Name = "Safety Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 21, IndustrySectorId = 2, Name = "Technology Consulting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 22, IndustrySectorId = 3, Name = "General Contractors" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 23, IndustrySectorId = 3, Name = "Manufacturing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 24, IndustrySectorId = 3, Name = "Subcontractors" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 25, IndustrySectorId = 4, Name = "Advertising" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 26, IndustrySectorId = 4, Name = "Graphic Design Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 27, IndustrySectorId = 4, Name = "Marketing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 28, IndustrySectorId = 4, Name = "Photographer Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 29, IndustrySectorId = 4, Name = "Post Production" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 30, IndustrySectorId = 4, Name = "Public Relations" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 31, IndustrySectorId = 5, Name = "Agency Construction Management" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 32, IndustrySectorId = 5, Name = "Architectural Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 33, IndustrySectorId = 5, Name = "Engineering Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 34, IndustrySectorId = 5, Name = "Inspection and Testing Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 35, IndustrySectorId = 5, Name = "Interior Design Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 36, IndustrySectorId = 5, Name = "Surveying & Mapping" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 37, IndustrySectorId = 6, Name = "Accountants & Tax Preparation" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 38, IndustrySectorId = 6, Name = "Actuarial Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 39, IndustrySectorId = 6, Name = "Debt / Credit Management Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 40, IndustrySectorId = 6, Name = "Financial Activities" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 41, IndustrySectorId = 6, Name = "Insurance Related Actvities" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 42, IndustrySectorId = 6, Name = "Interim Management Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 43, IndustrySectorId = 6, Name = "Trustees" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 44, IndustrySectorId = 7, Name = "Assisted & Independent Living Facilities" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 45, IndustrySectorId = 7, Name = "Group Home" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 46, IndustrySectorId = 7, Name = "Hospice (inpatient)" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 47, IndustrySectorId = 7, Name = "Mental Health - Non-Substance Abuse" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 48, IndustrySectorId = 7, Name = "Substance Abuse" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 49, IndustrySectorId = 8, Name = "Administrative and Support Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 50, IndustrySectorId = 8, Name = "Agents and Managers for Public Figures" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 51, IndustrySectorId = 8, Name = "Analytical Testing Labs" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 52, IndustrySectorId = 8, Name = "Associations" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 53, IndustrySectorId = 8, Name = "Billing & Collection Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 54, IndustrySectorId = 8, Name = "Business Broker Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 55, IndustrySectorId = 8, Name = "Business Management" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 56, IndustrySectorId = 8, Name = "Court Reporting Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 57, IndustrySectorId = 8, Name = "Educational Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 58, IndustrySectorId = 8, Name = "Franchisor Services " });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 59, IndustrySectorId = 8, Name = "Landman" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 60, IndustrySectorId = 8, Name = "Other Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 61, IndustrySectorId = 8, Name = "Printing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 62, IndustrySectorId = 8, Name = "Private Investigation Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 63, IndustrySectorId = 8, Name = "Professional, Scientific, and Technical Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 64, IndustrySectorId = 8, Name = "Referral Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 65, IndustrySectorId = 8, Name = "Security/Defense/Military Contractor" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 66, IndustrySectorId = 8, Name = "Staffing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 67, IndustrySectorId = 8, Name = "Third Party Administration" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 68, IndustrySectorId = 8, Name = "Transportation and Warehousing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 69, IndustrySectorId = 8, Name = "Travel Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 70, IndustrySectorId = 9, Name = "Adult Day Care" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 71, IndustrySectorId = 9, Name = "Audiologists" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 72, IndustrySectorId = 9, Name = "Blood and Organ Banks" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 73, IndustrySectorId = 9, Name = "Case Management" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 74, IndustrySectorId = 9, Name = "Clinic" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 75, IndustrySectorId = 9, Name = "Clinical Research/ Trials" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 76, IndustrySectorId = 9, Name = "Counseling" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 77, IndustrySectorId = 9, Name = "Dental" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 78, IndustrySectorId = 9, Name = "Dialysis" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 79, IndustrySectorId = 9, Name = "Health Screening" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 80, IndustrySectorId = 9, Name = "Healthcare Staffing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 81, IndustrySectorId = 9, Name = "Home Healthcare (no nursing home/hospital/correctional)" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 82, IndustrySectorId = 9, Name = "Imaging / Testing Labs" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 83, IndustrySectorId = 9, Name = "Individual Practioner" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 84, IndustrySectorId = 9, Name = "Medical Transportation" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 85, IndustrySectorId = 9, Name = "Nutrition/ Dietician" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 86, IndustrySectorId = 9, Name = "Optometrists/opticians" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 87, IndustrySectorId = 9, Name = "Orthotic/prosthetic fitting" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 88, IndustrySectorId = 9, Name = "Pharmacy" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 89, IndustrySectorId = 9, Name = "Post Mortem Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 90, IndustrySectorId = 9, Name = "Prescribed Pediatric Extended Care (PPEC)" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 91, IndustrySectorId = 9, Name = "Social Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 92, IndustrySectorId = 9, Name = "Surgery Centers" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 93, IndustrySectorId = 9, Name = "Therapy" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 94, IndustrySectorId = 9, Name = "Training School" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 95, IndustrySectorId = 9, Name = "Veterinary" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 96, IndustrySectorId = 10, Name = "Miscellaneous Real Estate Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 97, IndustrySectorId = 10, Name = "Real Estate Appraisers" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 98, IndustrySectorId = 10, Name = "Real Estate Developers" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 99, IndustrySectorId = 10, Name = "Real Estate Sales & Property Management" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 100, IndustrySectorId = 11, Name = "Security Guards" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 101, IndustrySectorId = 12, Name = "Application Service Provider" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 102, IndustrySectorId = 12, Name = "Cloud & Infrastructure Outsourcing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 103, IndustrySectorId = 12, Name = "Computer & Electronic Hardware" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 104, IndustrySectorId = 12, Name = "Custom Software Developers" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 105, IndustrySectorId = 12, Name = "Digital Marketing Agency" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 106, IndustrySectorId = 12, Name = "Document and Data Conversion" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 107, IndustrySectorId = 12, Name = "Internet Service Provider" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 108, IndustrySectorId = 12, Name = "IT Management Services" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 109, IndustrySectorId = 12, Name = "IT Staffing" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 110, IndustrySectorId = 12, Name = "Software Publisher" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 111, IndustrySectorId = 12, Name = "Telecomunications" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 112, IndustrySectorId = 12, Name = "Value Added Reseller" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 113, IndustrySectorId = 12, Name = "Web Developers" });
        this.IndustrySubSectorList.Add(new IndustrySubSector() { Version = "v2.0.101", Id = 114, IndustrySectorId = 12, Name = "Web Hosting & Domains" });
    }

    private void LoadIndustrySpecialties()
    {
        this.IndustrySpecialtyList = new();
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 1, IndustrySubSectorId = 1, Name = "Acupuncture" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 2, IndustrySubSectorId = 2, Name = "Athletic Trainers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 3, IndustrySubSectorId = 3, Name = "Biofeedback " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 4, IndustrySubSectorId = 4, Name = "Chiropractor" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 5, IndustrySubSectorId = 5, Name = "Cryotherapy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 6, IndustrySubSectorId = 6, Name = "Doula" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 7, IndustrySubSectorId = 7, Name = "Holistic healthcare " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 8, IndustrySubSectorId = 8, Name = "Naturopathic Physician" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 9, IndustrySubSectorId = 9, Name = "Personal Trainers/ Yoga" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 10, IndustrySubSectorId = 10, Name = "Spa: Invasive" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 11, IndustrySubSectorId = 10, Name = "Spa: Minimally Invasive - Day Spa" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 12, IndustrySubSectorId = 10, Name = "Massage Franchise" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 13, IndustrySubSectorId = 10, Name = "Spa: More Invasive" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 14, IndustrySubSectorId = 11, Name = "Tattoo/body piercing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 15, IndustrySubSectorId = 12, Name = "Acoustic Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 16, IndustrySubSectorId = 12, Name = "Construction Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 17, IndustrySubSectorId = 12, Name = "Cost Estimation Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 18, IndustrySubSectorId = 12, Name = "Energy Consulting Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 19, IndustrySubSectorId = 12, Name = "Fire Protection Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 20, IndustrySubSectorId = 12, Name = "Mining Consultant" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 21, IndustrySubSectorId = 12, Name = "Oil and Gas Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 22, IndustrySubSectorId = 13, Name = "Environmental Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 23, IndustrySubSectorId = 14, Name = "Bankruptcy Advisory Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 24, IndustrySubSectorId = 14, Name = "Employee Benefit Plan / Pension Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 25, IndustrySubSectorId = 14, Name = "Loan, Lending, Financing Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 26, IndustrySubSectorId = 14, Name = "Mergers and Acquisitions Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 27, IndustrySubSectorId = 14, Name = "Financial Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 28, IndustrySubSectorId = 14, Name = "Revenue Cycle Management Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 29, IndustrySubSectorId = 14, Name = "Risk Management & Insurance Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 30, IndustrySubSectorId = 14, Name = "Valuations Consultant" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 31, IndustrySubSectorId = 15, Name = "Business Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 32, IndustrySubSectorId = 15, Name = "Human Resources Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 33, IndustrySubSectorId = 15, Name = "Leadership Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 34, IndustrySubSectorId = 15, Name = "Management Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 35, IndustrySubSectorId = 15, Name = "Municipal Advisory Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 36, IndustrySubSectorId = 15, Name = "Product Development Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 37, IndustrySubSectorId = 15, Name = "Public Affairs/Policy Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 38, IndustrySubSectorId = 16, Name = "Media / Branding Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 39, IndustrySubSectorId = 17, Name = "Healthcare Operations Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 40, IndustrySubSectorId = 17, Name = "Independent Medical Exams" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 41, IndustrySubSectorId = 17, Name = "Medical Director" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 42, IndustrySubSectorId = 17, Name = "Patient Care Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 43, IndustrySubSectorId = 17, Name = "Peer-Review" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 44, IndustrySubSectorId = 17, Name = "Physician consultants" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 45, IndustrySubSectorId = 17, Name = "Utilization Review" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 46, IndustrySubSectorId = 18, Name = "Education Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 47, IndustrySubSectorId = 18, Name = "Energy Efficiency Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 48, IndustrySubSectorId = 18, Name = "Franchise Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 49, IndustrySubSectorId = 18, Name = "Intellectual Property & Licensing Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 50, IndustrySubSectorId = 18, Name = "Lifestyle Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 51, IndustrySubSectorId = 18, Name = "Logistics Management Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 52, IndustrySubSectorId = 18, Name = "Manufacturing Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 53, IndustrySubSectorId = 18, Name = "Other Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 54, IndustrySubSectorId = 18, Name = "Legal Consulting Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 55, IndustrySubSectorId = 18, Name = "Regulatory Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 56, IndustrySubSectorId = 18, Name = "Relocation Consulting & Coordination" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 57, IndustrySubSectorId = 18, Name = "Scientific/Technical Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 58, IndustrySubSectorId = 18, Name = "Vocational Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 59, IndustrySubSectorId = 19, Name = "Cell Tower Acquisition & Leasing Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 60, IndustrySubSectorId = 19, Name = "Real Estate Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 61, IndustrySubSectorId = 19, Name = "Real Estate Development Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 62, IndustrySubSectorId = 19, Name = "Right Of Way Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 63, IndustrySubSectorId = 20, Name = "Safety Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 64, IndustrySubSectorId = 21, Name = "Compliance Certification" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 65, IndustrySubSectorId = 21, Name = "Cybersecurity Testing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 66, IndustrySubSectorId = 21, Name = "General IT Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 67, IndustrySubSectorId = 21, Name = "Software Testing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 68, IndustrySubSectorId = 21, Name = "Other Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 69, IndustrySubSectorId = 21, Name = "Training" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 70, IndustrySubSectorId = 22, Name = "At Risk Construction Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 71, IndustrySubSectorId = 22, Name = "Construction and Installation Only" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 72, IndustrySubSectorId = 22, Name = "Manufactured, Prefabricated, Pre-engineered or Modular Builder" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 73, IndustrySubSectorId = 22, Name = "Design-Build Firms" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 74, IndustrySubSectorId = 23, Name = "Manufacturer" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 75, IndustrySubSectorId = 24, Name = "Demolition and Excavation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 76, IndustrySubSectorId = 24, Name = "Drywall and Insulation Contractors " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 77, IndustrySubSectorId = 24, Name = "Electrical Contractors and Other Wiring Installation Contractors - Electricians" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 78, IndustrySubSectorId = 24, Name = "Exterior Finishing & Siding" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 79, IndustrySubSectorId = 24, Name = "Finish Carpentry Contractors - Finish Carpenter" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 80, IndustrySubSectorId = 24, Name = "Fire Systems & Sprinkler Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 81, IndustrySubSectorId = 24, Name = "Flooring Contractors" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 82, IndustrySubSectorId = 24, Name = "Framing Contractors " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 83, IndustrySubSectorId = 24, Name = "Glass and Glazing Contractors  - Glaziers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 84, IndustrySubSectorId = 24, Name = "HVAC Contractors" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 85, IndustrySubSectorId = 24, Name = "Landscaping Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 86, IndustrySubSectorId = 24, Name = "Masonry Contractors " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 87, IndustrySubSectorId = 24, Name = "Oil and Gas Subcontractor" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 88, IndustrySubSectorId = 24, Name = "Painting and Wall Covering Contractors" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 89, IndustrySubSectorId = 24, Name = "Paving Contractor" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 90, IndustrySubSectorId = 24, Name = "Plumbing Contractors" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 91, IndustrySubSectorId = 24, Name = "Poured Concrete Foundation and Structure Contractors " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 92, IndustrySubSectorId = 24, Name = "Remediation Contractor " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 93, IndustrySubSectorId = 24, Name = "Renovation Contractor" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 94, IndustrySubSectorId = 24, Name = "Roofing Contractors" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 95, IndustrySubSectorId = 24, Name = "Solar Panel Installation Contractor" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 96, IndustrySubSectorId = 24, Name = "Structural Steel and Precast Concrete Contractors " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 97, IndustrySubSectorId = 24, Name = "Telecom installation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 98, IndustrySubSectorId = 24, Name = "Tile and Terrazzo Contractors" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 99, IndustrySubSectorId = 24, Name = "Underground Utility Locating" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 100, IndustrySubSectorId = 25, Name = "Advertising/Creative Agency" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 101, IndustrySubSectorId = 25, Name = "Other Creative Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 102, IndustrySubSectorId = 26, Name = "Graphic Design Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 103, IndustrySubSectorId = 27, Name = "Direct Marketing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 104, IndustrySubSectorId = 27, Name = "Market Research" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 105, IndustrySubSectorId = 27, Name = "Marketing Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 106, IndustrySubSectorId = 27, Name = "Media Buying Agencies" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 107, IndustrySubSectorId = 27, Name = "Promotional Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 108, IndustrySubSectorId = 28, Name = "Photographer Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 109, IndustrySubSectorId = 29, Name = "Post Production" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 110, IndustrySubSectorId = 30, Name = "Public Relations Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 111, IndustrySubSectorId = 31, Name = "Agency Construction Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 112, IndustrySubSectorId = 32, Name = "Architectural Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 113, IndustrySubSectorId = 32, Name = "Drafting / CAD / BIM" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 114, IndustrySubSectorId = 32, Name = "Land Use and Master Planning" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 115, IndustrySubSectorId = 32, Name = "Landscape Architects" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 116, IndustrySubSectorId = 33, Name = "Aerospace Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 117, IndustrySubSectorId = 33, Name = "Chemical Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 118, IndustrySubSectorId = 33, Name = "Civil Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 119, IndustrySubSectorId = 33, Name = "Control Systems Integration and Automation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 120, IndustrySubSectorId = 33, Name = "Electrical Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 121, IndustrySubSectorId = 33, Name = "Environmental Engineers and Consultants" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 122, IndustrySubSectorId = 33, Name = "Geotechnical Engineer" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 123, IndustrySubSectorId = 33, Name = "Heating and Cooling Systems Engineer" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 124, IndustrySubSectorId = 33, Name = "Industrial Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 125, IndustrySubSectorId = 33, Name = "Marine Engineers and Naval Architects" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 126, IndustrySubSectorId = 33, Name = "Mechanical Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 127, IndustrySubSectorId = 33, Name = "Mining Engineer" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 128, IndustrySubSectorId = 33, Name = "Nuclear Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 129, IndustrySubSectorId = 33, Name = "Petroleum Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 130, IndustrySubSectorId = 33, Name = "Seismic Engineer" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 131, IndustrySubSectorId = 33, Name = "Structural Engineer" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 132, IndustrySubSectorId = 33, Name = "Consulting Engineers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 133, IndustrySubSectorId = 34, Name = "Building Code Inspector" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 134, IndustrySubSectorId = 34, Name = "Building Commissioning" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 135, IndustrySubSectorId = 34, Name = "Building Materials Testing and Engineering" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 136, IndustrySubSectorId = 34, Name = "Crane Inspector" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 137, IndustrySubSectorId = 34, Name = "Elevator Inspector" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 138, IndustrySubSectorId = 34, Name = "Home Inspector" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 139, IndustrySubSectorId = 34, Name = "Mechanical / Electrical / Plumbing Inspector" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 140, IndustrySubSectorId = 34, Name = "Roofing Inspector" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 141, IndustrySubSectorId = 34, Name = "Welding Inspector" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 142, IndustrySubSectorId = 34, Name = "Forensic Analysis and Expert Witness" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 143, IndustrySubSectorId = 35, Name = "Interior Design Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 144, IndustrySubSectorId = 36, Name = "Geophysical Surveying and Mapping Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 145, IndustrySubSectorId = 36, Name = "Surveying and Mapping (except Geophysical) Services - Land Surveyor" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 146, IndustrySubSectorId = 37, Name = "Accountants" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 147, IndustrySubSectorId = 37, Name = "Other Accounting Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 148, IndustrySubSectorId = 37, Name = "Payroll Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 149, IndustrySubSectorId = 37, Name = "Tax Preparation Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 150, IndustrySubSectorId = 38, Name = "Actuarial services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 151, IndustrySubSectorId = 39, Name = "Debt / Credit Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 152, IndustrySubSectorId = 40, Name = "Life Settlement Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 153, IndustrySubSectorId = 40, Name = "Other Financial Activites" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 154, IndustrySubSectorId = 40, Name = "Structured Settlement Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 155, IndustrySubSectorId = 41, Name = "Claims Adjuster" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 156, IndustrySubSectorId = 41, Name = "Insurance Related Activities" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 157, IndustrySubSectorId = 41, Name = "Public Claims Adjuster" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 158, IndustrySubSectorId = 42, Name = "Interim Management Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 159, IndustrySubSectorId = 43, Name = "Trustees" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 160, IndustrySubSectorId = 44, Name = "Assisted Living Facility  " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 161, IndustrySubSectorId = 44, Name = "Independent Living Facility" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 162, IndustrySubSectorId = 44, Name = "Memory Care Facility" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 163, IndustrySubSectorId = 45, Name = "Group Home - Adults" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 164, IndustrySubSectorId = 45, Name = "Group Home - Minors  " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 165, IndustrySubSectorId = 46, Name = "Hospice (inpatient)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 166, IndustrySubSectorId = 47, Name = "Mental Health - Non-Substance Abuse" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 167, IndustrySubSectorId = 48, Name = "Inpatient Substance Abuse: Detox Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 168, IndustrySubSectorId = 48, Name = "Inpatient Substance Abuse: Halfway House" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 169, IndustrySubSectorId = 48, Name = "Inpatient Substance Abuse: Medication Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 170, IndustrySubSectorId = 49, Name = "Administrative and Support Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 171, IndustrySubSectorId = 49, Name = "Association Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 172, IndustrySubSectorId = 49, Name = "Background Checks / Screening Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 173, IndustrySubSectorId = 49, Name = "Grant Administration and Monitoring Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 174, IndustrySubSectorId = 49, Name = "Permit Processing and Expediting Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 175, IndustrySubSectorId = 49, Name = "Writing Services for Hire (No Authors)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 176, IndustrySubSectorId = 50, Name = "Agents and Managers for Public Figures" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 177, IndustrySubSectorId = 51, Name = "Analytical Testing Lab Services: Food" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 178, IndustrySubSectorId = 51, Name = "Analytical Testing Lab Services: Medical/Forensic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 179, IndustrySubSectorId = 51, Name = "Analytical Testing Lab Services: Non-Destructive Materials" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 180, IndustrySubSectorId = 51, Name = "Analytical Testing Lab Services: Other" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 181, IndustrySubSectorId = 51, Name = "Analytical Testing Lab Services: Soil" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 182, IndustrySubSectorId = 52, Name = "Associations" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 183, IndustrySubSectorId = 53, Name = "Collection Agent Services: Owned/factored debt" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 184, IndustrySubSectorId = 53, Name = "Collection Agent Services: Third party debt" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 185, IndustrySubSectorId = 53, Name = "Medical Billing Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 186, IndustrySubSectorId = 53, Name = "Other Billing Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 187, IndustrySubSectorId = 54, Name = "Business Broker Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 188, IndustrySubSectorId = 55, Name = "Business Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 189, IndustrySubSectorId = 55, Name = "Full Service Management of Third Party Business" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 190, IndustrySubSectorId = 55, Name = "Hotel Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 191, IndustrySubSectorId = 55, Name = "Medical Practice Management Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 192, IndustrySubSectorId = 56, Name = "Court Reporting Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 193, IndustrySubSectorId = 57, Name = "Instructional & Training Activities" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 194, IndustrySubSectorId = 57, Name = "Educational Test Development, Scoring and Proctoring Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 195, IndustrySubSectorId = 57, Name = "Exam Preparation and Tutoring" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 196, IndustrySubSectorId = 57, Name = "Foreign Exchange Student & Homestay Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 197, IndustrySubSectorId = 57, Name = "Vocational Training & Consulting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 198, IndustrySubSectorId = 58, Name = "Franchisor Services " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 199, IndustrySubSectorId = 59, Name = "Landman" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 200, IndustrySubSectorId = 60, Name = "Aircraft/Jet Broker" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 201, IndustrySubSectorId = 60, Name = "Appraisal of Goods" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 202, IndustrySubSectorId = 60, Name = "Auctioneering of Goods and Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 203, IndustrySubSectorId = 60, Name = "Bail Agent" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 204, IndustrySubSectorId = 60, Name = "Broker of Other Goods and Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 205, IndustrySubSectorId = 60, Name = "Event Planning Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 206, IndustrySubSectorId = 60, Name = "Extermination and Pest Control Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 207, IndustrySubSectorId = 60, Name = "Janitorial Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 208, IndustrySubSectorId = 60, Name = "Other Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 209, IndustrySubSectorId = 60, Name = "Skip Tracing Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 210, IndustrySubSectorId = 60, Name = "Telephone Call Center Services: Inbound" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 211, IndustrySubSectorId = 60, Name = "Telephone Call Center Services: Outbound" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 212, IndustrySubSectorId = 60, Name = "Translation Services " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 213, IndustrySubSectorId = 60, Name = "Repossession Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 214, IndustrySubSectorId = 60, Name = "Yacht/Ship/Boat Broker" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 215, IndustrySubSectorId = 61, Name = "Printing Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 216, IndustrySubSectorId = 62, Name = "Private Investigation Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 217, IndustrySubSectorId = 63, Name = "Accreditation Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 218, IndustrySubSectorId = 63, Name = "Other Professional, Scientific, and Technical Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 219, IndustrySubSectorId = 63, Name = "Business Process Operator/Outsourcer" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 220, IndustrySubSectorId = 63, Name = "Dispute Resolution Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 221, IndustrySubSectorId = 63, Name = "Energy Broker" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 222, IndustrySubSectorId = 63, Name = "Executive Coaching and Mentoring" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 223, IndustrySubSectorId = 63, Name = "Expert Witness" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 224, IndustrySubSectorId = 63, Name = "Guardianship services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 225, IndustrySubSectorId = 63, Name = "Lobbying" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 226, IndustrySubSectorId = 63, Name = "Notaries" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 227, IndustrySubSectorId = 63, Name = "Inspection, Repair, Calibration, Maintenance Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 228, IndustrySubSectorId = 63, Name = "Process Server" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 229, IndustrySubSectorId = 64, Name = "Referral Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 230, IndustrySubSectorId = 65, Name = "Security/Defense/Military Contractor Services " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 231, IndustrySubSectorId = 66, Name = "Permanent Employment Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 232, IndustrySubSectorId = 66, Name = "Professional Employer Organization Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 233, IndustrySubSectorId = 66, Name = "Temporary & Permanent Employment Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 234, IndustrySubSectorId = 66, Name = "Temporary Employment Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 235, IndustrySubSectorId = 67, Name = "Third Party Administration: Employee benefits" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 236, IndustrySubSectorId = 67, Name = "Third Party Administration: Non-employee benefits" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 237, IndustrySubSectorId = 68, Name = "Couriers, Messengers, and Delivery Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 238, IndustrySubSectorId = 68, Name = "Custom House/Freight Forwarder Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 239, IndustrySubSectorId = 68, Name = "Marine Surveying Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 240, IndustrySubSectorId = 68, Name = "Transportation Related Activities" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 241, IndustrySubSectorId = 68, Name = "Pilot Car Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 242, IndustrySubSectorId = 68, Name = "Traffic Control and Management Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 243, IndustrySubSectorId = 68, Name = "Warehousing, Storage, and Fulfillment" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 244, IndustrySubSectorId = 69, Name = "Other Travel Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 245, IndustrySubSectorId = 69, Name = "Tour Operator Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 246, IndustrySubSectorId = 69, Name = "Travel Agency Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 247, IndustrySubSectorId = 70, Name = "Adult Day Care" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 248, IndustrySubSectorId = 71, Name = "Audiologists" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 249, IndustrySubSectorId = 72, Name = "Blood and Organ Banks: Blood" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 250, IndustrySubSectorId = 72, Name = "Blood and Organ Banks: Milk" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 251, IndustrySubSectorId = 72, Name = "Blood and Organ Banks: Organs" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 252, IndustrySubSectorId = 72, Name = "Blood and Organ Banks: Reproductive" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 253, IndustrySubSectorId = 72, Name = "Blood and Organ Banks: Tissue" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 254, IndustrySubSectorId = 73, Name = "Case Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 255, IndustrySubSectorId = 73, Name = "Medical Guardianship" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 256, IndustrySubSectorId = 74, Name = "General Medical Clinic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 257, IndustrySubSectorId = 74, Name = "Methadone Clinic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 258, IndustrySubSectorId = 74, Name = "Pain Management Clinic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 259, IndustrySubSectorId = 74, Name = "Physical Medicine Clinic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 260, IndustrySubSectorId = 74, Name = "Pregnancy education/testing " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 261, IndustrySubSectorId = 74, Name = "Sleep Clinic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 262, IndustrySubSectorId = 74, Name = "Weight Loss Clinic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 263, IndustrySubSectorId = 75, Name = "Clinical Research/ Trials" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 264, IndustrySubSectorId = 76, Name = "Behavioral Counseling" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 265, IndustrySubSectorId = 76, Name = "Egg Donor or Surrogate Matching Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 266, IndustrySubSectorId = 76, Name = "Marriage and Family Counseling" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 267, IndustrySubSectorId = 76, Name = "Pastoral counseling" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 268, IndustrySubSectorId = 76, Name = "PHP / IOP" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 269, IndustrySubSectorId = 76, Name = "Substance Abuse: Counseling" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 270, IndustrySubSectorId = 77, Name = "Dental assistant or hygenist" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 271, IndustrySubSectorId = 77, Name = "Dental labs" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 272, IndustrySubSectorId = 77, Name = "Dentist: Non-Specialist - Non-Surgery" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 273, IndustrySubSectorId = 77, Name = "Dentist: Non-Specialist - Surgery " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 274, IndustrySubSectorId = 77, Name = "Dentist: Specialist - Non-Surgery" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 275, IndustrySubSectorId = 77, Name = "Dentist: Specialist - Surgery" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 276, IndustrySubSectorId = 78, Name = "Dialysis" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 277, IndustrySubSectorId = 79, Name = "Health Screening" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 278, IndustrySubSectorId = 79, Name = "Wellness Counseling " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 279, IndustrySubSectorId = 80, Name = "Healthcare Staffing: Correctional Facility - Skilled" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 280, IndustrySubSectorId = 80, Name = "Healthcare Staffing: Hospital - ICU" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 281, IndustrySubSectorId = 80, Name = "Healthcare Staffing: Hospital - Non-ICU " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 282, IndustrySubSectorId = 80, Name = "Healthcare Staffing: Nursing Home / ALF" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 283, IndustrySubSectorId = 80, Name = "Healthcare Staffing: Other Healthcare" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 284, IndustrySubSectorId = 81, Name = "Home Healthcare: Developmentally Disabled " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 285, IndustrySubSectorId = 81, Name = "Home Healthcare: Remote Patient Monitoring" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 286, IndustrySubSectorId = 81, Name = "Home Healthcare: Skilled - Hospice (outpatient)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 287, IndustrySubSectorId = 81, Name = "Home Healthcare: Skilled - non-pediatrics" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 288, IndustrySubSectorId = 81, Name = "Home Healthcare: Skilled - pediatrics" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 289, IndustrySubSectorId = 81, Name = "Home Healthcare: Unskilled" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 290, IndustrySubSectorId = 82, Name = "Drug / Alcohol Testing - Other" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 291, IndustrySubSectorId = 82, Name = "Drug / Alcohol Testing - Substance Abuse Testing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 292, IndustrySubSectorId = 82, Name = "Medical Imaging: Inpatient (Hospital)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 293, IndustrySubSectorId = 82, Name = "Medical Imaging: Mobile" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 294, IndustrySubSectorId = 82, Name = "Medical Imaging: Outpatient" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 295, IndustrySubSectorId = 82, Name = "Phlebotomy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 296, IndustrySubSectorId = 82, Name = "Testing laboratory: Fertility" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 297, IndustrySubSectorId = 82, Name = "Testing laboratory: Genetics (non-diagnostic)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 298, IndustrySubSectorId = 82, Name = "Testing laboratory: Medical/diagnostic " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 299, IndustrySubSectorId = 82, Name = "Testing laboratory: Reference" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 300, IndustrySubSectorId = 83, Name = "Certified Nursing Assistant" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 301, IndustrySubSectorId = 83, Name = "Licensed Vocational Nurse" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 302, IndustrySubSectorId = 83, Name = "Nurse Practitioner" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 303, IndustrySubSectorId = 83, Name = "Physician Assistant" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 304, IndustrySubSectorId = 83, Name = "Registered Nurse" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 305, IndustrySubSectorId = 84, Name = "Transportation: Emergency Air" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 306, IndustrySubSectorId = 84, Name = "Transportation: Emergency Ground" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 307, IndustrySubSectorId = 84, Name = "Transportation: Non-Emergency Air" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 308, IndustrySubSectorId = 84, Name = "Transportation: Non-Emergency Ground" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 309, IndustrySubSectorId = 84, Name = "Transportation: Special Needs" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 310, IndustrySubSectorId = 85, Name = "Facility Dietician" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 311, IndustrySubSectorId = 85, Name = "Nutrition/ Dietician" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 312, IndustrySubSectorId = 86, Name = "Optometrists/opticians" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 313, IndustrySubSectorId = 87, Name = "Orthotic/prosthetic fitting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 314, IndustrySubSectorId = 88, Name = "Pharmacy: Compounding " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 315, IndustrySubSectorId = 88, Name = "Pharmacy: Non-Compounding " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 316, IndustrySubSectorId = 89, Name = "Post Mortem Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 317, IndustrySubSectorId = 90, Name = "Prescribed Pediatric Extended Care (PPEC)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 318, IndustrySubSectorId = 91, Name = "Adoption Agency  " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 319, IndustrySubSectorId = 91, Name = "Food bank" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 320, IndustrySubSectorId = 91, Name = "Foster Care Agency  " });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 321, IndustrySubSectorId = 91, Name = "Homeless shelter" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 322, IndustrySubSectorId = 91, Name = "Social Services - High/Multi-Disciplinary" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 323, IndustrySubSectorId = 91, Name = "Social Services - Job Training" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 324, IndustrySubSectorId = 91, Name = "Social Services - Supervised Visitation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 325, IndustrySubSectorId = 92, Name = "Surgery Centers: Highly Complex Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 326, IndustrySubSectorId = 92, Name = "Surgery Centers: Low Complexity Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 327, IndustrySubSectorId = 92, Name = "Surgery Centers: Moderately Complex Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 328, IndustrySubSectorId = 93, Name = "Applied Behavior Analysis (ABA)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 329, IndustrySubSectorId = 93, Name = "Durable Medical Equipment (DME)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 330, IndustrySubSectorId = 93, Name = "Facility Therapy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 331, IndustrySubSectorId = 93, Name = "Hyperbaric Oxygen Therapy (HBOT)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 332, IndustrySubSectorId = 93, Name = "Occupational Therapy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 333, IndustrySubSectorId = 93, Name = "Physical Therapy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 334, IndustrySubSectorId = 93, Name = "Respiratory Therapy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 335, IndustrySubSectorId = 93, Name = "Speech Therapy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 336, IndustrySubSectorId = 94, Name = "CPR/ First Aid Training" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 337, IndustrySubSectorId = 94, Name = "Medical Arts School: Chiropractor/Pharmacy/Mental Health" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 338, IndustrySubSectorId = 94, Name = "Medical Arts School: Dental" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 339, IndustrySubSectorId = 94, Name = "Medical Arts School: First Response" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 340, IndustrySubSectorId = 94, Name = "Medical Arts School: Nurses" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 341, IndustrySubSectorId = 94, Name = "Medical Arts School: Radiology" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 342, IndustrySubSectorId = 94, Name = "Medical Arts School: Spa" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 343, IndustrySubSectorId = 94, Name = "Medical Arts School: Surgical" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 344, IndustrySubSectorId = 95, Name = "Veterinary - Domestic Pets" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 345, IndustrySubSectorId = 95, Name = "Veterinary - Non-Domestic Pets" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 346, IndustrySubSectorId = 96, Name = "1031 Exchange Agent" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 347, IndustrySubSectorId = 96, Name = "Auctioneering of real property" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 348, IndustrySubSectorId = 96, Name = "Mortgage Field and Property Preservation Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 349, IndustrySubSectorId = 96, Name = "Other Activities Related to Real Estate" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 350, IndustrySubSectorId = 97, Name = "Real Estate Appraisers" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 351, IndustrySubSectorId = 98, Name = "Real Estate Developers - Homebuilders" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 352, IndustrySubSectorId = 98, Name = "Real Estate Developers - Project Specific" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 353, IndustrySubSectorId = 98, Name = "Real Estate Developers - Residential / Commercial" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 354, IndustrySubSectorId = 98, Name = "Real Estate Developers - Sale / Property Management Services only" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 355, IndustrySubSectorId = 99, Name = "Property Management - Standalone" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 356, IndustrySubSectorId = 99, Name = "Property Management & Real Estate Sales" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 357, IndustrySubSectorId = 99, Name = "Real Estate Agent/Broker - Standalone" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 358, IndustrySubSectorId = 100, Name = "Security Guards" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 359, IndustrySubSectorId = 101, Name = "Accounting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 360, IndustrySubSectorId = 101, Name = "Autonomous AI" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 361, IndustrySubSectorId = 101, Name = "Biometric" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 362, IndustrySubSectorId = 101, Name = "Broadcasting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 363, IndustrySubSectorId = 101, Name = "Business Analytics" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 364, IndustrySubSectorId = 101, Name = "Cloud Storage" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 365, IndustrySubSectorId = 101, Name = "Communications" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 366, IndustrySubSectorId = 101, Name = "Computer-aided Design (CAD)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 367, IndustrySubSectorId = 101, Name = "Computer-aided Manufacturing (CAM)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 368, IndustrySubSectorId = 101, Name = "Control Systems" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 369, IndustrySubSectorId = 101, Name = "Crowdfunding" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 370, IndustrySubSectorId = 101, Name = "Cryptocurrency" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 371, IndustrySubSectorId = 101, Name = "Customer Engagement / CRM" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 372, IndustrySubSectorId = 101, Name = "Customer Rewards" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 373, IndustrySubSectorId = 101, Name = "Cybersecurity" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 374, IndustrySubSectorId = 101, Name = "Data Mining / Aggregation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 375, IndustrySubSectorId = 101, Name = "Digital Marketing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 376, IndustrySubSectorId = 101, Name = "E-Commerce" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 377, IndustrySubSectorId = 101, Name = "E-Discovery" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 378, IndustrySubSectorId = 101, Name = "Emergency Notification" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 379, IndustrySubSectorId = 101, Name = "Enterprise Resource Planning (ERP)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 380, IndustrySubSectorId = 101, Name = "Financial Trading" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 381, IndustrySubSectorId = 101, Name = "Gambling" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 382, IndustrySubSectorId = 101, Name = "Geographic Information Systems (GIS)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 383, IndustrySubSectorId = 101, Name = "Health and Wellness" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 384, IndustrySubSectorId = 101, Name = "Human Resources" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 385, IndustrySubSectorId = 101, Name = "Identity and Fraud Protection" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 386, IndustrySubSectorId = 101, Name = "Internet of Things (IoT)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 387, IndustrySubSectorId = 101, Name = "Banking - Investment" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 388, IndustrySubSectorId = 101, Name = "IT Analytics" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 389, IndustrySubSectorId = 101, Name = "Learning Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 390, IndustrySubSectorId = 101, Name = "Medical Diagnostic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 391, IndustrySubSectorId = 101, Name = "Password Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 392, IndustrySubSectorId = 101, Name = "Payment Processing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 393, IndustrySubSectorId = 101, Name = "Point of Sale (POS)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 394, IndustrySubSectorId = 101, Name = "Practice Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 395, IndustrySubSectorId = 101, Name = "Banking - Retail" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 396, IndustrySubSectorId = 101, Name = "Risk Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 397, IndustrySubSectorId = 101, Name = "Sharing Economy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 398, IndustrySubSectorId = 101, Name = "Social Media" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 399, IndustrySubSectorId = 101, Name = "Supply Chain Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 400, IndustrySubSectorId = 101, Name = "Telematics" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 401, IndustrySubSectorId = 101, Name = "Video Game" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 402, IndustrySubSectorId = 101, Name = "Other" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 403, IndustrySubSectorId = 102, Name = "Cloud Computing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 404, IndustrySubSectorId = 102, Name = "Content Delivery Network (CDN)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 405, IndustrySubSectorId = 102, Name = "Data Center / Colocation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 406, IndustrySubSectorId = 102, Name = "Virtual Private Network (VPN)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 407, IndustrySubSectorId = 103, Name = "Electronic Repair" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 408, IndustrySubSectorId = 103, Name = "E-Recycling & Data Destruction" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 409, IndustrySubSectorId = 103, Name = "Hardware Design / Manufacturing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 410, IndustrySubSectorId = 103, Name = "Hardware Installation / Integration" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 411, IndustrySubSectorId = 104, Name = "Agriculture" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 412, IndustrySubSectorId = 104, Name = "Cannabis" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 413, IndustrySubSectorId = 104, Name = "Construction" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 414, IndustrySubSectorId = 104, Name = "Education" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 415, IndustrySubSectorId = 104, Name = "Electronic Health Records (EHR)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 416, IndustrySubSectorId = 104, Name = "Enterprise Resource Planning (ERP)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 417, IndustrySubSectorId = 104, Name = "Finance and Insurance" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 418, IndustrySubSectorId = 104, Name = "Government / Military" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 419, IndustrySubSectorId = 104, Name = "Healthcare and Social Assistance" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 420, IndustrySubSectorId = 104, Name = "Hospitality" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 421, IndustrySubSectorId = 104, Name = "Banking - Investment" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 422, IndustrySubSectorId = 104, Name = "Legal" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 423, IndustrySubSectorId = 104, Name = "Manufacturing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 424, IndustrySubSectorId = 104, Name = "Media" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 425, IndustrySubSectorId = 104, Name = "Payment Processing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 426, IndustrySubSectorId = 104, Name = "Real Estate" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 427, IndustrySubSectorId = 104, Name = "Retail" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 428, IndustrySubSectorId = 104, Name = "Banking - Retail" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 429, IndustrySubSectorId = 104, Name = "Supply Chain Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 430, IndustrySubSectorId = 104, Name = "Transportation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 431, IndustrySubSectorId = 104, Name = "Utilities" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 432, IndustrySubSectorId = 104, Name = "General" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 433, IndustrySubSectorId = 105, Name = "Digital Marketing Agency" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 434, IndustrySubSectorId = 106, Name = "Document and Data Conversion" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 435, IndustrySubSectorId = 107, Name = "Internet Service Provider" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 436, IndustrySubSectorId = 108, Name = "Managed Cybersecurity Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 437, IndustrySubSectorId = 108, Name = "Managed IT Services" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 438, IndustrySubSectorId = 109, Name = "IT Staffing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 439, IndustrySubSectorId = 110, Name = "Accounting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 440, IndustrySubSectorId = 110, Name = "Autonomous AI" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 441, IndustrySubSectorId = 110, Name = "Biometric" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 442, IndustrySubSectorId = 110, Name = "Broadcasting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 443, IndustrySubSectorId = 110, Name = "Business Analytics" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 444, IndustrySubSectorId = 110, Name = "Cloud Storage" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 445, IndustrySubSectorId = 110, Name = "Communications" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 446, IndustrySubSectorId = 110, Name = "Computer-aided Design (CAD)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 447, IndustrySubSectorId = 110, Name = "Computer-aided Manufacturing (CAM)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 448, IndustrySubSectorId = 110, Name = "Control Systems" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 449, IndustrySubSectorId = 110, Name = "Crowdfunding" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 450, IndustrySubSectorId = 110, Name = "Cryptocurrency" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 451, IndustrySubSectorId = 110, Name = "Customer Engagement / CRM" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 452, IndustrySubSectorId = 110, Name = "Customer Rewards" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 453, IndustrySubSectorId = 110, Name = "Cybersecurity" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 454, IndustrySubSectorId = 110, Name = "Data Mining / Aggregation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 455, IndustrySubSectorId = 110, Name = "Digital Marketing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 456, IndustrySubSectorId = 110, Name = "E-Commerce" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 457, IndustrySubSectorId = 110, Name = "E-Discovery" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 458, IndustrySubSectorId = 110, Name = "Emergency Notification" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 459, IndustrySubSectorId = 110, Name = "Enterprise Resource Planning (ERP)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 460, IndustrySubSectorId = 110, Name = "Financial Trading" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 461, IndustrySubSectorId = 110, Name = "Gambling" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 462, IndustrySubSectorId = 110, Name = "Geographic Information Systems (GIS)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 463, IndustrySubSectorId = 110, Name = "Health and Wellness" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 464, IndustrySubSectorId = 110, Name = "Human Resources" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 465, IndustrySubSectorId = 110, Name = "Identity and Fraud Protection" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 466, IndustrySubSectorId = 110, Name = "Internet of Things (IoT)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 467, IndustrySubSectorId = 110, Name = "Banking - Investment" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 468, IndustrySubSectorId = 110, Name = "IT Analytics" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 469, IndustrySubSectorId = 110, Name = "Learning Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 470, IndustrySubSectorId = 110, Name = "Medical Diagnostic" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 471, IndustrySubSectorId = 110, Name = "Password Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 472, IndustrySubSectorId = 110, Name = "Payment Processing" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 473, IndustrySubSectorId = 110, Name = "Point of Sale (POS)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 474, IndustrySubSectorId = 110, Name = "Practice Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 475, IndustrySubSectorId = 110, Name = "Banking - Retail" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 476, IndustrySubSectorId = 110, Name = "Risk Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 477, IndustrySubSectorId = 110, Name = "Sharing Economy" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 478, IndustrySubSectorId = 110, Name = "Social Media" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 479, IndustrySubSectorId = 110, Name = "Supply Chain Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 480, IndustrySubSectorId = 110, Name = "Telematics" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 481, IndustrySubSectorId = 110, Name = "Video Game" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 482, IndustrySubSectorId = 110, Name = "Other" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 483, IndustrySubSectorId = 111, Name = "Telecommunications" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 484, IndustrySubSectorId = 112, Name = "Product Sales" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 485, IndustrySubSectorId = 112, Name = "Product Sales & Implementation" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 486, IndustrySubSectorId = 112, Name = "Product Sales & Implementation - Electronic Health Records (EHR)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 487, IndustrySubSectorId = 112, Name = "Product Sales & Implementation - Enterprise Resource Planning (ERP)" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 488, IndustrySubSectorId = 112, Name = "Product Sales & Implementation - Banking - Investment" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 489, IndustrySubSectorId = 112, Name = "Product Sales & Implementation - Payment Systems" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 490, IndustrySubSectorId = 112, Name = "Product Sales & Implementation - Banking - Retail" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 491, IndustrySubSectorId = 112, Name = "Product Sales & Implementation - Supply Chain Management" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 492, IndustrySubSectorId = 113, Name = "Web Development" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 493, IndustrySubSectorId = 113, Name = "Web Development and Hosting" });
        this.IndustrySpecialtyList.Add(new IndustrySpecialty() { Version = "v2.0.101", Id = 494, IndustrySubSectorId = 114, Name = "Web Hosting & Domains" });
    }

    private async Task LoadGeographicMods()
    {
        var filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        using (StreamReader reader = new StreamReader($"{filePath}\\datafiles\\GeographicMod.json"))
        {
            string json = reader.ReadToEnd();
            var list = JsonSerializer.Deserialize<List<GeographicMod>>(json);
            this.GeographiModDictionary = list.Select(_ => new KeyValuePair<string, GeographicMod>(_.Zip, _)).ToDictionary();
        }
    }
    private async Task LoadRatingFactors()
    {
        var filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        using (StreamReader reader = new StreamReader($"{filePath}\\datafiles\\RatingFactor.json"))
        {
            string json = reader.ReadToEnd();
            this.RatingFactorsList = JsonSerializer.Deserialize<List<RatingFactorMaster>>(json);
        }
    }
    private void LoadPolicyDetails()
    {
        this.PolicyDetailsList = new();
        this.PolicyDetailsList.Add(new PolicyDetails()
        {
            Version = "v2.0.101",
            Id = 1,
            PUID = "6135471_MUP_5",
            PolicyNo = "5064044",
            NameDescr = "Ryan W Lemon, ARCHITECT 84319",
            Zip = "84319",
            TimestampEffectivePolicy = new DateTime(2025, 11, 2, 0, 0, 0),
            TimestampExpirationPolicy = new DateTime(2026, 10, 2, 0, 0, 0),
            ExposureBase = 54569.00m,
            EO_GWP = 1822.00m,
            EO_Retention = 2500.00m,
            EO_OccLimit = 1000000.00m,
            EO_AggLimit = 3000000.00m,
            EO_2_GWP = 0m,
            EO_2_Retention = 0m,
            EO_2_OccLimit = 0m,
            EO_2_AggLimit = 0m,
            GL_GWP = 0m,
            GL_Retention = 0m,
            GL_OccLimit = 0m,
            GL_AggLimit = 0m,
            Cyb_GWP = 0m,
            Cyb_Retention = 0m,
            Cyb_OccLimit = 0m,
            Cyb_AggLimit = 0m
        });
    }
}