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
    /// Details of a field that can be used in advanced searches.
    /// </summary>
    [DataContract(Name = "FieldReferenceData")]
    public partial class FieldReferenceData : IValidatableObject
    {
        /// <summary>
        /// Whether the field provide auto-complete suggestions.
        /// </summary>
        /// <value>Whether the field provide auto-complete suggestions.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AutoEnum
        {
            /// <summary>
            /// Enum True for value: true
            /// </summary>
            [EnumMember(Value = "true")]
            True = 1,

            /// <summary>
            /// Enum False for value: false
            /// </summary>
            [EnumMember(Value = "false")]
            False = 2
        }


        /// <summary>
        /// Whether the field provide auto-complete suggestions.
        /// </summary>
        /// <value>Whether the field provide auto-complete suggestions.</value>
        [DataMember(Name = "auto", EmitDefaultValue = false)]
        public AutoEnum? Auto { get; set; }
        /// <summary>
        /// Whether this field has been deprecated.
        /// </summary>
        /// <value>Whether this field has been deprecated.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeprecatedEnum
        {
            /// <summary>
            /// Enum True for value: true
            /// </summary>
            [EnumMember(Value = "true")]
            True = 1,

            /// <summary>
            /// Enum False for value: false
            /// </summary>
            [EnumMember(Value = "false")]
            False = 2
        }


        /// <summary>
        /// Whether this field has been deprecated.
        /// </summary>
        /// <value>Whether this field has been deprecated.</value>
        [DataMember(Name = "deprecated", EmitDefaultValue = false)]
        public DeprecatedEnum? Deprecated { get; set; }
        /// <summary>
        /// Whether the field can be used in a query&#39;s &#x60;ORDER BY&#x60; clause.
        /// </summary>
        /// <value>Whether the field can be used in a query&#39;s &#x60;ORDER BY&#x60; clause.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderableEnum
        {
            /// <summary>
            /// Enum True for value: true
            /// </summary>
            [EnumMember(Value = "true")]
            True = 1,

            /// <summary>
            /// Enum False for value: false
            /// </summary>
            [EnumMember(Value = "false")]
            False = 2
        }


        /// <summary>
        /// Whether the field can be used in a query&#39;s &#x60;ORDER BY&#x60; clause.
        /// </summary>
        /// <value>Whether the field can be used in a query&#39;s &#x60;ORDER BY&#x60; clause.</value>
        [DataMember(Name = "orderable", EmitDefaultValue = false)]
        public OrderableEnum? Orderable { get; set; }
        /// <summary>
        /// Whether the content of this field can be searched.
        /// </summary>
        /// <value>Whether the content of this field can be searched.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SearchableEnum
        {
            /// <summary>
            /// Enum True for value: true
            /// </summary>
            [EnumMember(Value = "true")]
            True = 1,

            /// <summary>
            /// Enum False for value: false
            /// </summary>
            [EnumMember(Value = "false")]
            False = 2
        }


        /// <summary>
        /// Whether the content of this field can be searched.
        /// </summary>
        /// <value>Whether the content of this field can be searched.</value>
        [DataMember(Name = "searchable", EmitDefaultValue = false)]
        public SearchableEnum? Searchable { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldReferenceData" /> class.
        /// </summary>
        /// <param name="auto">Whether the field provide auto-complete suggestions..</param>
        /// <param name="cfid">If the item is a custom field, the ID of the custom field..</param>
        /// <param name="deprecated">Whether this field has been deprecated..</param>
        /// <param name="deprecatedSearcherKey">The searcher key of the field, only passed when the field is deprecated..</param>
        /// <param name="displayName">The display name contains the following:   *  for system fields, the field name. For example, &#x60;Summary&#x60;.  *  for collapsed custom fields, the field name followed by a hyphen and then the field name and field type. For example, &#x60;Component - Component[Dropdown]&#x60;.  *  for other custom fields, the field name followed by a hyphen and then the custom field ID. For example, &#x60;Component - cf[10061]&#x60;..</param>
        /// <param name="operators">The valid search operators for the field..</param>
        /// <param name="orderable">Whether the field can be used in a query&#39;s &#x60;ORDER BY&#x60; clause..</param>
        /// <param name="searchable">Whether the content of this field can be searched..</param>
        /// <param name="types">The data types of items in the field..</param>
        /// <param name="value">The field identifier..</param>
        public FieldReferenceData(AutoEnum? auto = default(AutoEnum?), string cfid = default(string), DeprecatedEnum? deprecated = default(DeprecatedEnum?), string deprecatedSearcherKey = default(string), string displayName = default(string), List<string> operators = default(List<string>), OrderableEnum? orderable = default(OrderableEnum?), SearchableEnum? searchable = default(SearchableEnum?), List<string> types = default(List<string>), string value = default(string))
        {
            this.Auto = auto;
            this.Cfid = cfid;
            this.Deprecated = deprecated;
            this.DeprecatedSearcherKey = deprecatedSearcherKey;
            this.DisplayName = displayName;
            this.Operators = operators;
            this.Orderable = orderable;
            this.Searchable = searchable;
            this.Types = types;
            this.Value = value;
        }

        /// <summary>
        /// If the item is a custom field, the ID of the custom field.
        /// </summary>
        /// <value>If the item is a custom field, the ID of the custom field.</value>
        [DataMember(Name = "cfid", EmitDefaultValue = false)]
        public string Cfid { get; set; }

        /// <summary>
        /// The searcher key of the field, only passed when the field is deprecated.
        /// </summary>
        /// <value>The searcher key of the field, only passed when the field is deprecated.</value>
        [DataMember(Name = "deprecatedSearcherKey", EmitDefaultValue = false)]
        public string DeprecatedSearcherKey { get; set; }

        /// <summary>
        /// The display name contains the following:   *  for system fields, the field name. For example, &#x60;Summary&#x60;.  *  for collapsed custom fields, the field name followed by a hyphen and then the field name and field type. For example, &#x60;Component - Component[Dropdown]&#x60;.  *  for other custom fields, the field name followed by a hyphen and then the custom field ID. For example, &#x60;Component - cf[10061]&#x60;.
        /// </summary>
        /// <value>The display name contains the following:   *  for system fields, the field name. For example, &#x60;Summary&#x60;.  *  for collapsed custom fields, the field name followed by a hyphen and then the field name and field type. For example, &#x60;Component - Component[Dropdown]&#x60;.  *  for other custom fields, the field name followed by a hyphen and then the custom field ID. For example, &#x60;Component - cf[10061]&#x60;.</value>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The valid search operators for the field.
        /// </summary>
        /// <value>The valid search operators for the field.</value>
        [DataMember(Name = "operators", EmitDefaultValue = false)]
        public List<string> Operators { get; set; }

        /// <summary>
        /// The data types of items in the field.
        /// </summary>
        /// <value>The data types of items in the field.</value>
        [DataMember(Name = "types", EmitDefaultValue = false)]
        public List<string> Types { get; set; }

        /// <summary>
        /// The field identifier.
        /// </summary>
        /// <value>The field identifier.</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FieldReferenceData {\n");
            sb.Append("  Auto: ").Append(Auto).Append("\n");
            sb.Append("  Cfid: ").Append(Cfid).Append("\n");
            sb.Append("  Deprecated: ").Append(Deprecated).Append("\n");
            sb.Append("  DeprecatedSearcherKey: ").Append(DeprecatedSearcherKey).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Operators: ").Append(Operators).Append("\n");
            sb.Append("  Orderable: ").Append(Orderable).Append("\n");
            sb.Append("  Searchable: ").Append(Searchable).Append("\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
