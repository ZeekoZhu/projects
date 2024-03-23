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
    /// Details of the users and groups to receive the notification.
    /// </summary>
    [DataContract(Name = "NotificationRecipients")]
    public partial class NotificationRecipients : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRecipients" /> class.
        /// </summary>
        /// <param name="assignee">Whether the notification should be sent to the issue&#39;s assignees..</param>
        /// <param name="groupIds">List of groupIds to receive the notification..</param>
        /// <param name="groups">List of groups to receive the notification..</param>
        /// <param name="reporter">Whether the notification should be sent to the issue&#39;s reporter..</param>
        /// <param name="users">List of users to receive the notification..</param>
        /// <param name="voters">Whether the notification should be sent to the issue&#39;s voters..</param>
        /// <param name="watchers">Whether the notification should be sent to the issue&#39;s watchers..</param>
        public NotificationRecipients(bool assignee = default(bool), List<string> groupIds = default(List<string>), List<GroupName> groups = default(List<GroupName>), bool reporter = default(bool), List<UserDetails> users = default(List<UserDetails>), bool voters = default(bool), bool watchers = default(bool))
        {
            this.Assignee = assignee;
            this.GroupIds = groupIds;
            this.Groups = groups;
            this.Reporter = reporter;
            this.Users = users;
            this.Voters = voters;
            this.Watchers = watchers;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Whether the notification should be sent to the issue&#39;s assignees.
        /// </summary>
        /// <value>Whether the notification should be sent to the issue&#39;s assignees.</value>
        [DataMember(Name = "assignee", EmitDefaultValue = true)]
        public bool Assignee { get; set; }

        /// <summary>
        /// List of groupIds to receive the notification.
        /// </summary>
        /// <value>List of groupIds to receive the notification.</value>
        [DataMember(Name = "groupIds", EmitDefaultValue = false)]
        public List<string> GroupIds { get; set; }

        /// <summary>
        /// List of groups to receive the notification.
        /// </summary>
        /// <value>List of groups to receive the notification.</value>
        [DataMember(Name = "groups", EmitDefaultValue = false)]
        public List<GroupName> Groups { get; set; }

        /// <summary>
        /// Whether the notification should be sent to the issue&#39;s reporter.
        /// </summary>
        /// <value>Whether the notification should be sent to the issue&#39;s reporter.</value>
        [DataMember(Name = "reporter", EmitDefaultValue = true)]
        public bool Reporter { get; set; }

        /// <summary>
        /// List of users to receive the notification.
        /// </summary>
        /// <value>List of users to receive the notification.</value>
        [DataMember(Name = "users", EmitDefaultValue = false)]
        public List<UserDetails> Users { get; set; }

        /// <summary>
        /// Whether the notification should be sent to the issue&#39;s voters.
        /// </summary>
        /// <value>Whether the notification should be sent to the issue&#39;s voters.</value>
        [DataMember(Name = "voters", EmitDefaultValue = true)]
        public bool Voters { get; set; }

        /// <summary>
        /// Whether the notification should be sent to the issue&#39;s watchers.
        /// </summary>
        /// <value>Whether the notification should be sent to the issue&#39;s watchers.</value>
        [DataMember(Name = "watchers", EmitDefaultValue = true)]
        public bool Watchers { get; set; }

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
            sb.Append("class NotificationRecipients {\n");
            sb.Append("  Assignee: ").Append(Assignee).Append("\n");
            sb.Append("  GroupIds: ").Append(GroupIds).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  Reporter: ").Append(Reporter).Append("\n");
            sb.Append("  Users: ").Append(Users).Append("\n");
            sb.Append("  Voters: ").Append(Voters).Append("\n");
            sb.Append("  Watchers: ").Append(Watchers).Append("\n");
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
