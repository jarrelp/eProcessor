namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Enums;

public enum SendValue
{
    // Not yet picked up
    N = 1,

    // Busy
    B = 2,

    // Successfully processed
    Y = 3,

    // Processed, but with error
    E = 4
}
