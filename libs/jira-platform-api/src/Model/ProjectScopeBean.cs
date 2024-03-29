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
    /// ProjectScopeBean
    /// </summary>
    [DataContract(Name = "ProjectScopeBean")]
    public partial class ProjectScopeBean : IValidatableObject
    {
        /// <summary>
        /// Defines Attributes
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AttributesEnum
        {
            /// <summary>
            /// Enum NotSelectable for value: notSelectable
            /// </summary>
            [EnumMember(Value = "notSelectable")]
            NotSelectable = 1,

            /// <summary>
            /// Enum DefaultValue for value: defaultValue
            /// </summary>
            [EnumMember(Value = "defaultValue")]
            DefaultValue = 2
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectScopeBean" /> class.
        /// </summary>
        /// <param name="attributes">Defines the behavior of the option in the project.If notSelectable is set, the option cannot be set as the field&#39;s value. This is useful for archiving an option that has previously been selected but shouldn&#39;t be used anymore.If defaultValue is set, the option is selected by default..</param>
        /// <param name="id">The ID of the project that the option&#39;s behavior applies to..</param>
        public ProjectScopeBean(List<AttributesEnum> attributes = default(List<AttributesEnum>), long id = default(long))
        {
            this.Attributes = attributes;
            this.Id = id;
        }

        /// <summary>
        /// Defines the behavior of the option in the project.If notSelectable is set, the option cannot be set as the field&#39;s value. This is useful for archiving an option that has previously been selected but shouldn&#39;t be used anymore.If defaultValue is set, the option is selected by default.
        /// </summary>
        /// <value>Defines the behavior of the option in the project.If notSelectable is set, the option cannot be set as the field&#39;s value. This is useful for archiving an option that has previously been selected but shouldn&#39;t be used anymore.If defaultValue is set, the option is selected by default.</value>
        [DataMember(Name = "attributes", EmitDefaultValue = false)]
        public List<ProjectScopeBean.AttributesEnum> Attributes { get; set; }

        /// <summary>
        /// The ID of the project that the option&#39;s behavior applies to.
        /// </summary>
        /// <value>The ID of the project that the option&#39;s behavior applies to.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProjectScopeBean {\n");
            sb.Append("  Attributes: ").Append(Attributes).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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