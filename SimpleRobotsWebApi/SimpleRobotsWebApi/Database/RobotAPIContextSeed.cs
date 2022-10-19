using SimpleRobotsWebApi.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using RestSharp;

namespace SimpleRobotsWebApi.Database

{
    public class RobotAPIContextSeed : IRobotAPIContextSeed
    {
        private readonly RobotAPIDbContext _dbContext;

        public RobotAPIContextSeed(RobotAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedAsync()
        {
            var client = new RestClient("https://60c8ed887dafc90017ffbd56.mockapi.io");

            var request = new RestRequest("robots");
            request.AddHeader("User-Agent", "Nothing");

            var robots = client.GetAsync<List<RobotInfo>>(request).Result;

            _dbContext.RobotInfo.AddRange(robots);
            _dbContext.SaveChanges();
        }
    }
}
