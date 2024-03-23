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
    /// Details about the operations available in this version.
    /// </summary>
    [DataContract(Name = "SimpleLink")]
    public partial class SimpleLink : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLink" /> class.
        /// </summary>
        /// <param name="href">href.</param>
        /// <param name="iconClass">iconClass.</param>
        /// <param name="id">id.</param>
        /// <param name="label">label.</param>
        /// <param name="styleClass">styleClass.</param>
        /// <param name="title">title.</param>
        /// <param name="weight">weight.</param>
        public SimpleLink(string href = default(string), string iconClass = default(string), string id = default(string), string label = default(string), string styleClass = default(string), string title = default(string), int weight = default(int))
        {
            this.Href = href;
            this.IconClass = iconClass;
            this.Id = id;
            this.Label = label;
            this.StyleClass = styleClass;
            this.Title = title;
            this.Weight = weight;
        }

        /// <summary>
        /// Gets or Sets Href
        /// </summary>
        [DataMember(Name = "href", EmitDefaultValue = false)]
        public string Href { get; set; }

        /// <summary>
        /// Gets or Sets IconClass
        /// </summary>
        [DataMember(Name = "iconClass", EmitDefaultValue = false)]
        public string IconClass { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets StyleClass
        /// </summary>
        [DataMember(Name = "styleClass", EmitDefaultValue = false)]
        public string StyleClass { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Weight
        /// </summary>
        [DataMember(Name = "weight", EmitDefaultValue = false)]
        public int Weight { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SimpleLink {\n");
            sb.Append("  Href: ").Append(Href).Append("\n");
            sb.Append("  IconClass: ").Append(IconClass).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  StyleClass: ").Append(StyleClass).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
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
