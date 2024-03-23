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
    /// A project and issueType ID pair that identifies a status mapping.
    /// </summary>
    [DataContract(Name = "ProjectAndIssueTypePair")]
    public partial class ProjectAndIssueTypePair : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectAndIssueTypePair" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProjectAndIssueTypePair() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectAndIssueTypePair" /> class.
        /// </summary>
        /// <param name="issueTypeId">The ID of the issue type. (required).</param>
        /// <param name="projectId">The ID of the project. (required).</param>
        public ProjectAndIssueTypePair(string issueTypeId = default(string), string projectId = default(string))
        {
            // to ensure "issueTypeId" is required (not null)
            if (issueTypeId == null)
            {
                throw new ArgumentNullException("issueTypeId is a required property for ProjectAndIssueTypePair and cannot be null");
            }
            this.IssueTypeId = issueTypeId;
            // to ensure "projectId" is required (not null)
            if (projectId == null)
            {
                throw new ArgumentNullException("projectId is a required property for ProjectAndIssueTypePair and cannot be null");
            }
            this.ProjectId = projectId;
        }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        /// <value>The ID of the issue type.</value>
        [DataMember(Name = "issueTypeId", IsRequired = true, EmitDefaultValue = true)]
        public string IssueTypeId { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        /// <value>The ID of the project.</value>
        [DataMember(Name = "projectId", IsRequired = true, EmitDefaultValue = true)]
        public string ProjectId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProjectAndIssueTypePair {\n");
            sb.Append("  IssueTypeId: ").Append(IssueTypeId).Append("\n");
            sb.Append("  ProjectId: ").Append(ProjectId).Append("\n");
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
