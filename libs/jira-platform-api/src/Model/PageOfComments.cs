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
    /// A page of comments.
    /// </summary>
    [DataContract(Name = "PageOfComments")]
    public partial class PageOfComments : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageOfComments" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public PageOfComments()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// The list of comments.
        /// </summary>
        /// <value>The list of comments.</value>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public List<Comment> Comments { get; private set; }

        /// <summary>
        /// Returns false as Comments should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeComments()
        {
            return false;
        }
        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        /// <value>The maximum number of items that could be returned.</value>
        [DataMember(Name = "maxResults", EmitDefaultValue = false)]
        public int MaxResults { get; private set; }

        /// <summary>
        /// Returns false as MaxResults should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeMaxResults()
        {
            return false;
        }
        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        /// <value>The index of the first item returned.</value>
        [DataMember(Name = "startAt", EmitDefaultValue = false)]
        public long StartAt { get; private set; }

        /// <summary>
        /// Returns false as StartAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeStartAt()
        {
            return false;
        }
        /// <summary>
        /// The number of items returned.
        /// </summary>
        /// <value>The number of items returned.</value>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public long Total { get; private set; }

        /// <summary>
        /// Returns false as Total should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeTotal()
        {
            return false;
        }
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
            sb.Append("class PageOfComments {\n");
            sb.Append("  Comments: ").Append(Comments).Append("\n");
            sb.Append("  MaxResults: ").Append(MaxResults).Append("\n");
            sb.Append("  StartAt: ").Append(StartAt).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
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
