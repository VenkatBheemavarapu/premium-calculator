using PremiumCalculator.BAL.Interface;
using PremiumCalculator.BAL.Models;
using System.Threading.Tasks;

namespace PremiumCalculator.BAL.BusinessService
{
    public class PremiumCalculatorBAL : IPremiumCalculatorBAL
    {
        IOccupationBAL _occupationBAL;
        public PremiumCalculatorBAL(IOccupationBAL occupationBAL)
        {
            _occupationBAL = occupationBAL;
        }

        public async Task<decimal> getPremiumValue(PremiumParametersData premiumParamData)
        {
            var occupationFactor = await _occupationBAL.getOccupationFactor(premiumParamData.OccupationId);

            return (premiumParamData.SumInsured * occupationFactor * premiumParamData.Age) / (1000 * 12);
        }
    }
}
