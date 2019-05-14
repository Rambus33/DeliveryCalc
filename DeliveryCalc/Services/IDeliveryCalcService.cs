using DeliveryCalc.Classes;
using DeliveryCalc.Models;
using System.Collections.Generic;

namespace DeliveryCalc.Services
{
    public interface IDeliveryCalcService<T> where T : InputElement
    {
        DeliveryCalcRespond DeliveryCalcByName(string nameProvider, string sender, string recipient, IEnumerable<T> elements);
        IEnumerable<DeliveryCalcRespond> DeliveryCalcAll(string sender, string recipient, IEnumerable<T> elements);
    }
}