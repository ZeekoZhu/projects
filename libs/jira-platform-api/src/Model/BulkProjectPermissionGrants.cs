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
    /// List of project permissions and the projects and issues those permissions grant access to.
    /// </summary>
    [DataContract(Name = "BulkProjectPermissionGrants")]
    public partial class BulkProjectPermissionGrants : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkProjectPermissionGrants" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BulkProjectPermissionGrants() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkProjectPermissionGrants" /> class.
        /// </summary>
        /// <param name="issues">IDs of the issues the user has the permission for. (required).</param>
        /// <param name="permission">A project permission, (required).</param>
        /// <param name="projects">IDs of the projects the user has the permission for. (required).</param>
        public BulkProjectPermissionGrants(List<long> issues = default(List<long>), string permission = default(string), List<long> projects = default(List<long>))
        {
            // to ensure "issues" is required (not null)
            if (issues == null)
            {
                throw new ArgumentNullException("issues is a required property for BulkProjectPermissionGrants and cannot be null");
            }
            this.Issues = issues;
            // to ensure "permission" is required (not null)
            if (permission == null)
            {
                throw new ArgumentNullException("permission is a required property for BulkProjectPermissionGrants and cannot be null");
            }
            this.Permission = permission;
            // to ensure "projects" is required (not null)
            if (projects == null)
            {
                throw new ArgumentNullException("projects is a required property for BulkProjectPermissionGrants and cannot be null");
            }
            this.Projects = projects;
        }

        /// <summary>
        /// IDs of the issues the user has the permission for.
        /// </summary>
        /// <value>IDs of the issues the user has the permission for.</value>
        [DataMember(Name = "issues", IsRequired = true, EmitDefaultValue = true)]
        public List<long> Issues { get; set; }

        /// <summary>
        /// A project permission,
        /// </summary>
        /// <value>A project permission,</value>
        [DataMember(Name = "permission", IsRequired = true, EmitDefaultValue = true)]
        public string Permission { get; set; }

        /// <summary>
        /// IDs of the projects the user has the permission for.
        /// </summary>
        /// <value>IDs of the projects the user has the permission for.</value>
        [DataMember(Name = "projects", IsRequired = true, EmitDefaultValue = true)]
        public List<long> Projects { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BulkProjectPermissionGrants {\n");
            sb.Append("  Issues: ").Append(Issues).Append("\n");
            sb.Append("  Permission: ").Append(Permission).Append("\n");
            sb.Append("  Projects: ").Append(Projects).Append("\n");
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
