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
    /// The list of JQL queries to sanitize for the given account IDs.
    /// </summary>
    [DataContract(Name = "JqlQueriesToSanitize")]
    public partial class JqlQueriesToSanitize : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueriesToSanitize" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected JqlQueriesToSanitize() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueriesToSanitize" /> class.
        /// </summary>
        /// <param name="queries">The list of JQL queries to sanitize. Must contain unique values. Maximum of 20 queries. (required).</param>
        public JqlQueriesToSanitize(List<JqlQueryToSanitize> queries = default(List<JqlQueryToSanitize>))
        {
            // to ensure "queries" is required (not null)
            if (queries == null)
            {
                throw new ArgumentNullException("queries is a required property for JqlQueriesToSanitize and cannot be null");
            }
            this.Queries = queries;
        }

        /// <summary>
        /// The list of JQL queries to sanitize. Must contain unique values. Maximum of 20 queries.
        /// </summary>
        /// <value>The list of JQL queries to sanitize. Must contain unique values. Maximum of 20 queries.</value>
        [DataMember(Name = "queries", IsRequired = true, EmitDefaultValue = true)]
        public List<JqlQueryToSanitize> Queries { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class JqlQueriesToSanitize {\n");
            sb.Append("  Queries: ").Append(Queries).Append("\n");
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