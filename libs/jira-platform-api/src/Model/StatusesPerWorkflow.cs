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
    /// The statuses associated with each workflow.
    /// </summary>
    [DataContract(Name = "StatusesPerWorkflow")]
    public partial class StatusesPerWorkflow : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusesPerWorkflow" /> class.
        /// </summary>
        /// <param name="initialStatusId">The ID of the initial status for the workflow..</param>
        /// <param name="statuses">The status IDs associated with the workflow..</param>
        /// <param name="workflowId">The ID of the workflow..</param>
        public StatusesPerWorkflow(string initialStatusId = default(string), List<string> statuses = default(List<string>), string workflowId = default(string))
        {
            this.InitialStatusId = initialStatusId;
            this.Statuses = statuses;
            this.WorkflowId = workflowId;
        }

        /// <summary>
        /// The ID of the initial status for the workflow.
        /// </summary>
        /// <value>The ID of the initial status for the workflow.</value>
        [DataMember(Name = "initialStatusId", EmitDefaultValue = false)]
        public string InitialStatusId { get; set; }

        /// <summary>
        /// The status IDs associated with the workflow.
        /// </summary>
        /// <value>The status IDs associated with the workflow.</value>
        [DataMember(Name = "statuses", EmitDefaultValue = false)]
        public List<string> Statuses { get; set; }

        /// <summary>
        /// The ID of the workflow.
        /// </summary>
        /// <value>The ID of the workflow.</value>
        [DataMember(Name = "workflowId", EmitDefaultValue = false)]
        public string WorkflowId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StatusesPerWorkflow {\n");
            sb.Append("  InitialStatusId: ").Append(InitialStatusId).Append("\n");
            sb.Append("  Statuses: ").Append(Statuses).Append("\n");
            sb.Append("  WorkflowId: ").Append(WorkflowId).Append("\n");
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
