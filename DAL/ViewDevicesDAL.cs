using Application.Models;
using Application.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ViewDevicesDAL : IViewDevicesDAL
    {

        List<ViewDevice> appViewDevices;
        public ViewDevicesDAL()
        {
            appViewDevices = new List<ViewDevice>();
            appViewDevices.Add(new ViewDevice(
                new Application.Models.Range(90, 90),
                new DayType(),
                new FieldOfView(30, 100)
           )); ;

            appViewDevices.Add(new ViewDevice(
                new Application.Models.Range(50, 50),
                new DayType(),
                new FieldOfView(20, 100)
            )); ;
        }

        public List<ViewDevice> GetByType(string type)
        {
            return appViewDevices.Where(d => d.Type.TypeName == type).ToList();
        }

        public void Delete(int id)
        {
            IEnumerable<ViewDevice> deviceToDell = appViewDevices.Where(d => d.Id == id);
            appViewDevices.Remove(deviceToDell.FirstOrDefault());

        }

        public bool AddDevice(ViewDevice viewDevice)
        {
            appViewDevices.Add(viewDevice);
            return true;
        }

        public List<ViewDevice> GetAll()
        {
            return appViewDevices;
        }

        public ViewDevice GetMinMax(int minField)
        { 
            List<ViewDevice> minFieldOfView = appViewDevices.Where(d => d.FieldOfView.Degrees >= minField).ToList();
            return minFieldOfView.FirstOrDefault(d => d.Range.Meters == appViewDevices.Max(d => d.Range.Meters));
        }
    }
}
