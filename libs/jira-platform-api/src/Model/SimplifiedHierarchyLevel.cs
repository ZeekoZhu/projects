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
    /// SimplifiedHierarchyLevel
    /// </summary>
    [DataContract(Name = "SimplifiedHierarchyLevel")]
    public partial class SimplifiedHierarchyLevel : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimplifiedHierarchyLevel" /> class.
        /// </summary>
        /// <param name="aboveLevelId">The ID of the level above this one in the hierarchy. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/)..</param>
        /// <param name="belowLevelId">The ID of the level below this one in the hierarchy. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/)..</param>
        /// <param name="externalUuid">The external UUID of the hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/)..</param>
        /// <param name="hierarchyLevelNumber">hierarchyLevelNumber.</param>
        /// <param name="id">The ID of the hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/)..</param>
        /// <param name="issueTypeIds">The issue types available in this hierarchy level..</param>
        /// <param name="level">The level of this item in the hierarchy..</param>
        /// <param name="name">The name of this hierarchy level..</param>
        /// <param name="projectConfigurationId">The ID of the project configuration. This property is deprecated, see [Change oticen: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/)..</param>
        public SimplifiedHierarchyLevel(long aboveLevelId = default(long), long belowLevelId = default(long), Guid externalUuid = default(Guid), int hierarchyLevelNumber = default(int), long id = default(long), List<long> issueTypeIds = default(List<long>), int level = default(int), string name = default(string), long projectConfigurationId = default(long))
        {
            this.AboveLevelId = aboveLevelId;
            this.BelowLevelId = belowLevelId;
            this.ExternalUuid = externalUuid;
            this.HierarchyLevelNumber = hierarchyLevelNumber;
            this.Id = id;
            this.IssueTypeIds = issueTypeIds;
            this.Level = level;
            this.Name = name;
            this.ProjectConfigurationId = projectConfigurationId;
        }

        /// <summary>
        /// The ID of the level above this one in the hierarchy. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        /// <value>The ID of the level above this one in the hierarchy. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).</value>
        [DataMember(Name = "aboveLevelId", EmitDefaultValue = false)]
        public long AboveLevelId { get; set; }

        /// <summary>
        /// The ID of the level below this one in the hierarchy. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        /// <value>The ID of the level below this one in the hierarchy. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).</value>
        [DataMember(Name = "belowLevelId", EmitDefaultValue = false)]
        public long BelowLevelId { get; set; }

        /// <summary>
        /// The external UUID of the hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        /// <value>The external UUID of the hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).</value>
        [DataMember(Name = "externalUuid", EmitDefaultValue = false)]
        public Guid ExternalUuid { get; set; }

        /// <summary>
        /// Gets or Sets HierarchyLevelNumber
        /// </summary>
        [DataMember(Name = "hierarchyLevelNumber", EmitDefaultValue = false)]
        public int HierarchyLevelNumber { get; set; }

        /// <summary>
        /// The ID of the hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        /// <value>The ID of the hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// The issue types available in this hierarchy level.
        /// </summary>
        /// <value>The issue types available in this hierarchy level.</value>
        [DataMember(Name = "issueTypeIds", EmitDefaultValue = false)]
        public List<long> IssueTypeIds { get; set; }

        /// <summary>
        /// The level of this item in the hierarchy.
        /// </summary>
        /// <value>The level of this item in the hierarchy.</value>
        [DataMember(Name = "level", EmitDefaultValue = false)]
        public int Level { get; set; }

        /// <summary>
        /// The name of this hierarchy level.
        /// </summary>
        /// <value>The name of this hierarchy level.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the project configuration. This property is deprecated, see [Change oticen: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        /// <value>The ID of the project configuration. This property is deprecated, see [Change oticen: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).</value>
        [DataMember(Name = "projectConfigurationId", EmitDefaultValue = false)]
        public long ProjectConfigurationId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SimplifiedHierarchyLevel {\n");
            sb.Append("  AboveLevelId: ").Append(AboveLevelId).Append("\n");
            sb.Append("  BelowLevelId: ").Append(BelowLevelId).Append("\n");
            sb.Append("  ExternalUuid: ").Append(ExternalUuid).Append("\n");
            sb.Append("  HierarchyLevelNumber: ").Append(HierarchyLevelNumber).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IssueTypeIds: ").Append(IssueTypeIds).Append("\n");
            sb.Append("  Level: ").Append(Level).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ProjectConfigurationId: ").Append(ProjectConfigurationId).Append("\n");
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