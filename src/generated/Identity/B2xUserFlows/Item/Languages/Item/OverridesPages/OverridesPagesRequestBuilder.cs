using ApiSdk.Identity.B2xUserFlows.Item.Languages.Item.OverridesPages.Item;
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
namespace ApiSdk.Identity.B2xUserFlows.Item.Languages.Item.OverridesPages {
    /// <summary>Builds and executes requests for operations under \identity\b2xUserFlows\{b2xIdentityUserFlow-id}\languages\{userFlowLanguageConfiguration-id}\overridesPages</summary>
    public class OverridesPagesRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command[] BuildCommand() {
            var builder = new UserFlowLanguagePageRequestBuilder(PathParameters, RequestAdapter);
            var commands = new List<Command> { 
                builder.BuildContentCommand(),
                builder.BuildPatchCommand(),
                builder.BuildGetCommand(),
                builder.BuildDeleteCommand(),
            };
            return commands.ToArray();
        }
        /// <summary>
        /// Collection of pages with the overrides messages to display in a user flow for a specified language. This collection only allows to modify the content of the page, any other modification is not allowed (creation or deletion of pages).
        /// </summary>
        public Command BuildCreateCommand() {
            var command = new Command("create");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--b2xidentityuserflow-id", description: "key: id of b2xIdentityUserFlow"));
            command.AddOption(new Option<string>("--userflowlanguageconfiguration-id", description: "key: id of userFlowLanguageConfiguration"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string, string>(async (b2xIdentityUserFlowId, userFlowLanguageConfigurationId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<UserFlowLanguagePage>();
                var requestInfo = CreatePostRequestInformation(model);
                if (!String.IsNullOrEmpty(b2xIdentityUserFlowId)) requestInfo.PathParameters.Add("b2xIdentityUserFlow_id", b2xIdentityUserFlowId);
                if (!String.IsNullOrEmpty(userFlowLanguageConfigurationId)) requestInfo.PathParameters.Add("userFlowLanguageConfiguration_id", userFlowLanguageConfigurationId);
                var result = await RequestAdapter.SendAsync<UserFlowLanguagePage>(requestInfo);
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
        /// Collection of pages with the overrides messages to display in a user flow for a specified language. This collection only allows to modify the content of the page, any other modification is not allowed (creation or deletion of pages).
        /// </summary>
        public Command BuildListCommand() {
            var command = new Command("list");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--b2xidentityuserflow-id", description: "key: id of b2xIdentityUserFlow"));
            command.AddOption(new Option<string>("--userflowlanguageconfiguration-id", description: "key: id of userFlowLanguageConfiguration"));
            command.AddOption(new Option<int?>("--top", description: "Show only the first n items"));
            command.AddOption(new Option<int?>("--skip", description: "Skip the first n items"));
            command.AddOption(new Option<string>("--search", description: "Search items by search phrases"));
            command.AddOption(new Option<string>("--filter", description: "Filter items by property values"));
            command.AddOption(new Option<bool?>("--count", description: "Include count of items"));
            command.AddOption(new Option<object>("--orderby", description: "Order items by property values"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.AddOption(new Option<object>("--expand", description: "Expand related entities"));
            command.Handler = CommandHandler.Create<string, string, int?, int?, string, string, bool?, object, object, object>(async (b2xIdentityUserFlowId, userFlowLanguageConfigurationId, top, skip, search, filter, count, orderby, select, expand) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(b2xIdentityUserFlowId)) requestInfo.PathParameters.Add("b2xIdentityUserFlow_id", b2xIdentityUserFlowId);
                if (!String.IsNullOrEmpty(userFlowLanguageConfigurationId)) requestInfo.PathParameters.Add("userFlowLanguageConfiguration_id", userFlowLanguageConfigurationId);
                requestInfo.QueryParameters.Add("top", top);
                requestInfo.QueryParameters.Add("skip", skip);
                if (!String.IsNullOrEmpty(search)) requestInfo.QueryParameters.Add("search", search);
                if (!String.IsNullOrEmpty(filter)) requestInfo.QueryParameters.Add("filter", filter);
                requestInfo.QueryParameters.Add("count", count);
                requestInfo.QueryParameters.Add("orderby", orderby);
                requestInfo.QueryParameters.Add("select", select);
                requestInfo.QueryParameters.Add("expand", expand);
                var result = await RequestAdapter.SendAsync<OverridesPagesResponse>(requestInfo);
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
        /// Instantiates a new OverridesPagesRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public OverridesPagesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/identity/b2xUserFlows/{b2xIdentityUserFlow_id}/languages/{userFlowLanguageConfiguration_id}/overridesPages{?top,skip,search,filter,count,orderby,select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Collection of pages with the overrides messages to display in a user flow for a specified language. This collection only allows to modify the content of the page, any other modification is not allowed (creation or deletion of pages).
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
        /// Collection of pages with the overrides messages to display in a user flow for a specified language. This collection only allows to modify the content of the page, any other modification is not allowed (creation or deletion of pages).
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(UserFlowLanguagePage body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Collection of pages with the overrides messages to display in a user flow for a specified language. This collection only allows to modify the content of the page, any other modification is not allowed (creation or deletion of pages).
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<OverridesPagesResponse> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<OverridesPagesResponse>(requestInfo, responseHandler);
        }
        /// <summary>
        /// Collection of pages with the overrides messages to display in a user flow for a specified language. This collection only allows to modify the content of the page, any other modification is not allowed (creation or deletion of pages).
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<UserFlowLanguagePage> PostAsync(UserFlowLanguagePage model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePostRequestInformation(model, h, o);
            return await RequestAdapter.SendAsync<UserFlowLanguagePage>(requestInfo, responseHandler);
        }
        /// <summary>Collection of pages with the overrides messages to display in a user flow for a specified language. This collection only allows to modify the content of the page, any other modification is not allowed (creation or deletion of pages).</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Include count of items</summary>
            public bool? Count { get; set; }
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Filter items by property values</summary>
            public string Filter { get; set; }
            /// <summary>Order items by property values</summary>
            public string[] Orderby { get; set; }
            /// <summary>Search items by search phrases</summary>
            public string Search { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
            /// <summary>Skip the first n items</summary>
            public int? Skip { get; set; }
            /// <summary>Show only the first n items</summary>
            public int? Top { get; set; }
        }
    }
}