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
    /// Metadata for an archive (for example a zip) and its contents.
    /// </summary>
    [DataContract(Name = "AttachmentArchiveMetadataReadable")]
    public partial class AttachmentArchiveMetadataReadable : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentArchiveMetadataReadable" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public AttachmentArchiveMetadataReadable()
        {
        }

        /// <summary>
        /// The list of the items included in the archive.
        /// </summary>
        /// <value>The list of the items included in the archive.</value>
        [DataMember(Name = "entries", EmitDefaultValue = false)]
        public List<AttachmentArchiveItemReadable> Entries { get; private set; }

        /// <summary>
        /// Returns false as Entries should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeEntries()
        {
            return false;
        }
        /// <summary>
        /// The ID of the attachment.
        /// </summary>
        /// <value>The ID of the attachment.</value>
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
        /// The MIME type of the attachment.
        /// </summary>
        /// <value>The MIME type of the attachment.</value>
        [DataMember(Name = "mediaType", EmitDefaultValue = false)]
        public string MediaType { get; private set; }

        /// <summary>
        /// Returns false as MediaType should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeMediaType()
        {
            return false;
        }
        /// <summary>
        /// The name of the archive file.
        /// </summary>
        /// <value>The name of the archive file.</value>
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
        /// The number of items included in the archive.
        /// </summary>
        /// <value>The number of items included in the archive.</value>
        [DataMember(Name = "totalEntryCount", EmitDefaultValue = false)]
        public long TotalEntryCount { get; private set; }

        /// <summary>
        /// Returns false as TotalEntryCount should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeTotalEntryCount()
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
            sb.Append("class AttachmentArchiveMetadataReadable {\n");
            sb.Append("  Entries: ").Append(Entries).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MediaType: ").Append(MediaType).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TotalEntryCount: ").Append(TotalEntryCount).Append("\n");
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