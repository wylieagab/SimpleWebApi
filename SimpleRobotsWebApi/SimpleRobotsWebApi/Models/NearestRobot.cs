namespace SimpleRobotsWebApi.Models
{
    public class NearestRobot
    {
        public int robotId { get;  set; }
        public double distanceToGoal { get; set; }
        public int batteryLevel { get; set; }
    }
}
