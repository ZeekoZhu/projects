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
    /// The current version details of this workflow scheme.
    /// </summary>
    [DataContract(Name = "DocumentVersion")]
    public partial class DocumentVersion : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentVersion" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DocumentVersion() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentVersion" /> class.
        /// </summary>
        /// <param name="id">The version UUID. (required).</param>
        /// <param name="versionNumber">The version number. (required).</param>
        public DocumentVersion(string id = default(string), long versionNumber = default(long))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for DocumentVersion and cannot be null");
            }
            this.Id = id;
            this.VersionNumber = versionNumber;
        }

        /// <summary>
        /// The version UUID.
        /// </summary>
        /// <value>The version UUID.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// The version number.
        /// </summary>
        /// <value>The version number.</value>
        [DataMember(Name = "versionNumber", IsRequired = true, EmitDefaultValue = true)]
        public long VersionNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DocumentVersion {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  VersionNumber: ").Append(VersionNumber).Append("\n");
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
