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
    /// The result of a JQL search.
    /// </summary>
    [DataContract(Name = "SearchResults")]
    public partial class SearchResults : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResults" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public SearchResults()
        {
        }

        /// <summary>
        /// Expand options that include additional search result details in the response.
        /// </summary>
        /// <value>Expand options that include additional search result details in the response.</value>
        [DataMember(Name = "expand", EmitDefaultValue = false)]
        public string Expand { get; private set; }

        /// <summary>
        /// Returns false as Expand should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeExpand()
        {
            return false;
        }
        /// <summary>
        /// The list of issues found by the search.
        /// </summary>
        /// <value>The list of issues found by the search.</value>
        [DataMember(Name = "issues", EmitDefaultValue = false)]
        public List<IssueBean> Issues { get; private set; }

        /// <summary>
        /// Returns false as Issues should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIssues()
        {
            return false;
        }
        /// <summary>
        /// The maximum number of results that could be on the page.
        /// </summary>
        /// <value>The maximum number of results that could be on the page.</value>
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
        /// The ID and name of each field in the search results.
        /// </summary>
        /// <value>The ID and name of each field in the search results.</value>
        [DataMember(Name = "names", EmitDefaultValue = false)]
        public Dictionary<string, string> Names { get; private set; }

        /// <summary>
        /// Returns false as Names should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeNames()
        {
            return false;
        }
        /// <summary>
        /// The schema describing the field types in the search results.
        /// </summary>
        /// <value>The schema describing the field types in the search results.</value>
        [DataMember(Name = "schema", EmitDefaultValue = false)]
        public Dictionary<string, JsonTypeBean> Schema { get; private set; }

        /// <summary>
        /// Returns false as Schema should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSchema()
        {
            return false;
        }
        /// <summary>
        /// The index of the first item returned on the page.
        /// </summary>
        /// <value>The index of the first item returned on the page.</value>
        [DataMember(Name = "startAt", EmitDefaultValue = false)]
        public int StartAt { get; private set; }

        /// <summary>
        /// Returns false as StartAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeStartAt()
        {
            return false;
        }
        /// <summary>
        /// The number of results on the page.
        /// </summary>
        /// <value>The number of results on the page.</value>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; private set; }

        /// <summary>
        /// Returns false as Total should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeTotal()
        {
            return false;
        }
        /// <summary>
        /// Any warnings related to the JQL query.
        /// </summary>
        /// <value>Any warnings related to the JQL query.</value>
        [DataMember(Name = "warningMessages", EmitDefaultValue = false)]
        public List<string> WarningMessages { get; private set; }

        /// <summary>
        /// Returns false as WarningMessages should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeWarningMessages()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SearchResults {\n");
            sb.Append("  Expand: ").Append(Expand).Append("\n");
            sb.Append("  Issues: ").Append(Issues).Append("\n");
            sb.Append("  MaxResults: ").Append(MaxResults).Append("\n");
            sb.Append("  Names: ").Append(Names).Append("\n");
            sb.Append("  Schema: ").Append(Schema).Append("\n");
            sb.Append("  StartAt: ").Append(StartAt).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  WarningMessages: ").Append(WarningMessages).Append("\n");
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
