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
namespace ApiSdk.RoleManagement.Directory.RoleAssignments.Item.Principal.Ref {
    /// <summary>Builds and executes requests for operations under \roleManagement\directory\roleAssignments\{unifiedRoleAssignment-id}\principal\$ref</summary>
    public class RefRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.";
            // Create options for all the parameters
            var unifiedRoleAssignmentIdOption = new Option<string>("--unified-role-assignment-id", description: "key: id of unifiedRoleAssignment") {
            };
            unifiedRoleAssignmentIdOption.IsRequired = true;
            command.AddOption(unifiedRoleAssignmentIdOption);
            command.SetHandler(async (string unifiedRoleAssignmentId, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, unifiedRoleAssignmentIdOption);
            return command;
        }
        /// <summary>
        /// The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.";
            // Create options for all the parameters
            var unifiedRoleAssignmentIdOption = new Option<string>("--unified-role-assignment-id", description: "key: id of unifiedRoleAssignment") {
            };
            unifiedRoleAssignmentIdOption.IsRequired = true;
            command.AddOption(unifiedRoleAssignmentIdOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            command.SetHandler(async (string unifiedRoleAssignmentId, FormatterType output, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                var requestInfo = CreateGetRequestInformation(q => {
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                formatter.WriteOutput(response);
            }, unifiedRoleAssignmentIdOption, outputOption);
            return command;
        }
        /// <summary>
        /// The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.
        /// </summary>
        public Command BuildPutCommand() {
            var command = new Command("put");
            command.Description = "The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.";
            // Create options for all the parameters
            var unifiedRoleAssignmentIdOption = new Option<string>("--unified-role-assignment-id", description: "key: id of unifiedRoleAssignment") {
            };
            unifiedRoleAssignmentIdOption.IsRequired = true;
            command.AddOption(unifiedRoleAssignmentIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (string unifiedRoleAssignmentId, string body, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ApiSdk.RoleManagement.Directory.RoleAssignments.Item.Principal.Ref.Ref>();
                var requestInfo = CreatePutRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, unifiedRoleAssignmentIdOption, bodyOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new RefRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public RefRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/roleManagement/directory/roleAssignments/{unifiedRoleAssignment_id}/principal/$ref";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.
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
        /// The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// The assigned principal. Provided so that callers can get the principal using $expand at the same time as getting the role assignment. Read-only. Supports $expand.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePutRequestInformation(ApiSdk.RoleManagement.Directory.RoleAssignments.Item.Principal.Ref.Ref body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PUT,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
    }
}
