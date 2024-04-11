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
    /// ActorsMap
    /// </summary>
    [DataContract(Name = "ActorsMap")]
    public partial class ActorsMap : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActorsMap" /> class.
        /// </summary>
        /// <param name="group">The name of the group to add. This parameter cannot be used with the &#x60;groupId&#x60; parameter. As a group&#39;s name can change, use of &#x60;groupId&#x60; is recommended..</param>
        /// <param name="groupId">The ID of the group to add. This parameter cannot be used with the &#x60;group&#x60; parameter..</param>
        /// <param name="user">The user account ID of the user to add..</param>
        public ActorsMap(List<string> group = default(List<string>), List<string> groupId = default(List<string>), List<string> user = default(List<string>))
        {
            this.Group = group;
            this.GroupId = groupId;
            this.User = user;
        }

        /// <summary>
        /// The name of the group to add. This parameter cannot be used with the &#x60;groupId&#x60; parameter. As a group&#39;s name can change, use of &#x60;groupId&#x60; is recommended.
        /// </summary>
        /// <value>The name of the group to add. This parameter cannot be used with the &#x60;groupId&#x60; parameter. As a group&#39;s name can change, use of &#x60;groupId&#x60; is recommended.</value>
        [DataMember(Name = "group", EmitDefaultValue = false)]
        public List<string> Group { get; set; }

        /// <summary>
        /// The ID of the group to add. This parameter cannot be used with the &#x60;group&#x60; parameter.
        /// </summary>
        /// <value>The ID of the group to add. This parameter cannot be used with the &#x60;group&#x60; parameter.</value>
        [DataMember(Name = "groupId", EmitDefaultValue = false)]
        public List<string> GroupId { get; set; }

        /// <summary>
        /// The user account ID of the user to add.
        /// </summary>
        /// <value>The user account ID of the user to add.</value>
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public List<string> User { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActorsMap {\n");
            sb.Append("  Group: ").Append(Group).Append("\n");
            sb.Append("  GroupId: ").Append(GroupId).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
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
