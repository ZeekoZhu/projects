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
    /// LinkIssueRequestJsonBean
    /// </summary>
    [DataContract(Name = "LinkIssueRequestJsonBean")]
    public partial class LinkIssueRequestJsonBean : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkIssueRequestJsonBean" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LinkIssueRequestJsonBean() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkIssueRequestJsonBean" /> class.
        /// </summary>
        /// <param name="comment">comment.</param>
        /// <param name="inwardIssue">inwardIssue (required).</param>
        /// <param name="outwardIssue">outwardIssue (required).</param>
        /// <param name="type">type (required).</param>
        public LinkIssueRequestJsonBean(Comment comment = default(Comment), LinkedIssue inwardIssue = default(LinkedIssue), LinkedIssue outwardIssue = default(LinkedIssue), IssueLinkType type = default(IssueLinkType))
        {
            // to ensure "inwardIssue" is required (not null)
            if (inwardIssue == null)
            {
                throw new ArgumentNullException("inwardIssue is a required property for LinkIssueRequestJsonBean and cannot be null");
            }
            this.InwardIssue = inwardIssue;
            // to ensure "outwardIssue" is required (not null)
            if (outwardIssue == null)
            {
                throw new ArgumentNullException("outwardIssue is a required property for LinkIssueRequestJsonBean and cannot be null");
            }
            this.OutwardIssue = outwardIssue;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for LinkIssueRequestJsonBean and cannot be null");
            }
            this.Type = type;
            this.Comment = comment;
        }

        /// <summary>
        /// Gets or Sets Comment
        /// </summary>
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public Comment Comment { get; set; }

        /// <summary>
        /// Gets or Sets InwardIssue
        /// </summary>
        [DataMember(Name = "inwardIssue", IsRequired = true, EmitDefaultValue = true)]
        public LinkedIssue InwardIssue { get; set; }

        /// <summary>
        /// Gets or Sets OutwardIssue
        /// </summary>
        [DataMember(Name = "outwardIssue", IsRequired = true, EmitDefaultValue = true)]
        public LinkedIssue OutwardIssue { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public IssueLinkType Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LinkIssueRequestJsonBean {\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  InwardIssue: ").Append(InwardIssue).Append("\n");
            sb.Append("  OutwardIssue: ").Append(OutwardIssue).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
