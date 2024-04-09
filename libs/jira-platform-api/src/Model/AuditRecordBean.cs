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
    /// An audit record.
    /// </summary>
    [DataContract(Name = "AuditRecordBean")]
    public partial class AuditRecordBean : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditRecordBean" /> class.
        /// </summary>
        /// <param name="objectItem">objectItem.</param>
        public AuditRecordBean(AssociatedItemBean objectItem = default(AssociatedItemBean))
        {
            this.ObjectItem = objectItem;
        }

        /// <summary>
        /// The list of items associated with the changed record.
        /// </summary>
        /// <value>The list of items associated with the changed record.</value>
        [DataMember(Name = "associatedItems", EmitDefaultValue = false)]
        public List<AssociatedItemBean> AssociatedItems { get; private set; }

        /// <summary>
        /// Returns false as AssociatedItems should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAssociatedItems()
        {
            return false;
        }
        /// <summary>
        /// Deprecated, use &#x60;authorAccountId&#x60; instead. The key of the user who created the audit record.
        /// </summary>
        /// <value>Deprecated, use &#x60;authorAccountId&#x60; instead. The key of the user who created the audit record.</value>
        [DataMember(Name = "authorKey", EmitDefaultValue = false)]
        public string AuthorKey { get; private set; }

        /// <summary>
        /// Returns false as AuthorKey should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeAuthorKey()
        {
            return false;
        }
        /// <summary>
        /// The category of the audit record. For a list of these categories, see the help article [Auditing in Jira applications](https://confluence.atlassian.com/x/noXKM).
        /// </summary>
        /// <value>The category of the audit record. For a list of these categories, see the help article [Auditing in Jira applications](https://confluence.atlassian.com/x/noXKM).</value>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public string Category { get; private set; }

        /// <summary>
        /// Returns false as Category should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCategory()
        {
            return false;
        }
        /// <summary>
        /// The list of values changed in the record event.
        /// </summary>
        /// <value>The list of values changed in the record event.</value>
        [DataMember(Name = "changedValues", EmitDefaultValue = false)]
        public List<ChangedValueBean> ChangedValues { get; private set; }

        /// <summary>
        /// Returns false as ChangedValues should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeChangedValues()
        {
            return false;
        }
        /// <summary>
        /// The date and time on which the audit record was created.
        /// </summary>
        /// <value>The date and time on which the audit record was created.</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime Created { get; private set; }

        /// <summary>
        /// Returns false as Created should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCreated()
        {
            return false;
        }
        /// <summary>
        /// The description of the audit record.
        /// </summary>
        /// <value>The description of the audit record.</value>
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
        /// The event the audit record originated from.
        /// </summary>
        /// <value>The event the audit record originated from.</value>
        [DataMember(Name = "eventSource", EmitDefaultValue = false)]
        public string EventSource { get; private set; }

        /// <summary>
        /// Returns false as EventSource should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeEventSource()
        {
            return false;
        }
        /// <summary>
        /// The ID of the audit record.
        /// </summary>
        /// <value>The ID of the audit record.</value>
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
        /// Gets or Sets ObjectItem
        /// </summary>
        [DataMember(Name = "objectItem", EmitDefaultValue = false)]
        public AssociatedItemBean ObjectItem { get; set; }

        /// <summary>
        /// The URL of the computer where the creation of the audit record was initiated.
        /// </summary>
        /// <value>The URL of the computer where the creation of the audit record was initiated.</value>
        [DataMember(Name = "remoteAddress", EmitDefaultValue = false)]
        public string RemoteAddress { get; private set; }

        /// <summary>
        /// Returns false as RemoteAddress should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeRemoteAddress()
        {
            return false;
        }
        /// <summary>
        /// The summary of the audit record.
        /// </summary>
        /// <value>The summary of the audit record.</value>
        [DataMember(Name = "summary", EmitDefaultValue = false)]
        public string Summary { get; private set; }

        /// <summary>
        /// Returns false as Summary should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSummary()
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
            sb.Append("class AuditRecordBean {\n");
            sb.Append("  AssociatedItems: ").Append(AssociatedItems).Append("\n");
            sb.Append("  AuthorKey: ").Append(AuthorKey).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  ChangedValues: ").Append(ChangedValues).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EventSource: ").Append(EventSource).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ObjectItem: ").Append(ObjectItem).Append("\n");
            sb.Append("  RemoteAddress: ").Append(RemoteAddress).Append("\n");
            sb.Append("  Summary: ").Append(Summary).Append("\n");
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