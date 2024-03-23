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
    /// A change item.
    /// </summary>
    [DataContract(Name = "ChangeDetails")]
    public partial class ChangeDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public ChangeDetails()
        {
        }

        /// <summary>
        /// The name of the field changed.
        /// </summary>
        /// <value>The name of the field changed.</value>
        [DataMember(Name = "field", EmitDefaultValue = false)]
        public string Field { get; private set; }

        /// <summary>
        /// Returns false as Field should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeField()
        {
            return false;
        }
        /// <summary>
        /// The ID of the field changed.
        /// </summary>
        /// <value>The ID of the field changed.</value>
        [DataMember(Name = "fieldId", EmitDefaultValue = false)]
        public string FieldId { get; private set; }

        /// <summary>
        /// Returns false as FieldId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeFieldId()
        {
            return false;
        }
        /// <summary>
        /// The type of the field changed.
        /// </summary>
        /// <value>The type of the field changed.</value>
        [DataMember(Name = "fieldtype", EmitDefaultValue = false)]
        public string Fieldtype { get; private set; }

        /// <summary>
        /// Returns false as Fieldtype should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeFieldtype()
        {
            return false;
        }
        /// <summary>
        /// The details of the original value.
        /// </summary>
        /// <value>The details of the original value.</value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public string From { get; private set; }

        /// <summary>
        /// Returns false as From should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeFrom()
        {
            return false;
        }
        /// <summary>
        /// The details of the original value as a string.
        /// </summary>
        /// <value>The details of the original value as a string.</value>
        [DataMember(Name = "fromString", EmitDefaultValue = false)]
        public string FromString { get; private set; }

        /// <summary>
        /// Returns false as FromString should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeFromString()
        {
            return false;
        }
        /// <summary>
        /// The details of the new value.
        /// </summary>
        /// <value>The details of the new value.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; private set; }

        /// <summary>
        /// Returns false as To should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeTo()
        {
            return false;
        }
        /// <summary>
        /// The details of the new value as a string.
        /// </summary>
        /// <value>The details of the new value as a string.</value>
        [DataMember(Name = "toString", EmitDefaultValue = false)]
        public string PropertyToString { get; private set; }

        /// <summary>
        /// Returns false as PropertyToString should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePropertyToString()
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
            sb.Append("class ChangeDetails {\n");
            sb.Append("  Field: ").Append(Field).Append("\n");
            sb.Append("  FieldId: ").Append(FieldId).Append("\n");
            sb.Append("  Fieldtype: ").Append(Fieldtype).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  FromString: ").Append(FromString).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  PropertyToString: ").Append(PropertyToString).Append("\n");
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
