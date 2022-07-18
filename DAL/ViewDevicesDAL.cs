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

        List<ViewDevice> AppViewDevices = new List<ViewDevice>();
        public ViewDevicesDAL()
        {
            AppViewDevices.Add(new ViewDevice(
                new DayType(),
                new Application.Models.Range(90, 90),
                new FieldOfView(100, 100)
           )); ;

            AppViewDevices.Add(new ViewDevice(
                new DayType(),
                new Application.Models.Range(50, 50),
                new FieldOfView(20, 100)
            )); ;
        }


        public List<ViewDevice> GetAll()
        {
            return AppViewDevices;
        }


    }
}
