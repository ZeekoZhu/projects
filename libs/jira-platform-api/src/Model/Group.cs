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
    /// Group
    /// </summary>
    [DataContract(Name = "Group")]
    public partial class Group : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Group" /> class.
        /// </summary>
        /// <param name="groupId">The ID of the group, which uniquely identifies the group across all Atlassian products. For example, *952d12c3-5b5b-4d04-bb32-44d383afc4b2*..</param>
        /// <param name="name">The name of group..</param>
        /// <param name="users">users.</param>
        public Group(string groupId = default(string), string name = default(string), GroupUsers users = default(GroupUsers))
        {
            this.GroupId = groupId;
            this.Name = name;
            this.Users = users;
        }

        /// <summary>
        /// Expand options that include additional group details in the response.
        /// </summary>
        /// <value>Expand options that include additional group details in the response.</value>
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
        /// The ID of the group, which uniquely identifies the group across all Atlassian products. For example, *952d12c3-5b5b-4d04-bb32-44d383afc4b2*.
        /// </summary>
        /// <value>The ID of the group, which uniquely identifies the group across all Atlassian products. For example, *952d12c3-5b5b-4d04-bb32-44d383afc4b2*.</value>
        [DataMember(Name = "groupId", EmitDefaultValue = true)]
        public string GroupId { get; set; }

        /// <summary>
        /// The name of group.
        /// </summary>
        /// <value>The name of group.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The URL for these group details.
        /// </summary>
        /// <value>The URL for these group details.</value>
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
        /// Gets or Sets Users
        /// </summary>
        [DataMember(Name = "users", EmitDefaultValue = false)]
        public GroupUsers Users { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Group {\n");
            sb.Append("  Expand: ").Append(Expand).Append("\n");
            sb.Append("  GroupId: ").Append(GroupId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  Users: ").Append(Users).Append("\n");
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