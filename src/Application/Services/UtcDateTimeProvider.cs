﻿using Application.Common.Abstractions;

namespace Application.Services;

public class UtcDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

    public long UtcNowUnixMs => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}