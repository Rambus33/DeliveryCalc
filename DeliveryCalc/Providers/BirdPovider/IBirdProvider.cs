namespace DeliveryCalc.Provider
{
    public interface IBirdProvider<T> : IProvider<T> where T : class, new()
    { }
}