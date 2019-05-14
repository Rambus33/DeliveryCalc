using DeliveryCalc.Provider;
using DeliveryCalc.Models;
using System.Collections.Generic;
using DeliveryCalc.Classes;
using System.Linq;
using DeliveryCalc.Exceptions;

namespace DeliveryCalc.Services
{
    public class DeliveryCalcService : IDeliveryCalcService<InputElement>
    {
        public IEnumerable<IProvider<InputElement>> Providers { get; set; }

        public DeliveryCalcService(IEnumerable<IProvider<InputElement>> providers)
        {
            Providers = providers;
        }

        public IEnumerable<DeliveryCalcRespond> DeliveryCalcAll(string sender, string recipient, IEnumerable<InputElement> elements)
        {
            var result = new List<DeliveryCalcRespond>();

            foreach (var provider in Providers)
            {
                result.Add(provider.DeliveryCalc(sender, recipient, elements));
            }

            return result;
        }

        public DeliveryCalcRespond DeliveryCalcByName(string nameProvider, string sender, string recipient, IEnumerable<InputElement> elements)
        {
            var provider = Providers.Where(x => x.Name == nameProvider).FirstOrDefault();
            if (provider == null)
            {
                throw new DeliveryCalcException("Invalid provider name");
            }

            return provider.DeliveryCalc(sender, recipient, elements);
        }
    }
}