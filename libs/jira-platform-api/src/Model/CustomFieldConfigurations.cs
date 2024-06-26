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
    /// Details of configurations for a custom field.
    /// </summary>
    [DataContract(Name = "CustomFieldConfigurations")]
    public partial class CustomFieldConfigurations : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldConfigurations" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CustomFieldConfigurations() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldConfigurations" /> class.
        /// </summary>
        /// <param name="configurations">The list of custom field configuration details. (required).</param>
        public CustomFieldConfigurations(List<ContextualConfiguration> configurations = default(List<ContextualConfiguration>))
        {
            // to ensure "configurations" is required (not null)
            if (configurations == null)
            {
                throw new ArgumentNullException("configurations is a required property for CustomFieldConfigurations and cannot be null");
            }
            this.Configurations = configurations;
        }

        /// <summary>
        /// The list of custom field configuration details.
        /// </summary>
        /// <value>The list of custom field configuration details.</value>
        [DataMember(Name = "configurations", IsRequired = true, EmitDefaultValue = true)]
        public List<ContextualConfiguration> Configurations { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomFieldConfigurations {\n");
            sb.Append("  Configurations: ").Append(Configurations).Append("\n");
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
