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
    /// Details of notifications which should be added to the notification scheme.
    /// </summary>
    [DataContract(Name = "AddNotificationsDetails")]
    public partial class AddNotificationsDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddNotificationsDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AddNotificationsDetails()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddNotificationsDetails" /> class.
        /// </summary>
        /// <param name="notificationSchemeEvents">The list of notifications which should be added to the notification scheme. (required).</param>
        public AddNotificationsDetails(List<NotificationSchemeEventDetails> notificationSchemeEvents = default(List<NotificationSchemeEventDetails>))
        {
            // to ensure "notificationSchemeEvents" is required (not null)
            if (notificationSchemeEvents == null)
            {
                throw new ArgumentNullException("notificationSchemeEvents is a required property for AddNotificationsDetails and cannot be null");
            }
            this.NotificationSchemeEvents = notificationSchemeEvents;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// The list of notifications which should be added to the notification scheme.
        /// </summary>
        /// <value>The list of notifications which should be added to the notification scheme.</value>
        [DataMember(Name = "notificationSchemeEvents", IsRequired = true, EmitDefaultValue = true)]
        public List<NotificationSchemeEventDetails> NotificationSchemeEvents { get; set; }

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
            sb.Append("class AddNotificationsDetails {\n");
            sb.Append("  NotificationSchemeEvents: ").Append(NotificationSchemeEvents).Append("\n");
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
