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
    /// A user found in a search.
    /// </summary>
    [DataContract(Name = "UserPickerUser")]
    public partial class UserPickerUser : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPickerUser" /> class.
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*..</param>
        /// <param name="avatarUrl">The avatar URL of the user..</param>
        /// <param name="displayName">The display name of the user. Depending on the user’s privacy setting, this may be returned as null..</param>
        /// <param name="html">The display name, email address, and key of the user with the matched query string highlighted with the HTML bold tag..</param>
        /// <param name="key">This property is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details..</param>
        /// <param name="name">This property is no longer available . See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details..</param>
        public UserPickerUser(string accountId = default(string), string avatarUrl = default(string), string displayName = default(string), string html = default(string), string key = default(string), string name = default(string))
        {
            this.AccountId = accountId;
            this.AvatarUrl = avatarUrl;
            this.DisplayName = displayName;
            this.Html = html;
            this.Key = key;
            this.Name = name;
        }

        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.
        /// </summary>
        /// <value>The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</value>
        [DataMember(Name = "accountId", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// The avatar URL of the user.
        /// </summary>
        /// <value>The avatar URL of the user.</value>
        [DataMember(Name = "avatarUrl", EmitDefaultValue = false)]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// The display name of the user. Depending on the user’s privacy setting, this may be returned as null.
        /// </summary>
        /// <value>The display name of the user. Depending on the user’s privacy setting, this may be returned as null.</value>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The display name, email address, and key of the user with the matched query string highlighted with the HTML bold tag.
        /// </summary>
        /// <value>The display name, email address, and key of the user with the matched query string highlighted with the HTML bold tag.</value>
        [DataMember(Name = "html", EmitDefaultValue = false)]
        public string Html { get; set; }

        /// <summary>
        /// This property is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        /// <value>This property is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</value>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        /// <summary>
        /// This property is no longer available . See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        /// <value>This property is no longer available . See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserPickerUser {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AvatarUrl: ").Append(AvatarUrl).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Html: ").Append(Html).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
