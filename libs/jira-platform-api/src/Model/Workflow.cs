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
    /// Details about a workflow.
    /// </summary>
    [DataContract(Name = "Workflow")]
    public partial class Workflow : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Workflow" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Workflow() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Workflow" /> class.
        /// </summary>
        /// <param name="created">The creation date of the workflow..</param>
        /// <param name="description">The description of the workflow. (required).</param>
        /// <param name="hasDraftWorkflow">Whether the workflow has a draft version..</param>
        /// <param name="id">id (required).</param>
        /// <param name="isDefault">Whether this is the default workflow..</param>
        /// <param name="operations">operations.</param>
        /// <param name="projects">The projects the workflow is assigned to, through workflow schemes..</param>
        /// <param name="schemes">The workflow schemes the workflow is assigned to..</param>
        /// <param name="statuses">The statuses of the workflow..</param>
        /// <param name="transitions">The transitions of the workflow..</param>
        /// <param name="updated">The last edited date of the workflow..</param>
        public Workflow(DateTime created = default(DateTime), string description = default(string), bool hasDraftWorkflow = default(bool), PublishedWorkflowId id = default(PublishedWorkflowId), bool isDefault = default(bool), WorkflowOperations operations = default(WorkflowOperations), List<ProjectDetails> projects = default(List<ProjectDetails>), List<WorkflowSchemeIdName> schemes = default(List<WorkflowSchemeIdName>), List<WorkflowStatus> statuses = default(List<WorkflowStatus>), List<Transition> transitions = default(List<Transition>), DateTime updated = default(DateTime))
        {
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for Workflow and cannot be null");
            }
            this.Description = description;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for Workflow and cannot be null");
            }
            this.Id = id;
            this.Created = created;
            this.HasDraftWorkflow = hasDraftWorkflow;
            this.IsDefault = isDefault;
            this.Operations = operations;
            this.Projects = projects;
            this.Schemes = schemes;
            this.Statuses = statuses;
            this.Transitions = transitions;
            this.Updated = updated;
        }

        /// <summary>
        /// The creation date of the workflow.
        /// </summary>
        /// <value>The creation date of the workflow.</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime Created { get; set; }

        /// <summary>
        /// The description of the workflow.
        /// </summary>
        /// <value>The description of the workflow.</value>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Whether the workflow has a draft version.
        /// </summary>
        /// <value>Whether the workflow has a draft version.</value>
        [DataMember(Name = "hasDraftWorkflow", EmitDefaultValue = true)]
        public bool HasDraftWorkflow { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public PublishedWorkflowId Id { get; set; }

        /// <summary>
        /// Whether this is the default workflow.
        /// </summary>
        /// <value>Whether this is the default workflow.</value>
        [DataMember(Name = "isDefault", EmitDefaultValue = true)]
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or Sets Operations
        /// </summary>
        [DataMember(Name = "operations", EmitDefaultValue = false)]
        public WorkflowOperations Operations { get; set; }

        /// <summary>
        /// The projects the workflow is assigned to, through workflow schemes.
        /// </summary>
        /// <value>The projects the workflow is assigned to, through workflow schemes.</value>
        [DataMember(Name = "projects", EmitDefaultValue = false)]
        public List<ProjectDetails> Projects { get; set; }

        /// <summary>
        /// The workflow schemes the workflow is assigned to.
        /// </summary>
        /// <value>The workflow schemes the workflow is assigned to.</value>
        [DataMember(Name = "schemes", EmitDefaultValue = false)]
        public List<WorkflowSchemeIdName> Schemes { get; set; }

        /// <summary>
        /// The statuses of the workflow.
        /// </summary>
        /// <value>The statuses of the workflow.</value>
        [DataMember(Name = "statuses", EmitDefaultValue = false)]
        public List<WorkflowStatus> Statuses { get; set; }

        /// <summary>
        /// The transitions of the workflow.
        /// </summary>
        /// <value>The transitions of the workflow.</value>
        [DataMember(Name = "transitions", EmitDefaultValue = false)]
        public List<Transition> Transitions { get; set; }

        /// <summary>
        /// The last edited date of the workflow.
        /// </summary>
        /// <value>The last edited date of the workflow.</value>
        [DataMember(Name = "updated", EmitDefaultValue = false)]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Workflow {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  HasDraftWorkflow: ").Append(HasDraftWorkflow).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsDefault: ").Append(IsDefault).Append("\n");
            sb.Append("  Operations: ").Append(Operations).Append("\n");
            sb.Append("  Projects: ").Append(Projects).Append("\n");
            sb.Append("  Schemes: ").Append(Schemes).Append("\n");
            sb.Append("  Statuses: ").Append(Statuses).Append("\n");
            sb.Append("  Transitions: ").Append(Transitions).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
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