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
    /// Details of a field.
    /// </summary>
    [DataContract(Name = "Field")]
    public partial class Field : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Field" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Field() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Field" /> class.
        /// </summary>
        /// <param name="contextsCount">Number of contexts where the field is used..</param>
        /// <param name="description">The description of the field..</param>
        /// <param name="id">The ID of the field. (required).</param>
        /// <param name="isLocked">Whether the field is locked..</param>
        /// <param name="isUnscreenable">Whether the field is shown on screen or not..</param>
        /// <param name="key">The key of the field..</param>
        /// <param name="lastUsed">lastUsed.</param>
        /// <param name="name">The name of the field. (required).</param>
        /// <param name="projectsCount">Number of projects where the field is used..</param>
        /// <param name="schema">schema (required).</param>
        /// <param name="screensCount">Number of screens where the field is used..</param>
        /// <param name="searcherKey">The searcher key of the field. Returned for custom fields..</param>
        public Field(long contextsCount = default(long), string description = default(string), string id = default(string), bool isLocked = default(bool), bool isUnscreenable = default(bool), string key = default(string), FieldLastUsed lastUsed = default(FieldLastUsed), string name = default(string), long projectsCount = default(long), JsonTypeBean schema = default(JsonTypeBean), long screensCount = default(long), string searcherKey = default(string))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for Field and cannot be null");
            }
            this.Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for Field and cannot be null");
            }
            this.Name = name;
            // to ensure "schema" is required (not null)
            if (schema == null)
            {
                throw new ArgumentNullException("schema is a required property for Field and cannot be null");
            }
            this.Schema = schema;
            this.ContextsCount = contextsCount;
            this.Description = description;
            this.IsLocked = isLocked;
            this.IsUnscreenable = isUnscreenable;
            this.Key = key;
            this.LastUsed = lastUsed;
            this.ProjectsCount = projectsCount;
            this.ScreensCount = screensCount;
            this.SearcherKey = searcherKey;
        }

        /// <summary>
        /// Number of contexts where the field is used.
        /// </summary>
        /// <value>Number of contexts where the field is used.</value>
        [DataMember(Name = "contextsCount", EmitDefaultValue = false)]
        public long ContextsCount { get; set; }

        /// <summary>
        /// The description of the field.
        /// </summary>
        /// <value>The description of the field.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the field.
        /// </summary>
        /// <value>The ID of the field.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Whether the field is locked.
        /// </summary>
        /// <value>Whether the field is locked.</value>
        [DataMember(Name = "isLocked", EmitDefaultValue = true)]
        public bool IsLocked { get; set; }

        /// <summary>
        /// Whether the field is shown on screen or not.
        /// </summary>
        /// <value>Whether the field is shown on screen or not.</value>
        [DataMember(Name = "isUnscreenable", EmitDefaultValue = true)]
        public bool IsUnscreenable { get; set; }

        /// <summary>
        /// The key of the field.
        /// </summary>
        /// <value>The key of the field.</value>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or Sets LastUsed
        /// </summary>
        [DataMember(Name = "lastUsed", EmitDefaultValue = false)]
        public FieldLastUsed LastUsed { get; set; }

        /// <summary>
        /// The name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Number of projects where the field is used.
        /// </summary>
        /// <value>Number of projects where the field is used.</value>
        [DataMember(Name = "projectsCount", EmitDefaultValue = false)]
        public long ProjectsCount { get; set; }

        /// <summary>
        /// Gets or Sets Schema
        /// </summary>
        [DataMember(Name = "schema", IsRequired = true, EmitDefaultValue = true)]
        public JsonTypeBean Schema { get; set; }

        /// <summary>
        /// Number of screens where the field is used.
        /// </summary>
        /// <value>Number of screens where the field is used.</value>
        [DataMember(Name = "screensCount", EmitDefaultValue = false)]
        public long ScreensCount { get; set; }

        /// <summary>
        /// The searcher key of the field. Returned for custom fields.
        /// </summary>
        /// <value>The searcher key of the field. Returned for custom fields.</value>
        [DataMember(Name = "searcherKey", EmitDefaultValue = false)]
        public string SearcherKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Field {\n");
            sb.Append("  ContextsCount: ").Append(ContextsCount).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsLocked: ").Append(IsLocked).Append("\n");
            sb.Append("  IsUnscreenable: ").Append(IsUnscreenable).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  LastUsed: ").Append(LastUsed).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ProjectsCount: ").Append(ProjectsCount).Append("\n");
            sb.Append("  Schema: ").Append(Schema).Append("\n");
            sb.Append("  ScreensCount: ").Append(ScreensCount).Append("\n");
            sb.Append("  SearcherKey: ").Append(SearcherKey).Append("\n");
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
