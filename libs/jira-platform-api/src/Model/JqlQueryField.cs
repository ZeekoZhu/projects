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
    /// A field used in a JQL query. See [Advanced searching - fields reference](https://confluence.atlassian.com/x/dAiiLQ) for more information about fields in JQL queries.
    /// </summary>
    [DataContract(Name = "JqlQueryField")]
    public partial class JqlQueryField : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueryField" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JqlQueryField() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueryField" /> class.
        /// </summary>
        /// <param name="encodedName">The encoded name of the field, which can be used directly in a JQL query..</param>
        /// <param name="name">The name of the field. (required).</param>
        /// <param name="property">When the field refers to a value in an entity property, details of the entity property value..</param>
        public JqlQueryField(string encodedName = default(string), string name = default(string), List<JqlQueryFieldEntityProperty> property = default(List<JqlQueryFieldEntityProperty>))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for JqlQueryField and cannot be null");
            }
            this.Name = name;
            this.EncodedName = encodedName;
            this.Property = property;
        }

        /// <summary>
        /// The encoded name of the field, which can be used directly in a JQL query.
        /// </summary>
        /// <value>The encoded name of the field, which can be used directly in a JQL query.</value>
        [DataMember(Name = "encodedName", EmitDefaultValue = false)]
        public string EncodedName { get; set; }

        /// <summary>
        /// The name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// When the field refers to a value in an entity property, details of the entity property value.
        /// </summary>
        /// <value>When the field refers to a value in an entity property, details of the entity property value.</value>
        [DataMember(Name = "property", EmitDefaultValue = false)]
        public List<JqlQueryFieldEntityProperty> Property { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JqlQueryField {\n");
            sb.Append("  EncodedName: ").Append(EncodedName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Property: ").Append(Property).Append("\n");
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
