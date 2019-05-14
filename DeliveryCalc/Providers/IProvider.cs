using DeliveryCalc.Classes;
using DeliveryCalc.Models;
using System.Collections.Generic;

namespace DeliveryCalc.Provider
{
    public interface IProvider<T> where T : class, new()
    {
        string Name { get; set; }
        DeliveryCalcRespond DeliveryCalc(string sender, string recipient, IEnumerable<T> elements);
    }
}