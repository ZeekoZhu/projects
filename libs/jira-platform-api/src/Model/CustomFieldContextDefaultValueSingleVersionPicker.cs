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
    /// The default value for a version picker custom field.
    /// </summary>
    [DataContract(Name = "CustomFieldContextDefaultValueSingleVersionPicker")]
    public partial class CustomFieldContextDefaultValueSingleVersionPicker : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldContextDefaultValueSingleVersionPicker" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CustomFieldContextDefaultValueSingleVersionPicker() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldContextDefaultValueSingleVersionPicker" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="versionId">The ID of the default version. (required).</param>
        /// <param name="versionOrder">The order the pickable versions are displayed in. If not provided, the released-first order is used. Available version orders are &#x60;\&quot;releasedFirst\&quot;&#x60; and &#x60;\&quot;unreleasedFirst\&quot;&#x60;..</param>
        public CustomFieldContextDefaultValueSingleVersionPicker(string type = default(string), string versionId = default(string), string versionOrder = default(string))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for CustomFieldContextDefaultValueSingleVersionPicker and cannot be null");
            }
            this.Type = type;
            // to ensure "versionId" is required (not null)
            if (versionId == null)
            {
                throw new ArgumentNullException("versionId is a required property for CustomFieldContextDefaultValueSingleVersionPicker and cannot be null");
            }
            this.VersionId = versionId;
            this.VersionOrder = versionOrder;
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// The ID of the default version.
        /// </summary>
        /// <value>The ID of the default version.</value>
        [DataMember(Name = "versionId", IsRequired = true, EmitDefaultValue = true)]
        public string VersionId { get; set; }

        /// <summary>
        /// The order the pickable versions are displayed in. If not provided, the released-first order is used. Available version orders are &#x60;\&quot;releasedFirst\&quot;&#x60; and &#x60;\&quot;unreleasedFirst\&quot;&#x60;.
        /// </summary>
        /// <value>The order the pickable versions are displayed in. If not provided, the released-first order is used. Available version orders are &#x60;\&quot;releasedFirst\&quot;&#x60; and &#x60;\&quot;unreleasedFirst\&quot;&#x60;.</value>
        [DataMember(Name = "versionOrder", EmitDefaultValue = false)]
        public string VersionOrder { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomFieldContextDefaultValueSingleVersionPicker {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  VersionId: ").Append(VersionId).Append("\n");
            sb.Append("  VersionOrder: ").Append(VersionOrder).Append("\n");
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
