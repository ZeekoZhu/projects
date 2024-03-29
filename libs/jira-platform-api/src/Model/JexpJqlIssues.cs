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
    /// The JQL specifying the issues available in the evaluated Jira expression under the &#x60;issues&#x60; context variable. Not all issues returned by the JQL query are loaded, only those described by the &#x60;startAt&#x60; and &#x60;maxResults&#x60; properties. To determine whether it is necessary to iterate to ensure all the issues returned by the JQL query are evaluated, inspect &#x60;meta.issues.jql.count&#x60; in the response.
    /// </summary>
    [DataContract(Name = "JexpJqlIssues")]
    public partial class JexpJqlIssues : IValidatableObject
    {
        /// <summary>
        /// Determines how to validate the JQL query and treat the validation results.
        /// </summary>
        /// <value>Determines how to validate the JQL query and treat the validation results.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ValidationEnum
        {
            /// <summary>
            /// Enum Strict for value: strict
            /// </summary>
            [EnumMember(Value = "strict")]
            Strict = 1,

            /// <summary>
            /// Enum Warn for value: warn
            /// </summary>
            [EnumMember(Value = "warn")]
            Warn = 2,

            /// <summary>
            /// Enum None for value: none
            /// </summary>
            [EnumMember(Value = "none")]
            None = 3
        }


        /// <summary>
        /// Determines how to validate the JQL query and treat the validation results.
        /// </summary>
        /// <value>Determines how to validate the JQL query and treat the validation results.</value>
        [DataMember(Name = "validation", EmitDefaultValue = false)]
        public ValidationEnum? Validation { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="JexpJqlIssues" /> class.
        /// </summary>
        /// <param name="maxResults">The maximum number of issues to return from the JQL query. Inspect &#x60;meta.issues.jql.maxResults&#x60; in the response to ensure the maximum value has not been exceeded..</param>
        /// <param name="query">The JQL query..</param>
        /// <param name="startAt">The index of the first issue to return from the JQL query..</param>
        /// <param name="validation">Determines how to validate the JQL query and treat the validation results. (default to ValidationEnum.Strict).</param>
        public JexpJqlIssues(int maxResults = default(int), string query = default(string), long startAt = default(long), ValidationEnum? validation = ValidationEnum.Strict)
        {
            this.MaxResults = maxResults;
            this.Query = query;
            this.StartAt = startAt;
            this.Validation = validation;
        }

        /// <summary>
        /// The maximum number of issues to return from the JQL query. Inspect &#x60;meta.issues.jql.maxResults&#x60; in the response to ensure the maximum value has not been exceeded.
        /// </summary>
        /// <value>The maximum number of issues to return from the JQL query. Inspect &#x60;meta.issues.jql.maxResults&#x60; in the response to ensure the maximum value has not been exceeded.</value>
        [DataMember(Name = "maxResults", EmitDefaultValue = false)]
        public int MaxResults { get; set; }

        /// <summary>
        /// The JQL query.
        /// </summary>
        /// <value>The JQL query.</value>
        [DataMember(Name = "query", EmitDefaultValue = false)]
        public string Query { get; set; }

        /// <summary>
        /// The index of the first issue to return from the JQL query.
        /// </summary>
        /// <value>The index of the first issue to return from the JQL query.</value>
        [DataMember(Name = "startAt", EmitDefaultValue = false)]
        public long StartAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JexpJqlIssues {\n");
            sb.Append("  MaxResults: ").Append(MaxResults).Append("\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
            sb.Append("  StartAt: ").Append(StartAt).Append("\n");
            sb.Append("  Validation: ").Append(Validation).Append("\n");
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