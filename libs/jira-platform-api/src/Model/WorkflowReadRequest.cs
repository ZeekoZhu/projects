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
    /// WorkflowReadRequest
    /// </summary>
    [DataContract(Name = "WorkflowReadRequest")]
    public partial class WorkflowReadRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowReadRequest" /> class.
        /// </summary>
        /// <param name="projectAndIssueTypes">The list of projects and issue types to query..</param>
        /// <param name="workflowIds">The list of workflow IDs to query..</param>
        /// <param name="workflowNames">The list of workflow names to query..</param>
        public WorkflowReadRequest(List<ProjectAndIssueTypePair> projectAndIssueTypes = default(List<ProjectAndIssueTypePair>), List<string> workflowIds = default(List<string>), List<string> workflowNames = default(List<string>))
        {
            this.ProjectAndIssueTypes = projectAndIssueTypes;
            this.WorkflowIds = workflowIds;
            this.WorkflowNames = workflowNames;
        }

        /// <summary>
        /// The list of projects and issue types to query.
        /// </summary>
        /// <value>The list of projects and issue types to query.</value>
        [DataMember(Name = "projectAndIssueTypes", EmitDefaultValue = false)]
        public List<ProjectAndIssueTypePair> ProjectAndIssueTypes { get; set; }

        /// <summary>
        /// The list of workflow IDs to query.
        /// </summary>
        /// <value>The list of workflow IDs to query.</value>
        [DataMember(Name = "workflowIds", EmitDefaultValue = false)]
        public List<string> WorkflowIds { get; set; }

        /// <summary>
        /// The list of workflow names to query.
        /// </summary>
        /// <value>The list of workflow names to query.</value>
        [DataMember(Name = "workflowNames", EmitDefaultValue = false)]
        public List<string> WorkflowNames { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowReadRequest {\n");
            sb.Append("  ProjectAndIssueTypes: ").Append(ProjectAndIssueTypes).Append("\n");
            sb.Append("  WorkflowIds: ").Append(WorkflowIds).Append("\n");
            sb.Append("  WorkflowNames: ").Append(WorkflowNames).Append("\n");
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
