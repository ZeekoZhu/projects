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
    /// Bulk operation filter details.
    /// </summary>
    [DataContract(Name = "IssueFilterForBulkPropertySet")]
    public partial class IssueFilterForBulkPropertySet : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueFilterForBulkPropertySet" /> class.
        /// </summary>
        /// <param name="currentValue">The value of properties to perform the bulk operation on..</param>
        /// <param name="entityIds">List of issues to perform the bulk operation on..</param>
        /// <param name="hasProperty">Whether the bulk operation occurs only when the property is present on or absent from an issue..</param>
        public IssueFilterForBulkPropertySet(Object currentValue = default(Object), List<long> entityIds = default(List<long>), bool hasProperty = default(bool))
        {
            this.CurrentValue = currentValue;
            this.EntityIds = entityIds;
            this.HasProperty = hasProperty;
        }

        /// <summary>
        /// The value of properties to perform the bulk operation on.
        /// </summary>
        /// <value>The value of properties to perform the bulk operation on.</value>
        [DataMember(Name = "currentValue", EmitDefaultValue = true)]
        public Object CurrentValue { get; set; }

        /// <summary>
        /// List of issues to perform the bulk operation on.
        /// </summary>
        /// <value>List of issues to perform the bulk operation on.</value>
        [DataMember(Name = "entityIds", EmitDefaultValue = false)]
        public List<long> EntityIds { get; set; }

        /// <summary>
        /// Whether the bulk operation occurs only when the property is present on or absent from an issue.
        /// </summary>
        /// <value>Whether the bulk operation occurs only when the property is present on or absent from an issue.</value>
        [DataMember(Name = "hasProperty", EmitDefaultValue = true)]
        public bool HasProperty { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IssueFilterForBulkPropertySet {\n");
            sb.Append("  CurrentValue: ").Append(CurrentValue).Append("\n");
            sb.Append("  EntityIds: ").Append(EntityIds).Append("\n");
            sb.Append("  HasProperty: ").Append(HasProperty).Append("\n");
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
