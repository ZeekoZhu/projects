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
    /// Details of a request to bulk edit shareable entity.
    /// </summary>
    [DataContract(Name = "BulkEditShareableEntityRequest")]
    public partial class BulkEditShareableEntityRequest : IValidatableObject
    {
        /// <summary>
        /// Allowed action for bulk edit shareable entity
        /// </summary>
        /// <value>Allowed action for bulk edit shareable entity</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ActionEnum
        {
            /// <summary>
            /// Enum ChangeOwner for value: changeOwner
            /// </summary>
            [EnumMember(Value = "changeOwner")]
            ChangeOwner = 1,

            /// <summary>
            /// Enum ChangePermission for value: changePermission
            /// </summary>
            [EnumMember(Value = "changePermission")]
            ChangePermission = 2,

            /// <summary>
            /// Enum AddPermission for value: addPermission
            /// </summary>
            [EnumMember(Value = "addPermission")]
            AddPermission = 3,

            /// <summary>
            /// Enum RemovePermission for value: removePermission
            /// </summary>
            [EnumMember(Value = "removePermission")]
            RemovePermission = 4
        }


        /// <summary>
        /// Allowed action for bulk edit shareable entity
        /// </summary>
        /// <value>Allowed action for bulk edit shareable entity</value>
        [DataMember(Name = "action", IsRequired = true, EmitDefaultValue = true)]
        public ActionEnum Action { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkEditShareableEntityRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BulkEditShareableEntityRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkEditShareableEntityRequest" /> class.
        /// </summary>
        /// <param name="action">Allowed action for bulk edit shareable entity (required).</param>
        /// <param name="changeOwnerDetails">The details of change owner action..</param>
        /// <param name="entityIds">The id list of shareable entities to be changed. (required).</param>
        /// <param name="extendAdminPermissions">Whether the actions are executed by users with Administer Jira global permission..</param>
        /// <param name="permissionDetails">The permission details to be changed..</param>
        public BulkEditShareableEntityRequest(ActionEnum action = default(ActionEnum), BulkChangeOwnerDetails changeOwnerDetails = default(BulkChangeOwnerDetails), List<long> entityIds = default(List<long>), bool extendAdminPermissions = default(bool), PermissionDetails permissionDetails = default(PermissionDetails))
        {
            this.Action = action;
            // to ensure "entityIds" is required (not null)
            if (entityIds == null)
            {
                throw new ArgumentNullException("entityIds is a required property for BulkEditShareableEntityRequest and cannot be null");
            }
            this.EntityIds = entityIds;
            this.ChangeOwnerDetails = changeOwnerDetails;
            this.ExtendAdminPermissions = extendAdminPermissions;
            this.PermissionDetails = permissionDetails;
        }

        /// <summary>
        /// The details of change owner action.
        /// </summary>
        /// <value>The details of change owner action.</value>
        [DataMember(Name = "changeOwnerDetails", EmitDefaultValue = false)]
        public BulkChangeOwnerDetails ChangeOwnerDetails { get; set; }

        /// <summary>
        /// The id list of shareable entities to be changed.
        /// </summary>
        /// <value>The id list of shareable entities to be changed.</value>
        [DataMember(Name = "entityIds", IsRequired = true, EmitDefaultValue = true)]
        public List<long> EntityIds { get; set; }

        /// <summary>
        /// Whether the actions are executed by users with Administer Jira global permission.
        /// </summary>
        /// <value>Whether the actions are executed by users with Administer Jira global permission.</value>
        [DataMember(Name = "extendAdminPermissions", EmitDefaultValue = true)]
        public bool ExtendAdminPermissions { get; set; }

        /// <summary>
        /// The permission details to be changed.
        /// </summary>
        /// <value>The permission details to be changed.</value>
        [DataMember(Name = "permissionDetails", EmitDefaultValue = false)]
        public PermissionDetails PermissionDetails { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BulkEditShareableEntityRequest {\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  ChangeOwnerDetails: ").Append(ChangeOwnerDetails).Append("\n");
            sb.Append("  EntityIds: ").Append(EntityIds).Append("\n");
            sb.Append("  ExtendAdminPermissions: ").Append(ExtendAdminPermissions).Append("\n");
            sb.Append("  PermissionDetails: ").Append(PermissionDetails).Append("\n");
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
