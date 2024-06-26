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
    /// Issue security scheme and it&#39;s details
    /// </summary>
    [DataContract(Name = "CreateIssueSecuritySchemeDetails")]
    public partial class CreateIssueSecuritySchemeDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateIssueSecuritySchemeDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateIssueSecuritySchemeDetails()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateIssueSecuritySchemeDetails" /> class.
        /// </summary>
        /// <param name="description">The description of the issue security scheme..</param>
        /// <param name="levels">The list of scheme levels which should be added to the security scheme..</param>
        /// <param name="name">The name of the issue security scheme. Must be unique (case-insensitive). (required).</param>
        public CreateIssueSecuritySchemeDetails(string description = default(string), List<SecuritySchemeLevelBean> levels = default(List<SecuritySchemeLevelBean>), string name = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for CreateIssueSecuritySchemeDetails and cannot be null");
            }
            this.Name = name;
            this.Description = description;
            this.Levels = levels;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// The description of the issue security scheme.
        /// </summary>
        /// <value>The description of the issue security scheme.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The list of scheme levels which should be added to the security scheme.
        /// </summary>
        /// <value>The list of scheme levels which should be added to the security scheme.</value>
        [DataMember(Name = "levels", EmitDefaultValue = false)]
        public List<SecuritySchemeLevelBean> Levels { get; set; }

        /// <summary>
        /// The name of the issue security scheme. Must be unique (case-insensitive).
        /// </summary>
        /// <value>The name of the issue security scheme. Must be unique (case-insensitive).</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateIssueSecuritySchemeDetails {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Levels: ").Append(Levels).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
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
            // Description (string) maxLength
            if (this.Description != null && this.Description.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be less than 255.", new [] { "Description" });
            }

            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 60)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 60.", new [] { "Name" });
            }

            yield break;
        }
    }

}
