using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Validation
{
    /// <summary>
    /// Interface to be implemented by <see cref="System.Attribute"/>s that can validate the parameters of an invocation of <see cref="IHub"/> methods.
    /// </summary>
    public interface IValidateHubMethodInvocation
    {
        /// <summary>
        /// Given a <see cref="IHubIncomingInvokerContext"/>, validate all the passed in parameters to determine if it is authorized to invoke the <see cref="IHub"/> method.
        /// </summary>
        /// <param name="hubIncomingInvokerContext">An <see cref="IHubIncomingInvokerContext"/> providing details regarding the <see cref="IHub"/> method invocation.</param>
        /// <returns>true if the caller is authorized to invoke the <see cref="IHub"/> method; otherwise, false.</returns>
        IEnumerable<ValidationError> ValidateHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext);
    }
}
