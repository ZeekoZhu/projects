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
    /// A screen scheme.
    /// </summary>
    [DataContract(Name = "ScreenScheme")]
    public partial class ScreenScheme : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenScheme" /> class.
        /// </summary>
        /// <param name="description">The description of the screen scheme..</param>
        /// <param name="id">The ID of the screen scheme..</param>
        /// <param name="issueTypeScreenSchemes">Details of the issue type screen schemes associated with the screen scheme..</param>
        /// <param name="name">The name of the screen scheme..</param>
        /// <param name="screens">The IDs of the screens for the screen types of the screen scheme..</param>
        public ScreenScheme(string description = default(string), long id = default(long), PageBeanIssueTypeScreenScheme issueTypeScreenSchemes = default(PageBeanIssueTypeScreenScheme), string name = default(string), ScreenTypes screens = default(ScreenTypes))
        {
            this.Description = description;
            this.Id = id;
            this.IssueTypeScreenSchemes = issueTypeScreenSchemes;
            this.Name = name;
            this.Screens = screens;
        }

        /// <summary>
        /// The description of the screen scheme.
        /// </summary>
        /// <value>The description of the screen scheme.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the screen scheme.
        /// </summary>
        /// <value>The ID of the screen scheme.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// Details of the issue type screen schemes associated with the screen scheme.
        /// </summary>
        /// <value>Details of the issue type screen schemes associated with the screen scheme.</value>
        [DataMember(Name = "issueTypeScreenSchemes", EmitDefaultValue = false)]
        public PageBeanIssueTypeScreenScheme IssueTypeScreenSchemes { get; set; }

        /// <summary>
        /// The name of the screen scheme.
        /// </summary>
        /// <value>The name of the screen scheme.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The IDs of the screens for the screen types of the screen scheme.
        /// </summary>
        /// <value>The IDs of the screens for the screen types of the screen scheme.</value>
        [DataMember(Name = "screens", EmitDefaultValue = false)]
        public ScreenTypes Screens { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ScreenScheme {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IssueTypeScreenSchemes: ").Append(IssueTypeScreenSchemes).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Screens: ").Append(Screens).Append("\n");
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
