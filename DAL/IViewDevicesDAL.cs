using Application.Models;

namespace DAL
{
    public interface IViewDevicesDAL
    {
        public List<ViewDevice> GetAll();

        public bool AddDevice(ViewDevice viewDevice);

        public void Delete(int id);
        public List<ViewDevice> GetByType(string type);
        ViewDevice GetMinMax(int minField);
    }
}