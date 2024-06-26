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
    /// The details of the statuses in the associated workflows.
    /// </summary>
    [DataContract(Name = "StatusMetadata")]
    public partial class StatusMetadata : IValidatableObject
    {
        /// <summary>
        /// The category of the status.
        /// </summary>
        /// <value>The category of the status.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CategoryEnum
        {
            /// <summary>
            /// Enum TODO for value: TODO
            /// </summary>
            [EnumMember(Value = "TODO")]
            TODO = 1,

            /// <summary>
            /// Enum INPROGRESS for value: IN_PROGRESS
            /// </summary>
            [EnumMember(Value = "IN_PROGRESS")]
            INPROGRESS = 2,

            /// <summary>
            /// Enum DONE for value: DONE
            /// </summary>
            [EnumMember(Value = "DONE")]
            DONE = 3
        }


        /// <summary>
        /// The category of the status.
        /// </summary>
        /// <value>The category of the status.</value>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public CategoryEnum? Category { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusMetadata" /> class.
        /// </summary>
        /// <param name="category">The category of the status..</param>
        /// <param name="id">The ID of the status..</param>
        /// <param name="name">The name of the status..</param>
        public StatusMetadata(CategoryEnum? category = default(CategoryEnum?), string id = default(string), string name = default(string))
        {
            this.Category = category;
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// The ID of the status.
        /// </summary>
        /// <value>The ID of the status.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the status.
        /// </summary>
        /// <value>The name of the status.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StatusMetadata {\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
