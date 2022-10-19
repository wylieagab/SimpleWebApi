namespace SimpleRobotsWebApi.Models
{
    public class NearestRobotComparer : IComparer<NearestRobot>
    {
        public int Compare(NearestRobot x, NearestRobot y)
        {
            if(x.distanceToGoal == y.distanceToGoal)
            {
                if(x.batteryLevel > y.batteryLevel)
                {
                    return -1;
                }
                else if(y.batteryLevel > x.batteryLevel)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (x.distanceToGoal < y.distanceToGoal)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

    }
}
