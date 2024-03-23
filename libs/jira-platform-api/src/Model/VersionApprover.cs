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
    /// Contains details about a version approver.
    /// </summary>
    [DataContract(Name = "VersionApprover")]
    public partial class VersionApprover : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionApprover" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public VersionApprover()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// The Atlassian account ID of the approver.
        /// </summary>
        /// <value>The Atlassian account ID of the approver.</value>
        [DataMember(Name = "accountId", EmitDefaultValue = false)]
        public string AccountId { get; private set; }

        /// <summary>
        /// Returns false as AccountId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAccountId()
        {
            return false;
        }
        /// <summary>
        /// A description of why the user is declining the approval.
        /// </summary>
        /// <value>A description of why the user is declining the approval.</value>
        [DataMember(Name = "declineReason", EmitDefaultValue = false)]
        public string DeclineReason { get; private set; }

        /// <summary>
        /// Returns false as DeclineReason should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDeclineReason()
        {
            return false;
        }
        /// <summary>
        /// A description of what the user is approving within the specified version.
        /// </summary>
        /// <value>A description of what the user is approving within the specified version.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; private set; }

        /// <summary>
        /// Returns false as Description should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDescription()
        {
            return false;
        }
        /// <summary>
        /// The status of the approval, which can be *PENDING*, *APPROVED*, or *DECLINED*
        /// </summary>
        /// <value>The status of the approval, which can be *PENDING*, *APPROVED*, or *DECLINED*</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; private set; }

        /// <summary>
        /// Returns false as Status should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeStatus()
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
            sb.Append("class VersionApprover {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  DeclineReason: ").Append(DeclineReason).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
