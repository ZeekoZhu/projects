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
    /// Details of the order-by JQL clause.
    /// </summary>
    [DataContract(Name = "JqlQueryOrderByClause")]
    public partial class JqlQueryOrderByClause : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueryOrderByClause" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JqlQueryOrderByClause() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueryOrderByClause" /> class.
        /// </summary>
        /// <param name="fields">The list of order-by clause fields and their ordering directives. (required).</param>
        public JqlQueryOrderByClause(List<JqlQueryOrderByClauseElement> fields = default(List<JqlQueryOrderByClauseElement>))
        {
            // to ensure "fields" is required (not null)
            if (fields == null)
            {
                throw new ArgumentNullException("fields is a required property for JqlQueryOrderByClause and cannot be null");
            }
            this.Fields = fields;
        }

        /// <summary>
        /// The list of order-by clause fields and their ordering directives.
        /// </summary>
        /// <value>The list of order-by clause fields and their ordering directives.</value>
        [DataMember(Name = "fields", IsRequired = true, EmitDefaultValue = true)]
        public List<JqlQueryOrderByClauseElement> Fields { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JqlQueryOrderByClause {\n");
            sb.Append("  Fields: ").Append(Fields).Append("\n");
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
