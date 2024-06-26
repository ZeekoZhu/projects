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
    /// An associated workflow scheme and project.
    /// </summary>
    [DataContract(Name = "WorkflowSchemeProjectAssociation")]
    public partial class WorkflowSchemeProjectAssociation : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowSchemeProjectAssociation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkflowSchemeProjectAssociation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowSchemeProjectAssociation" /> class.
        /// </summary>
        /// <param name="projectId">The ID of the project. (required).</param>
        /// <param name="workflowSchemeId">The ID of the workflow scheme. If the workflow scheme ID is &#x60;null&#x60;, the operation assigns the default workflow scheme..</param>
        public WorkflowSchemeProjectAssociation(string projectId = default(string), string workflowSchemeId = default(string))
        {
            // to ensure "projectId" is required (not null)
            if (projectId == null)
            {
                throw new ArgumentNullException("projectId is a required property for WorkflowSchemeProjectAssociation and cannot be null");
            }
            this.ProjectId = projectId;
            this.WorkflowSchemeId = workflowSchemeId;
        }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        /// <value>The ID of the project.</value>
        [DataMember(Name = "projectId", IsRequired = true, EmitDefaultValue = true)]
        public string ProjectId { get; set; }

        /// <summary>
        /// The ID of the workflow scheme. If the workflow scheme ID is &#x60;null&#x60;, the operation assigns the default workflow scheme.
        /// </summary>
        /// <value>The ID of the workflow scheme. If the workflow scheme ID is &#x60;null&#x60;, the operation assigns the default workflow scheme.</value>
        [DataMember(Name = "workflowSchemeId", EmitDefaultValue = false)]
        public string WorkflowSchemeId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowSchemeProjectAssociation {\n");
            sb.Append("  ProjectId: ").Append(ProjectId).Append("\n");
            sb.Append("  WorkflowSchemeId: ").Append(WorkflowSchemeId).Append("\n");
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
