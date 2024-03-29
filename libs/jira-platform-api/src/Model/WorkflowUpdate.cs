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
    /// The details of the workflows to update.
    /// </summary>
    [DataContract(Name = "WorkflowUpdate")]
    public partial class WorkflowUpdate : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowUpdate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkflowUpdate()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowUpdate" /> class.
        /// </summary>
        /// <param name="defaultStatusMappings">The mapping of old to new status ID..</param>
        /// <param name="description">The new description for this workflow..</param>
        /// <param name="id">The ID of this workflow. (required).</param>
        /// <param name="startPointLayout">startPointLayout.</param>
        /// <param name="statusMappings">The mapping of old to new status ID for a specific project and issue type..</param>
        /// <param name="statuses">The statuses associated with this workflow. (required).</param>
        /// <param name="transitions">The transitions of this workflow. (required).</param>
        /// <param name="varVersion">varVersion (required).</param>
        public WorkflowUpdate(List<StatusMigration> defaultStatusMappings = default(List<StatusMigration>), string description = default(string), string id = default(string), WorkflowLayout startPointLayout = default(WorkflowLayout), List<StatusMappingDTO> statusMappings = default(List<StatusMappingDTO>), List<StatusLayoutUpdate> statuses = default(List<StatusLayoutUpdate>), List<TransitionUpdateDTO> transitions = default(List<TransitionUpdateDTO>), DocumentVersion varVersion = default(DocumentVersion))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for WorkflowUpdate and cannot be null");
            }
            this.Id = id;
            // to ensure "statuses" is required (not null)
            if (statuses == null)
            {
                throw new ArgumentNullException("statuses is a required property for WorkflowUpdate and cannot be null");
            }
            this.Statuses = statuses;
            // to ensure "transitions" is required (not null)
            if (transitions == null)
            {
                throw new ArgumentNullException("transitions is a required property for WorkflowUpdate and cannot be null");
            }
            this.Transitions = transitions;
            // to ensure "varVersion" is required (not null)
            if (varVersion == null)
            {
                throw new ArgumentNullException("varVersion is a required property for WorkflowUpdate and cannot be null");
            }
            this.VarVersion = varVersion;
            this.DefaultStatusMappings = defaultStatusMappings;
            this.Description = description;
            this.StartPointLayout = startPointLayout;
            this.StatusMappings = statusMappings;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// The mapping of old to new status ID.
        /// </summary>
        /// <value>The mapping of old to new status ID.</value>
        [DataMember(Name = "defaultStatusMappings", EmitDefaultValue = false)]
        public List<StatusMigration> DefaultStatusMappings { get; set; }

        /// <summary>
        /// The new description for this workflow.
        /// </summary>
        /// <value>The new description for this workflow.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The ID of this workflow.
        /// </summary>
        /// <value>The ID of this workflow.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets StartPointLayout
        /// </summary>
        [DataMember(Name = "startPointLayout", EmitDefaultValue = true)]
        public WorkflowLayout StartPointLayout { get; set; }

        /// <summary>
        /// The mapping of old to new status ID for a specific project and issue type.
        /// </summary>
        /// <value>The mapping of old to new status ID for a specific project and issue type.</value>
        [DataMember(Name = "statusMappings", EmitDefaultValue = false)]
        public List<StatusMappingDTO> StatusMappings { get; set; }

        /// <summary>
        /// The statuses associated with this workflow.
        /// </summary>
        /// <value>The statuses associated with this workflow.</value>
        [DataMember(Name = "statuses", IsRequired = true, EmitDefaultValue = true)]
        public List<StatusLayoutUpdate> Statuses { get; set; }

        /// <summary>
        /// The transitions of this workflow.
        /// </summary>
        /// <value>The transitions of this workflow.</value>
        [DataMember(Name = "transitions", IsRequired = true, EmitDefaultValue = true)]
        public List<TransitionUpdateDTO> Transitions { get; set; }

        /// <summary>
        /// Gets or Sets VarVersion
        /// </summary>
        [DataMember(Name = "version", IsRequired = true, EmitDefaultValue = true)]
        public DocumentVersion VarVersion { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowUpdate {\n");
            sb.Append("  DefaultStatusMappings: ").Append(DefaultStatusMappings).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  StartPointLayout: ").Append(StartPointLayout).Append("\n");
            sb.Append("  StatusMappings: ").Append(StatusMappings).Append("\n");
            sb.Append("  Statuses: ").Append(Statuses).Append("\n");
            sb.Append("  Transitions: ").Append(Transitions).Append("\n");
            sb.Append("  VarVersion: ").Append(VarVersion).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
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