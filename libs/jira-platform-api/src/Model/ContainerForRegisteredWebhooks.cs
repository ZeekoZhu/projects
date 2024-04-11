/*
 * The Jira Cloud platform REST API
 *
 * Jira Cloud platform REST API documentation
 *
 * The version of the OpenAPI document: 1001.0.0-SNAPSHOT-9aad01a33a3dae75a5b6aedf98c77d2cbd2f865d
 * Contact: ecosystem@atlassian.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Projects.JiraPlatformApi.Client.OpenAPIDateConverter;

namespace Projects.JiraPlatformApi.Model
{
    /// <summary>
    /// Container for a list of registered webhooks. Webhook details are returned in the same order as the request.
    /// </summary>
    [DataContract(Name = "ContainerForRegisteredWebhooks")]
    public partial class ContainerForRegisteredWebhooks : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerForRegisteredWebhooks" /> class.
        /// </summary>
        /// <param name="webhookRegistrationResult">A list of registered webhooks..</param>
        public ContainerForRegisteredWebhooks(List<RegisteredWebhook> webhookRegistrationResult = default(List<RegisteredWebhook>))
        {
            this.WebhookRegistrationResult = webhookRegistrationResult;
        }

        /// <summary>
        /// A list of registered webhooks.
        /// </summary>
        /// <value>A list of registered webhooks.</value>
        [DataMember(Name = "webhookRegistrationResult", EmitDefaultValue = false)]
        public List<RegisteredWebhook> WebhookRegistrationResult { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContainerForRegisteredWebhooks {\n");
            sb.Append("  WebhookRegistrationResult: ").Append(WebhookRegistrationResult).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
