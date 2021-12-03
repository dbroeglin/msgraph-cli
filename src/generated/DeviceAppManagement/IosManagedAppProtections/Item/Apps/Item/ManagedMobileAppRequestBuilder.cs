using ApiSdk.Models.Microsoft.Graph;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApiSdk.DeviceAppManagement.IosManagedAppProtections.Item.Apps.Item {
    /// <summary>Builds and executes requests for operations under \deviceAppManagement\iosManagedAppProtections\{iosManagedAppProtection-id}\apps\{managedMobileApp-id}</summary>
    public class ManagedMobileAppRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--iosmanagedappprotection-id", description: "key: id of iosManagedAppProtection"));
            command.AddOption(new Option<string>("--managedmobileapp-id", description: "key: id of managedMobileApp"));
            command.Handler = CommandHandler.Create<string, string>(async (iosManagedAppProtectionId, managedMobileAppId) => {
                var requestInfo = CreateDeleteRequestInformation();
                if (!String.IsNullOrEmpty(iosManagedAppProtectionId)) requestInfo.PathParameters.Add("iosManagedAppProtection_id", iosManagedAppProtectionId);
                if (!String.IsNullOrEmpty(managedMobileAppId)) requestInfo.PathParameters.Add("managedMobileApp_id", managedMobileAppId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--iosmanagedappprotection-id", description: "key: id of iosManagedAppProtection"));
            command.AddOption(new Option<string>("--managedmobileapp-id", description: "key: id of managedMobileApp"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.AddOption(new Option<object>("--expand", description: "Expand related entities"));
            command.Handler = CommandHandler.Create<string, string, object, object>(async (iosManagedAppProtectionId, managedMobileAppId, select, expand) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(iosManagedAppProtectionId)) requestInfo.PathParameters.Add("iosManagedAppProtection_id", iosManagedAppProtectionId);
                if (!String.IsNullOrEmpty(managedMobileAppId)) requestInfo.PathParameters.Add("managedMobileApp_id", managedMobileAppId);
                requestInfo.QueryParameters.Add("select", select);
                requestInfo.QueryParameters.Add("expand", expand);
                var result = await RequestAdapter.SendAsync<ManagedMobileApp>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteObjectValue(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            });
            return command;
        }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--iosmanagedappprotection-id", description: "key: id of iosManagedAppProtection"));
            command.AddOption(new Option<string>("--managedmobileapp-id", description: "key: id of managedMobileApp"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string, string>(async (iosManagedAppProtectionId, managedMobileAppId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ManagedMobileApp>();
                var requestInfo = CreatePatchRequestInformation(model);
                if (!String.IsNullOrEmpty(iosManagedAppProtectionId)) requestInfo.PathParameters.Add("iosManagedAppProtection_id", iosManagedAppProtectionId);
                if (!String.IsNullOrEmpty(managedMobileAppId)) requestInfo.PathParameters.Add("managedMobileApp_id", managedMobileAppId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new ManagedMobileAppRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ManagedMobileAppRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceAppManagement/iosManagedAppProtections/{iosManagedAppProtection_id}/apps/{managedMobileApp_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (q != null) {
                var qParams = new GetQueryParameters();
                q.Invoke(qParams);
                qParams.AddQueryParameters(requestInfo.QueryParameters);
            }
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(ManagedMobileApp body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateDeleteRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<ManagedMobileApp> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<ManagedMobileApp>(requestInfo, responseHandler);
        }
        /// <summary>
        /// List of apps to which the policy is deployed.
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(ManagedMobileApp model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePatchRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>List of apps to which the policy is deployed.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}