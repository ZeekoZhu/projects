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
    /// MoveFieldBean
    /// </summary>
    [DataContract(Name = "MoveFieldBean")]
    public partial class MoveFieldBean : IValidatableObject
    {
        /// <summary>
        /// The named position to which the screen tab field should be moved. Required if &#x60;after&#x60; isn&#39;t provided.
        /// </summary>
        /// <value>The named position to which the screen tab field should be moved. Required if &#x60;after&#x60; isn&#39;t provided.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PositionEnum
        {
            /// <summary>
            /// Enum Earlier for value: Earlier
            /// </summary>
            [EnumMember(Value = "Earlier")]
            Earlier = 1,

            /// <summary>
            /// Enum Later for value: Later
            /// </summary>
            [EnumMember(Value = "Later")]
            Later = 2,

            /// <summary>
            /// Enum First for value: First
            /// </summary>
            [EnumMember(Value = "First")]
            First = 3,

            /// <summary>
            /// Enum Last for value: Last
            /// </summary>
            [EnumMember(Value = "Last")]
            Last = 4
        }


        /// <summary>
        /// The named position to which the screen tab field should be moved. Required if &#x60;after&#x60; isn&#39;t provided.
        /// </summary>
        /// <value>The named position to which the screen tab field should be moved. Required if &#x60;after&#x60; isn&#39;t provided.</value>
        [DataMember(Name = "position", EmitDefaultValue = false)]
        public PositionEnum? Position { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveFieldBean" /> class.
        /// </summary>
        /// <param name="after">The ID of the screen tab field after which to place the moved screen tab field. Required if &#x60;position&#x60; isn&#39;t provided..</param>
        /// <param name="position">The named position to which the screen tab field should be moved. Required if &#x60;after&#x60; isn&#39;t provided..</param>
        public MoveFieldBean(string after = default(string), PositionEnum? position = default(PositionEnum?))
        {
            this.After = after;
            this.Position = position;
        }

        /// <summary>
        /// The ID of the screen tab field after which to place the moved screen tab field. Required if &#x60;position&#x60; isn&#39;t provided.
        /// </summary>
        /// <value>The ID of the screen tab field after which to place the moved screen tab field. Required if &#x60;position&#x60; isn&#39;t provided.</value>
        [DataMember(Name = "after", EmitDefaultValue = false)]
        public string After { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MoveFieldBean {\n");
            sb.Append("  After: ").Append(After).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
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
