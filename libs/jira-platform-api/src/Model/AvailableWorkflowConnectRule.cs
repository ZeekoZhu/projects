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
    /// The Connect provided ecosystem rules available.
    /// </summary>
    [DataContract(Name = "AvailableWorkflowConnectRule")]
    public partial class AvailableWorkflowConnectRule : IValidatableObject
    {
        /// <summary>
        /// The rule type.
        /// </summary>
        /// <value>The rule type.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RuleTypeEnum
        {
            /// <summary>
            /// Enum Condition for value: Condition
            /// </summary>
            [EnumMember(Value = "Condition")]
            Condition = 1,

            /// <summary>
            /// Enum Validator for value: Validator
            /// </summary>
            [EnumMember(Value = "Validator")]
            Validator = 2,

            /// <summary>
            /// Enum Function for value: Function
            /// </summary>
            [EnumMember(Value = "Function")]
            Function = 3,

            /// <summary>
            /// Enum Screen for value: Screen
            /// </summary>
            [EnumMember(Value = "Screen")]
            Screen = 4
        }


        /// <summary>
        /// The rule type.
        /// </summary>
        /// <value>The rule type.</value>
        [DataMember(Name = "ruleType", EmitDefaultValue = false)]
        public RuleTypeEnum? RuleType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableWorkflowConnectRule" /> class.
        /// </summary>
        /// <param name="addonKey">The add-on providing the rule..</param>
        /// <param name="createUrl">The URL creation path segment defined in the Connect module..</param>
        /// <param name="description">The rule description..</param>
        /// <param name="editUrl">The URL edit path segment defined in the Connect module..</param>
        /// <param name="moduleKey">The module providing the rule..</param>
        /// <param name="name">The rule name..</param>
        /// <param name="ruleKey">The rule key..</param>
        /// <param name="ruleType">The rule type..</param>
        /// <param name="viewUrl">The URL view path segment defined in the Connect module..</param>
        public AvailableWorkflowConnectRule(string addonKey = default(string), string createUrl = default(string), string description = default(string), string editUrl = default(string), string moduleKey = default(string), string name = default(string), string ruleKey = default(string), RuleTypeEnum? ruleType = default(RuleTypeEnum?), string viewUrl = default(string))
        {
            this.AddonKey = addonKey;
            this.CreateUrl = createUrl;
            this.Description = description;
            this.EditUrl = editUrl;
            this.ModuleKey = moduleKey;
            this.Name = name;
            this.RuleKey = ruleKey;
            this.RuleType = ruleType;
            this.ViewUrl = viewUrl;
        }

        /// <summary>
        /// The add-on providing the rule.
        /// </summary>
        /// <value>The add-on providing the rule.</value>
        [DataMember(Name = "addonKey", EmitDefaultValue = false)]
        public string AddonKey { get; set; }

        /// <summary>
        /// The URL creation path segment defined in the Connect module.
        /// </summary>
        /// <value>The URL creation path segment defined in the Connect module.</value>
        [DataMember(Name = "createUrl", EmitDefaultValue = false)]
        public string CreateUrl { get; set; }

        /// <summary>
        /// The rule description.
        /// </summary>
        /// <value>The rule description.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The URL edit path segment defined in the Connect module.
        /// </summary>
        /// <value>The URL edit path segment defined in the Connect module.</value>
        [DataMember(Name = "editUrl", EmitDefaultValue = false)]
        public string EditUrl { get; set; }

        /// <summary>
        /// The module providing the rule.
        /// </summary>
        /// <value>The module providing the rule.</value>
        [DataMember(Name = "moduleKey", EmitDefaultValue = false)]
        public string ModuleKey { get; set; }

        /// <summary>
        /// The rule name.
        /// </summary>
        /// <value>The rule name.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The rule key.
        /// </summary>
        /// <value>The rule key.</value>
        [DataMember(Name = "ruleKey", EmitDefaultValue = false)]
        public string RuleKey { get; set; }

        /// <summary>
        /// The URL view path segment defined in the Connect module.
        /// </summary>
        /// <value>The URL view path segment defined in the Connect module.</value>
        [DataMember(Name = "viewUrl", EmitDefaultValue = false)]
        public string ViewUrl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AvailableWorkflowConnectRule {\n");
            sb.Append("  AddonKey: ").Append(AddonKey).Append("\n");
            sb.Append("  CreateUrl: ").Append(CreateUrl).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EditUrl: ").Append(EditUrl).Append("\n");
            sb.Append("  ModuleKey: ").Append(ModuleKey).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RuleKey: ").Append(RuleKey).Append("\n");
            sb.Append("  RuleType: ").Append(RuleType).Append("\n");
            sb.Append("  ViewUrl: ").Append(ViewUrl).Append("\n");
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
