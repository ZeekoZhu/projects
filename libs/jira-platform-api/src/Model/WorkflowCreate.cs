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
    /// The details of the workflows to create.
    /// </summary>
    [DataContract(Name = "WorkflowCreate")]
    public partial class WorkflowCreate : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowCreate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkflowCreate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowCreate" /> class.
        /// </summary>
        /// <param name="description">The description of the workflow to create..</param>
        /// <param name="name">The name of the workflow to create. (required).</param>
        /// <param name="startPointLayout">startPointLayout.</param>
        /// <param name="statuses">The statuses associated with this workflow. (required).</param>
        /// <param name="transitions">The transitions of this workflow. (required).</param>
        public WorkflowCreate(string description = default(string), string name = default(string), WorkflowLayout startPointLayout = default(WorkflowLayout), List<StatusLayoutUpdate> statuses = default(List<StatusLayoutUpdate>), List<TransitionUpdateDTO> transitions = default(List<TransitionUpdateDTO>))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for WorkflowCreate and cannot be null");
            }
            this.Name = name;
            // to ensure "statuses" is required (not null)
            if (statuses == null)
            {
                throw new ArgumentNullException("statuses is a required property for WorkflowCreate and cannot be null");
            }
            this.Statuses = statuses;
            // to ensure "transitions" is required (not null)
            if (transitions == null)
            {
                throw new ArgumentNullException("transitions is a required property for WorkflowCreate and cannot be null");
            }
            this.Transitions = transitions;
            this.Description = description;
            this.StartPointLayout = startPointLayout;
        }

        /// <summary>
        /// The description of the workflow to create.
        /// </summary>
        /// <value>The description of the workflow to create.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The name of the workflow to create.
        /// </summary>
        /// <value>The name of the workflow to create.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets StartPointLayout
        /// </summary>
        [DataMember(Name = "startPointLayout", EmitDefaultValue = true)]
        public WorkflowLayout StartPointLayout { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowCreate {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  StartPointLayout: ").Append(StartPointLayout).Append("\n");
            sb.Append("  Statuses: ").Append(Statuses).Append("\n");
            sb.Append("  Transitions: ").Append(Transitions).Append("\n");
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
