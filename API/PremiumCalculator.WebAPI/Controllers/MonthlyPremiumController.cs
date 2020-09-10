using Elmah;
using PremiumCalculator.BAL.BusinessService;
using PremiumCalculator.BAL.Interface;
using PremiumCalculator.BAL.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PremiumCalculator.WebAPI.Controllers
{
    public class MonthlyPremiumController : ApiController
    {
        IOccupationBAL _occupationBAL;
        IPremiumCalculatorBAL _premiumCalculatorBAL;

        public MonthlyPremiumController(IOccupationBAL occupationBAL, IPremiumCalculatorBAL premiumCalculatorBAL)
        {
            _occupationBAL = occupationBAL;
            _premiumCalculatorBAL = premiumCalculatorBAL;
        }

        [HttpGet]
        [ActionName("GetOccupations")]
        public async Task<IHttpActionResult> GetOccupations()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _occupationBAL.getAllOccupations();
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex));
            }
        }

        [HttpPost]
        [ActionName("GetPremiumValue")]
        public async Task<IHttpActionResult> GetPremiumValue([FromBody]PremiumParametersData premiumParametersData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _premiumCalculatorBAL.getPremiumValue(premiumParametersData);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, ex));
            }
        }
    }
}
