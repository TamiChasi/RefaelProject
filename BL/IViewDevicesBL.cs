using Application.Models;

namespace BL
{
    public interface IViewDevicesBL
    {
        public List<ViewDevice> GetAll();

        public bool AddDevice(Object viewDevice);

        public void Delete(int id);
        public List<ViewDevice> GetByType(string type);
        ViewDevice GetMinMax(int minField);
    }
}