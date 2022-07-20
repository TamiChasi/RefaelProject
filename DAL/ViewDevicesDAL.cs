using Application.Models;
using Application.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ViewDevicesDAL
    {

        static List<ViewDevice> appViewDevices;
        public ViewDevicesDAL()
        {
            appViewDevices = new List<ViewDevice>();
            // appViewDevices.Add(new ViewDevice(
            //     new Application.Models.Range(90, 90),
            //     new DayType(),
            //     new FieldOfView(100, 100)
            //)); ;

            appViewDevices.Add(new ViewDevice(
                new Application.Models.Range(50, 50),
                new DayType(),
                new FieldOfView(20, 100)
            )); ;
        }

        public List<ViewDevice> GetByType(string type)
        {
            return (List<ViewDevice>)appViewDevices.Where(d => d.Type.TypeName == type);
        }

        public void Delete(int id)
        {
            IEnumerable<ViewDevice> deviceToDell = appViewDevices.Where(d => d.Id == 1);
            appViewDevices.Remove(deviceToDell.FirstOrDefault());

        }

        public void AddDevice(ViewDevice viewDevice)
        {
            appViewDevices.Add(viewDevice);
        }

        public List<ViewDevice> GetAll()
        {
            return appViewDevices;
        }


    }
}
