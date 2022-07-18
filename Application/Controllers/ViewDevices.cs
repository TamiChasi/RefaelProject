using Application.Models;
using BL;
using Microsoft.AspNetCore.Mvc;


namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewDevices : ControllerBase
    {
        ViewDevicesBL viewDevicesBL;
        public ViewDevices()
        {
            viewDevicesBL = new ViewDevicesBL();
        }

        [HttpGet]
        public List<ViewDevice> Get()
        {
            return viewDevicesBL.GetAll();
        }

        //[HttpGet("name/{name}")]
        //public IEnumerable<Application.ViewDevices> Get(string name)
        //{
        //    return viewDevicesBL.GetAll();
        //}
    }
}