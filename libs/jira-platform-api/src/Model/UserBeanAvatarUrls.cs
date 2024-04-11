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
    /// UserBeanAvatarUrls
    /// </summary>
    [DataContract(Name = "UserBeanAvatarUrls")]
    public partial class UserBeanAvatarUrls : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserBeanAvatarUrls" /> class.
        /// </summary>
        /// <param name="var16x16">The URL of the user&#39;s 16x16 pixel avatar..</param>
        /// <param name="var24x24">The URL of the user&#39;s 24x24 pixel avatar..</param>
        /// <param name="var32x32">The URL of the user&#39;s 32x32 pixel avatar..</param>
        /// <param name="var48x48">The URL of the user&#39;s 48x48 pixel avatar..</param>
        public UserBeanAvatarUrls(string var16x16 = default(string), string var24x24 = default(string), string var32x32 = default(string), string var48x48 = default(string))
        {
            this.Var16x16 = var16x16;
            this.Var24x24 = var24x24;
            this.Var32x32 = var32x32;
            this.Var48x48 = var48x48;
        }

        /// <summary>
        /// The URL of the user&#39;s 16x16 pixel avatar.
        /// </summary>
        /// <value>The URL of the user&#39;s 16x16 pixel avatar.</value>
        [DataMember(Name = "16x16", EmitDefaultValue = false)]
        public string Var16x16 { get; set; }

        /// <summary>
        /// The URL of the user&#39;s 24x24 pixel avatar.
        /// </summary>
        /// <value>The URL of the user&#39;s 24x24 pixel avatar.</value>
        [DataMember(Name = "24x24", EmitDefaultValue = false)]
        public string Var24x24 { get; set; }

        /// <summary>
        /// The URL of the user&#39;s 32x32 pixel avatar.
        /// </summary>
        /// <value>The URL of the user&#39;s 32x32 pixel avatar.</value>
        [DataMember(Name = "32x32", EmitDefaultValue = false)]
        public string Var32x32 { get; set; }

        /// <summary>
        /// The URL of the user&#39;s 48x48 pixel avatar.
        /// </summary>
        /// <value>The URL of the user&#39;s 48x48 pixel avatar.</value>
        [DataMember(Name = "48x48", EmitDefaultValue = false)]
        public string Var48x48 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserBeanAvatarUrls {\n");
            sb.Append("  Var16x16: ").Append(Var16x16).Append("\n");
            sb.Append("  Var24x24: ").Append(Var24x24).Append("\n");
            sb.Append("  Var32x32: ").Append(Var32x32).Append("\n");
            sb.Append("  Var48x48: ").Append(Var48x48).Append("\n");
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
