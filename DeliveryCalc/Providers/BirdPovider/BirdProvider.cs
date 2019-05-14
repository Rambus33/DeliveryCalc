using System.Collections.Generic;
using DeliveryCalc.Classes;
using DeliveryCalc.Exceptions;
using DeliveryCalc.Models;

namespace DeliveryCalc.Provider
{
    public class BirdProvider : IBirdProvider<InputElement>
    {
        public string Name { get; set; } = "Bird";

        public BirdRespond Calc(string sender, string recipient, IEnumerable<InputElement> elements)
        {
            if (string.IsNullOrEmpty(sender) || string.IsNullOrEmpty(recipient) || elements == null)
            {
                throw new DeliveryCalcException("Invalid input params");
            }
            return new BirdRespond
            {
                Cost = 3456,
                Days = 54
            };
        }

        public DeliveryCalcRespond DeliveryCalc(string sender, string recipient, IEnumerable<InputElement> elements)
        {
            var respond = Calc(sender, recipient, elements);
            return new DeliveryCalcRespond
            {
                Cost = respond.Cost,
                Days = respond.Days
            };
        }
    }
}