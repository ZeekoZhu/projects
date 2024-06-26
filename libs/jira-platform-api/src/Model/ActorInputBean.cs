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
    /// ActorInputBean
    /// </summary>
    [DataContract(Name = "ActorInputBean")]
    public partial class ActorInputBean : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActorInputBean" /> class.
        /// </summary>
        /// <param name="group">The name of the group to add as a default actor. This parameter cannot be used with the &#x60;groupId&#x60; parameter. As a group&#39;s name can change,use of &#x60;groupId&#x60; is recommended. This parameter accepts a comma-separated list. For example, &#x60;\&quot;group\&quot;:[\&quot;project-admin\&quot;, \&quot;jira-developers\&quot;]&#x60;..</param>
        /// <param name="groupId">The ID of the group to add as a default actor. This parameter cannot be used with the &#x60;group&#x60; parameter This parameter accepts a comma-separated list. For example, &#x60;\&quot;groupId\&quot;:[\&quot;77f6ab39-e755-4570-a6ae-2d7a8df0bcb8\&quot;, \&quot;0c011f85-69ed-49c4-a801-3b18d0f771bc\&quot;]&#x60;..</param>
        /// <param name="user">The account IDs of the users to add as default actors. This parameter accepts a comma-separated list. For example, &#x60;\&quot;user\&quot;:[\&quot;5b10a2844c20165700ede21g\&quot;, \&quot;5b109f2e9729b51b54dc274d\&quot;]&#x60;..</param>
        public ActorInputBean(List<string> group = default(List<string>), List<string> groupId = default(List<string>), List<string> user = default(List<string>))
        {
            this.Group = group;
            this.GroupId = groupId;
            this.User = user;
        }

        /// <summary>
        /// The name of the group to add as a default actor. This parameter cannot be used with the &#x60;groupId&#x60; parameter. As a group&#39;s name can change,use of &#x60;groupId&#x60; is recommended. This parameter accepts a comma-separated list. For example, &#x60;\&quot;group\&quot;:[\&quot;project-admin\&quot;, \&quot;jira-developers\&quot;]&#x60;.
        /// </summary>
        /// <value>The name of the group to add as a default actor. This parameter cannot be used with the &#x60;groupId&#x60; parameter. As a group&#39;s name can change,use of &#x60;groupId&#x60; is recommended. This parameter accepts a comma-separated list. For example, &#x60;\&quot;group\&quot;:[\&quot;project-admin\&quot;, \&quot;jira-developers\&quot;]&#x60;.</value>
        [DataMember(Name = "group", EmitDefaultValue = false)]
        public List<string> Group { get; set; }

        /// <summary>
        /// The ID of the group to add as a default actor. This parameter cannot be used with the &#x60;group&#x60; parameter This parameter accepts a comma-separated list. For example, &#x60;\&quot;groupId\&quot;:[\&quot;77f6ab39-e755-4570-a6ae-2d7a8df0bcb8\&quot;, \&quot;0c011f85-69ed-49c4-a801-3b18d0f771bc\&quot;]&#x60;.
        /// </summary>
        /// <value>The ID of the group to add as a default actor. This parameter cannot be used with the &#x60;group&#x60; parameter This parameter accepts a comma-separated list. For example, &#x60;\&quot;groupId\&quot;:[\&quot;77f6ab39-e755-4570-a6ae-2d7a8df0bcb8\&quot;, \&quot;0c011f85-69ed-49c4-a801-3b18d0f771bc\&quot;]&#x60;.</value>
        [DataMember(Name = "groupId", EmitDefaultValue = false)]
        public List<string> GroupId { get; set; }

        /// <summary>
        /// The account IDs of the users to add as default actors. This parameter accepts a comma-separated list. For example, &#x60;\&quot;user\&quot;:[\&quot;5b10a2844c20165700ede21g\&quot;, \&quot;5b109f2e9729b51b54dc274d\&quot;]&#x60;.
        /// </summary>
        /// <value>The account IDs of the users to add as default actors. This parameter accepts a comma-separated list. For example, &#x60;\&quot;user\&quot;:[\&quot;5b10a2844c20165700ede21g\&quot;, \&quot;5b109f2e9729b51b54dc274d\&quot;]&#x60;.</value>
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public List<string> User { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActorInputBean {\n");
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
