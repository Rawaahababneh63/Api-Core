using System;
using System.Collections.Generic;

namespace task2.Models;

public partial class CacheTable
{
    public string Id { get; set; } = null!;

    public byte[]? Value { get; set; }

    public DateTimeOffset? ExpiresAtTime { get; set; }

    public long? SlidingExpirationInSeconds { get; set; }

    public DateTimeOffset? AbsoluteExpiration { get; set; }
}
