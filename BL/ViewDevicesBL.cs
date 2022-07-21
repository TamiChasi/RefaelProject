using Application.Models;
using Application.Models.Types;
using DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BL
{
    public class ViewDevicesBL : IViewDevicesBL
    {
        IViewDevicesDAL viewDevicesDAL ;
        public ViewDevicesBL(IViewDevicesDAL ViewDevicesDAL)
        {
            viewDevicesDAL = ViewDevicesDAL;
        }

        public List<ViewDevice> GetAll()
        {
            return viewDevicesDAL.GetAll();
        }

        public bool AddDevice(Object data)
        {
            JObject devices = JObject.Parse(data.ToString());
            var values = devices.ToObject<Dictionary<string, object>>();

            JObject rangeData = JObject.Parse(values["Range"].ToString());
            var range = rangeData.ToObject<Dictionary<string, object>>();

            JObject fieldData = JObject.Parse(values["FieldOfView"].ToString());
            var field = fieldData.ToObject<Dictionary<string, object>>();

            Application.Models.Type type;

            switch (values["Type"])
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
            return viewDevicesDAL.AddDevice(new ViewDevice(
                new Application.Models.Range(Convert.ToDecimal(range["Meters"]), Convert.ToDecimal(range["AerialLine"])),
                type,
                new FieldOfView(Convert.ToDecimal( field["Degrees"]), Convert.ToDecimal(field["engle"]))));
        }

        public void Delete(int id)
        {
            viewDevicesDAL.Delete(id);
        }

        public List<ViewDevice> GetByType(string type)
        {
            return viewDevicesDAL.GetByType(type);
        }

        public ViewDevice GetMinMax(int minField)
        {
            return viewDevicesDAL.GetMinMax(minField);
        }
    }
}