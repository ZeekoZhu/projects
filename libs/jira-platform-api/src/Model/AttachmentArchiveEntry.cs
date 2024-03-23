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
    /// AttachmentArchiveEntry
    /// </summary>
    [DataContract(Name = "AttachmentArchiveEntry")]
    public partial class AttachmentArchiveEntry : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentArchiveEntry" /> class.
        /// </summary>
        /// <param name="abbreviatedName">abbreviatedName.</param>
        /// <param name="entryIndex">entryIndex.</param>
        /// <param name="mediaType">mediaType.</param>
        /// <param name="name">name.</param>
        /// <param name="size">size.</param>
        public AttachmentArchiveEntry(string abbreviatedName = default(string), long entryIndex = default(long), string mediaType = default(string), string name = default(string), long size = default(long))
        {
            this.AbbreviatedName = abbreviatedName;
            this.EntryIndex = entryIndex;
            this.MediaType = mediaType;
            this.Name = name;
            this.Size = size;
        }

        /// <summary>
        /// Gets or Sets AbbreviatedName
        /// </summary>
        [DataMember(Name = "abbreviatedName", EmitDefaultValue = false)]
        public string AbbreviatedName { get; set; }

        /// <summary>
        /// Gets or Sets EntryIndex
        /// </summary>
        [DataMember(Name = "entryIndex", EmitDefaultValue = false)]
        public long EntryIndex { get; set; }

        /// <summary>
        /// Gets or Sets MediaType
        /// </summary>
        [DataMember(Name = "mediaType", EmitDefaultValue = false)]
        public string MediaType { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [DataMember(Name = "size", EmitDefaultValue = false)]
        public long Size { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AttachmentArchiveEntry {\n");
            sb.Append("  AbbreviatedName: ").Append(AbbreviatedName).Append("\n");
            sb.Append("  EntryIndex: ").Append(EntryIndex).Append("\n");
            sb.Append("  MediaType: ").Append(MediaType).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
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
