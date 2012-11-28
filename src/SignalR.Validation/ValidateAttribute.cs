using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Validation
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public sealed class ValidateAttribute : Attribute, IValidateHubMethodInvocation
    {
        public IEnumerable<ValidationError> ValidateHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext)
        {
            List<ValidationError> errors = new List<ValidationError>();

            for (int i = 0; i < hubIncomingInvokerContext.Args.Length; ++i)
            {
                var arg = hubIncomingInvokerContext.Args[i];
                ValidationContext ctx = new ValidationContext(arg, null, null);
                List<ValidationResult> results = new List<ValidationResult>();

                bool valid = Validator.TryValidateObject(arg, ctx, results, true);

                if (!valid)
                {
                    ValidationError ve = ValidationErrorsFactory.Buildup(hubIncomingInvokerContext.MethodDescriptor.Parameters[i].Name, arg, results);
                    errors.Add(ve);
                }
            }

            return errors;
        }
    }
}
