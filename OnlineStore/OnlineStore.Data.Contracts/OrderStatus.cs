namespace OnlineStore.Data.Contracts
{
    public enum OrderStatus
    {
        NotProcessed = 1,
        Cancelled = 2,
        MissingProducts = 3,
        Approved = 4,
        Sent = 5,
        Delivered = 6
    }
}
