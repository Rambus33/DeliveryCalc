using System.Collections.Generic;

namespace DeliveryCalc.Dtos
{
    public class InputParamsDto
    {
        public string Name { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public IEnumerable<InputElementDto> Elements { get; set; }
    }
}