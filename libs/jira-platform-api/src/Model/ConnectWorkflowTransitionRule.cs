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
    /// A workflow transition rule.
    /// </summary>
    [DataContract(Name = "ConnectWorkflowTransitionRule")]
    public partial class ConnectWorkflowTransitionRule : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectWorkflowTransitionRule" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ConnectWorkflowTransitionRule() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectWorkflowTransitionRule" /> class.
        /// </summary>
        /// <param name="varConfiguration">varConfiguration (required).</param>
        /// <param name="id">The ID of the transition rule. (required).</param>
        /// <param name="key">The key of the rule, as defined in the Connect app descriptor. (required).</param>
        /// <param name="transition">transition.</param>
        public ConnectWorkflowTransitionRule(RuleConfiguration varConfiguration = default(RuleConfiguration), string id = default(string), string key = default(string), WorkflowTransition transition = default(WorkflowTransition))
        {
            // to ensure "varConfiguration" is required (not null)
            if (varConfiguration == null)
            {
                throw new ArgumentNullException("varConfiguration is a required property for ConnectWorkflowTransitionRule and cannot be null");
            }
            this.VarConfiguration = varConfiguration;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for ConnectWorkflowTransitionRule and cannot be null");
            }
            this.Id = id;
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new ArgumentNullException("key is a required property for ConnectWorkflowTransitionRule and cannot be null");
            }
            this.Key = key;
            this.Transition = transition;
        }

        /// <summary>
        /// Gets or Sets VarConfiguration
        /// </summary>
        [DataMember(Name = "configuration", IsRequired = true, EmitDefaultValue = true)]
        public RuleConfiguration VarConfiguration { get; set; }

        /// <summary>
        /// The ID of the transition rule.
        /// </summary>
        /// <value>The ID of the transition rule.</value>
        /// <example>123</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The key of the rule, as defined in the Connect app descriptor.
        /// </summary>
        /// <value>The key of the rule, as defined in the Connect app descriptor.</value>
        /// <example>WorkflowKey</example>
        [DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or Sets Transition
        /// </summary>
        [DataMember(Name = "transition", EmitDefaultValue = false)]
        public WorkflowTransition Transition { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ConnectWorkflowTransitionRule {\n");
            sb.Append("  VarConfiguration: ").Append(VarConfiguration).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Transition: ").Append(Transition).Append("\n");
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
