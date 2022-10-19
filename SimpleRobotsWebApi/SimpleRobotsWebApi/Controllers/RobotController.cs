using Microsoft.AspNetCore.Mvc;
using SimpleRobotsWebApi.Database;
using SimpleRobotsWebApi.Models;

namespace SimpleRobotsWebApi.Controllers
{
    [ApiController]
    [Route("api/robot")]
    public class RobotController : Controller
    {

        private readonly RobotAPIDbContext _dbContext;

        public RobotController(RobotAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("closest/")]
        public IActionResult GetNearestRobot(NearestRobotRequest nearestRobotRequest)
        {
            var availableRobots = _dbContext.RobotInfo.ToList();
            var nearestRobot = GetNearestRobot(nearestRobotRequest, availableRobots);

            return Ok(nearestRobot);
        }

        private NearestRobot GetNearestRobot(NearestRobotRequest nearestRobotRequest, List<RobotInfo> availableRobots)
        {
            var nearestRobotQueue = new PriorityQueue<NearestRobot, NearestRobot>(new NearestRobotComparer());

            for(int i = 0; i < availableRobots.Count; i++)
            {
                var distance = GetDistance(availableRobots[i].x, availableRobots[i].y, nearestRobotRequest.x, nearestRobotRequest.y);
                var availableRobot = new NearestRobot() { robotId = availableRobots[i].robotId, batteryLevel = availableRobots[i].batteryLevel, distanceToGoal = distance };
                nearestRobotQueue.Enqueue(availableRobot, availableRobot);
            }

            return nearestRobotQueue.Dequeue();
        }

        private static double GetDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(Convert.ToDouble(x2) - Convert.ToDouble(x1), 2) + Math.Pow(Convert.ToDouble(y2)- Convert.ToDouble(y1), 2));
        }



    }
}