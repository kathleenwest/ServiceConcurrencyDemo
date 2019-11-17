using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace ServiceConcurrencyDemo
{
    /// <summary>
    /// TestService
    /// Implements the ITestService Interface
    /// A simple test service that simulates a long running process
    /// Average time in method will be 3 seconds but
    /// depending on the service configuration, the average
    /// total client call time (including time spent in service)
    /// varies based on the configuration.
    /// Test Modes
    /// Concurrency: Multiple | Instance: PerCall  
    /// Concurrency: Multiple | Instance: Single   
    /// Concurrency: Single   | Instance: PerCall  
    /// Concurrency: Single   | Instance: Single   
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class TestService : ITestService
    {
        /// <summary>
        /// TestMethod
        /// Simulates a long running process on a service
        /// </summary>
        /// <returns>the TotalMilliseconds (int) spent in the service method</returns>
        public int TestMethod()
        {
            DateTime start = DateTime.Now;
            Thread.Sleep(3000);
            DateTime end = DateTime.Now;
            return (int)end.Subtract(start).TotalMilliseconds;
        }
    } // end of class
} // end of namespace
