// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RatingApiWrapper.Domain.Exceptions;

public class ServiceException(int statusCode, string message) : Exception(message)
{
}
