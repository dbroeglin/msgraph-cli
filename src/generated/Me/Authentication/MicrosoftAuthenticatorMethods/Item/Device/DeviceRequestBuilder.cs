using ApiSdk.Models.Microsoft.Graph;
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
namespace ApiSdk.Me.Authentication.MicrosoftAuthenticatorMethods.Item.Device {
    /// <summary>Builds and executes requests for operations under \me\authentication\microsoftAuthenticatorMethods\{microsoftAuthenticatorAuthenticationMethod-id}\device</summary>
    public class DeviceRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.";
            // Create options for all the parameters
            var microsoftAuthenticatorAuthenticationMethodIdOption = new Option<string>("--microsoft-authenticator-authentication-method-id", description: "key: id of microsoftAuthenticatorAuthenticationMethod") {
            };
            microsoftAuthenticatorAuthenticationMethodIdOption.IsRequired = true;
            command.AddOption(microsoftAuthenticatorAuthenticationMethodIdOption);
            command.SetHandler(async (string microsoftAuthenticatorAuthenticationMethodId, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, microsoftAuthenticatorAuthenticationMethodIdOption);
            return command;
        }
        /// <summary>
        /// The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.";
            // Create options for all the parameters
            var microsoftAuthenticatorAuthenticationMethodIdOption = new Option<string>("--microsoft-authenticator-authentication-method-id", description: "key: id of microsoftAuthenticatorAuthenticationMethod") {
            };
            microsoftAuthenticatorAuthenticationMethodIdOption.IsRequired = true;
            command.AddOption(microsoftAuthenticatorAuthenticationMethodIdOption);
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
            command.SetHandler(async (string microsoftAuthenticatorAuthenticationMethodId, string[] select, string[] expand, FormatterType output, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                formatter.WriteOutput(response);
            }, microsoftAuthenticatorAuthenticationMethodIdOption, selectOption, expandOption, outputOption);
            return command;
        }
        /// <summary>
        /// The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.";
            // Create options for all the parameters
            var microsoftAuthenticatorAuthenticationMethodIdOption = new Option<string>("--microsoft-authenticator-authentication-method-id", description: "key: id of microsoftAuthenticatorAuthenticationMethod") {
            };
            microsoftAuthenticatorAuthenticationMethodIdOption.IsRequired = true;
            command.AddOption(microsoftAuthenticatorAuthenticationMethodIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (string microsoftAuthenticatorAuthenticationMethodId, string body, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ApiSdk.Models.Microsoft.Graph.Device>();
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, microsoftAuthenticatorAuthenticationMethodIdOption, bodyOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new DeviceRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public DeviceRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/me/authentication/microsoftAuthenticatorMethods/{microsoftAuthenticatorAuthenticationMethod_id}/device{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
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
        /// The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(ApiSdk.Models.Microsoft.Graph.Device body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}
