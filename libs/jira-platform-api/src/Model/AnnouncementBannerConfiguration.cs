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
    /// Announcement banner configuration.
    /// </summary>
    [DataContract(Name = "AnnouncementBannerConfiguration")]
    public partial class AnnouncementBannerConfiguration : IValidatableObject
    {
        /// <summary>
        /// Visibility of the announcement banner.
        /// </summary>
        /// <value>Visibility of the announcement banner.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum VisibilityEnum
        {
            /// <summary>
            /// Enum PUBLIC for value: PUBLIC
            /// </summary>
            [EnumMember(Value = "PUBLIC")]
            PUBLIC = 1,

            /// <summary>
            /// Enum PRIVATE for value: PRIVATE
            /// </summary>
            [EnumMember(Value = "PRIVATE")]
            PRIVATE = 2
        }


        /// <summary>
        /// Visibility of the announcement banner.
        /// </summary>
        /// <value>Visibility of the announcement banner.</value>
        [DataMember(Name = "visibility", EmitDefaultValue = false)]
        public VisibilityEnum? Visibility { get; set; }

        /// <summary>
        /// Returns false as Visibility should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeVisibility()
        {
            return false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AnnouncementBannerConfiguration" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public AnnouncementBannerConfiguration()
        {
        }

        /// <summary>
        /// Hash of the banner data. The client detects updates by comparing hash IDs.
        /// </summary>
        /// <value>Hash of the banner data. The client detects updates by comparing hash IDs.</value>
        [DataMember(Name = "hashId", EmitDefaultValue = false)]
        public string HashId { get; private set; }

        /// <summary>
        /// Returns false as HashId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeHashId()
        {
            return false;
        }
        /// <summary>
        /// Flag indicating if the announcement banner can be dismissed by the user.
        /// </summary>
        /// <value>Flag indicating if the announcement banner can be dismissed by the user.</value>
        [DataMember(Name = "isDismissible", EmitDefaultValue = true)]
        public bool IsDismissible { get; private set; }

        /// <summary>
        /// Returns false as IsDismissible should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIsDismissible()
        {
            return false;
        }
        /// <summary>
        /// Flag indicating if the announcement banner is enabled or not.
        /// </summary>
        /// <value>Flag indicating if the announcement banner is enabled or not.</value>
        [DataMember(Name = "isEnabled", EmitDefaultValue = true)]
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// Returns false as IsEnabled should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIsEnabled()
        {
            return false;
        }
        /// <summary>
        /// The text on the announcement banner.
        /// </summary>
        /// <value>The text on the announcement banner.</value>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; private set; }

        /// <summary>
        /// Returns false as Message should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeMessage()
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
            sb.Append("class AnnouncementBannerConfiguration {\n");
            sb.Append("  HashId: ").Append(HashId).Append("\n");
            sb.Append("  IsDismissible: ").Append(IsDismissible).Append("\n");
            sb.Append("  IsEnabled: ").Append(IsEnabled).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Visibility: ").Append(Visibility).Append("\n");
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