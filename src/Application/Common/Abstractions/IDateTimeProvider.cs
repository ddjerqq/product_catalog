﻿namespace Application.Common.Abstractions;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }

    public long UtcNowUnixMs { get; }
}