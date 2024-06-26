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
    /// AttachmentArchive
    /// </summary>
    [DataContract(Name = "AttachmentArchive")]
    public partial class AttachmentArchive : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentArchive" /> class.
        /// </summary>
        /// <param name="entries">entries.</param>
        /// <param name="moreAvailable">moreAvailable.</param>
        /// <param name="totalEntryCount">totalEntryCount.</param>
        /// <param name="totalNumberOfEntriesAvailable">totalNumberOfEntriesAvailable.</param>
        public AttachmentArchive(List<AttachmentArchiveEntry> entries = default(List<AttachmentArchiveEntry>), bool moreAvailable = default(bool), int totalEntryCount = default(int), int totalNumberOfEntriesAvailable = default(int))
        {
            this.Entries = entries;
            this.MoreAvailable = moreAvailable;
            this.TotalEntryCount = totalEntryCount;
            this.TotalNumberOfEntriesAvailable = totalNumberOfEntriesAvailable;
        }

        /// <summary>
        /// Gets or Sets Entries
        /// </summary>
        [DataMember(Name = "entries", EmitDefaultValue = false)]
        public List<AttachmentArchiveEntry> Entries { get; set; }

        /// <summary>
        /// Gets or Sets MoreAvailable
        /// </summary>
        [DataMember(Name = "moreAvailable", EmitDefaultValue = true)]
        public bool MoreAvailable { get; set; }

        /// <summary>
        /// Gets or Sets TotalEntryCount
        /// </summary>
        [DataMember(Name = "totalEntryCount", EmitDefaultValue = false)]
        public int TotalEntryCount { get; set; }

        /// <summary>
        /// Gets or Sets TotalNumberOfEntriesAvailable
        /// </summary>
        [DataMember(Name = "totalNumberOfEntriesAvailable", EmitDefaultValue = false)]
        public int TotalNumberOfEntriesAvailable { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AttachmentArchive {\n");
            sb.Append("  Entries: ").Append(Entries).Append("\n");
            sb.Append("  MoreAvailable: ").Append(MoreAvailable).Append("\n");
            sb.Append("  TotalEntryCount: ").Append(TotalEntryCount).Append("\n");
            sb.Append("  TotalNumberOfEntriesAvailable: ").Append(TotalNumberOfEntriesAvailable).Append("\n");
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
