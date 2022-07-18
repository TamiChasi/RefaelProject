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

        public int GetAll()
        {
            return viewDevicesDAL.GetAll();
        }

    }
}