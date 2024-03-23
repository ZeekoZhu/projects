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
    /// A webhook.
    /// </summary>
    [DataContract(Name = "Webhook")]
    public partial class Webhook : IValidatableObject
    {
        /// <summary>
        /// Defines Events
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventsEnum
        {
            /// <summary>
            /// Enum JiraissueCreated for value: jira:issue_created
            /// </summary>
            [EnumMember(Value = "jira:issue_created")]
            JiraissueCreated = 1,

            /// <summary>
            /// Enum JiraissueUpdated for value: jira:issue_updated
            /// </summary>
            [EnumMember(Value = "jira:issue_updated")]
            JiraissueUpdated = 2,

            /// <summary>
            /// Enum JiraissueDeleted for value: jira:issue_deleted
            /// </summary>
            [EnumMember(Value = "jira:issue_deleted")]
            JiraissueDeleted = 3,

            /// <summary>
            /// Enum CommentCreated for value: comment_created
            /// </summary>
            [EnumMember(Value = "comment_created")]
            CommentCreated = 4,

            /// <summary>
            /// Enum CommentUpdated for value: comment_updated
            /// </summary>
            [EnumMember(Value = "comment_updated")]
            CommentUpdated = 5,

            /// <summary>
            /// Enum CommentDeleted for value: comment_deleted
            /// </summary>
            [EnumMember(Value = "comment_deleted")]
            CommentDeleted = 6,

            /// <summary>
            /// Enum IssuePropertySet for value: issue_property_set
            /// </summary>
            [EnumMember(Value = "issue_property_set")]
            IssuePropertySet = 7,

            /// <summary>
            /// Enum IssuePropertyDeleted for value: issue_property_deleted
            /// </summary>
            [EnumMember(Value = "issue_property_deleted")]
            IssuePropertyDeleted = 8
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Webhook" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Webhook() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Webhook" /> class.
        /// </summary>
        /// <param name="events">The Jira events that trigger the webhook. (required).</param>
        /// <param name="fieldIdsFilter">A list of field IDs. When the issue changelog contains any of the fields, the webhook &#x60;jira:issue_updated&#x60; is sent. If this parameter is not present, the app is notified about all field updates..</param>
        /// <param name="id">The ID of the webhook. (required).</param>
        /// <param name="issuePropertyKeysFilter">A list of issue property keys. A change of those issue properties triggers the &#x60;issue_property_set&#x60; or &#x60;issue_property_deleted&#x60; webhooks. If this parameter is not present, the app is notified about all issue property updates..</param>
        /// <param name="jqlFilter">The JQL filter that specifies which issues the webhook is sent for. (required).</param>
        public Webhook(List<EventsEnum> events = default(List<EventsEnum>), List<string> fieldIdsFilter = default(List<string>), long id = default(long), List<string> issuePropertyKeysFilter = default(List<string>), string jqlFilter = default(string))
        {
            // to ensure "events" is required (not null)
            if (events == null)
            {
                throw new ArgumentNullException("events is a required property for Webhook and cannot be null");
            }
            this.Events = events;
            this.Id = id;
            // to ensure "jqlFilter" is required (not null)
            if (jqlFilter == null)
            {
                throw new ArgumentNullException("jqlFilter is a required property for Webhook and cannot be null");
            }
            this.JqlFilter = jqlFilter;
            this.FieldIdsFilter = fieldIdsFilter;
            this.IssuePropertyKeysFilter = issuePropertyKeysFilter;
        }

        /// <summary>
        /// The Jira events that trigger the webhook.
        /// </summary>
        /// <value>The Jira events that trigger the webhook.</value>
        [DataMember(Name = "events", IsRequired = true, EmitDefaultValue = true)]
        public List<Webhook.EventsEnum> Events { get; set; }

        /// <summary>
        /// The date after which the webhook is no longer sent. Use [Extend webhook life](https://developer.atlassian.com/cloud/jira/platform/rest/v3/api-group-webhooks/#api-rest-api-3-webhook-refresh-put) to extend the date.
        /// </summary>
        /// <value>The date after which the webhook is no longer sent. Use [Extend webhook life](https://developer.atlassian.com/cloud/jira/platform/rest/v3/api-group-webhooks/#api-rest-api-3-webhook-refresh-put) to extend the date.</value>
        [DataMember(Name = "expirationDate", EmitDefaultValue = false)]
        public long ExpirationDate { get; private set; }

        /// <summary>
        /// Returns false as ExpirationDate should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeExpirationDate()
        {
            return false;
        }
        /// <summary>
        /// A list of field IDs. When the issue changelog contains any of the fields, the webhook &#x60;jira:issue_updated&#x60; is sent. If this parameter is not present, the app is notified about all field updates.
        /// </summary>
        /// <value>A list of field IDs. When the issue changelog contains any of the fields, the webhook &#x60;jira:issue_updated&#x60; is sent. If this parameter is not present, the app is notified about all field updates.</value>
        [DataMember(Name = "fieldIdsFilter", EmitDefaultValue = false)]
        public List<string> FieldIdsFilter { get; set; }

        /// <summary>
        /// The ID of the webhook.
        /// </summary>
        /// <value>The ID of the webhook.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public long Id { get; set; }

        /// <summary>
        /// A list of issue property keys. A change of those issue properties triggers the &#x60;issue_property_set&#x60; or &#x60;issue_property_deleted&#x60; webhooks. If this parameter is not present, the app is notified about all issue property updates.
        /// </summary>
        /// <value>A list of issue property keys. A change of those issue properties triggers the &#x60;issue_property_set&#x60; or &#x60;issue_property_deleted&#x60; webhooks. If this parameter is not present, the app is notified about all issue property updates.</value>
        [DataMember(Name = "issuePropertyKeysFilter", EmitDefaultValue = false)]
        public List<string> IssuePropertyKeysFilter { get; set; }

        /// <summary>
        /// The JQL filter that specifies which issues the webhook is sent for.
        /// </summary>
        /// <value>The JQL filter that specifies which issues the webhook is sent for.</value>
        [DataMember(Name = "jqlFilter", IsRequired = true, EmitDefaultValue = true)]
        public string JqlFilter { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Webhook {\n");
            sb.Append("  Events: ").Append(Events).Append("\n");
            sb.Append("  ExpirationDate: ").Append(ExpirationDate).Append("\n");
            sb.Append("  FieldIdsFilter: ").Append(FieldIdsFilter).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IssuePropertyKeysFilter: ").Append(IssuePropertyKeysFilter).Append("\n");
            sb.Append("  JqlFilter: ").Append(JqlFilter).Append("\n");
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
