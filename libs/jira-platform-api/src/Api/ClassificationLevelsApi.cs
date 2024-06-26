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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Projects.JiraPlatformApi.Client;
using Projects.JiraPlatformApi.Client.Auth;
using Projects.JiraPlatformApi.Model;

namespace Projects.JiraPlatformApi.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IClassificationLevelsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get all classification levels
        /// </summary>
        /// <remarks>
        /// Returns all classification levels.  **[Permissions](#permissions) required:** None.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="status">Optional set of statuses to filter by. (optional)</param>
        /// <param name="orderBy">Ordering of the results by a given field. If not provided, values will not be sorted. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DataClassificationLevelsBean</returns>
        DataClassificationLevelsBean GetAllUserDataClassificationLevels(List<string>? status = default(List<string>?), string? orderBy = default(string?), int operationIndex = 0);

        /// <summary>
        /// Get all classification levels
        /// </summary>
        /// <remarks>
        /// Returns all classification levels.  **[Permissions](#permissions) required:** None.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="status">Optional set of statuses to filter by. (optional)</param>
        /// <param name="orderBy">Ordering of the results by a given field. If not provided, values will not be sorted. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DataClassificationLevelsBean</returns>
        ApiResponse<DataClassificationLevelsBean> GetAllUserDataClassificationLevelsWithHttpInfo(List<string>? status = default(List<string>?), string? orderBy = default(string?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IClassificationLevelsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get all classification levels
        /// </summary>
        /// <remarks>
        /// Returns all classification levels.  **[Permissions](#permissions) required:** None.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="status">Optional set of statuses to filter by. (optional)</param>
        /// <param name="orderBy">Ordering of the results by a given field. If not provided, values will not be sorted. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DataClassificationLevelsBean</returns>
        System.Threading.Tasks.Task<DataClassificationLevelsBean> GetAllUserDataClassificationLevelsAsync(List<string>? status = default(List<string>?), string? orderBy = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all classification levels
        /// </summary>
        /// <remarks>
        /// Returns all classification levels.  **[Permissions](#permissions) required:** None.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="status">Optional set of statuses to filter by. (optional)</param>
        /// <param name="orderBy">Ordering of the results by a given field. If not provided, values will not be sorted. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DataClassificationLevelsBean)</returns>
        System.Threading.Tasks.Task<ApiResponse<DataClassificationLevelsBean>> GetAllUserDataClassificationLevelsWithHttpInfoAsync(List<string>? status = default(List<string>?), string? orderBy = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IClassificationLevelsApi : IClassificationLevelsApiSync, IClassificationLevelsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ClassificationLevelsApi : IClassificationLevelsApi
    {
        private Projects.JiraPlatformApi.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationLevelsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ClassificationLevelsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationLevelsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ClassificationLevelsApi(string basePath)
        {
            this.Configuration = Projects.JiraPlatformApi.Client.Configuration.MergeConfigurations(
                Projects.JiraPlatformApi.Client.GlobalConfiguration.Instance,
                new Projects.JiraPlatformApi.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Projects.JiraPlatformApi.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Projects.JiraPlatformApi.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Projects.JiraPlatformApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationLevelsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ClassificationLevelsApi(Projects.JiraPlatformApi.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Projects.JiraPlatformApi.Client.Configuration.MergeConfigurations(
                Projects.JiraPlatformApi.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Projects.JiraPlatformApi.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Projects.JiraPlatformApi.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Projects.JiraPlatformApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassificationLevelsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ClassificationLevelsApi(Projects.JiraPlatformApi.Client.ISynchronousClient client, Projects.JiraPlatformApi.Client.IAsynchronousClient asyncClient, Projects.JiraPlatformApi.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Projects.JiraPlatformApi.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Projects.JiraPlatformApi.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Projects.JiraPlatformApi.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Projects.JiraPlatformApi.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Projects.JiraPlatformApi.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Get all classification levels Returns all classification levels.  **[Permissions](#permissions) required:** None.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="status">Optional set of statuses to filter by. (optional)</param>
        /// <param name="orderBy">Ordering of the results by a given field. If not provided, values will not be sorted. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>DataClassificationLevelsBean</returns>
        public DataClassificationLevelsBean GetAllUserDataClassificationLevels(List<string>? status = default(List<string>?), string? orderBy = default(string?), int operationIndex = 0)
        {
            Projects.JiraPlatformApi.Client.ApiResponse<DataClassificationLevelsBean> localVarResponse = GetAllUserDataClassificationLevelsWithHttpInfo(status, orderBy);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all classification levels Returns all classification levels.  **[Permissions](#permissions) required:** None.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="status">Optional set of statuses to filter by. (optional)</param>
        /// <param name="orderBy">Ordering of the results by a given field. If not provided, values will not be sorted. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of DataClassificationLevelsBean</returns>
        public Projects.JiraPlatformApi.Client.ApiResponse<DataClassificationLevelsBean> GetAllUserDataClassificationLevelsWithHttpInfo(List<string>? status = default(List<string>?), string? orderBy = default(string?), int operationIndex = 0)
        {
            Projects.JiraPlatformApi.Client.RequestOptions localVarRequestOptions = new Projects.JiraPlatformApi.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Projects.JiraPlatformApi.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Projects.JiraPlatformApi.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (status != null)
            {
                localVarRequestOptions.QueryParameters.Add(Projects.JiraPlatformApi.Client.ClientUtils.ParameterToMultiMap("multi", "status", status));
            }
            if (orderBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Projects.JiraPlatformApi.Client.ClientUtils.ParameterToMultiMap("", "orderBy", orderBy));
            }

            localVarRequestOptions.Operation = "ClassificationLevelsApi.GetAllUserDataClassificationLevels";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }
            // authentication (basicAuth) required
            // http basic authentication required
            if (!string.IsNullOrEmpty(this.Configuration.Username) || !string.IsNullOrEmpty(this.Configuration.Password) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + Projects.JiraPlatformApi.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<DataClassificationLevelsBean>("/rest/api/2/classification-levels", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAllUserDataClassificationLevels", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all classification levels Returns all classification levels.  **[Permissions](#permissions) required:** None.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="status">Optional set of statuses to filter by. (optional)</param>
        /// <param name="orderBy">Ordering of the results by a given field. If not provided, values will not be sorted. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DataClassificationLevelsBean</returns>
        public async System.Threading.Tasks.Task<DataClassificationLevelsBean> GetAllUserDataClassificationLevelsAsync(List<string>? status = default(List<string>?), string? orderBy = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Projects.JiraPlatformApi.Client.ApiResponse<DataClassificationLevelsBean> localVarResponse = await GetAllUserDataClassificationLevelsWithHttpInfoAsync(status, orderBy, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all classification levels Returns all classification levels.  **[Permissions](#permissions) required:** None.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="status">Optional set of statuses to filter by. (optional)</param>
        /// <param name="orderBy">Ordering of the results by a given field. If not provided, values will not be sorted. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DataClassificationLevelsBean)</returns>
        public async System.Threading.Tasks.Task<Projects.JiraPlatformApi.Client.ApiResponse<DataClassificationLevelsBean>> GetAllUserDataClassificationLevelsWithHttpInfoAsync(List<string>? status = default(List<string>?), string? orderBy = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Projects.JiraPlatformApi.Client.RequestOptions localVarRequestOptions = new Projects.JiraPlatformApi.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Projects.JiraPlatformApi.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Projects.JiraPlatformApi.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (status != null)
            {
                localVarRequestOptions.QueryParameters.Add(Projects.JiraPlatformApi.Client.ClientUtils.ParameterToMultiMap("multi", "status", status));
            }
            if (orderBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Projects.JiraPlatformApi.Client.ClientUtils.ParameterToMultiMap("", "orderBy", orderBy));
            }

            localVarRequestOptions.Operation = "ClassificationLevelsApi.GetAllUserDataClassificationLevels";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }
            // authentication (basicAuth) required
            // http basic authentication required
            if (!string.IsNullOrEmpty(this.Configuration.Username) || !string.IsNullOrEmpty(this.Configuration.Password) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + Projects.JiraPlatformApi.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<DataClassificationLevelsBean>("/rest/api/2/classification-levels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAllUserDataClassificationLevels", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
