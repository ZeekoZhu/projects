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
    /// SecuritySchemeLevelMemberBean
    /// </summary>
    [DataContract(Name = "SecuritySchemeLevelMemberBean")]
    public partial class SecuritySchemeLevelMemberBean : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecuritySchemeLevelMemberBean" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SecuritySchemeLevelMemberBean() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SecuritySchemeLevelMemberBean" /> class.
        /// </summary>
        /// <param name="varParameter">The value corresponding to the specified member type..</param>
        /// <param name="type">The issue security level member type, e.g &#x60;reporter&#x60;, &#x60;group&#x60;, &#x60;user&#x60;. (required).</param>
        public SecuritySchemeLevelMemberBean(string varParameter = default(string), string type = default(string))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for SecuritySchemeLevelMemberBean and cannot be null");
            }
            this.Type = type;
            this.VarParameter = varParameter;
        }

        /// <summary>
        /// The value corresponding to the specified member type.
        /// </summary>
        /// <value>The value corresponding to the specified member type.</value>
        [DataMember(Name = "parameter", EmitDefaultValue = false)]
        public string VarParameter { get; set; }

        /// <summary>
        /// The issue security level member type, e.g &#x60;reporter&#x60;, &#x60;group&#x60;, &#x60;user&#x60;.
        /// </summary>
        /// <value>The issue security level member type, e.g &#x60;reporter&#x60;, &#x60;group&#x60;, &#x60;user&#x60;.</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SecuritySchemeLevelMemberBean {\n");
            sb.Append("  VarParameter: ").Append(VarParameter).Append("\n");
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
