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
    /// The default value for a multi-select custom field.
    /// </summary>
    [DataContract(Name = "CustomFieldContextDefaultValueMultipleOption")]
    public partial class CustomFieldContextDefaultValueMultipleOption : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldContextDefaultValueMultipleOption" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CustomFieldContextDefaultValueMultipleOption() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldContextDefaultValueMultipleOption" /> class.
        /// </summary>
        /// <param name="contextId">The ID of the context. (required).</param>
        /// <param name="optionIds">The list of IDs of the default options. (required).</param>
        /// <param name="type">type (required).</param>
        public CustomFieldContextDefaultValueMultipleOption(string contextId = default(string), List<string> optionIds = default(List<string>), string type = default(string))
        {
            // to ensure "contextId" is required (not null)
            if (contextId == null)
            {
                throw new ArgumentNullException("contextId is a required property for CustomFieldContextDefaultValueMultipleOption and cannot be null");
            }
            this.ContextId = contextId;
            // to ensure "optionIds" is required (not null)
            if (optionIds == null)
            {
                throw new ArgumentNullException("optionIds is a required property for CustomFieldContextDefaultValueMultipleOption and cannot be null");
            }
            this.OptionIds = optionIds;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for CustomFieldContextDefaultValueMultipleOption and cannot be null");
            }
            this.Type = type;
        }

        /// <summary>
        /// The ID of the context.
        /// </summary>
        /// <value>The ID of the context.</value>
        [DataMember(Name = "contextId", IsRequired = true, EmitDefaultValue = true)]
        public string ContextId { get; set; }

        /// <summary>
        /// The list of IDs of the default options.
        /// </summary>
        /// <value>The list of IDs of the default options.</value>
        [DataMember(Name = "optionIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> OptionIds { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomFieldContextDefaultValueMultipleOption {\n");
            sb.Append("  ContextId: ").Append(ContextId).Append("\n");
            sb.Append("  OptionIds: ").Append(OptionIds).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
