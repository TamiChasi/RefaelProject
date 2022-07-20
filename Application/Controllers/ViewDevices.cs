using Application.Models;
using Application.Models.Types;
using BL;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewDevices : ControllerBase
    {
        static ViewDevicesBL viewDevicesBL;
        public ViewDevices()
        {
            viewDevicesBL = new ViewDevicesBL();
        }

        [HttpGet]
        public List<ViewDevice> Get()
        {
            return viewDevicesBL.GetAll();
        }

        [HttpPost]
        public HttpResponseMessage Post(ViewDevice viewDevice)
        {
            if (ModelState.IsValid)
            {
                Application.Models.Type type;

                switch (viewDevice.Type.TypeName)
                {
                    case "Day":
                        type = new DayType();
                        break;
                    case "Night":
                        type = new NightType();
                        break;
                    case "Fog":
                        type = new FogType();
                        break;
                    default:
                        type = null;
                        break;
                }

                viewDevicesBL.AddDevice(new ViewDevice(viewDevice.Range, type, viewDevice.FieldOfView));
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

        [Route("/type/")]
        [HttpGet]
        public List<ViewDevice> GetByType(string type)
        {
            return viewDevicesBL.GetByType(type);
        }

    }
}