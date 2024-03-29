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
    /// A workflow transition condition.
    /// </summary>
    [DataContract(Name = "CreateWorkflowCondition")]
    public partial class CreateWorkflowCondition : IValidatableObject
    {
        /// <summary>
        /// The compound condition operator.
        /// </summary>
        /// <value>The compound condition operator.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OperatorEnum
        {
            /// <summary>
            /// Enum AND for value: AND
            /// </summary>
            [EnumMember(Value = "AND")]
            AND = 1,

            /// <summary>
            /// Enum OR for value: OR
            /// </summary>
            [EnumMember(Value = "OR")]
            OR = 2
        }


        /// <summary>
        /// The compound condition operator.
        /// </summary>
        /// <value>The compound condition operator.</value>
        [DataMember(Name = "operator", EmitDefaultValue = false)]
        public OperatorEnum? VarOperator { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWorkflowCondition" /> class.
        /// </summary>
        /// <param name="conditions">The list of workflow conditions..</param>
        /// <param name="varConfiguration">EXPERIMENTAL. The configuration of the transition rule..</param>
        /// <param name="varOperator">The compound condition operator..</param>
        /// <param name="type">The type of the transition rule..</param>
        public CreateWorkflowCondition(List<CreateWorkflowCondition> conditions = default(List<CreateWorkflowCondition>), Dictionary<string, Object> varConfiguration = default(Dictionary<string, Object>), OperatorEnum? varOperator = default(OperatorEnum?), string type = default(string))
        {
            this.Conditions = conditions;
            this.VarConfiguration = varConfiguration;
            this.VarOperator = varOperator;
            this.Type = type;
        }

        /// <summary>
        /// The list of workflow conditions.
        /// </summary>
        /// <value>The list of workflow conditions.</value>
        [DataMember(Name = "conditions", EmitDefaultValue = false)]
        public List<CreateWorkflowCondition> Conditions { get; set; }

        /// <summary>
        /// EXPERIMENTAL. The configuration of the transition rule.
        /// </summary>
        /// <value>EXPERIMENTAL. The configuration of the transition rule.</value>
        [DataMember(Name = "configuration", EmitDefaultValue = false)]
        public Dictionary<string, Object> VarConfiguration { get; set; }

        /// <summary>
        /// The type of the transition rule.
        /// </summary>
        /// <value>The type of the transition rule.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateWorkflowCondition {\n");
            sb.Append("  Conditions: ").Append(Conditions).Append("\n");
            sb.Append("  VarConfiguration: ").Append(VarConfiguration).Append("\n");
            sb.Append("  VarOperator: ").Append(VarOperator).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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