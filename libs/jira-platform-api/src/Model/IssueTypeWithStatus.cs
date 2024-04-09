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
    /// Status details for an issue type.
    /// </summary>
    [DataContract(Name = "IssueTypeWithStatus")]
    public partial class IssueTypeWithStatus : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueTypeWithStatus" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public IssueTypeWithStatus()
        {
        }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        /// <value>The ID of the issue type.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; private set; }

        /// <summary>
        /// Returns false as Id should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeId()
        {
            return false;
        }
        /// <summary>
        /// The name of the issue type.
        /// </summary>
        /// <value>The name of the issue type.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; private set; }

        /// <summary>
        /// Returns false as Name should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeName()
        {
            return false;
        }
        /// <summary>
        /// The URL of the issue type&#39;s status details.
        /// </summary>
        /// <value>The URL of the issue type&#39;s status details.</value>
        [DataMember(Name = "self", IsRequired = true, EmitDefaultValue = true)]
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
        /// List of status details for the issue type.
        /// </summary>
        /// <value>List of status details for the issue type.</value>
        [DataMember(Name = "statuses", IsRequired = true, EmitDefaultValue = true)]
        public List<StatusDetails> Statuses { get; private set; }

        /// <summary>
        /// Returns false as Statuses should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeStatuses()
        {
            return false;
        }
        /// <summary>
        /// Whether this issue type represents subtasks.
        /// </summary>
        /// <value>Whether this issue type represents subtasks.</value>
        [DataMember(Name = "subtask", IsRequired = true, EmitDefaultValue = true)]
        public bool Subtask { get; private set; }

        /// <summary>
        /// Returns false as Subtask should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSubtask()
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
            sb.Append("class IssueTypeWithStatus {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  Statuses: ").Append(Statuses).Append("\n");
            sb.Append("  Subtask: ").Append(Subtask).Append("\n");
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