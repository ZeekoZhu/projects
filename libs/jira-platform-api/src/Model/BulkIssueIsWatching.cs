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
    /// A container for the watch status of a list of issues.
    /// </summary>
    [DataContract(Name = "BulkIssueIsWatching")]
    public partial class BulkIssueIsWatching : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkIssueIsWatching" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public BulkIssueIsWatching()
        {
        }

        /// <summary>
        /// The map of issue ID to boolean watch status.
        /// </summary>
        /// <value>The map of issue ID to boolean watch status.</value>
        [DataMember(Name = "issuesIsWatching", EmitDefaultValue = false)]
        public Dictionary<string, bool> IssuesIsWatching { get; private set; }

        /// <summary>
        /// Returns false as IssuesIsWatching should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIssuesIsWatching()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BulkIssueIsWatching {\n");
            sb.Append("  IssuesIsWatching: ").Append(IssuesIsWatching).Append("\n");
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