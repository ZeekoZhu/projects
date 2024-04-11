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
    /// Details of a status.
    /// </summary>
    [DataContract(Name = "JiraStatus")]
    public partial class JiraStatus : IValidatableObject
    {
        /// <summary>
        /// The category of the status.
        /// </summary>
        /// <value>The category of the status.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusCategoryEnum
        {
            /// <summary>
            /// Enum TODO for value: TODO
            /// </summary>
            [EnumMember(Value = "TODO")]
            TODO = 1,

            /// <summary>
            /// Enum INPROGRESS for value: IN_PROGRESS
            /// </summary>
            [EnumMember(Value = "IN_PROGRESS")]
            INPROGRESS = 2,

            /// <summary>
            /// Enum DONE for value: DONE
            /// </summary>
            [EnumMember(Value = "DONE")]
            DONE = 3
        }


        /// <summary>
        /// The category of the status.
        /// </summary>
        /// <value>The category of the status.</value>
        [DataMember(Name = "statusCategory", EmitDefaultValue = false)]
        public StatusCategoryEnum? StatusCategory { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="JiraStatus" /> class.
        /// </summary>
        /// <param name="description">The description of the status..</param>
        /// <param name="id">The ID of the status..</param>
        /// <param name="name">The name of the status..</param>
        /// <param name="scope">scope.</param>
        /// <param name="statusCategory">The category of the status..</param>
        /// <param name="usages">Projects and issue types where the status is used. Only available if the &#x60;usages&#x60; expand is requested..</param>
        /// <param name="workflowUsages">The workflows that use this status. Only available if the &#x60;workflowUsages&#x60; expand is requested..</param>
        public JiraStatus(string description = default(string), string id = default(string), string name = default(string), StatusScope scope = default(StatusScope), StatusCategoryEnum? statusCategory = default(StatusCategoryEnum?), List<ProjectIssueTypes> usages = default(List<ProjectIssueTypes>), List<WorkflowUsages> workflowUsages = default(List<WorkflowUsages>))
        {
            this.Description = description;
            this.Id = id;
            this.Name = name;
            this.Scope = scope;
            this.StatusCategory = statusCategory;
            this.Usages = usages;
            this.WorkflowUsages = workflowUsages;
        }

        /// <summary>
        /// The description of the status.
        /// </summary>
        /// <value>The description of the status.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the status.
        /// </summary>
        /// <value>The ID of the status.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the status.
        /// </summary>
        /// <value>The name of the status.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Scope
        /// </summary>
        [DataMember(Name = "scope", EmitDefaultValue = false)]
        public StatusScope Scope { get; set; }

        /// <summary>
        /// Projects and issue types where the status is used. Only available if the &#x60;usages&#x60; expand is requested.
        /// </summary>
        /// <value>Projects and issue types where the status is used. Only available if the &#x60;usages&#x60; expand is requested.</value>
        [DataMember(Name = "usages", EmitDefaultValue = false)]
        public List<ProjectIssueTypes> Usages { get; set; }

        /// <summary>
        /// The workflows that use this status. Only available if the &#x60;workflowUsages&#x60; expand is requested.
        /// </summary>
        /// <value>The workflows that use this status. Only available if the &#x60;workflowUsages&#x60; expand is requested.</value>
        [DataMember(Name = "workflowUsages", EmitDefaultValue = false)]
        public List<WorkflowUsages> WorkflowUsages { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JiraStatus {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
            sb.Append("  StatusCategory: ").Append(StatusCategory).Append("\n");
            sb.Append("  Usages: ").Append(Usages).Append("\n");
            sb.Append("  WorkflowUsages: ").Append(WorkflowUsages).Append("\n");
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
