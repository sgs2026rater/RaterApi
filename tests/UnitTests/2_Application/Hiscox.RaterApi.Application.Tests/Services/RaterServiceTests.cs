// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Application.Tests.Services;

public class RaterServiceTests
{
    //private IRaterService _raterService;

    //public RaterServiceTests()
    //{
    //    // Need to figure out how to mock to create the service to test it.
    //    _raterService = new RaterService(memoryCache, logger, magicPolicyRepository, geographicModRepository, industrySectorRepository,
    //                                    industrySubSectorRepository, industrySpecialtyRepository, raterOptions, iRatingFactorsRepository,
    //                                    formRepository, formEligibilityRepository);
    //}

    #region ValidateTotalExposure

    [Fact]
    public void ValidateTotalExposureTest_ExposuresAddUpTo1_ReturnTrue()
    {
        // Arrange


        // Act


        // Assert

    }

    [Fact]
    public void ValidateTotalExposureTest_ExposuresAddUpToMoreThan1_ReturnFalse()
    {
        // Arrange


        // Act


        // Assert

    }

    [Fact]
    public void ValidateTotalExposureTest_ExposuresAddUpToLessThan1_ReturnFalse()
    {
        // Arrange


        // Act


        // Assert

    }

    #endregion ValidateTotalExposure
}