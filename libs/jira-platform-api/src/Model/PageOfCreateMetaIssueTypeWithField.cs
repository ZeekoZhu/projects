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
    /// A page of CreateMetaIssueType with Field.
    /// </summary>
    [DataContract(Name = "PageOfCreateMetaIssueTypeWithField")]
    public partial class PageOfCreateMetaIssueTypeWithField : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageOfCreateMetaIssueTypeWithField" /> class.
        /// </summary>
        /// <param name="results">results.</param>
        public PageOfCreateMetaIssueTypeWithField(List<FieldCreateMetadata> results = default(List<FieldCreateMetadata>))
        {
            this.Results = results;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// The collection of FieldCreateMetaBeans.
        /// </summary>
        /// <value>The collection of FieldCreateMetaBeans.</value>
        [DataMember(Name = "fields", EmitDefaultValue = false)]
        public List<FieldCreateMetadata> Fields { get; private set; }

        /// <summary>
        /// Returns false as Fields should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeFields()
        {
            return false;
        }
        /// <summary>
        /// The maximum number of items to return per page.
        /// </summary>
        /// <value>The maximum number of items to return per page.</value>
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
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<FieldCreateMetadata> Results { get; set; }

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
        /// The total number of items in all pages.
        /// </summary>
        /// <value>The total number of items in all pages.</value>
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
            sb.Append("class PageOfCreateMetaIssueTypeWithField {\n");
            sb.Append("  Fields: ").Append(Fields).Append("\n");
            sb.Append("  MaxResults: ").Append(MaxResults).Append("\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
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
