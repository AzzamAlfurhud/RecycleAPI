
namespace RecycleAPI.Models
{
    public class MyGeometry
    {
        public string Type { get; set; }
        public double[] Coordinates { get; set; }

        public MyGeometry(string type, double x, double y)
        {
            Type = type;
            Coordinates = new double[] { x, y };
        }
    }
}
