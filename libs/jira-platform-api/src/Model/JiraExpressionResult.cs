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
    /// The result of evaluating a Jira expression.
    /// </summary>
    [DataContract(Name = "JiraExpressionResult")]
    public partial class JiraExpressionResult : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JiraExpressionResult" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JiraExpressionResult() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JiraExpressionResult" /> class.
        /// </summary>
        /// <param name="meta">Contains various characteristics of the performed expression evaluation..</param>
        /// <param name="value">The value of the evaluated expression. It may be a primitive JSON value or a Jira REST API object. (Some expressions do not produce any meaningful results—for example, an expression that returns a lambda function—if that&#39;s the case a simple string representation is returned. These string representations should not be relied upon and may change without notice.) (required).</param>
        public JiraExpressionResult(JiraExpressionEvaluationMetaDataBean meta = default(JiraExpressionEvaluationMetaDataBean), Object value = default(Object))
        {
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for JiraExpressionResult and cannot be null");
            }
            this.Value = value;
            this.Meta = meta;
        }

        /// <summary>
        /// Contains various characteristics of the performed expression evaluation.
        /// </summary>
        /// <value>Contains various characteristics of the performed expression evaluation.</value>
        [DataMember(Name = "meta", EmitDefaultValue = false)]
        public JiraExpressionEvaluationMetaDataBean Meta { get; set; }

        /// <summary>
        /// The value of the evaluated expression. It may be a primitive JSON value or a Jira REST API object. (Some expressions do not produce any meaningful results—for example, an expression that returns a lambda function—if that&#39;s the case a simple string representation is returned. These string representations should not be relied upon and may change without notice.)
        /// </summary>
        /// <value>The value of the evaluated expression. It may be a primitive JSON value or a Jira REST API object. (Some expressions do not produce any meaningful results—for example, an expression that returns a lambda function—if that&#39;s the case a simple string representation is returned. These string representations should not be relied upon and may change without notice.)</value>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public Object Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JiraExpressionResult {\n");
            sb.Append("  Meta: ").Append(Meta).Append("\n");
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