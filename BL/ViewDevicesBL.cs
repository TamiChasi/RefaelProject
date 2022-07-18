using Application.Models;
using DAL;

namespace BL
{
    public class ViewDevicesBL
    {
        ViewDevicesDAL viewDevicesDAL;
        public ViewDevicesBL()
        {
            viewDevicesDAL = new ViewDevicesDAL();
        }

        public List<ViewDevice> GetAll()
        {
            return viewDevicesDAL.GetAll();
        }

    }
}