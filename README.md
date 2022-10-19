# SimpleWebApi

API Post Request can be executed via Postman at https://localhost:5001/api/robots/closest/ 

To Run:

Open up the solution in visual studio and run with or without debugging. Postman can be used to query the api. 


Description of Features: 
I went for a Restful Approach with an MVC design using C# .NET 6. The solution uses an in memory Database to first load the robot list via the 
endpoint provided. Then when a post request is executed the RobotController gets the list of available robots from the db and loads them into 
a priority queue that utilizes a custom comparer to rank the priority of each robot. The comparer checks if the distance is within 10.00 units 
and then ranks by battery life otherwise it ranks by distance and then battery life. The runtime complexity for this algorithm is O(N*Log(N)) where
N represents the number of robots provided by the API. 

Proposed Updates: 
Given more time I would firstly refactor the controller so that the helper functions could be given their own class and be added as a service.
In addition to this, I believe that in a realworld scenario the endpoints and other connection strings would need to be secured as secrets either in Kubernetes or Azure KeyVault. 
With the refactored engine many more methods could be created to supply more information about and also we could easily translate the selected robots to there destination
which could readily be stored in the database I have prepared. Also after use of this API, we could identify bottleknecks that could be eleviated by cacheing 
or scaling the solution. 
