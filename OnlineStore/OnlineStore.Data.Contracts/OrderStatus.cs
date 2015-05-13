namespace OnlineStore.Data.Contracts
{
    public enum OrderStatus
    {
        NotProcessed = 0,
        Approved = 1,
        MissingProducts = 2,
        Sent = 3,
        Delivered = 4
    }
}
