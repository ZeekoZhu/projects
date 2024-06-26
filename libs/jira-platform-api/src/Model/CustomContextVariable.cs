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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Projects.JiraPlatformApi.Client.OpenAPIDateConverter;
using System.Reflection;

namespace Projects.JiraPlatformApi.Model
{
    /// <summary>
    /// CustomContextVariable
    /// </summary>
    [JsonConverter(typeof(CustomContextVariableJsonConverter))]
    [DataContract(Name = "CustomContextVariable")]
    public partial class CustomContextVariable : AbstractOpenAPISchema, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomContextVariable" /> class
        /// with the <see cref="UserContextVariable" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of UserContextVariable.</param>
        public CustomContextVariable(UserContextVariable actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomContextVariable" /> class
        /// with the <see cref="IssueContextVariable" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of IssueContextVariable.</param>
        public CustomContextVariable(IssueContextVariable actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomContextVariable" /> class
        /// with the <see cref="JsonContextVariable" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of JsonContextVariable.</param>
        public CustomContextVariable(JsonContextVariable actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
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
                if (value.GetType() == typeof(IssueContextVariable))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(JsonContextVariable))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(UserContextVariable))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: IssueContextVariable, JsonContextVariable, UserContextVariable");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `UserContextVariable`. If the actual instance is not `UserContextVariable`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of UserContextVariable</returns>
        public UserContextVariable GetUserContextVariable()
        {
            return (UserContextVariable)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `IssueContextVariable`. If the actual instance is not `IssueContextVariable`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of IssueContextVariable</returns>
        public IssueContextVariable GetIssueContextVariable()
        {
            return (IssueContextVariable)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `JsonContextVariable`. If the actual instance is not `JsonContextVariable`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of JsonContextVariable</returns>
        public JsonContextVariable GetJsonContextVariable()
        {
            return (JsonContextVariable)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CustomContextVariable {\n");
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
            return JsonConvert.SerializeObject(this.ActualInstance, CustomContextVariable.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of CustomContextVariable
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of CustomContextVariable</returns>
        public static CustomContextVariable FromJson(string jsonString)
        {
            CustomContextVariable newCustomContextVariable = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newCustomContextVariable;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(IssueContextVariable).GetProperty("AdditionalProperties") == null)
                {
                    newCustomContextVariable = new CustomContextVariable(JsonConvert.DeserializeObject<IssueContextVariable>(jsonString, CustomContextVariable.SerializerSettings));
                }
                else
                {
                    newCustomContextVariable = new CustomContextVariable(JsonConvert.DeserializeObject<IssueContextVariable>(jsonString, CustomContextVariable.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("IssueContextVariable");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into IssueContextVariable: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(JsonContextVariable).GetProperty("AdditionalProperties") == null)
                {
                    newCustomContextVariable = new CustomContextVariable(JsonConvert.DeserializeObject<JsonContextVariable>(jsonString, CustomContextVariable.SerializerSettings));
                }
                else
                {
                    newCustomContextVariable = new CustomContextVariable(JsonConvert.DeserializeObject<JsonContextVariable>(jsonString, CustomContextVariable.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("JsonContextVariable");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into JsonContextVariable: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(UserContextVariable).GetProperty("AdditionalProperties") == null)
                {
                    newCustomContextVariable = new CustomContextVariable(JsonConvert.DeserializeObject<UserContextVariable>(jsonString, CustomContextVariable.SerializerSettings));
                }
                else
                {
                    newCustomContextVariable = new CustomContextVariable(JsonConvert.DeserializeObject<UserContextVariable>(jsonString, CustomContextVariable.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("UserContextVariable");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into UserContextVariable: {1}", jsonString, exception.ToString()));
            }

            if (match == 0)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
            }
            else if (match > 1)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` incorrectly matches more than one schema (should be exactly one match): " + String.Join(",", matchedTypes));
            }

            // deserialization is considered successful at this point if no exception has been thrown.
            return newCustomContextVariable;
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
    /// Custom JSON converter for CustomContextVariable
    /// </summary>
    public class CustomContextVariableJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(CustomContextVariable).GetMethod("ToJson").Invoke(value, null)));
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
                    return CustomContextVariable.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return CustomContextVariable.FromJson(JArray.Load(reader).ToString(Formatting.None));
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
