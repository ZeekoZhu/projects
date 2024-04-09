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
    /// ServiceRegistryTier
    /// </summary>
    [DataContract(Name = "ServiceRegistryTier")]
    public partial class ServiceRegistryTier : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRegistryTier" /> class.
        /// </summary>
        /// <param name="description">tier description.</param>
        /// <param name="id">tier ID.</param>
        /// <param name="level">tier level.</param>
        /// <param name="name">tier name.</param>
        /// <param name="nameKey">name key of the tier.</param>
        public ServiceRegistryTier(string description = default(string), Guid id = default(Guid), int level = default(int), string name = default(string), string nameKey = default(string))
        {
            this.Description = description;
            this.Id = id;
            this.Level = level;
            this.Name = name;
            this.NameKey = nameKey;
        }

        /// <summary>
        /// tier description
        /// </summary>
        /// <value>tier description</value>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// tier ID
        /// </summary>
        /// <value>tier ID</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        /// <summary>
        /// tier level
        /// </summary>
        /// <value>tier level</value>
        [DataMember(Name = "level", EmitDefaultValue = false)]
        public int Level { get; set; }

        /// <summary>
        /// tier name
        /// </summary>
        /// <value>tier name</value>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// name key of the tier
        /// </summary>
        /// <value>name key of the tier</value>
        /// <example>service-registry.tier1.name</example>
        [DataMember(Name = "nameKey", EmitDefaultValue = false)]
        public string NameKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ServiceRegistryTier {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Level: ").Append(Level).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NameKey: ").Append(NameKey).Append("\n");
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