using Application.Models;
using DAL;

namespace BL
{
    public class ViewDevicesBL
    {
        static ViewDevicesDAL viewDevicesDAL;
        public ViewDevicesBL()
        {
            viewDevicesDAL = new ViewDevicesDAL();
        }

        public List<ViewDevice> GetAll()
        {
            return viewDevicesDAL.GetAll();
        }

        public void AddDevice(ViewDevice viewDevice)
        {
            viewDevicesDAL.AddDevice(viewDevice);
        }

        public void Delete(int id)
        {
            viewDevicesDAL.Delete(id);
        }

        public List<ViewDevice> GetByType(string type)
        {
            return viewDevicesDAL.GetByType(type);
        }
    }
}