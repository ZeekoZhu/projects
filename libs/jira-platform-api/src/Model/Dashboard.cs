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
    /// Details of a dashboard.
    /// </summary>
    [DataContract(Name = "Dashboard")]
    public partial class Dashboard : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dashboard" /> class.
        /// </summary>
        /// <param name="description">description.</param>
        /// <param name="owner">owner.</param>
        public Dashboard(string description = default(string), DashboardOwner owner = default(DashboardOwner))
        {
            this.Description = description;
            this.Owner = owner;
        }

        /// <summary>
        /// The automatic refresh interval for the dashboard in milliseconds.
        /// </summary>
        /// <value>The automatic refresh interval for the dashboard in milliseconds.</value>
        [DataMember(Name = "automaticRefreshMs", EmitDefaultValue = false)]
        public int AutomaticRefreshMs { get; private set; }

        /// <summary>
        /// Returns false as AutomaticRefreshMs should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAutomaticRefreshMs()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The details of any edit share permissions for the dashboard.
        /// </summary>
        /// <value>The details of any edit share permissions for the dashboard.</value>
        [DataMember(Name = "editPermissions", EmitDefaultValue = false)]
        public List<SharePermission> EditPermissions { get; private set; }

        /// <summary>
        /// Returns false as EditPermissions should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeEditPermissions()
        {
            return false;
        }
        /// <summary>
        /// The ID of the dashboard.
        /// </summary>
        /// <value>The ID of the dashboard.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; private set; }

        /// <summary>
        /// Returns false as Id should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeId()
        {
            return false;
        }
        /// <summary>
        /// Whether the dashboard is selected as a favorite by the user.
        /// </summary>
        /// <value>Whether the dashboard is selected as a favorite by the user.</value>
        [DataMember(Name = "isFavourite", EmitDefaultValue = true)]
        public bool IsFavourite { get; private set; }

        /// <summary>
        /// Returns false as IsFavourite should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIsFavourite()
        {
            return false;
        }
        /// <summary>
        /// Whether the current user has permission to edit the dashboard.
        /// </summary>
        /// <value>Whether the current user has permission to edit the dashboard.</value>
        [DataMember(Name = "isWritable", EmitDefaultValue = true)]
        public bool IsWritable { get; private set; }

        /// <summary>
        /// Returns false as IsWritable should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeIsWritable()
        {
            return false;
        }
        /// <summary>
        /// The name of the dashboard.
        /// </summary>
        /// <value>The name of the dashboard.</value>
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
        /// Gets or Sets Owner
        /// </summary>
        [DataMember(Name = "owner", EmitDefaultValue = false)]
        public DashboardOwner Owner { get; set; }

        /// <summary>
        /// The number of users who have this dashboard as a favorite.
        /// </summary>
        /// <value>The number of users who have this dashboard as a favorite.</value>
        [DataMember(Name = "popularity", EmitDefaultValue = false)]
        public long Popularity { get; private set; }

        /// <summary>
        /// Returns false as Popularity should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePopularity()
        {
            return false;
        }
        /// <summary>
        /// The rank of this dashboard.
        /// </summary>
        /// <value>The rank of this dashboard.</value>
        [DataMember(Name = "rank", EmitDefaultValue = false)]
        public int Rank { get; private set; }

        /// <summary>
        /// Returns false as Rank should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeRank()
        {
            return false;
        }
        /// <summary>
        /// The URL of these dashboard details.
        /// </summary>
        /// <value>The URL of these dashboard details.</value>
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
        /// The details of any view share permissions for the dashboard.
        /// </summary>
        /// <value>The details of any view share permissions for the dashboard.</value>
        [DataMember(Name = "sharePermissions", EmitDefaultValue = false)]
        public List<SharePermission> SharePermissions { get; private set; }

        /// <summary>
        /// Returns false as SharePermissions should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSharePermissions()
        {
            return false;
        }
        /// <summary>
        /// Whether the current dashboard is system dashboard.
        /// </summary>
        /// <value>Whether the current dashboard is system dashboard.</value>
        [DataMember(Name = "systemDashboard", EmitDefaultValue = true)]
        public bool SystemDashboard { get; private set; }

        /// <summary>
        /// Returns false as SystemDashboard should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSystemDashboard()
        {
            return false;
        }
        /// <summary>
        /// The URL of the dashboard.
        /// </summary>
        /// <value>The URL of the dashboard.</value>
        [DataMember(Name = "view", EmitDefaultValue = false)]
        public string View { get; private set; }

        /// <summary>
        /// Returns false as View should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeView()
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
            sb.Append("class Dashboard {\n");
            sb.Append("  AutomaticRefreshMs: ").Append(AutomaticRefreshMs).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EditPermissions: ").Append(EditPermissions).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsFavourite: ").Append(IsFavourite).Append("\n");
            sb.Append("  IsWritable: ").Append(IsWritable).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  Popularity: ").Append(Popularity).Append("\n");
            sb.Append("  Rank: ").Append(Rank).Append("\n");
            sb.Append("  Self: ").Append(Self).Append("\n");
            sb.Append("  SharePermissions: ").Append(SharePermissions).Append("\n");
            sb.Append("  SystemDashboard: ").Append(SystemDashboard).Append("\n");
            sb.Append("  View: ").Append(View).Append("\n");
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
