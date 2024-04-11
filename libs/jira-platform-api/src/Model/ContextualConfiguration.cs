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
    /// Details of the contextual configuration for a custom field.
    /// </summary>
    [DataContract(Name = "ContextualConfiguration")]
    public partial class ContextualConfiguration : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualConfiguration" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ContextualConfiguration() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualConfiguration" /> class.
        /// </summary>
        /// <param name="varConfiguration">The field configuration..</param>
        /// <param name="id">The ID of the configuration. (required).</param>
        /// <param name="schema">The field value schema..</param>
        public ContextualConfiguration(Object varConfiguration = default(Object), string id = default(string), Object schema = default(Object))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for ContextualConfiguration and cannot be null");
            }
            this.Id = id;
            this.VarConfiguration = varConfiguration;
            this.Schema = schema;
        }

        /// <summary>
        /// The field configuration.
        /// </summary>
        /// <value>The field configuration.</value>
        [DataMember(Name = "configuration", EmitDefaultValue = true)]
        public Object VarConfiguration { get; set; }

        /// <summary>
        /// The ID of the field context the configuration is associated with.
        /// </summary>
        /// <value>The ID of the field context the configuration is associated with.</value>
        [DataMember(Name = "fieldContextId", IsRequired = true, EmitDefaultValue = true)]
        public string FieldContextId { get; private set; }

        /// <summary>
        /// Returns false as FieldContextId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeFieldContextId()
        {
            return false;
        }
        /// <summary>
        /// The ID of the configuration.
        /// </summary>
        /// <value>The ID of the configuration.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The field value schema.
        /// </summary>
        /// <value>The field value schema.</value>
        [DataMember(Name = "schema", EmitDefaultValue = true)]
        public Object Schema { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContextualConfiguration {\n");
            sb.Append("  VarConfiguration: ").Append(VarConfiguration).Append("\n");
            sb.Append("  FieldContextId: ").Append(FieldContextId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Schema: ").Append(Schema).Append("\n");
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
