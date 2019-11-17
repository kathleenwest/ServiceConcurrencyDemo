using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceConcurrencyDemo
{
    /// <summary>
    /// Interface for Service
    /// A simple test service that simulates a long running process
    /// </summary>
    [ServiceContract]
    public interface ITestService
    {
        /// <summary>
        /// TestMethod
        /// Simulates a long running process on a service
        /// </summary>
        /// <returns>the TotalMilliseconds (int) spent in the service method</returns>
        [OperationContract]
        int TestMethod();

    } // end of class
} // end of namespace
