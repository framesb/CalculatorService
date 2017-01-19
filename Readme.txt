The CalculatorService consists on a JSON WebApi application and a client Console to send requests. The client Console comes with instructions to use it. 
To test the solution, simply run the Server and Client projects

The only dependencies are NuGet packages, so to run the application you only need to compile it, to restore NuGet packages.

The persistence system selected is a Json file system. I choose this system for its simplicity, given that the scenario 
is not intensive in data management. Another option could have been use Code-First EF. Data is saved in the App_Data of the Server project

The solution comes with tests over the useCases and the controllers, by using the SelfHost NuGet package, 
which allows you to test web requests against localhost. Open the solution with ADMIN RIGHTS is NEEDED to run the tests.

I reuse the domain entities for the persistence layer to speed up the development. Of course would have been better to create 
a data layer in the persistence project and map data entities to domain entities (via AutoMapper for instance).