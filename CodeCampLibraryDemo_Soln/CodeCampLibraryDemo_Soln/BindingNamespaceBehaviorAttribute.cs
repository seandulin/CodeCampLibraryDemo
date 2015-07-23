using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Web;

namespace CodeCampLibraryDemo_Soln
{
    /// <summary>
    /// Attribute which will add a binding namespace to every endpoint it's used in.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class BindingNamespaceBehaviorAttribute : Attribute, IServiceBehavior
    {
        /// <summary>
        /// The binding namespace;
        /// </summary>
        private readonly string bindingNamespace;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingNamespaceBehaviorAttribute"/> class.
        /// </summary>
        /// <param name="bindingNamespace">The binding namespace.</param>
        public BindingNamespaceBehaviorAttribute(string bindingNamespace)
        {
            this.bindingNamespace = bindingNamespace;
        }

        /// <summary>
        /// Gets the binding namespace.
        /// </summary>
        /// <value>The binding namespace.</value>
        public string BindingNamespace
        {
            get
            {
                return this.bindingNamespace;
            }
        }

        /// <summary>
        /// Provides the ability to pass custom data to binding elements to support the contract implementation.
        /// </summary>
        /// <param name="serviceDescription">The service description of the service.</param>
        /// <param name="serviceHostBase">The host of the service.</param>
        /// <param name="endpoints">The service endpoints.</param>
        /// <param name="bindingParameters">Custom objects to which binding elements have access.</param>
        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Provides the ability to change run-time property values or insert custom extension objects such as error
        /// handlers, message or parameter interceptors, security extensions, and other custom extension objects.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The host that is currently being built.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        /// Provides the ability to inspect the service host and the service description to confirm that the service
        /// can run successfully.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host that is currently being constructed.</param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            if (serviceHostBase == null)
            {
                throw new ArgumentNullException("serviceHostBase");
            }

            foreach (var endpoint in serviceHostBase.Description.Endpoints)
            {
                endpoint.Binding.Namespace = this.bindingNamespace;
            }
        }
    }
}