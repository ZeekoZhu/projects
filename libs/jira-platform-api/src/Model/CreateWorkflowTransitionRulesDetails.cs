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
    /// The details of a workflow transition rules.
    /// </summary>
    [DataContract(Name = "CreateWorkflowTransitionRulesDetails")]
    public partial class CreateWorkflowTransitionRulesDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWorkflowTransitionRulesDetails" /> class.
        /// </summary>
        /// <param name="conditions">The workflow conditions..</param>
        /// <param name="postFunctions">The workflow post functions.  **Note:** The default post functions are always added to the *initial* transition, as in:      \&quot;postFunctions\&quot;: [         {             \&quot;type\&quot;: \&quot;IssueCreateFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;IssueReindexFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;FireIssueEventFunction\&quot;,             \&quot;configuration\&quot;: {                 \&quot;event\&quot;: {                     \&quot;id\&quot;: \&quot;1\&quot;,                     \&quot;name\&quot;: \&quot;issue_created\&quot;                 }             }         }     ]  **Note:** The default post functions are always added to the *global* and *directed* transitions, as in:      \&quot;postFunctions\&quot;: [         {             \&quot;type\&quot;: \&quot;UpdateIssueStatusFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;CreateCommentFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;GenerateChangeHistoryFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;IssueReindexFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;FireIssueEventFunction\&quot;,             \&quot;configuration\&quot;: {                 \&quot;event\&quot;: {                     \&quot;id\&quot;: \&quot;13\&quot;,                     \&quot;name\&quot;: \&quot;issue_generic\&quot;                 }             }         }     ].</param>
        /// <param name="validators">The workflow validators.  **Note:** The default permission validator is always added to the *initial* transition, as in:      \&quot;validators\&quot;: [         {             \&quot;type\&quot;: \&quot;PermissionValidator\&quot;,             \&quot;configuration\&quot;: {                 \&quot;permissionKey\&quot;: \&quot;CREATE_ISSUES\&quot;             }         }     ].</param>
        public CreateWorkflowTransitionRulesDetails(CreateWorkflowCondition conditions = default(CreateWorkflowCondition), List<CreateWorkflowTransitionRule> postFunctions = default(List<CreateWorkflowTransitionRule>), List<CreateWorkflowTransitionRule> validators = default(List<CreateWorkflowTransitionRule>))
        {
            this.Conditions = conditions;
            this.PostFunctions = postFunctions;
            this.Validators = validators;
        }

        /// <summary>
        /// The workflow conditions.
        /// </summary>
        /// <value>The workflow conditions.</value>
        [DataMember(Name = "conditions", EmitDefaultValue = false)]
        public CreateWorkflowCondition Conditions { get; set; }

        /// <summary>
        /// The workflow post functions.  **Note:** The default post functions are always added to the *initial* transition, as in:      \&quot;postFunctions\&quot;: [         {             \&quot;type\&quot;: \&quot;IssueCreateFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;IssueReindexFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;FireIssueEventFunction\&quot;,             \&quot;configuration\&quot;: {                 \&quot;event\&quot;: {                     \&quot;id\&quot;: \&quot;1\&quot;,                     \&quot;name\&quot;: \&quot;issue_created\&quot;                 }             }         }     ]  **Note:** The default post functions are always added to the *global* and *directed* transitions, as in:      \&quot;postFunctions\&quot;: [         {             \&quot;type\&quot;: \&quot;UpdateIssueStatusFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;CreateCommentFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;GenerateChangeHistoryFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;IssueReindexFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;FireIssueEventFunction\&quot;,             \&quot;configuration\&quot;: {                 \&quot;event\&quot;: {                     \&quot;id\&quot;: \&quot;13\&quot;,                     \&quot;name\&quot;: \&quot;issue_generic\&quot;                 }             }         }     ]
        /// </summary>
        /// <value>The workflow post functions.  **Note:** The default post functions are always added to the *initial* transition, as in:      \&quot;postFunctions\&quot;: [         {             \&quot;type\&quot;: \&quot;IssueCreateFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;IssueReindexFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;FireIssueEventFunction\&quot;,             \&quot;configuration\&quot;: {                 \&quot;event\&quot;: {                     \&quot;id\&quot;: \&quot;1\&quot;,                     \&quot;name\&quot;: \&quot;issue_created\&quot;                 }             }         }     ]  **Note:** The default post functions are always added to the *global* and *directed* transitions, as in:      \&quot;postFunctions\&quot;: [         {             \&quot;type\&quot;: \&quot;UpdateIssueStatusFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;CreateCommentFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;GenerateChangeHistoryFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;IssueReindexFunction\&quot;         },         {             \&quot;type\&quot;: \&quot;FireIssueEventFunction\&quot;,             \&quot;configuration\&quot;: {                 \&quot;event\&quot;: {                     \&quot;id\&quot;: \&quot;13\&quot;,                     \&quot;name\&quot;: \&quot;issue_generic\&quot;                 }             }         }     ]</value>
        [DataMember(Name = "postFunctions", EmitDefaultValue = false)]
        public List<CreateWorkflowTransitionRule> PostFunctions { get; set; }

        /// <summary>
        /// The workflow validators.  **Note:** The default permission validator is always added to the *initial* transition, as in:      \&quot;validators\&quot;: [         {             \&quot;type\&quot;: \&quot;PermissionValidator\&quot;,             \&quot;configuration\&quot;: {                 \&quot;permissionKey\&quot;: \&quot;CREATE_ISSUES\&quot;             }         }     ]
        /// </summary>
        /// <value>The workflow validators.  **Note:** The default permission validator is always added to the *initial* transition, as in:      \&quot;validators\&quot;: [         {             \&quot;type\&quot;: \&quot;PermissionValidator\&quot;,             \&quot;configuration\&quot;: {                 \&quot;permissionKey\&quot;: \&quot;CREATE_ISSUES\&quot;             }         }     ]</value>
        [DataMember(Name = "validators", EmitDefaultValue = false)]
        public List<CreateWorkflowTransitionRule> Validators { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateWorkflowTransitionRulesDetails {\n");
            sb.Append("  Conditions: ").Append(Conditions).Append("\n");
            sb.Append("  PostFunctions: ").Append(PostFunctions).Append("\n");
            sb.Append("  Validators: ").Append(Validators).Append("\n");
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
