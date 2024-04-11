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
    /// The list of issue type IDs.
    /// </summary>
    [DataContract(Name = "IssueTypeIds")]
    public partial class IssueTypeIds : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueTypeIds" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected IssueTypeIds() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueTypeIds" /> class.
        /// </summary>
        /// <param name="varIssueTypeIds">The list of issue type IDs. (required).</param>
        public IssueTypeIds(List<string> varIssueTypeIds = default(List<string>))
        {
            // to ensure "varIssueTypeIds" is required (not null)
            if (varIssueTypeIds == null)
            {
                throw new ArgumentNullException("varIssueTypeIds is a required property for IssueTypeIds and cannot be null");
            }
            this.VarIssueTypeIds = varIssueTypeIds;
        }

        /// <summary>
        /// The list of issue type IDs.
        /// </summary>
        /// <value>The list of issue type IDs.</value>
        [DataMember(Name = "issueTypeIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> VarIssueTypeIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IssueTypeIds {\n");
            sb.Append("  VarIssueTypeIds: ").Append(VarIssueTypeIds).Append("\n");
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
