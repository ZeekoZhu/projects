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
    /// The level of validation to return from the API. If no values are provided, the default would return &#x60;WARNING&#x60; and &#x60;ERROR&#x60; level validation results.
    /// </summary>
    [DataContract(Name = "ValidationOptionsForCreate")]
    public partial class ValidationOptionsForCreate : IValidatableObject
    {
        /// <summary>
        /// Defines Levels
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LevelsEnum
        {
            /// <summary>
            /// Enum WARNING for value: WARNING
            /// </summary>
            [EnumMember(Value = "WARNING")]
            WARNING = 1,

            /// <summary>
            /// Enum ERROR for value: ERROR
            /// </summary>
            [EnumMember(Value = "ERROR")]
            ERROR = 2
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationOptionsForCreate" /> class.
        /// </summary>
        /// <param name="levels">levels.</param>
        public ValidationOptionsForCreate(List<LevelsEnum> levels = default(List<LevelsEnum>))
        {
            this.Levels = levels;
        }

        /// <summary>
        /// Gets or Sets Levels
        /// </summary>
        [DataMember(Name = "levels", EmitDefaultValue = false)]
        public List<ValidationOptionsForCreate.LevelsEnum> Levels { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ValidationOptionsForCreate {\n");
            sb.Append("  Levels: ").Append(Levels).Append("\n");
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
