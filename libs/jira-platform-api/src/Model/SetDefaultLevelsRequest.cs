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
    /// Details of new default levels.
    /// </summary>
    [DataContract(Name = "SetDefaultLevelsRequest")]
    public partial class SetDefaultLevelsRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetDefaultLevelsRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SetDefaultLevelsRequest()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SetDefaultLevelsRequest" /> class.
        /// </summary>
        /// <param name="defaultValues">List of objects with issue security scheme ID and new default level ID. (required).</param>
        public SetDefaultLevelsRequest(List<DefaultLevelValue> defaultValues = default(List<DefaultLevelValue>))
        {
            // to ensure "defaultValues" is required (not null)
            if (defaultValues == null)
            {
                throw new ArgumentNullException("defaultValues is a required property for SetDefaultLevelsRequest and cannot be null");
            }
            this.DefaultValues = defaultValues;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// List of objects with issue security scheme ID and new default level ID.
        /// </summary>
        /// <value>List of objects with issue security scheme ID and new default level ID.</value>
        [DataMember(Name = "defaultValues", IsRequired = true, EmitDefaultValue = true)]
        public List<DefaultLevelValue> DefaultValues { get; set; }

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
            sb.Append("class SetDefaultLevelsRequest {\n");
            sb.Append("  DefaultValues: ").Append(DefaultValues).Append("\n");
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
            yield break;
        }
    }

}
