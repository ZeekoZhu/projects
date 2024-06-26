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
using System.Reflection;

namespace Projects.JiraPlatformApi.Model
{
    /// <summary>
    /// A JQL query clause.
    /// </summary>
    [JsonConverter(typeof(JqlQueryClauseJsonConverter))]
    [DataContract(Name = "JqlQueryClause")]
    public partial class JqlQueryClause : AbstractOpenAPISchema, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueryClause" /> class
        /// with the <see cref="CompoundClause" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of CompoundClause.</param>
        public JqlQueryClause(CompoundClause actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueryClause" /> class
        /// with the <see cref="FieldValueClause" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of FieldValueClause.</param>
        public JqlQueryClause(FieldValueClause actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueryClause" /> class
        /// with the <see cref="FieldWasClause" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of FieldWasClause.</param>
        public JqlQueryClause(FieldWasClause actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JqlQueryClause" /> class
        /// with the <see cref="FieldChangedClause" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of FieldChangedClause.</param>
        public JqlQueryClause(FieldChangedClause actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(CompoundClause))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(FieldChangedClause))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(FieldValueClause))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(FieldWasClause))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: CompoundClause, FieldChangedClause, FieldValueClause, FieldWasClause");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `CompoundClause`. If the actual instance is not `CompoundClause`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of CompoundClause</returns>
        public CompoundClause GetCompoundClause()
        {
            return (CompoundClause)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `FieldValueClause`. If the actual instance is not `FieldValueClause`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of FieldValueClause</returns>
        public FieldValueClause GetFieldValueClause()
        {
            return (FieldValueClause)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `FieldWasClause`. If the actual instance is not `FieldWasClause`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of FieldWasClause</returns>
        public FieldWasClause GetFieldWasClause()
        {
            return (FieldWasClause)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `FieldChangedClause`. If the actual instance is not `FieldChangedClause`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of FieldChangedClause</returns>
        public FieldChangedClause GetFieldChangedClause()
        {
            return (FieldChangedClause)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JqlQueryClause {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, JqlQueryClause.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of JqlQueryClause
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of JqlQueryClause</returns>
        public static JqlQueryClause FromJson(string jsonString)
        {
            JqlQueryClause newJqlQueryClause = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newJqlQueryClause;
            }

            try
            {
                newJqlQueryClause = new JqlQueryClause(JsonConvert.DeserializeObject<CompoundClause>(jsonString, JqlQueryClause.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newJqlQueryClause;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into CompoundClause: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newJqlQueryClause = new JqlQueryClause(JsonConvert.DeserializeObject<FieldChangedClause>(jsonString, JqlQueryClause.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newJqlQueryClause;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into FieldChangedClause: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newJqlQueryClause = new JqlQueryClause(JsonConvert.DeserializeObject<FieldValueClause>(jsonString, JqlQueryClause.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newJqlQueryClause;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into FieldValueClause: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newJqlQueryClause = new JqlQueryClause(JsonConvert.DeserializeObject<FieldWasClause>(jsonString, JqlQueryClause.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newJqlQueryClause;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into FieldWasClause: {1}", jsonString, exception.ToString()));
            }

            // no match found, throw an exception
            throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
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

    /// <summary>
    /// Custom JSON converter for JqlQueryClause
    /// </summary>
    public class JqlQueryClauseJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(JqlQueryClause).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch(reader.TokenType) 
            {
                case JsonToken.StartObject:
                    return JqlQueryClause.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return JqlQueryClause.FromJson(JArray.Load(reader).ToString(Formatting.None));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
