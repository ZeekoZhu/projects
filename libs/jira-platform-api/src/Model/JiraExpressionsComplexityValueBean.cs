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
    /// JiraExpressionsComplexityValueBean
    /// </summary>
    [DataContract(Name = "JiraExpressionsComplexityValueBean")]
    public partial class JiraExpressionsComplexityValueBean : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JiraExpressionsComplexityValueBean" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JiraExpressionsComplexityValueBean() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JiraExpressionsComplexityValueBean" /> class.
        /// </summary>
        /// <param name="limit">The maximum allowed complexity. The evaluation will fail if this value is exceeded. (required).</param>
        /// <param name="value">The complexity value of the current expression. (required).</param>
        public JiraExpressionsComplexityValueBean(int limit = default(int), int value = default(int))
        {
            this.Limit = limit;
            this.Value = value;
        }

        /// <summary>
        /// The maximum allowed complexity. The evaluation will fail if this value is exceeded.
        /// </summary>
        /// <value>The maximum allowed complexity. The evaluation will fail if this value is exceeded.</value>
        [DataMember(Name = "limit", IsRequired = true, EmitDefaultValue = true)]
        public int Limit { get; set; }

        /// <summary>
        /// The complexity value of the current expression.
        /// </summary>
        /// <value>The complexity value of the current expression.</value>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public int Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JiraExpressionsComplexityValueBean {\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
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