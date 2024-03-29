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
    /// Details of global permissions to look up and project permissions with associated projects and issues to look up.
    /// </summary>
    [DataContract(Name = "BulkPermissionsRequestBean")]
    public partial class BulkPermissionsRequestBean : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkPermissionsRequestBean" /> class.
        /// </summary>
        /// <param name="accountId">The account ID of a user..</param>
        /// <param name="globalPermissions">Global permissions to look up..</param>
        /// <param name="projectPermissions">Project permissions with associated projects and issues to look up..</param>
        public BulkPermissionsRequestBean(string accountId = default(string), List<string> globalPermissions = default(List<string>), List<BulkProjectPermissions> projectPermissions = default(List<BulkProjectPermissions>))
        {
            this.AccountId = accountId;
            this.GlobalPermissions = globalPermissions;
            this.ProjectPermissions = projectPermissions;
        }

        /// <summary>
        /// The account ID of a user.
        /// </summary>
        /// <value>The account ID of a user.</value>
        [DataMember(Name = "accountId", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// Global permissions to look up.
        /// </summary>
        /// <value>Global permissions to look up.</value>
        [DataMember(Name = "globalPermissions", EmitDefaultValue = false)]
        public List<string> GlobalPermissions { get; set; }

        /// <summary>
        /// Project permissions with associated projects and issues to look up.
        /// </summary>
        /// <value>Project permissions with associated projects and issues to look up.</value>
        [DataMember(Name = "projectPermissions", EmitDefaultValue = false)]
        public List<BulkProjectPermissions> ProjectPermissions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BulkPermissionsRequestBean {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  GlobalPermissions: ").Append(GlobalPermissions).Append("\n");
            sb.Append("  ProjectPermissions: ").Append(ProjectPermissions).Append("\n");
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