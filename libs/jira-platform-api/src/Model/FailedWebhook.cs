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
    /// Details about a failed webhook.
    /// </summary>
    [DataContract(Name = "FailedWebhook")]
    public partial class FailedWebhook : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedWebhook" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FailedWebhook() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedWebhook" /> class.
        /// </summary>
        /// <param name="body">The webhook body..</param>
        /// <param name="failureTime">The time the webhook was added to the list of failed webhooks (that is, the time of the last failed retry). (required).</param>
        /// <param name="id">The webhook ID, as sent in the &#x60;X-Atlassian-Webhook-Identifier&#x60; header with the webhook. (required).</param>
        /// <param name="url">The original webhook destination. (required).</param>
        public FailedWebhook(string body = default(string), long failureTime = default(long), string id = default(string), string url = default(string))
        {
            this.FailureTime = failureTime;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for FailedWebhook and cannot be null");
            }
            this.Id = id;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for FailedWebhook and cannot be null");
            }
            this.Url = url;
            this.Body = body;
        }

        /// <summary>
        /// The webhook body.
        /// </summary>
        /// <value>The webhook body.</value>
        [DataMember(Name = "body", EmitDefaultValue = false)]
        public string Body { get; set; }

        /// <summary>
        /// The time the webhook was added to the list of failed webhooks (that is, the time of the last failed retry).
        /// </summary>
        /// <value>The time the webhook was added to the list of failed webhooks (that is, the time of the last failed retry).</value>
        [DataMember(Name = "failureTime", IsRequired = true, EmitDefaultValue = true)]
        public long FailureTime { get; set; }

        /// <summary>
        /// The webhook ID, as sent in the &#x60;X-Atlassian-Webhook-Identifier&#x60; header with the webhook.
        /// </summary>
        /// <value>The webhook ID, as sent in the &#x60;X-Atlassian-Webhook-Identifier&#x60; header with the webhook.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The original webhook destination.
        /// </summary>
        /// <value>The original webhook destination.</value>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public string Url { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FailedWebhook {\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  FailureTime: ").Append(FailureTime).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
