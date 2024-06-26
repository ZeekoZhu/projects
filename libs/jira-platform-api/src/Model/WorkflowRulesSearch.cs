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
    /// Details of the workflow and its transition rules.
    /// </summary>
    [DataContract(Name = "WorkflowRulesSearch")]
    public partial class WorkflowRulesSearch : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowRulesSearch" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkflowRulesSearch() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowRulesSearch" /> class.
        /// </summary>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts &#x60;transition&#x60; which, for each rule, returns information about the transition the rule is assigned to..</param>
        /// <param name="ruleIds">The list of workflow rule IDs. (required).</param>
        /// <param name="workflowEntityId">The workflow ID. (required).</param>
        public WorkflowRulesSearch(string expand = default(string), List<Guid> ruleIds = default(List<Guid>), Guid workflowEntityId = default(Guid))
        {
            // to ensure "ruleIds" is required (not null)
            if (ruleIds == null)
            {
                throw new ArgumentNullException("ruleIds is a required property for WorkflowRulesSearch and cannot be null");
            }
            this.RuleIds = ruleIds;
            this.WorkflowEntityId = workflowEntityId;
            this.Expand = expand;
        }

        /// <summary>
        /// Use expand to include additional information in the response. This parameter accepts &#x60;transition&#x60; which, for each rule, returns information about the transition the rule is assigned to.
        /// </summary>
        /// <value>Use expand to include additional information in the response. This parameter accepts &#x60;transition&#x60; which, for each rule, returns information about the transition the rule is assigned to.</value>
        /// <example>transition</example>
        [DataMember(Name = "expand", EmitDefaultValue = false)]
        public string Expand { get; set; }

        /// <summary>
        /// The list of workflow rule IDs.
        /// </summary>
        /// <value>The list of workflow rule IDs.</value>
        [DataMember(Name = "ruleIds", IsRequired = true, EmitDefaultValue = true)]
        public List<Guid> RuleIds { get; set; }

        /// <summary>
        /// The workflow ID.
        /// </summary>
        /// <value>The workflow ID.</value>
        /// <example>a498d711-685d-428d-8c3e-bc03bb450ea7</example>
        [DataMember(Name = "workflowEntityId", IsRequired = true, EmitDefaultValue = true)]
        public Guid WorkflowEntityId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowRulesSearch {\n");
            sb.Append("  Expand: ").Append(Expand).Append("\n");
            sb.Append("  RuleIds: ").Append(RuleIds).Append("\n");
            sb.Append("  WorkflowEntityId: ").Append(WorkflowEntityId).Append("\n");
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
