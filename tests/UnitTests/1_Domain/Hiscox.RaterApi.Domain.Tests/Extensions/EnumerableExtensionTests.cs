// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Extensions;

namespace Hiscox.RaterApi.Domain.Tests.Extensions;

public class EnumerableExtensionTests
{
    #region IsNullOrEmpty

    [Fact]
    public void IsNullOrEmptyTest_EnumerableNull_ReturnsTrue()
    {
        // Arrange
        List<int>? enumerable = null;

        // Act
        var result = enumerable!.IsNullOrEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmptyTest_EnumerableEmpty_ReturnsTrue()
    {
        // Arrange
        List<int>? enumerable = [];

        // Act
        var result = enumerable.IsNullOrEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmptyTest_EnumerableHasElements_ReturnsFalse()
    {
        // Arrange
        List<int>? enumerable = [1, 2, 3, 4, 5];

        // Act
        var result = enumerable.IsNullOrEmpty();

        // Assert
        Assert.False(result);
    }

    #endregion IsNullOrEmpty
}