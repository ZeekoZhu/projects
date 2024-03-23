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
    /// The trigger configuration associated with a workflow.
    /// </summary>
    [DataContract(Name = "WorkflowTrigger")]
    public partial class WorkflowTrigger : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTrigger" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WorkflowTrigger() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowTrigger" /> class.
        /// </summary>
        /// <param name="id">The ID of the trigger..</param>
        /// <param name="parameters">The parameters of the trigger. (required).</param>
        /// <param name="ruleKey">The rule key of the trigger. (required).</param>
        public WorkflowTrigger(string id = default(string), Dictionary<string, string> parameters = default(Dictionary<string, string>), string ruleKey = default(string))
        {
            // to ensure "parameters" is required (not null)
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters is a required property for WorkflowTrigger and cannot be null");
            }
            this.Parameters = parameters;
            // to ensure "ruleKey" is required (not null)
            if (ruleKey == null)
            {
                throw new ArgumentNullException("ruleKey is a required property for WorkflowTrigger and cannot be null");
            }
            this.RuleKey = ruleKey;
            this.Id = id;
        }

        /// <summary>
        /// The ID of the trigger.
        /// </summary>
        /// <value>The ID of the trigger.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The parameters of the trigger.
        /// </summary>
        /// <value>The parameters of the trigger.</value>
        [DataMember(Name = "parameters", IsRequired = true, EmitDefaultValue = true)]
        public Dictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// The rule key of the trigger.
        /// </summary>
        /// <value>The rule key of the trigger.</value>
        [DataMember(Name = "ruleKey", IsRequired = true, EmitDefaultValue = true)]
        public string RuleKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowTrigger {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Parameters: ").Append(Parameters).Append("\n");
            sb.Append("  RuleKey: ").Append(RuleKey).Append("\n");
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
