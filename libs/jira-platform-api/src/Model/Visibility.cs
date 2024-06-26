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
    /// The group or role to which this item is visible.
    /// </summary>
    [DataContract(Name = "Visibility")]
    public partial class Visibility : IValidatableObject
    {
        /// <summary>
        /// Whether visibility of this item is restricted to a group or role.
        /// </summary>
        /// <value>Whether visibility of this item is restricted to a group or role.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Group for value: group
            /// </summary>
            [EnumMember(Value = "group")]
            Group = 1,

            /// <summary>
            /// Enum Role for value: role
            /// </summary>
            [EnumMember(Value = "role")]
            Role = 2
        }


        /// <summary>
        /// Whether visibility of this item is restricted to a group or role.
        /// </summary>
        /// <value>Whether visibility of this item is restricted to a group or role.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Visibility" /> class.
        /// </summary>
        /// <param name="identifier">The ID of the group or the name of the role that visibility of this item is restricted to..</param>
        /// <param name="type">Whether visibility of this item is restricted to a group or role..</param>
        /// <param name="value">The name of the group or role that visibility of this item is restricted to. Please note that the name of a group is mutable, to reliably identify a group use &#x60;identifier&#x60;..</param>
        public Visibility(string identifier = default(string), TypeEnum? type = default(TypeEnum?), string value = default(string))
        {
            this.Identifier = identifier;
            this.Type = type;
            this.Value = value;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// The ID of the group or the name of the role that visibility of this item is restricted to.
        /// </summary>
        /// <value>The ID of the group or the name of the role that visibility of this item is restricted to.</value>
        [DataMember(Name = "identifier", EmitDefaultValue = true)]
        public string Identifier { get; set; }

        /// <summary>
        /// The name of the group or role that visibility of this item is restricted to. Please note that the name of a group is mutable, to reliably identify a group use &#x60;identifier&#x60;.
        /// </summary>
        /// <value>The name of the group or role that visibility of this item is restricted to. Please note that the name of a group is mutable, to reliably identify a group use &#x60;identifier&#x60;.</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Visibility {\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
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
