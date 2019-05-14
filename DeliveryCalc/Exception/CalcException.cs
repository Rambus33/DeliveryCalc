using System;

namespace DeliveryCalc.Exceptions
{
    public class DeliveryCalcException : Exception
    {
        public DeliveryCalcException(string message) : base(message) { }
    }
}