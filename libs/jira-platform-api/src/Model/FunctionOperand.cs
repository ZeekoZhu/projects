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
    /// An operand that is a function. See [Advanced searching - functions reference](https://confluence.atlassian.com/x/dwiiLQ) for more information about JQL functions.
    /// </summary>
    [DataContract(Name = "FunctionOperand")]
    public partial class FunctionOperand : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionOperand" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FunctionOperand() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionOperand" /> class.
        /// </summary>
        /// <param name="arguments">The list of function arguments. (required).</param>
        /// <param name="encodedOperand">Encoded operand, which can be used directly in a JQL query..</param>
        /// <param name="function">The name of the function. (required).</param>
        public FunctionOperand(List<string> arguments = default(List<string>), string encodedOperand = default(string), string function = default(string))
        {
            // to ensure "arguments" is required (not null)
            if (arguments == null)
            {
                throw new ArgumentNullException("arguments is a required property for FunctionOperand and cannot be null");
            }
            this.Arguments = arguments;
            // to ensure "function" is required (not null)
            if (function == null)
            {
                throw new ArgumentNullException("function is a required property for FunctionOperand and cannot be null");
            }
            this.Function = function;
            this.EncodedOperand = encodedOperand;
        }

        /// <summary>
        /// The list of function arguments.
        /// </summary>
        /// <value>The list of function arguments.</value>
        [DataMember(Name = "arguments", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Arguments { get; set; }

        /// <summary>
        /// Encoded operand, which can be used directly in a JQL query.
        /// </summary>
        /// <value>Encoded operand, which can be used directly in a JQL query.</value>
        [DataMember(Name = "encodedOperand", EmitDefaultValue = false)]
        public string EncodedOperand { get; set; }

        /// <summary>
        /// The name of the function.
        /// </summary>
        /// <value>The name of the function.</value>
        [DataMember(Name = "function", IsRequired = true, EmitDefaultValue = true)]
        public string Function { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FunctionOperand {\n");
            sb.Append("  Arguments: ").Append(Arguments).Append("\n");
            sb.Append("  EncodedOperand: ").Append(EncodedOperand).Append("\n");
            sb.Append("  Function: ").Append(Function).Append("\n");
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
