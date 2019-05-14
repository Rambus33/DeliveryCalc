namespace DeliveryCalc.Provider
{
    public interface ITurtleProvider<T> : IProvider<T> where T : class, new()
    { }
}