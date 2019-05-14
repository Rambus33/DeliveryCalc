using DeliveryCalc.Classes;
using DeliveryCalc.Dtos;
using DeliveryCalc.Models;
using DeliveryCalc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryCalc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        public readonly IDeliveryCalcService<InputElement> DeliveryCalcService;

        public DeliveryController(IDeliveryCalcService<InputElement> deliveryCalcService)
        {
            DeliveryCalcService = deliveryCalcService;
        }

        [HttpPost("DeliveryCalcByName")]
        public ActionResult DeliveryCalcByName([FromBody] InputParamsDto inputParams)
        {
            var elements = MapElements(inputParams.Elements);
            var result = DeliveryCalcService.DeliveryCalcByName(inputParams.Name, inputParams.Sender, inputParams.Recipient, elements);
            return Ok(result);
        }

        [HttpPost("DeliveryCalcAll")]
        public ActionResult<IEnumerable<DeliveryCalcRespond>> DeliveryCalcAll([FromBody] InputParamsDto inputParams)
        {
            var elements = MapElements(inputParams.Elements);
            var result = DeliveryCalcService.DeliveryCalcAll(inputParams.Sender, inputParams.Recipient, elements);
            return result.ToList();
        }

        private IEnumerable<InputElement> MapElements(IEnumerable<InputElementDto> elements)
        {
            var result = new List<InputElement>();
            foreach (var element in elements)
            {
                result.Add(new InputElement
                {
                    Height = element.Height,
                    Length = element.Length,
                    Quantity = element.Quantity,
                    Weight = element.Weight,
                    Width = element.Width
                });
            }
            return result;
        }
    }
}