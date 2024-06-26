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
    /// Details of a field configuration.
    /// </summary>
    [DataContract(Name = "FieldConfiguration")]
    public partial class FieldConfiguration : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldConfiguration" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FieldConfiguration() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldConfiguration" /> class.
        /// </summary>
        /// <param name="description">The description of the field configuration. (required).</param>
        /// <param name="id">The ID of the field configuration. (required).</param>
        /// <param name="isDefault">Whether the field configuration is the default..</param>
        /// <param name="name">The name of the field configuration. (required).</param>
        public FieldConfiguration(string description = default(string), long id = default(long), bool isDefault = default(bool), string name = default(string))
        {
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for FieldConfiguration and cannot be null");
            }
            this.Description = description;
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for FieldConfiguration and cannot be null");
            }
            this.Name = name;
            this.IsDefault = isDefault;
        }

        /// <summary>
        /// The description of the field configuration.
        /// </summary>
        /// <value>The description of the field configuration.</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the field configuration.
        /// </summary>
        /// <value>The ID of the field configuration.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public long Id { get; set; }

        /// <summary>
        /// Whether the field configuration is the default.
        /// </summary>
        /// <value>Whether the field configuration is the default.</value>
        [DataMember(Name = "isDefault", EmitDefaultValue = true)]
        public bool IsDefault { get; set; }

        /// <summary>
        /// The name of the field configuration.
        /// </summary>
        /// <value>The name of the field configuration.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FieldConfiguration {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsDefault: ").Append(IsDefault).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
