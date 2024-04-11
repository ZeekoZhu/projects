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
    /// The details of a workflow transition.
    /// </summary>
    [DataContract(Name = "CreateWorkflowTransitionDetails")]
    public partial class CreateWorkflowTransitionDetails : IValidatableObject
    {
        /// <summary>
        /// The type of the transition.
        /// </summary>
        /// <value>The type of the transition.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Global for value: global
            /// </summary>
            [EnumMember(Value = "global")]
            Global = 1,

            /// <summary>
            /// Enum Initial for value: initial
            /// </summary>
            [EnumMember(Value = "initial")]
            Initial = 2,

            /// <summary>
            /// Enum Directed for value: directed
            /// </summary>
            [EnumMember(Value = "directed")]
            Directed = 3
        }


        /// <summary>
        /// The type of the transition.
        /// </summary>
        /// <value>The type of the transition.</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWorkflowTransitionDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateWorkflowTransitionDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWorkflowTransitionDetails" /> class.
        /// </summary>
        /// <param name="description">The description of the transition. The maximum length is 1000 characters..</param>
        /// <param name="from">The statuses the transition can start from..</param>
        /// <param name="name">The name of the transition. The maximum length is 60 characters. (required).</param>
        /// <param name="properties">The properties of the transition..</param>
        /// <param name="rules">The rules of the transition..</param>
        /// <param name="screen">The screen of the transition..</param>
        /// <param name="to">The status the transition goes to. (required).</param>
        /// <param name="type">The type of the transition. (required).</param>
        public CreateWorkflowTransitionDetails(string description = default(string), List<string> from = default(List<string>), string name = default(string), Dictionary<string, string> properties = default(Dictionary<string, string>), CreateWorkflowTransitionRulesDetails rules = default(CreateWorkflowTransitionRulesDetails), CreateWorkflowTransitionScreenDetails screen = default(CreateWorkflowTransitionScreenDetails), string to = default(string), TypeEnum type = default(TypeEnum))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for CreateWorkflowTransitionDetails and cannot be null");
            }
            this.Name = name;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for CreateWorkflowTransitionDetails and cannot be null");
            }
            this.To = to;
            this.Type = type;
            this.Description = description;
            this.From = from;
            this.Properties = properties;
            this.Rules = rules;
            this.Screen = screen;
        }

        /// <summary>
        /// The description of the transition. The maximum length is 1000 characters.
        /// </summary>
        /// <value>The description of the transition. The maximum length is 1000 characters.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The statuses the transition can start from.
        /// </summary>
        /// <value>The statuses the transition can start from.</value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public List<string> From { get; set; }

        /// <summary>
        /// The name of the transition. The maximum length is 60 characters.
        /// </summary>
        /// <value>The name of the transition. The maximum length is 60 characters.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The properties of the transition.
        /// </summary>
        /// <value>The properties of the transition.</value>
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public Dictionary<string, string> Properties { get; set; }

        /// <summary>
        /// The rules of the transition.
        /// </summary>
        /// <value>The rules of the transition.</value>
        [DataMember(Name = "rules", EmitDefaultValue = false)]
        public CreateWorkflowTransitionRulesDetails Rules { get; set; }

        /// <summary>
        /// The screen of the transition.
        /// </summary>
        /// <value>The screen of the transition.</value>
        [DataMember(Name = "screen", EmitDefaultValue = false)]
        public CreateWorkflowTransitionScreenDetails Screen { get; set; }

        /// <summary>
        /// The status the transition goes to.
        /// </summary>
        /// <value>The status the transition goes to.</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateWorkflowTransitionDetails {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  Rules: ").Append(Rules).Append("\n");
            sb.Append("  Screen: ").Append(Screen).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
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
