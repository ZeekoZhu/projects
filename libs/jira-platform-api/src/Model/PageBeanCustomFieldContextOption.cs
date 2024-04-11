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
    /// A page of items.
    /// </summary>
    [DataContract(Name = "PageBeanCustomFieldContextOption")]
    public partial class PageBeanCustomFieldContextOption : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageBeanCustomFieldContextOption" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public PageBeanCustomFieldContextOption()
        {
        }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        /// <value>Whether this is the last page.</value>
        [DataMember(Name = "isLast", EmitDefaultValue = true)]
        public bool IsLast { get; private set; }

        /// <summary>
        /// Returns false as IsLast should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIsLast()
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
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        /// <value>If there is another page of results, the URL of the next page.</value>
        [DataMember(Name = "nextPage", EmitDefaultValue = false)]
        public string NextPage { get; private set; }

        /// <summary>
        /// Returns false as NextPage should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeNextPage()
        {
            return false;
        }
        /// <summary>
        /// The URL of the page.
        /// </summary>
        /// <value>The URL of the page.</value>
        [DataMember(Name = "self", EmitDefaultValue = false)]
        public string Self { get; private set; }

        /// <summary>
        /// Returns false as Self should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSelf()
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
        /// The list of items.
        /// </summary>
        /// <value>The list of items.</value>
        [DataMember(Name = "values", EmitDefaultValue = false)]
        public List<CustomFieldContextOption> Values { get; private set; }

        /// <summary>
        /// Returns false as Values should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeValues()
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
            sb.Append("class PageBeanCustomFieldContextOption {\n");
            sb.Append("  IsLast: ").Append(IsLast).Append("\n");
            sb.Append("  MaxResults: ").Append(MaxResults).Append("\n");
            sb.Append("  NextPage: ").Append(NextPage).Append("\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  StartAt: ").Append(StartAt).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  Values: ").Append(Values).Append("\n");
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
