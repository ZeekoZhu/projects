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
    /// The list of statuses that will be updated.
    /// </summary>
    [DataContract(Name = "StatusUpdateRequest")]
    public partial class StatusUpdateRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusUpdateRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected StatusUpdateRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusUpdateRequest" /> class.
        /// </summary>
        /// <param name="statuses">The list of statuses that will be updated. (required).</param>
        public StatusUpdateRequest(List<StatusUpdate> statuses = default(List<StatusUpdate>))
        {
            // to ensure "statuses" is required (not null)
            if (statuses == null)
            {
                throw new ArgumentNullException("statuses is a required property for StatusUpdateRequest and cannot be null");
            }
            this.Statuses = statuses;
        }

        /// <summary>
        /// The list of statuses that will be updated.
        /// </summary>
        /// <value>The list of statuses that will be updated.</value>
        [DataMember(Name = "statuses", IsRequired = true, EmitDefaultValue = true)]
        public List<StatusUpdate> Statuses { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StatusUpdateRequest {\n");
            sb.Append("  Statuses: ").Append(Statuses).Append("\n");
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
