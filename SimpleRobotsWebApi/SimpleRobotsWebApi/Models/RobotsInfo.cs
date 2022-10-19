namespace SimpleRobotsWebApi.Models
{
    public class RobotInfo
    {
        public int robotId { get; set; }

        public int batteryLevel { get; set; }

        public int x { get; set; }

        public int y { get; set; }



        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //public string? Summary { get; set; }
    }
}