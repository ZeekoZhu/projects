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
    /// Details of a custom field option to create.
    /// </summary>
    [DataContract(Name = "CustomFieldOptionCreate")]
    public partial class CustomFieldOptionCreate : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldOptionCreate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CustomFieldOptionCreate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldOptionCreate" /> class.
        /// </summary>
        /// <param name="disabled">Whether the option is disabled..</param>
        /// <param name="optionId">For cascading options, the ID of the custom field object containing the cascading option..</param>
        /// <param name="value">The value of the custom field option. (required).</param>
        public CustomFieldOptionCreate(bool disabled = default(bool), string optionId = default(string), string value = default(string))
        {
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for CustomFieldOptionCreate and cannot be null");
            }
            this.Value = value;
            this.Disabled = disabled;
            this.OptionId = optionId;
        }

        /// <summary>
        /// Whether the option is disabled.
        /// </summary>
        /// <value>Whether the option is disabled.</value>
        [DataMember(Name = "disabled", EmitDefaultValue = true)]
        public bool Disabled { get; set; }

        /// <summary>
        /// For cascading options, the ID of the custom field object containing the cascading option.
        /// </summary>
        /// <value>For cascading options, the ID of the custom field object containing the cascading option.</value>
        [DataMember(Name = "optionId", EmitDefaultValue = false)]
        public string OptionId { get; set; }

        /// <summary>
        /// The value of the custom field option.
        /// </summary>
        /// <value>The value of the custom field option.</value>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomFieldOptionCreate {\n");
            sb.Append("  Disabled: ").Append(Disabled).Append("\n");
            sb.Append("  OptionId: ").Append(OptionId).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
