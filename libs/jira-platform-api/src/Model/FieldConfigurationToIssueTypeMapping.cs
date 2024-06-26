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
    /// The field configuration to issue type mapping.
    /// </summary>
    [DataContract(Name = "FieldConfigurationToIssueTypeMapping")]
    public partial class FieldConfigurationToIssueTypeMapping : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldConfigurationToIssueTypeMapping" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FieldConfigurationToIssueTypeMapping() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldConfigurationToIssueTypeMapping" /> class.
        /// </summary>
        /// <param name="fieldConfigurationId">The ID of the field configuration. (required).</param>
        /// <param name="issueTypeId">The ID of the issue type or *default*. When set to *default* this field configuration issue type item applies to all issue types without a field configuration. An issue type can be included only once in a request. (required).</param>
        public FieldConfigurationToIssueTypeMapping(string fieldConfigurationId = default(string), string issueTypeId = default(string))
        {
            // to ensure "fieldConfigurationId" is required (not null)
            if (fieldConfigurationId == null)
            {
                throw new ArgumentNullException("fieldConfigurationId is a required property for FieldConfigurationToIssueTypeMapping and cannot be null");
            }
            this.FieldConfigurationId = fieldConfigurationId;
            // to ensure "issueTypeId" is required (not null)
            if (issueTypeId == null)
            {
                throw new ArgumentNullException("issueTypeId is a required property for FieldConfigurationToIssueTypeMapping and cannot be null");
            }
            this.IssueTypeId = issueTypeId;
        }

        /// <summary>
        /// The ID of the field configuration.
        /// </summary>
        /// <value>The ID of the field configuration.</value>
        [DataMember(Name = "fieldConfigurationId", IsRequired = true, EmitDefaultValue = true)]
        public string FieldConfigurationId { get; set; }

        /// <summary>
        /// The ID of the issue type or *default*. When set to *default* this field configuration issue type item applies to all issue types without a field configuration. An issue type can be included only once in a request.
        /// </summary>
        /// <value>The ID of the issue type or *default*. When set to *default* this field configuration issue type item applies to all issue types without a field configuration. An issue type can be included only once in a request.</value>
        [DataMember(Name = "issueTypeId", IsRequired = true, EmitDefaultValue = true)]
        public string IssueTypeId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FieldConfigurationToIssueTypeMapping {\n");
            sb.Append("  FieldConfigurationId: ").Append(FieldConfigurationId).Append("\n");
            sb.Append("  IssueTypeId: ").Append(IssueTypeId).Append("\n");
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
