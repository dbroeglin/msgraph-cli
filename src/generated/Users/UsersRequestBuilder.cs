using ApiSdk.Models.Microsoft.Graph;
using ApiSdk.Users.Delta;
using ApiSdk.Users.GetAvailableExtensionProperties;
using ApiSdk.Users.GetByIds;
using ApiSdk.Users.Item;
using ApiSdk.Users.ValidateProperties;
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
namespace ApiSdk.Users {
    /// <summary>Builds and executes requests for operations under \users</summary>
    public class UsersRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command[] BuildCommand() {
            var builder = new UserRequestBuilder(PathParameters, RequestAdapter);
            var commands = new List<Command> { 
                builder.BuildPresenceCommand(),
                builder.BuildDeviceManagementTroubleshootingEventsCommand(),
                builder.BuildExportPersonalDataCommand(),
                builder.BuildCheckMemberGroupsCommand(),
                builder.BuildLicenseDetailsCommand(),
                builder.BuildDrivesCommand(),
                builder.BuildTransitiveMemberOfCommand(),
                builder.BuildGetMemberGroupsCommand(),
                builder.BuildEventsCommand(),
                builder.BuildRemoveAllDevicesFromManagementCommand(),
                builder.BuildTranslateExchangeIdsCommand(),
                builder.BuildScopedRoleMemberOfCommand(),
                builder.BuildFindMeetingTimesCommand(),
                builder.BuildTeamworkCommand(),
                builder.BuildDeleteCommand(),
                builder.BuildPhotosCommand(),
                builder.BuildOnenoteCommand(),
                builder.BuildGetMemberObjectsCommand(),
                builder.BuildOutlookCommand(),
                builder.BuildAssignLicenseCommand(),
                builder.BuildJoinedTeamsCommand(),
                builder.BuildActivitiesCommand(),
                builder.BuildManagedDevicesCommand(),
                builder.BuildDriveCommand(),
                builder.BuildRestoreCommand(),
                builder.BuildInferenceClassificationCommand(),
                builder.BuildFollowedSitesCommand(),
                builder.BuildInsightsCommand(),
                builder.BuildCalendarGroupsCommand(),
                builder.BuildPhotoCommand(),
                builder.BuildRegisteredDevicesCommand(),
                builder.BuildSendMailCommand(),
                builder.BuildCalendarViewCommand(),
                builder.BuildCalendarCommand(),
                builder.BuildWipeManagedAppRegistrationsByDeviceTagCommand(),
                builder.BuildPlannerCommand(),
                builder.BuildOwnedObjectsCommand(),
                builder.BuildCheckMemberObjectsCommand(),
                builder.BuildContactFoldersCommand(),
                builder.BuildDirectReportsCommand(),
                builder.BuildOnlineMeetingsCommand(),
                builder.BuildContactsCommand(),
                builder.BuildRevokeSignInSessionsCommand(),
                builder.BuildMessagesCommand(),
                builder.BuildAgreementAcceptancesCommand(),
                builder.BuildPeopleCommand(),
                builder.BuildMemberOfCommand(),
                builder.BuildSettingsCommand(),
                builder.BuildPatchCommand(),
                builder.BuildCreatedObjectsCommand(),
                builder.BuildAuthenticationCommand(),
                builder.BuildGetMailTipsCommand(),
                builder.BuildCalendarsCommand(),
                builder.BuildChatsCommand(),
                builder.BuildMailFoldersCommand(),
                builder.BuildGetCommand(),
                builder.BuildAppRoleAssignmentsCommand(),
                builder.BuildReprocessLicenseAssignmentCommand(),
                builder.BuildManagerCommand(),
                builder.BuildExtensionsCommand(),
                builder.BuildOauth2PermissionGrantsCommand(),
                builder.BuildTodoCommand(),
                builder.BuildOwnedDevicesCommand(),
                builder.BuildManagedAppRegistrationsCommand(),
                builder.BuildChangePasswordCommand(),
            };
            return commands.ToArray();
        }
        /// <summary>
        /// Add new entity to users
        /// </summary>
        public Command BuildCreateCommand() {
            var command = new Command("create");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string>(async (body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ApiSdk.Models.Microsoft.Graph.User>();
                var requestInfo = CreatePostRequestInformation(model);
                var result = await RequestAdapter.SendAsync<ApiSdk.Models.Microsoft.Graph.User>(requestInfo);
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
        public Command BuildGetAvailableExtensionPropertiesCommand() {
            var command = new Command("get-available-extension-properties");
            var builder = new ApiSdk.Users.GetAvailableExtensionProperties.GetAvailableExtensionPropertiesRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildGetByIdsCommand() {
            var command = new Command("get-by-ids");
            var builder = new ApiSdk.Users.GetByIds.GetByIdsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// Get entities from users
        /// </summary>
        public Command BuildListCommand() {
            var command = new Command("list");
            // Create options for all the parameters
            command.AddOption(new Option<int?>("--top", description: "Show only the first n items"));
            command.AddOption(new Option<int?>("--skip", description: "Skip the first n items"));
            command.AddOption(new Option<string>("--search", description: "Search items by search phrases"));
            command.AddOption(new Option<string>("--filter", description: "Filter items by property values"));
            command.AddOption(new Option<bool?>("--count", description: "Include count of items"));
            command.AddOption(new Option<object>("--orderby", description: "Order items by property values"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.AddOption(new Option<object>("--expand", description: "Expand related entities"));
            command.Handler = CommandHandler.Create<int?, int?, string, string, bool?, object, object, object>(async (top, skip, search, filter, count, orderby, select, expand) => {
                var requestInfo = CreateGetRequestInformation();
                requestInfo.QueryParameters.Add("top", top);
                requestInfo.QueryParameters.Add("skip", skip);
                if (!String.IsNullOrEmpty(search)) requestInfo.QueryParameters.Add("search", search);
                if (!String.IsNullOrEmpty(filter)) requestInfo.QueryParameters.Add("filter", filter);
                requestInfo.QueryParameters.Add("count", count);
                requestInfo.QueryParameters.Add("orderby", orderby);
                requestInfo.QueryParameters.Add("select", select);
                requestInfo.QueryParameters.Add("expand", expand);
                var result = await RequestAdapter.SendAsync<UsersResponse>(requestInfo);
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
        public Command BuildValidatePropertiesCommand() {
            var command = new Command("validate-properties");
            var builder = new ApiSdk.Users.ValidateProperties.ValidatePropertiesRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new UsersRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public UsersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users{?top,skip,search,filter,count,orderby,select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Get entities from users
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
        /// Add new entity to users
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(ApiSdk.Models.Microsoft.Graph.User body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// Builds and executes requests for operations under \users\microsoft.graph.delta()
        /// </summary>
        public DeltaRequestBuilder Delta() {
            return new DeltaRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Get entities from users
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<UsersResponse> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<UsersResponse>(requestInfo, responseHandler);
        }
        /// <summary>
        /// Add new entity to users
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<ApiSdk.Models.Microsoft.Graph.User> PostAsync(ApiSdk.Models.Microsoft.Graph.User model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePostRequestInformation(model, h, o);
            return await RequestAdapter.SendAsync<ApiSdk.Models.Microsoft.Graph.User>(requestInfo, responseHandler);
        }
        /// <summary>Get entities from users</summary>
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