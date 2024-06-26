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
    /// A list of issues and their respective properties to set or update. See [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/) for more information.
    /// </summary>
    [DataContract(Name = "MultiIssueEntityProperties")]
    public partial class MultiIssueEntityProperties : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiIssueEntityProperties" /> class.
        /// </summary>
        /// <param name="issues">A list of issue IDs and their respective properties..</param>
        public MultiIssueEntityProperties(List<IssueEntityPropertiesForMultiUpdate> issues = default(List<IssueEntityPropertiesForMultiUpdate>))
        {
            this.Issues = issues;
        }

        /// <summary>
        /// A list of issue IDs and their respective properties.
        /// </summary>
        /// <value>A list of issue IDs and their respective properties.</value>
        [DataMember(Name = "issues", EmitDefaultValue = false)]
        public List<IssueEntityPropertiesForMultiUpdate> Issues { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MultiIssueEntityProperties {\n");
            sb.Append("  Issues: ").Append(Issues).Append("\n");
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
