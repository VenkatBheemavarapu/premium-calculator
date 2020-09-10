using PremiumCalculator.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.BAL.BusinessService
{
    public interface IOccupationBAL
    {
      Task<List<OccupationData>>  getAllOccupations();
      Task<decimal> getOccupationFactor(int occupationId);
    }
}
