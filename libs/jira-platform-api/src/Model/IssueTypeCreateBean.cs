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
    /// IssueTypeCreateBean
    /// </summary>
    [DataContract(Name = "IssueTypeCreateBean")]
    public partial class IssueTypeCreateBean : IValidatableObject
    {
        /// <summary>
        /// Deprecated. Use &#x60;hierarchyLevel&#x60; instead. See the [deprecation notice](https://community.developer.atlassian.com/t/deprecation-of-the-epic-link-parent-link-and-other-related-fields-in-rest-apis-and-webhooks/54048) for details.  Whether the issue type is &#x60;subtype&#x60; or &#x60;standard&#x60;. Defaults to &#x60;standard&#x60;.
        /// </summary>
        /// <value>Deprecated. Use &#x60;hierarchyLevel&#x60; instead. See the [deprecation notice](https://community.developer.atlassian.com/t/deprecation-of-the-epic-link-parent-link-and-other-related-fields-in-rest-apis-and-webhooks/54048) for details.  Whether the issue type is &#x60;subtype&#x60; or &#x60;standard&#x60;. Defaults to &#x60;standard&#x60;.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Subtask for value: subtask
            /// </summary>
            [EnumMember(Value = "subtask")]
            Subtask = 1,

            /// <summary>
            /// Enum Standard for value: standard
            /// </summary>
            [EnumMember(Value = "standard")]
            Standard = 2
        }


        /// <summary>
        /// Deprecated. Use &#x60;hierarchyLevel&#x60; instead. See the [deprecation notice](https://community.developer.atlassian.com/t/deprecation-of-the-epic-link-parent-link-and-other-related-fields-in-rest-apis-and-webhooks/54048) for details.  Whether the issue type is &#x60;subtype&#x60; or &#x60;standard&#x60;. Defaults to &#x60;standard&#x60;.
        /// </summary>
        /// <value>Deprecated. Use &#x60;hierarchyLevel&#x60; instead. See the [deprecation notice](https://community.developer.atlassian.com/t/deprecation-of-the-epic-link-parent-link-and-other-related-fields-in-rest-apis-and-webhooks/54048) for details.  Whether the issue type is &#x60;subtype&#x60; or &#x60;standard&#x60;. Defaults to &#x60;standard&#x60;.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueTypeCreateBean" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected IssueTypeCreateBean() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueTypeCreateBean" /> class.
        /// </summary>
        /// <param name="description">The description of the issue type..</param>
        /// <param name="hierarchyLevel">The hierarchy level of the issue type. Use:   *  &#x60;-1&#x60; for Subtask.  *  &#x60;0&#x60; for Base.  Defaults to &#x60;0&#x60;..</param>
        /// <param name="name">The unique name for the issue type. The maximum length is 60 characters. (required).</param>
        /// <param name="type">Deprecated. Use &#x60;hierarchyLevel&#x60; instead. See the [deprecation notice](https://community.developer.atlassian.com/t/deprecation-of-the-epic-link-parent-link-and-other-related-fields-in-rest-apis-and-webhooks/54048) for details.  Whether the issue type is &#x60;subtype&#x60; or &#x60;standard&#x60;. Defaults to &#x60;standard&#x60;..</param>
        public IssueTypeCreateBean(string description = default(string), int hierarchyLevel = default(int), string name = default(string), TypeEnum? type = default(TypeEnum?))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for IssueTypeCreateBean and cannot be null");
            }
            this.Name = name;
            this.Description = description;
            this.HierarchyLevel = hierarchyLevel;
            this.Type = type;
        }

        /// <summary>
        /// The description of the issue type.
        /// </summary>
        /// <value>The description of the issue type.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The hierarchy level of the issue type. Use:   *  &#x60;-1&#x60; for Subtask.  *  &#x60;0&#x60; for Base.  Defaults to &#x60;0&#x60;.
        /// </summary>
        /// <value>The hierarchy level of the issue type. Use:   *  &#x60;-1&#x60; for Subtask.  *  &#x60;0&#x60; for Base.  Defaults to &#x60;0&#x60;.</value>
        [DataMember(Name = "hierarchyLevel", EmitDefaultValue = false)]
        public int HierarchyLevel { get; set; }

        /// <summary>
        /// The unique name for the issue type. The maximum length is 60 characters.
        /// </summary>
        /// <value>The unique name for the issue type. The maximum length is 60 characters.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IssueTypeCreateBean {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  HierarchyLevel: ").Append(HierarchyLevel).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
