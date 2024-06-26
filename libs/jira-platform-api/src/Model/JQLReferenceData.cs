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
    /// Lists of JQL reference data.
    /// </summary>
    [DataContract(Name = "JQLReferenceData")]
    public partial class JQLReferenceData : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JQLReferenceData" /> class.
        /// </summary>
        /// <param name="jqlReservedWords">List of JQL query reserved words..</param>
        /// <param name="visibleFieldNames">List of fields usable in JQL queries..</param>
        /// <param name="visibleFunctionNames">List of functions usable in JQL queries..</param>
        public JQLReferenceData(List<string> jqlReservedWords = default(List<string>), List<FieldReferenceData> visibleFieldNames = default(List<FieldReferenceData>), List<FunctionReferenceData> visibleFunctionNames = default(List<FunctionReferenceData>))
        {
            this.JqlReservedWords = jqlReservedWords;
            this.VisibleFieldNames = visibleFieldNames;
            this.VisibleFunctionNames = visibleFunctionNames;
        }

        /// <summary>
        /// List of JQL query reserved words.
        /// </summary>
        /// <value>List of JQL query reserved words.</value>
        [DataMember(Name = "jqlReservedWords", EmitDefaultValue = false)]
        public List<string> JqlReservedWords { get; set; }

        /// <summary>
        /// List of fields usable in JQL queries.
        /// </summary>
        /// <value>List of fields usable in JQL queries.</value>
        [DataMember(Name = "visibleFieldNames", EmitDefaultValue = false)]
        public List<FieldReferenceData> VisibleFieldNames { get; set; }

        /// <summary>
        /// List of functions usable in JQL queries.
        /// </summary>
        /// <value>List of functions usable in JQL queries.</value>
        [DataMember(Name = "visibleFunctionNames", EmitDefaultValue = false)]
        public List<FunctionReferenceData> VisibleFunctionNames { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JQLReferenceData {\n");
            sb.Append("  JqlReservedWords: ").Append(JqlReservedWords).Append("\n");
            sb.Append("  VisibleFieldNames: ").Append(VisibleFieldNames).Append("\n");
            sb.Append("  VisibleFunctionNames: ").Append(VisibleFunctionNames).Append("\n");
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
