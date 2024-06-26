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
    /// BulkOperationErrorResult
    /// </summary>
    [DataContract(Name = "BulkOperationErrorResult")]
    public partial class BulkOperationErrorResult : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkOperationErrorResult" /> class.
        /// </summary>
        /// <param name="elementErrors">elementErrors.</param>
        /// <param name="failedElementNumber">failedElementNumber.</param>
        /// <param name="status">status.</param>
        public BulkOperationErrorResult(ErrorCollection elementErrors = default(ErrorCollection), int failedElementNumber = default(int), int status = default(int))
        {
            this.ElementErrors = elementErrors;
            this.FailedElementNumber = failedElementNumber;
            this.Status = status;
        }

        /// <summary>
        /// Gets or Sets ElementErrors
        /// </summary>
        [DataMember(Name = "elementErrors", EmitDefaultValue = false)]
        public ErrorCollection ElementErrors { get; set; }

        /// <summary>
        /// Gets or Sets FailedElementNumber
        /// </summary>
        [DataMember(Name = "failedElementNumber", EmitDefaultValue = false)]
        public int FailedElementNumber { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int Status { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BulkOperationErrorResult {\n");
            sb.Append("  ElementErrors: ").Append(ElementErrors).Append("\n");
            sb.Append("  FailedElementNumber: ").Append(FailedElementNumber).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
