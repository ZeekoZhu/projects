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
    /// The date the refreshed webhooks expire.
    /// </summary>
    [DataContract(Name = "WebhooksExpirationDate")]
    public partial class WebhooksExpirationDate : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhooksExpirationDate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public WebhooksExpirationDate()
        {
        }

        /// <summary>
        /// The expiration date of all the refreshed webhooks.
        /// </summary>
        /// <value>The expiration date of all the refreshed webhooks.</value>
        [DataMember(Name = "expirationDate", IsRequired = true, EmitDefaultValue = true)]
        public long ExpirationDate { get; private set; }

        /// <summary>
        /// Returns false as ExpirationDate should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeExpirationDate()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WebhooksExpirationDate {\n");
            sb.Append("  ExpirationDate: ").Append(ExpirationDate).Append("\n");
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
