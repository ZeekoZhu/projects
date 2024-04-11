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
    /// The new default issue resolution.
    /// </summary>
    [DataContract(Name = "SetDefaultResolutionRequest")]
    public partial class SetDefaultResolutionRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetDefaultResolutionRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SetDefaultResolutionRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SetDefaultResolutionRequest" /> class.
        /// </summary>
        /// <param name="id">The ID of the new default issue resolution. Must be an existing ID or null. Setting this to null erases the default resolution setting. (required).</param>
        public SetDefaultResolutionRequest(string id = default(string))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for SetDefaultResolutionRequest and cannot be null");
            }
            this.Id = id;
        }

        /// <summary>
        /// The ID of the new default issue resolution. Must be an existing ID or null. Setting this to null erases the default resolution setting.
        /// </summary>
        /// <value>The ID of the new default issue resolution. Must be an existing ID or null. Setting this to null erases the default resolution setting.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SetDefaultResolutionRequest {\n");
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
