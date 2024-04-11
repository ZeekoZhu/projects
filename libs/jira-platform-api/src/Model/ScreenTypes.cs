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
    /// The IDs of the screens for the screen types of the screen scheme.
    /// </summary>
    [DataContract(Name = "ScreenTypes")]
    public partial class ScreenTypes : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenTypes" /> class.
        /// </summary>
        /// <param name="create">The ID of the create screen..</param>
        /// <param name="varDefault">The ID of the default screen. Required when creating a screen scheme..</param>
        /// <param name="edit">The ID of the edit screen..</param>
        /// <param name="view">The ID of the view screen..</param>
        public ScreenTypes(long create = default(long), long varDefault = default(long), long edit = default(long), long view = default(long))
        {
            this.Create = create;
            this.VarDefault = varDefault;
            this.Edit = edit;
            this.View = view;
        }

        /// <summary>
        /// The ID of the create screen.
        /// </summary>
        /// <value>The ID of the create screen.</value>
        [DataMember(Name = "create", EmitDefaultValue = false)]
        public long Create { get; set; }

        /// <summary>
        /// The ID of the default screen. Required when creating a screen scheme.
        /// </summary>
        /// <value>The ID of the default screen. Required when creating a screen scheme.</value>
        [DataMember(Name = "default", EmitDefaultValue = false)]
        public long VarDefault { get; set; }

        /// <summary>
        /// The ID of the edit screen.
        /// </summary>
        /// <value>The ID of the edit screen.</value>
        [DataMember(Name = "edit", EmitDefaultValue = false)]
        public long Edit { get; set; }

        /// <summary>
        /// The ID of the view screen.
        /// </summary>
        /// <value>The ID of the view screen.</value>
        [DataMember(Name = "view", EmitDefaultValue = false)]
        public long View { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ScreenTypes {\n");
            sb.Append("  Create: ").Append(Create).Append("\n");
            sb.Append("  VarDefault: ").Append(VarDefault).Append("\n");
            sb.Append("  Edit: ").Append(Edit).Append("\n");
            sb.Append("  View: ").Append(View).Append("\n");
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
