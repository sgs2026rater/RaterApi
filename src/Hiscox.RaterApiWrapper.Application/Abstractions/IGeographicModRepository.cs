// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IGeographicModRepository
{
    Task<string> GetMetroArea(string version, string zipCode);
}
