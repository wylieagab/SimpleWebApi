using SimpleRobotsWebApi.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using RestSharp;

namespace SimpleRobotsWebApi.Database

{
    interface IRobotAPIContextSeed
    {

        public void SeedAsync();

    }
}
