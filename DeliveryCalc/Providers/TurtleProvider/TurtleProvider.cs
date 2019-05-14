using DeliveryCalc.Classes;
using DeliveryCalc.Exceptions;
using DeliveryCalc.Models;
using System;
using System.Collections.Generic;

namespace DeliveryCalc.Provider
{
    public class TurtleProvider : ITurtleProvider<InputElement>
    {
        private readonly double baseCost;

        public string Name { get; set; } = "Turtle";

        public TurtleProvider()
        {
            baseCost = 150;
        }

        public TurtleRespond Calc(string sender, string recipient, IEnumerable<InputElement> elements)
        {
            if (string.IsNullOrEmpty(sender) || string.IsNullOrEmpty(recipient) || elements == null)
            {
                throw new DeliveryCalcException("Invalid input params");
            }
            var days = new Random(20);
            return new TurtleRespond
            {
                СostСoefficient = 0.56,
                DateDelivery = DateTime.Now.AddDays(days.NextDouble())
            };
        }

        public DeliveryCalcRespond DeliveryCalc(string sender, string recipient, IEnumerable<InputElement> elements)
        {
            var respond = Calc(sender, recipient, elements);
            return new DeliveryCalcRespond
            {
                Cost = respond.СostСoefficient * baseCost,
                Days = (respond.DateDelivery - DateTime.Now).Days
            };
        }
    }
}