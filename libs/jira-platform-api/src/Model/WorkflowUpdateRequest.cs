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
    /// The update workflows payload.
    /// </summary>
    [DataContract(Name = "WorkflowUpdateRequest")]
    public partial class WorkflowUpdateRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowUpdateRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkflowUpdateRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowUpdateRequest" /> class.
        /// </summary>
        /// <param name="statuses">The statuses to associate with the workflows. (required).</param>
        /// <param name="workflows">The details of the workflows to update. (required).</param>
        public WorkflowUpdateRequest(List<WorkflowStatusUpdate> statuses = default(List<WorkflowStatusUpdate>), List<WorkflowUpdate> workflows = default(List<WorkflowUpdate>))
        {
            // to ensure "statuses" is required (not null)
            if (statuses == null)
            {
                throw new ArgumentNullException("statuses is a required property for WorkflowUpdateRequest and cannot be null");
            }
            this.Statuses = statuses;
            // to ensure "workflows" is required (not null)
            if (workflows == null)
            {
                throw new ArgumentNullException("workflows is a required property for WorkflowUpdateRequest and cannot be null");
            }
            this.Workflows = workflows;
        }

        /// <summary>
        /// The statuses to associate with the workflows.
        /// </summary>
        /// <value>The statuses to associate with the workflows.</value>
        [DataMember(Name = "statuses", IsRequired = true, EmitDefaultValue = true)]
        public List<WorkflowStatusUpdate> Statuses { get; set; }

        /// <summary>
        /// The details of the workflows to update.
        /// </summary>
        /// <value>The details of the workflows to update.</value>
        [DataMember(Name = "workflows", IsRequired = true, EmitDefaultValue = true)]
        public List<WorkflowUpdate> Workflows { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowUpdateRequest {\n");
            sb.Append("  Statuses: ").Append(Statuses).Append("\n");
            sb.Append("  Workflows: ").Append(Workflows).Append("\n");
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