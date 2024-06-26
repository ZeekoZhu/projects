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
    /// WorkflowSchemeReadResponse
    /// </summary>
    [DataContract(Name = "WorkflowSchemeReadResponse")]
    public partial class WorkflowSchemeReadResponse : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowSchemeReadResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkflowSchemeReadResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowSchemeReadResponse" /> class.
        /// </summary>
        /// <param name="defaultWorkflow">defaultWorkflow.</param>
        /// <param name="description">The description of the workflow scheme..</param>
        /// <param name="id">The ID of the workflow scheme. (required).</param>
        /// <param name="name">The name of the workflow scheme. (required).</param>
        /// <param name="projectIdsUsingScheme">The IDs of projects using the workflow scheme. (required).</param>
        /// <param name="scope">scope (required).</param>
        /// <param name="taskId">Indicates if there&#39;s an [asynchronous task](#async-operations) for this workflow scheme..</param>
        /// <param name="varVersion">varVersion (required).</param>
        /// <param name="workflowsForIssueTypes">Mappings from workflows to issue types. (required).</param>
        public WorkflowSchemeReadResponse(WorkflowMetadataRestModel defaultWorkflow = default(WorkflowMetadataRestModel), string description = default(string), string id = default(string), string name = default(string), List<string> projectIdsUsingScheme = default(List<string>), WorkflowScope scope = default(WorkflowScope), string taskId = default(string), DocumentVersion varVersion = default(DocumentVersion), List<WorkflowMetadataAndIssueTypeRestModel> workflowsForIssueTypes = default(List<WorkflowMetadataAndIssueTypeRestModel>))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for WorkflowSchemeReadResponse and cannot be null");
            }
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for WorkflowSchemeReadResponse and cannot be null");
            }
            this.Name = name;
            // to ensure "projectIdsUsingScheme" is required (not null)
            if (projectIdsUsingScheme == null)
            {
                throw new ArgumentNullException("projectIdsUsingScheme is a required property for WorkflowSchemeReadResponse and cannot be null");
            }
            this.ProjectIdsUsingScheme = projectIdsUsingScheme;
            // to ensure "scope" is required (not null)
            if (scope == null)
            {
                throw new ArgumentNullException("scope is a required property for WorkflowSchemeReadResponse and cannot be null");
            }
            this.Scope = scope;
            // to ensure "varVersion" is required (not null)
            if (varVersion == null)
            {
                throw new ArgumentNullException("varVersion is a required property for WorkflowSchemeReadResponse and cannot be null");
            }
            this.VarVersion = varVersion;
            // to ensure "workflowsForIssueTypes" is required (not null)
            if (workflowsForIssueTypes == null)
            {
                throw new ArgumentNullException("workflowsForIssueTypes is a required property for WorkflowSchemeReadResponse and cannot be null");
            }
            this.WorkflowsForIssueTypes = workflowsForIssueTypes;
            this.DefaultWorkflow = defaultWorkflow;
            this.Description = description;
            this.TaskId = taskId;
        }

        /// <summary>
        /// Gets or Sets DefaultWorkflow
        /// </summary>
        [DataMember(Name = "defaultWorkflow", EmitDefaultValue = false)]
        public WorkflowMetadataRestModel DefaultWorkflow { get; set; }

        /// <summary>
        /// The description of the workflow scheme.
        /// </summary>
        /// <value>The description of the workflow scheme.</value>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the workflow scheme.
        /// </summary>
        /// <value>The ID of the workflow scheme.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the workflow scheme.
        /// </summary>
        /// <value>The name of the workflow scheme.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The IDs of projects using the workflow scheme.
        /// </summary>
        /// <value>The IDs of projects using the workflow scheme.</value>
        [DataMember(Name = "projectIdsUsingScheme", IsRequired = true, EmitDefaultValue = true)]
        public List<string> ProjectIdsUsingScheme { get; set; }

        /// <summary>
        /// Gets or Sets Scope
        /// </summary>
        [DataMember(Name = "scope", IsRequired = true, EmitDefaultValue = true)]
        public WorkflowScope Scope { get; set; }

        /// <summary>
        /// Indicates if there&#39;s an [asynchronous task](#async-operations) for this workflow scheme.
        /// </summary>
        /// <value>Indicates if there&#39;s an [asynchronous task](#async-operations) for this workflow scheme.</value>
        [DataMember(Name = "taskId", EmitDefaultValue = true)]
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or Sets VarVersion
        /// </summary>
        [DataMember(Name = "version", IsRequired = true, EmitDefaultValue = true)]
        public DocumentVersion VarVersion { get; set; }

        /// <summary>
        /// Mappings from workflows to issue types.
        /// </summary>
        /// <value>Mappings from workflows to issue types.</value>
        [DataMember(Name = "workflowsForIssueTypes", IsRequired = true, EmitDefaultValue = true)]
        public List<WorkflowMetadataAndIssueTypeRestModel> WorkflowsForIssueTypes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowSchemeReadResponse {\n");
            sb.Append("  DefaultWorkflow: ").Append(DefaultWorkflow).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ProjectIdsUsingScheme: ").Append(ProjectIdsUsingScheme).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
            sb.Append("  VarVersion: ").Append(VarVersion).Append("\n");
            sb.Append("  WorkflowsForIssueTypes: ").Append(WorkflowsForIssueTypes).Append("\n");
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
