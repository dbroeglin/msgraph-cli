using ApiSdk.Directory.AdministrativeUnits.Item.Extensions;
using ApiSdk.Directory.AdministrativeUnits.Item.Members;
using ApiSdk.Directory.AdministrativeUnits.Item.ScopedRoleMembers;
using ApiSdk.Models;
using ApiSdk.Models.ODataErrors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.Directory.AdministrativeUnits.Item {
    /// <summary>Provides operations to manage the administrativeUnits property of the microsoft.graph.directory entity.</summary>
    public class AdministrativeUnitItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Delete navigation property administrativeUnits for directory
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property administrativeUnits for directory";
            // Create options for all the parameters
            var administrativeUnitIdOption = new Option<string>("--administrative-unit-id", description: "key: id of administrativeUnit") {
            };
            administrativeUnitIdOption.IsRequired = true;
            command.AddOption(administrativeUnitIdOption);
            var ifMatchOption = new Option<string>("--if-match", description: "ETag") {
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (invocationContext) => {
                var administrativeUnitId = invocationContext.ParseResult.GetValueForOption(administrativeUnitIdOption);
                var ifMatch = invocationContext.ParseResult.GetValueForOption(ifMatchOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("administrativeUnit%2Did", administrativeUnitId);
                requestInfo.Headers["If-Match"] = ifMatch;
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        public Command BuildExtensionsCommand() {
            var command = new Command("extensions");
            var builder = new ExtensionsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        /// <summary>
        /// Conceptual container for user and group directory objects.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Conceptual container for user and group directory objects.";
            // Create options for all the parameters
            var administrativeUnitIdOption = new Option<string>("--administrative-unit-id", description: "key: id of administrativeUnit") {
            };
            administrativeUnitIdOption.IsRequired = true;
            command.AddOption(administrativeUnitIdOption);
            var selectOption = new Option<string[]>("--select", description: "Select properties to be returned") {
                Arity = ArgumentArity.ZeroOrMore
            };
            selectOption.IsRequired = false;
            command.AddOption(selectOption);
            var expandOption = new Option<string[]>("--expand", description: "Expand related entities") {
                Arity = ArgumentArity.ZeroOrMore
            };
            expandOption.IsRequired = false;
            command.AddOption(expandOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            var jsonNoIndentOption = new Option<bool>("--json-no-indent", r => {
                if (bool.TryParse(r.Tokens.Select(t => t.Value).LastOrDefault(), out var value)) {
                    return value;
                }
                return true;
            }, description: "Disable indentation for the JSON output formatter.");
            command.AddOption(jsonNoIndentOption);
            command.SetHandler(async (invocationContext) => {
                var administrativeUnitId = invocationContext.ParseResult.GetValueForOption(administrativeUnitIdOption);
                var select = invocationContext.ParseResult.GetValueForOption(selectOption);
                var expand = invocationContext.ParseResult.GetValueForOption(expandOption);
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                var jsonNoIndent = invocationContext.ParseResult.GetValueForOption(jsonNoIndentOption);
                var outputFilter = invocationContext.BindingContext.GetRequiredService<IOutputFilter>();
                var outputFormatterFactory = invocationContext.BindingContext.GetRequiredService<IOutputFormatterFactory>();
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = CreateGetRequestInformation(q => {
                    q.QueryParameters.Select = select;
                    q.QueryParameters.Expand = expand;
                });
                requestInfo.PathParameters.Add("administrativeUnit%2Did", administrativeUnitId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            });
            return command;
        }
        public Command BuildMembersCommand() {
            var command = new Command("members");
            var builder = new MembersRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildApplicationCommand());
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildDeviceCommand());
            command.AddCommand(builder.BuildGroupCommand());
            command.AddCommand(builder.BuildListCommand());
            command.AddCommand(builder.BuildOrgContactCommand());
            command.AddCommand(builder.BuildRefCommand());
            command.AddCommand(builder.BuildServicePrincipalCommand());
            command.AddCommand(builder.BuildUserCommand());
            return command;
        }
        /// <summary>
        /// Update the navigation property administrativeUnits in directory
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property administrativeUnits in directory";
            // Create options for all the parameters
            var administrativeUnitIdOption = new Option<string>("--administrative-unit-id", description: "key: id of administrativeUnit") {
            };
            administrativeUnitIdOption.IsRequired = true;
            command.AddOption(administrativeUnitIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (invocationContext) => {
                var administrativeUnitId = invocationContext.ParseResult.GetValueForOption(administrativeUnitIdOption);
                var body = invocationContext.ParseResult.GetValueForOption(bodyOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ApiSdk.Models.AdministrativeUnit>(ApiSdk.Models.AdministrativeUnit.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                requestInfo.PathParameters.Add("administrativeUnit%2Did", administrativeUnitId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        public Command BuildScopedRoleMembersCommand() {
            var command = new Command("scoped-role-members");
            var builder = new ScopedRoleMembersRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new AdministrativeUnitItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public AdministrativeUnitItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/directory/administrativeUnits/{administrativeUnit%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property administrativeUnits for directory
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<AdministrativeUnitItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new AdministrativeUnitItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Conceptual container for user and group directory objects.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<AdministrativeUnitItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new AdministrativeUnitItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property administrativeUnits in directory
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(ApiSdk.Models.AdministrativeUnit body, Action<AdministrativeUnitItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new AdministrativeUnitItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class AdministrativeUnitItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new administrativeUnitItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public AdministrativeUnitItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Conceptual container for user and group directory objects.</summary>
        public class AdministrativeUnitItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class AdministrativeUnitItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public AdministrativeUnitItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new AdministrativeUnitItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new administrativeUnitItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public AdministrativeUnitItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class AdministrativeUnitItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new administrativeUnitItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public AdministrativeUnitItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
