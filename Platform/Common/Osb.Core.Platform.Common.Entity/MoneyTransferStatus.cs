namespace Osb.Core.Platform.Common.Entity
{
    public enum MoneyTransferStatus
    {
        Created = 0,
        Generated = 1,
        Registered = 2,
        Settled = 3,
        Canceled = 4,
        Error = 5,
        PreCanceled = 6
    }
}