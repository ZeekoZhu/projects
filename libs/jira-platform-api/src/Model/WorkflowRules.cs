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
    /// A collection of transition rules.
    /// </summary>
    [DataContract(Name = "WorkflowRules")]
    public partial class WorkflowRules : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowRules" /> class.
        /// </summary>
        /// <param name="conditionsTree">conditionsTree.</param>
        /// <param name="postFunctions">The workflow post functions..</param>
        /// <param name="validators">The workflow validators..</param>
        public WorkflowRules(WorkflowCondition conditionsTree = default(WorkflowCondition), List<WorkflowTransitionRule> postFunctions = default(List<WorkflowTransitionRule>), List<WorkflowTransitionRule> validators = default(List<WorkflowTransitionRule>))
        {
            this.ConditionsTree = conditionsTree;
            this.PostFunctions = postFunctions;
            this.Validators = validators;
        }

        /// <summary>
        /// Gets or Sets ConditionsTree
        /// </summary>
        [DataMember(Name = "conditionsTree", EmitDefaultValue = false)]
        public WorkflowCondition ConditionsTree { get; set; }

        /// <summary>
        /// The workflow post functions.
        /// </summary>
        /// <value>The workflow post functions.</value>
        [DataMember(Name = "postFunctions", EmitDefaultValue = false)]
        public List<WorkflowTransitionRule> PostFunctions { get; set; }

        /// <summary>
        /// The workflow validators.
        /// </summary>
        /// <value>The workflow validators.</value>
        [DataMember(Name = "validators", EmitDefaultValue = false)]
        public List<WorkflowTransitionRule> Validators { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowRules {\n");
            sb.Append("  ConditionsTree: ").Append(ConditionsTree).Append("\n");
            sb.Append("  PostFunctions: ").Append(PostFunctions).Append("\n");
            sb.Append("  Validators: ").Append(Validators).Append("\n");
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
