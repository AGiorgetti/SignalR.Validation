using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SignalR.Validation
{
    public class ValidationError
    {
        /// <summary>
        /// nome del parametro
        /// </summary>
        public string ParamName { get; set; }

        /// <summary>
        /// tipo dell'entità che ha generato l'errore
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// Key = nome nel campo che ha fallito la validazione
        /// Value = messaggio di validazione fallita
        /// </summary>
        public dynamic Errors { get; set; }
    }

    internal static class ValidationErrorsFactory
    {
        public static ValidationError Buildup(string paramName, object invalidObject, List<ValidationResult> errs)
        {
            ValidationError obj = new ValidationError();

            obj.ParamName = paramName;
            
            obj.EntityType = invalidObject.GetType().ToString();

            dynamic errors = new JObject();

            foreach (var err in errs)
            {
                errors[err.MemberNames.First()] = err.ErrorMessage;
            }

            obj.Errors = errors;

            return obj;
        }
    }
}
