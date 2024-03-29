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
    /// EntityPropertyDetails
    /// </summary>
    [DataContract(Name = "EntityPropertyDetails")]
    public partial class EntityPropertyDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EntityPropertyDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyDetails" /> class.
        /// </summary>
        /// <param name="entityId">The entity property ID. (required).</param>
        /// <param name="key">The entity property key. (required).</param>
        /// <param name="value">The new value of the entity property. (required).</param>
        public EntityPropertyDetails(decimal entityId = default(decimal), string key = default(string), string value = default(string))
        {
            this.EntityId = entityId;
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new ArgumentNullException("key is a required property for EntityPropertyDetails and cannot be null");
            }
            this.Key = key;
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for EntityPropertyDetails and cannot be null");
            }
            this.Value = value;
        }

        /// <summary>
        /// The entity property ID.
        /// </summary>
        /// <value>The entity property ID.</value>
        /// <example>123</example>
        [DataMember(Name = "entityId", IsRequired = true, EmitDefaultValue = true)]
        public decimal EntityId { get; set; }

        /// <summary>
        /// The entity property key.
        /// </summary>
        /// <value>The entity property key.</value>
        /// <example>mykey</example>
        [DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
        public string Key { get; set; }

        /// <summary>
        /// The new value of the entity property.
        /// </summary>
        /// <value>The new value of the entity property.</value>
        /// <example>newValue</example>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EntityPropertyDetails {\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
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