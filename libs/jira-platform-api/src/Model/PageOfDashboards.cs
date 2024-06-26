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
    /// A page containing dashboard details.
    /// </summary>
    [DataContract(Name = "PageOfDashboards")]
    public partial class PageOfDashboards : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageOfDashboards" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public PageOfDashboards()
        {
        }

        /// <summary>
        /// List of dashboards.
        /// </summary>
        /// <value>List of dashboards.</value>
        [DataMember(Name = "dashboards", EmitDefaultValue = false)]
        public List<Dashboard> Dashboards { get; private set; }

        /// <summary>
        /// Returns false as Dashboards should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDashboards()
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
        /// The URL of the next page of results, if any.
        /// </summary>
        /// <value>The URL of the next page of results, if any.</value>
        [DataMember(Name = "next", EmitDefaultValue = false)]
        public string Next { get; private set; }

        /// <summary>
        /// Returns false as Next should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeNext()
        {
            return false;
        }
        /// <summary>
        /// The URL of the previous page of results, if any.
        /// </summary>
        /// <value>The URL of the previous page of results, if any.</value>
        [DataMember(Name = "prev", EmitDefaultValue = false)]
        public string Prev { get; private set; }

        /// <summary>
        /// Returns false as Prev should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePrev()
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PageOfDashboards {\n");
            sb.Append("  Dashboards: ").Append(Dashboards).Append("\n");
            sb.Append("  MaxResults: ").Append(MaxResults).Append("\n");
            sb.Append("  Next: ").Append(Next).Append("\n");
            sb.Append("  Prev: ").Append(Prev).Append("\n");
            sb.Append("  StartAt: ").Append(StartAt).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
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
