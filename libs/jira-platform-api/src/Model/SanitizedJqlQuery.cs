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
    /// Details of the sanitized JQL query.
    /// </summary>
    [DataContract(Name = "SanitizedJqlQuery")]
    public partial class SanitizedJqlQuery : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SanitizedJqlQuery" /> class.
        /// </summary>
        /// <param name="accountId">The account ID of the user for whom sanitization was performed..</param>
        /// <param name="errors">The list of errors..</param>
        /// <param name="initialQuery">The initial query..</param>
        /// <param name="sanitizedQuery">The sanitized query, if there were no errors..</param>
        public SanitizedJqlQuery(string accountId = default(string), ErrorCollection errors = default(ErrorCollection), string initialQuery = default(string), string sanitizedQuery = default(string))
        {
            this.AccountId = accountId;
            this.Errors = errors;
            this.InitialQuery = initialQuery;
            this.SanitizedQuery = sanitizedQuery;
        }

        /// <summary>
        /// The account ID of the user for whom sanitization was performed.
        /// </summary>
        /// <value>The account ID of the user for whom sanitization was performed.</value>
        [DataMember(Name = "accountId", EmitDefaultValue = true)]
        public string AccountId { get; set; }

        /// <summary>
        /// The list of errors.
        /// </summary>
        /// <value>The list of errors.</value>
        [DataMember(Name = "errors", EmitDefaultValue = false)]
        public ErrorCollection Errors { get; set; }

        /// <summary>
        /// The initial query.
        /// </summary>
        /// <value>The initial query.</value>
        [DataMember(Name = "initialQuery", EmitDefaultValue = false)]
        public string InitialQuery { get; set; }

        /// <summary>
        /// The sanitized query, if there were no errors.
        /// </summary>
        /// <value>The sanitized query, if there were no errors.</value>
        [DataMember(Name = "sanitizedQuery", EmitDefaultValue = true)]
        public string SanitizedQuery { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SanitizedJqlQuery {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("  InitialQuery: ").Append(InitialQuery).Append("\n");
            sb.Append("  SanitizedQuery: ").Append(SanitizedQuery).Append("\n");
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
            // AccountId (string) maxLength
            if (this.AccountId != null && this.AccountId.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AccountId, length must be less than 128.", new [] { "AccountId" });
            }

            yield break;
        }
    }

}
