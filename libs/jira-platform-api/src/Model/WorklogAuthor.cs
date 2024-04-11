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
    /// Details of the user who created the worklog.
    /// </summary>
    [DataContract(Name = "Worklog_author")]
    public partial class WorklogAuthor : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorklogAuthor" /> class.
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*..</param>
        /// <param name="avatarUrls">avatarUrls.</param>
        public WorklogAuthor(string accountId = default(string), UserAvatarUrls avatarUrls = default(UserAvatarUrls))
        {
            this.AccountId = accountId;
            this.AvatarUrls = avatarUrls;
        }

        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.
        /// </summary>
        /// <value>The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</value>
        [DataMember(Name = "accountId", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// The type of account represented by this user. This will be one of &#39;atlassian&#39; (normal users), &#39;app&#39; (application user) or &#39;customer&#39; (Jira Service Desk customer user)
        /// </summary>
        /// <value>The type of account represented by this user. This will be one of &#39;atlassian&#39; (normal users), &#39;app&#39; (application user) or &#39;customer&#39; (Jira Service Desk customer user)</value>
        [DataMember(Name = "accountType", EmitDefaultValue = false)]
        public string AccountType { get; private set; }

        /// <summary>
        /// Returns false as AccountType should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAccountType()
        {
            return false;
        }
        /// <summary>
        /// Whether the user is active.
        /// </summary>
        /// <value>Whether the user is active.</value>
        [DataMember(Name = "active", EmitDefaultValue = true)]
        public bool Active { get; private set; }

        /// <summary>
        /// Returns false as Active should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeActive()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets AvatarUrls
        /// </summary>
        [DataMember(Name = "avatarUrls", EmitDefaultValue = false)]
        public UserAvatarUrls AvatarUrls { get; set; }

        /// <summary>
        /// The display name of the user. Depending on the user’s privacy settings, this may return an alternative value.
        /// </summary>
        /// <value>The display name of the user. Depending on the user’s privacy settings, this may return an alternative value.</value>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; private set; }

        /// <summary>
        /// Returns false as DisplayName should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDisplayName()
        {
            return false;
        }
        /// <summary>
        /// The email address of the user. Depending on the user’s privacy settings, this may be returned as null.
        /// </summary>
        /// <value>The email address of the user. Depending on the user’s privacy settings, this may be returned as null.</value>
        [DataMember(Name = "emailAddress", EmitDefaultValue = false)]
        public string EmailAddress { get; private set; }

        /// <summary>
        /// Returns false as EmailAddress should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeEmailAddress()
        {
            return false;
        }
        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        /// <value>This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</value>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; private set; }

        /// <summary>
        /// Returns false as Key should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeKey()
        {
            return false;
        }
        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        /// <value>This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
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
        /// The URL of the user.
        /// </summary>
        /// <value>The URL of the user.</value>
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
        /// The time zone specified in the user&#39;s profile. Depending on the user’s privacy settings, this may be returned as null.
        /// </summary>
        /// <value>The time zone specified in the user&#39;s profile. Depending on the user’s privacy settings, this may be returned as null.</value>
        [DataMember(Name = "timeZone", EmitDefaultValue = false)]
        public string VarTimeZone { get; private set; }

        /// <summary>
        /// Returns false as VarTimeZone should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeVarTimeZone()
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
            sb.Append("class WorklogAuthor {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AccountType: ").Append(AccountType).Append("\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  AvatarUrls: ").Append(AvatarUrls).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  EmailAddress: ").Append(EmailAddress).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  VarTimeZone: ").Append(VarTimeZone).Append("\n");
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
            // AccountId (string) maxLength
            if (this.AccountId != null && this.AccountId.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AccountId, length must be less than 128.", new [] { "AccountId" });
            }

            yield break;
        }
    }

}
