using Application.Models;
using Application.Models.Types;
using BL;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewDevices : ControllerBase
    {
        IViewDevicesBL viewDevicesBL;
        public ViewDevices(IViewDevicesBL ViewDevicesBL)
        {
            viewDevicesBL = ViewDevicesBL;
        }

        [HttpGet]
        public List<ViewDevice> Get()
        {
            return viewDevicesBL.GetAll();
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Object data)
        {
            if (viewDevicesBL.AddDevice(data))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            viewDevicesBL.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
            
        }

        [HttpGet("type")]
        public List<ViewDevice> GetByType([FromQuery]string type)
        {
            return viewDevicesBL.GetByType(type);
        }

        [HttpGet("minField")]
        public ViewDevice GetMinMax([FromQuery] int minField)
        {
            return viewDevicesBL.GetMinMax(minField);
        }

    }
}