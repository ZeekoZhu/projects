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
    public interface IProjectFeaturesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get project features
        /// </summary>
        /// <remarks>
        /// Returns the list of features for a project.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContainerForProjectFeatures</returns>
        ContainerForProjectFeatures GetFeaturesForProject(string projectIdOrKey, int operationIndex = 0);

        /// <summary>
        /// Get project features
        /// </summary>
        /// <remarks>
        /// Returns the list of features for a project.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContainerForProjectFeatures</returns>
        ApiResponse<ContainerForProjectFeatures> GetFeaturesForProjectWithHttpInfo(string projectIdOrKey, int operationIndex = 0);
        /// <summary>
        /// Set project feature state
        /// </summary>
        /// <remarks>
        /// Sets the state of a project feature.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="projectFeatureState">Details of the feature state change.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContainerForProjectFeatures</returns>
        ContainerForProjectFeatures ToggleFeatureForProject(string projectIdOrKey, string featureKey, ProjectFeatureState projectFeatureState, int operationIndex = 0);

        /// <summary>
        /// Set project feature state
        /// </summary>
        /// <remarks>
        /// Sets the state of a project feature.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="projectFeatureState">Details of the feature state change.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContainerForProjectFeatures</returns>
        ApiResponse<ContainerForProjectFeatures> ToggleFeatureForProjectWithHttpInfo(string projectIdOrKey, string featureKey, ProjectFeatureState projectFeatureState, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectFeaturesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get project features
        /// </summary>
        /// <remarks>
        /// Returns the list of features for a project.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContainerForProjectFeatures</returns>
        System.Threading.Tasks.Task<ContainerForProjectFeatures> GetFeaturesForProjectAsync(string projectIdOrKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get project features
        /// </summary>
        /// <remarks>
        /// Returns the list of features for a project.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContainerForProjectFeatures)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContainerForProjectFeatures>> GetFeaturesForProjectWithHttpInfoAsync(string projectIdOrKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Set project feature state
        /// </summary>
        /// <remarks>
        /// Sets the state of a project feature.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="projectFeatureState">Details of the feature state change.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContainerForProjectFeatures</returns>
        System.Threading.Tasks.Task<ContainerForProjectFeatures> ToggleFeatureForProjectAsync(string projectIdOrKey, string featureKey, ProjectFeatureState projectFeatureState, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Set project feature state
        /// </summary>
        /// <remarks>
        /// Sets the state of a project feature.
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="projectFeatureState">Details of the feature state change.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContainerForProjectFeatures)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContainerForProjectFeatures>> ToggleFeatureForProjectWithHttpInfoAsync(string projectIdOrKey, string featureKey, ProjectFeatureState projectFeatureState, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectFeaturesApi : IProjectFeaturesApiSync, IProjectFeaturesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProjectFeaturesApi : IProjectFeaturesApi
    {
        private Projects.JiraPlatformApi.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectFeaturesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProjectFeaturesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectFeaturesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProjectFeaturesApi(string basePath)
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
        /// Initializes a new instance of the <see cref="ProjectFeaturesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ProjectFeaturesApi(Projects.JiraPlatformApi.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="ProjectFeaturesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ProjectFeaturesApi(Projects.JiraPlatformApi.Client.ISynchronousClient client, Projects.JiraPlatformApi.Client.IAsynchronousClient asyncClient, Projects.JiraPlatformApi.Client.IReadableConfiguration configuration)
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
        /// Get project features Returns the list of features for a project.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContainerForProjectFeatures</returns>
        public ContainerForProjectFeatures GetFeaturesForProject(string projectIdOrKey, int operationIndex = 0)
        {
            Projects.JiraPlatformApi.Client.ApiResponse<ContainerForProjectFeatures> localVarResponse = GetFeaturesForProjectWithHttpInfo(projectIdOrKey);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get project features Returns the list of features for a project.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContainerForProjectFeatures</returns>
        public Projects.JiraPlatformApi.Client.ApiResponse<ContainerForProjectFeatures> GetFeaturesForProjectWithHttpInfo(string projectIdOrKey, int operationIndex = 0)
        {
            // verify the required parameter 'projectIdOrKey' is set
            if (projectIdOrKey == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'projectIdOrKey' when calling ProjectFeaturesApi->GetFeaturesForProject");
            }

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

            localVarRequestOptions.PathParameters.Add("projectIdOrKey", Projects.JiraPlatformApi.Client.ClientUtils.ParameterToString(projectIdOrKey)); // path parameter

            localVarRequestOptions.Operation = "ProjectFeaturesApi.GetFeaturesForProject";
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
            var localVarResponse = this.Client.Get<ContainerForProjectFeatures>("/rest/api/2/project/{projectIdOrKey}/features", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFeaturesForProject", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get project features Returns the list of features for a project.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContainerForProjectFeatures</returns>
        public async System.Threading.Tasks.Task<ContainerForProjectFeatures> GetFeaturesForProjectAsync(string projectIdOrKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Projects.JiraPlatformApi.Client.ApiResponse<ContainerForProjectFeatures> localVarResponse = await GetFeaturesForProjectWithHttpInfoAsync(projectIdOrKey, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get project features Returns the list of features for a project.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContainerForProjectFeatures)</returns>
        public async System.Threading.Tasks.Task<Projects.JiraPlatformApi.Client.ApiResponse<ContainerForProjectFeatures>> GetFeaturesForProjectWithHttpInfoAsync(string projectIdOrKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectIdOrKey' is set
            if (projectIdOrKey == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'projectIdOrKey' when calling ProjectFeaturesApi->GetFeaturesForProject");
            }


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

            localVarRequestOptions.PathParameters.Add("projectIdOrKey", Projects.JiraPlatformApi.Client.ClientUtils.ParameterToString(projectIdOrKey)); // path parameter

            localVarRequestOptions.Operation = "ProjectFeaturesApi.GetFeaturesForProject";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<ContainerForProjectFeatures>("/rest/api/2/project/{projectIdOrKey}/features", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFeaturesForProject", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Set project feature state Sets the state of a project feature.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="projectFeatureState">Details of the feature state change.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContainerForProjectFeatures</returns>
        public ContainerForProjectFeatures ToggleFeatureForProject(string projectIdOrKey, string featureKey, ProjectFeatureState projectFeatureState, int operationIndex = 0)
        {
            Projects.JiraPlatformApi.Client.ApiResponse<ContainerForProjectFeatures> localVarResponse = ToggleFeatureForProjectWithHttpInfo(projectIdOrKey, featureKey, projectFeatureState);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Set project feature state Sets the state of a project feature.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="projectFeatureState">Details of the feature state change.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContainerForProjectFeatures</returns>
        public Projects.JiraPlatformApi.Client.ApiResponse<ContainerForProjectFeatures> ToggleFeatureForProjectWithHttpInfo(string projectIdOrKey, string featureKey, ProjectFeatureState projectFeatureState, int operationIndex = 0)
        {
            // verify the required parameter 'projectIdOrKey' is set
            if (projectIdOrKey == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'projectIdOrKey' when calling ProjectFeaturesApi->ToggleFeatureForProject");
            }

            // verify the required parameter 'featureKey' is set
            if (featureKey == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'featureKey' when calling ProjectFeaturesApi->ToggleFeatureForProject");
            }

            // verify the required parameter 'projectFeatureState' is set
            if (projectFeatureState == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'projectFeatureState' when calling ProjectFeaturesApi->ToggleFeatureForProject");
            }

            Projects.JiraPlatformApi.Client.RequestOptions localVarRequestOptions = new Projects.JiraPlatformApi.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
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

            localVarRequestOptions.PathParameters.Add("projectIdOrKey", Projects.JiraPlatformApi.Client.ClientUtils.ParameterToString(projectIdOrKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("featureKey", Projects.JiraPlatformApi.Client.ClientUtils.ParameterToString(featureKey)); // path parameter
            localVarRequestOptions.Data = projectFeatureState;

            localVarRequestOptions.Operation = "ProjectFeaturesApi.ToggleFeatureForProject";
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
            var localVarResponse = this.Client.Put<ContainerForProjectFeatures>("/rest/api/2/project/{projectIdOrKey}/features/{featureKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ToggleFeatureForProject", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Set project feature state Sets the state of a project feature.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="projectFeatureState">Details of the feature state change.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContainerForProjectFeatures</returns>
        public async System.Threading.Tasks.Task<ContainerForProjectFeatures> ToggleFeatureForProjectAsync(string projectIdOrKey, string featureKey, ProjectFeatureState projectFeatureState, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Projects.JiraPlatformApi.Client.ApiResponse<ContainerForProjectFeatures> localVarResponse = await ToggleFeatureForProjectWithHttpInfoAsync(projectIdOrKey, featureKey, projectFeatureState, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Set project feature state Sets the state of a project feature.
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="projectFeatureState">Details of the feature state change.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContainerForProjectFeatures)</returns>
        public async System.Threading.Tasks.Task<Projects.JiraPlatformApi.Client.ApiResponse<ContainerForProjectFeatures>> ToggleFeatureForProjectWithHttpInfoAsync(string projectIdOrKey, string featureKey, ProjectFeatureState projectFeatureState, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectIdOrKey' is set
            if (projectIdOrKey == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'projectIdOrKey' when calling ProjectFeaturesApi->ToggleFeatureForProject");
            }

            // verify the required parameter 'featureKey' is set
            if (featureKey == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'featureKey' when calling ProjectFeaturesApi->ToggleFeatureForProject");
            }

            // verify the required parameter 'projectFeatureState' is set
            if (projectFeatureState == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'projectFeatureState' when calling ProjectFeaturesApi->ToggleFeatureForProject");
            }


            Projects.JiraPlatformApi.Client.RequestOptions localVarRequestOptions = new Projects.JiraPlatformApi.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
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

            localVarRequestOptions.PathParameters.Add("projectIdOrKey", Projects.JiraPlatformApi.Client.ClientUtils.ParameterToString(projectIdOrKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("featureKey", Projects.JiraPlatformApi.Client.ClientUtils.ParameterToString(featureKey)); // path parameter
            localVarRequestOptions.Data = projectFeatureState;

            localVarRequestOptions.Operation = "ProjectFeaturesApi.ToggleFeatureForProject";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<ContainerForProjectFeatures>("/rest/api/2/project/{projectIdOrKey}/features/{featureKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ToggleFeatureForProject", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
