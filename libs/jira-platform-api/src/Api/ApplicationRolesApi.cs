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
    public interface IApplicationRolesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get all application roles
        /// </summary>
        /// <remarks>
        /// Returns all application roles. In Jira, application roles are managed using the [Application access configuration](https://confluence.atlassian.com/x/3YxjL) page.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;ApplicationRole&gt;</returns>
        List<ApplicationRole> GetAllApplicationRoles(int operationIndex = 0);

        /// <summary>
        /// Get all application roles
        /// </summary>
        /// <remarks>
        /// Returns all application roles. In Jira, application roles are managed using the [Application access configuration](https://confluence.atlassian.com/x/3YxjL) page.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;ApplicationRole&gt;</returns>
        ApiResponse<List<ApplicationRole>> GetAllApplicationRolesWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// Get application role
        /// </summary>
        /// <remarks>
        /// Returns an application role.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-2-applicationrole-get) operation to get the key for each application role.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApplicationRole</returns>
        ApplicationRole GetApplicationRole(string key, int operationIndex = 0);

        /// <summary>
        /// Get application role
        /// </summary>
        /// <remarks>
        /// Returns an application role.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-2-applicationrole-get) operation to get the key for each application role.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApplicationRole</returns>
        ApiResponse<ApplicationRole> GetApplicationRoleWithHttpInfo(string key, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IApplicationRolesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get all application roles
        /// </summary>
        /// <remarks>
        /// Returns all application roles. In Jira, application roles are managed using the [Application access configuration](https://confluence.atlassian.com/x/3YxjL) page.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ApplicationRole&gt;</returns>
        System.Threading.Tasks.Task<List<ApplicationRole>> GetAllApplicationRolesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all application roles
        /// </summary>
        /// <remarks>
        /// Returns all application roles. In Jira, application roles are managed using the [Application access configuration](https://confluence.atlassian.com/x/3YxjL) page.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ApplicationRole&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<ApplicationRole>>> GetAllApplicationRolesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get application role
        /// </summary>
        /// <remarks>
        /// Returns an application role.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-2-applicationrole-get) operation to get the key for each application role.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApplicationRole</returns>
        System.Threading.Tasks.Task<ApplicationRole> GetApplicationRoleAsync(string key, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get application role
        /// </summary>
        /// <remarks>
        /// Returns an application role.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </remarks>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-2-applicationrole-get) operation to get the key for each application role.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApplicationRole)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApplicationRole>> GetApplicationRoleWithHttpInfoAsync(string key, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IApplicationRolesApi : IApplicationRolesApiSync, IApplicationRolesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ApplicationRolesApi : IApplicationRolesApi
    {
        private Projects.JiraPlatformApi.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRolesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ApplicationRolesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRolesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ApplicationRolesApi(string basePath)
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
        /// Initializes a new instance of the <see cref="ApplicationRolesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ApplicationRolesApi(Projects.JiraPlatformApi.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="ApplicationRolesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ApplicationRolesApi(Projects.JiraPlatformApi.Client.ISynchronousClient client, Projects.JiraPlatformApi.Client.IAsynchronousClient asyncClient, Projects.JiraPlatformApi.Client.IReadableConfiguration configuration)
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
        /// Get all application roles Returns all application roles. In Jira, application roles are managed using the [Application access configuration](https://confluence.atlassian.com/x/3YxjL) page.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;ApplicationRole&gt;</returns>
        public List<ApplicationRole> GetAllApplicationRoles(int operationIndex = 0)
        {
            Projects.JiraPlatformApi.Client.ApiResponse<List<ApplicationRole>> localVarResponse = GetAllApplicationRolesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all application roles Returns all application roles. In Jira, application roles are managed using the [Application access configuration](https://confluence.atlassian.com/x/3YxjL) page.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;ApplicationRole&gt;</returns>
        public Projects.JiraPlatformApi.Client.ApiResponse<List<ApplicationRole>> GetAllApplicationRolesWithHttpInfo(int operationIndex = 0)
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


            localVarRequestOptions.Operation = "ApplicationRolesApi.GetAllApplicationRoles";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (basicAuth) required
            // http basic authentication required
            if (!string.IsNullOrEmpty(this.Configuration.Username) || !string.IsNullOrEmpty(this.Configuration.Password) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + Projects.JiraPlatformApi.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<ApplicationRole>>("/rest/api/2/applicationrole", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAllApplicationRoles", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all application roles Returns all application roles. In Jira, application roles are managed using the [Application access configuration](https://confluence.atlassian.com/x/3YxjL) page.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ApplicationRole&gt;</returns>
        public async System.Threading.Tasks.Task<List<ApplicationRole>> GetAllApplicationRolesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Projects.JiraPlatformApi.Client.ApiResponse<List<ApplicationRole>> localVarResponse = await GetAllApplicationRolesWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all application roles Returns all application roles. In Jira, application roles are managed using the [Application access configuration](https://confluence.atlassian.com/x/3YxjL) page.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ApplicationRole&gt;)</returns>
        public async System.Threading.Tasks.Task<Projects.JiraPlatformApi.Client.ApiResponse<List<ApplicationRole>>> GetAllApplicationRolesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            localVarRequestOptions.Operation = "ApplicationRolesApi.GetAllApplicationRoles";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (basicAuth) required
            // http basic authentication required
            if (!string.IsNullOrEmpty(this.Configuration.Username) || !string.IsNullOrEmpty(this.Configuration.Password) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + Projects.JiraPlatformApi.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<ApplicationRole>>("/rest/api/2/applicationrole", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAllApplicationRoles", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get application role Returns an application role.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-2-applicationrole-get) operation to get the key for each application role.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApplicationRole</returns>
        public ApplicationRole GetApplicationRole(string key, int operationIndex = 0)
        {
            Projects.JiraPlatformApi.Client.ApiResponse<ApplicationRole> localVarResponse = GetApplicationRoleWithHttpInfo(key);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get application role Returns an application role.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-2-applicationrole-get) operation to get the key for each application role.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApplicationRole</returns>
        public Projects.JiraPlatformApi.Client.ApiResponse<ApplicationRole> GetApplicationRoleWithHttpInfo(string key, int operationIndex = 0)
        {
            // verify the required parameter 'key' is set
            if (key == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'key' when calling ApplicationRolesApi->GetApplicationRole");
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

            localVarRequestOptions.PathParameters.Add("key", Projects.JiraPlatformApi.Client.ClientUtils.ParameterToString(key)); // path parameter

            localVarRequestOptions.Operation = "ApplicationRolesApi.GetApplicationRole";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (basicAuth) required
            // http basic authentication required
            if (!string.IsNullOrEmpty(this.Configuration.Username) || !string.IsNullOrEmpty(this.Configuration.Password) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + Projects.JiraPlatformApi.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ApplicationRole>("/rest/api/2/applicationrole/{key}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetApplicationRole", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get application role Returns an application role.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-2-applicationrole-get) operation to get the key for each application role.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApplicationRole</returns>
        public async System.Threading.Tasks.Task<ApplicationRole> GetApplicationRoleAsync(string key, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Projects.JiraPlatformApi.Client.ApiResponse<ApplicationRole> localVarResponse = await GetApplicationRoleWithHttpInfoAsync(key, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get application role Returns an application role.  **[Permissions](#permissions) required:** *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).
        /// </summary>
        /// <exception cref="Projects.JiraPlatformApi.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-2-applicationrole-get) operation to get the key for each application role.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApplicationRole)</returns>
        public async System.Threading.Tasks.Task<Projects.JiraPlatformApi.Client.ApiResponse<ApplicationRole>> GetApplicationRoleWithHttpInfoAsync(string key, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'key' is set
            if (key == null)
            {
                throw new Projects.JiraPlatformApi.Client.ApiException(400, "Missing required parameter 'key' when calling ApplicationRolesApi->GetApplicationRole");
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

            localVarRequestOptions.PathParameters.Add("key", Projects.JiraPlatformApi.Client.ClientUtils.ParameterToString(key)); // path parameter

            localVarRequestOptions.Operation = "ApplicationRolesApi.GetApplicationRole";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (basicAuth) required
            // http basic authentication required
            if (!string.IsNullOrEmpty(this.Configuration.Username) || !string.IsNullOrEmpty(this.Configuration.Password) && !localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Basic " + Projects.JiraPlatformApi.Client.ClientUtils.Base64Encode(this.Configuration.Username + ":" + this.Configuration.Password));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApplicationRole>("/rest/api/2/applicationrole/{key}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetApplicationRole", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
