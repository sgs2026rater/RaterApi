// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Extensions;

public static class EnumerableExtension
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
    {
        return enumerable?.Any() != true;
    }
}
