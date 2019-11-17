# ServiceConcurrencyDemo
 
 Concurrency and Instancing in WCF Services – A Demo of Service Concurrency and Instancing Behaviors with Multi-threading Clients
 
 
 Project Article: https://portfolio.katiegirl.net/2019/11/17/concurrency-and-instancing-in-wcf-services-a-demo-of-service-concurrency-and-instancing-behaviors-with-multi-threading-clients/
 
 
About


This project presents a simple Demo WCF Service and “Tester” Client Application demonstration that implements concurrency and instancing behaviors on a service with multiple client thread calls to a method on the service. The Demo Service is a standard template WCF service application hosted by the development IIS. The service features one simple method… a test method that simulates a long running process (it sleeps for 3 seconds). The client “tester” is a simple console application that creates multiple threads that access the service and report back on the results. The objective of this project was not to demo setup and hosting of a service, nor the client interface, but retrieve and display results of service behaviors with respect to multi-threaded access. Discussion regarding the hosting and setup of the simple IIS hosted service application will be skipped in this project article. 


 
Architecture 

 
The demo project consists of these simple component topics:

•	WCF Service (Hosted by IIS) Application Project “ServiceConcurrencyDemo”

o	ITestService – Interface of Service and Operational Contracts
o	TestService – Implements the Service Interface
o	Web.config (Configuration for Service Hosted on IIS - Generic)


•	Client “Tester to Service” Windows Console Application “MultiThreadClientTester”

o	Service Reference Proxy (WSDL) to WCF Service
o	Program – Creates multiple threads that call the service, records time spent in threads, and reports statistics on the final results in a console window. 

