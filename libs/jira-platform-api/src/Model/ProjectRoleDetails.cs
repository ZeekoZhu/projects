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
    /// Details about a project role.
    /// </summary>
    [DataContract(Name = "ProjectRoleDetails")]
    public partial class ProjectRoleDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRoleDetails" /> class.
        /// </summary>
        /// <param name="name">The name of the project role..</param>
        /// <param name="scope">scope.</param>
        /// <param name="translatedName">The translated name of the project role..</param>
        public ProjectRoleDetails(string name = default(string), ProjectRoleScope scope = default(ProjectRoleScope), string translatedName = default(string))
        {
            this.Name = name;
            this.Scope = scope;
            this.TranslatedName = translatedName;
        }

        /// <summary>
        /// Whether this role is the admin role for the project.
        /// </summary>
        /// <value>Whether this role is the admin role for the project.</value>
        [DataMember(Name = "admin", EmitDefaultValue = true)]
        public bool Admin { get; private set; }

        /// <summary>
        /// Returns false as Admin should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAdmin()
        {
            return false;
        }
        /// <summary>
        /// Whether this role is the default role for the project.
        /// </summary>
        /// <value>Whether this role is the default role for the project.</value>
        [DataMember(Name = "default", EmitDefaultValue = true)]
        public bool VarDefault { get; private set; }

        /// <summary>
        /// Returns false as VarDefault should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeVarDefault()
        {
            return false;
        }
        /// <summary>
        /// The description of the project role.
        /// </summary>
        /// <value>The description of the project role.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; private set; }

        /// <summary>
        /// Returns false as Description should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeDescription()
        {
            return false;
        }
        /// <summary>
        /// The ID of the project role.
        /// </summary>
        /// <value>The ID of the project role.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; private set; }

        /// <summary>
        /// Returns false as Id should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeId()
        {
            return false;
        }
        /// <summary>
        /// The name of the project role.
        /// </summary>
        /// <value>The name of the project role.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Whether the roles are configurable for this project.
        /// </summary>
        /// <value>Whether the roles are configurable for this project.</value>
        [DataMember(Name = "roleConfigurable", EmitDefaultValue = true)]
        public bool RoleConfigurable { get; private set; }

        /// <summary>
        /// Returns false as RoleConfigurable should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeRoleConfigurable()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Scope
        /// </summary>
        [DataMember(Name = "scope", EmitDefaultValue = false)]
        public ProjectRoleScope Scope { get; set; }

        /// <summary>
        /// The URL the project role details.
        /// </summary>
        /// <value>The URL the project role details.</value>
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
        /// The translated name of the project role.
        /// </summary>
        /// <value>The translated name of the project role.</value>
        [DataMember(Name = "translatedName", EmitDefaultValue = false)]
        public string TranslatedName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProjectRoleDetails {\n");
            sb.Append("  Admin: ").Append(Admin).Append("\n");
            sb.Append("  VarDefault: ").Append(VarDefault).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RoleConfigurable: ").Append(RoleConfigurable).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  TranslatedName: ").Append(TranslatedName).Append("\n");
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
