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
    /// The details of the available dashboard gadget.
    /// </summary>
    [DataContract(Name = "AvailableDashboardGadget")]
    public partial class AvailableDashboardGadget : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableDashboardGadget" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public AvailableDashboardGadget()
        {
        }

        /// <summary>
        /// The module key of the gadget type.
        /// </summary>
        /// <value>The module key of the gadget type.</value>
        [DataMember(Name = "moduleKey", EmitDefaultValue = false)]
        public string ModuleKey { get; private set; }

        /// <summary>
        /// Returns false as ModuleKey should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeModuleKey()
        {
            return false;
        }
        /// <summary>
        /// The title of the gadget.
        /// </summary>
        /// <value>The title of the gadget.</value>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
        public string Title { get; private set; }

        /// <summary>
        /// Returns false as Title should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeTitle()
        {
            return false;
        }
        /// <summary>
        /// The URI of the gadget type.
        /// </summary>
        /// <value>The URI of the gadget type.</value>
        [DataMember(Name = "uri", EmitDefaultValue = false)]
        public string Uri { get; private set; }

        /// <summary>
        /// Returns false as Uri should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeUri()
        {
            return false;
        }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AvailableDashboardGadget {\n");
            sb.Append("  ModuleKey: ").Append(ModuleKey).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Uri: ").Append(Uri).Append("\n");
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
