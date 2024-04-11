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
    /// The response for status request for a running/completed export task.
    /// </summary>
    [DataContract(Name = "ExportArchivedIssuesTaskProgressResponse")]
    public partial class ExportArchivedIssuesTaskProgressResponse : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportArchivedIssuesTaskProgressResponse" /> class.
        /// </summary>
        /// <param name="fileUrl">fileUrl.</param>
        /// <param name="payload">payload.</param>
        /// <param name="progress">progress.</param>
        /// <param name="status">status.</param>
        /// <param name="submittedTime">submittedTime.</param>
        /// <param name="taskId">taskId.</param>
        public ExportArchivedIssuesTaskProgressResponse(string fileUrl = default(string), string payload = default(string), long progress = default(long), string status = default(string), DateTime submittedTime = default(DateTime), string taskId = default(string))
        {
            this.FileUrl = fileUrl;
            this.Payload = payload;
            this.Progress = progress;
            this.Status = status;
            this.SubmittedTime = submittedTime;
            this.TaskId = taskId;
        }

        /// <summary>
        /// Gets or Sets FileUrl
        /// </summary>
        [DataMember(Name = "fileUrl", EmitDefaultValue = false)]
        public string FileUrl { get; set; }

        /// <summary>
        /// Gets or Sets Payload
        /// </summary>
        [DataMember(Name = "payload", EmitDefaultValue = false)]
        public string Payload { get; set; }

        /// <summary>
        /// Gets or Sets Progress
        /// </summary>
        [DataMember(Name = "progress", EmitDefaultValue = false)]
        public long Progress { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets SubmittedTime
        /// </summary>
        [DataMember(Name = "submittedTime", EmitDefaultValue = false)]
        public DateTime SubmittedTime { get; set; }

        /// <summary>
        /// Gets or Sets TaskId
        /// </summary>
        [DataMember(Name = "taskId", EmitDefaultValue = false)]
        public string TaskId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ExportArchivedIssuesTaskProgressResponse {\n");
            sb.Append("  FileUrl: ").Append(FileUrl).Append("\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
            sb.Append("  Progress: ").Append(Progress).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubmittedTime: ").Append(SubmittedTime).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
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
