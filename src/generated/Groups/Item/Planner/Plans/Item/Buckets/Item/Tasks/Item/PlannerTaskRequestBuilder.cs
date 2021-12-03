using ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item.AssignedToTaskBoardFormat;
using ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item.BucketTaskBoardFormat;
using ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item.Details;
using ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item.ProgressTaskBoardFormat;
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
namespace ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item {
    /// <summary>Builds and executes requests for operations under \groups\{group-id}\planner\plans\{plannerPlan-id}\buckets\{plannerBucket-id}\tasks\{plannerTask-id}</summary>
    public class PlannerTaskRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildAssignedToTaskBoardFormatCommand() {
            var command = new Command("assigned-to-task-board-format");
            var builder = new ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item.AssignedToTaskBoardFormat.AssignedToTaskBoardFormatRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPatchCommand());
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildDeleteCommand());
            return command;
        }
        public Command BuildBucketTaskBoardFormatCommand() {
            var command = new Command("bucket-task-board-format");
            var builder = new ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item.BucketTaskBoardFormat.BucketTaskBoardFormatRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPatchCommand());
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildDeleteCommand());
            return command;
        }
        /// <summary>
        /// Read-only. Nullable. The collection of tasks in the bucket.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--group-id", description: "key: id of group"));
            command.AddOption(new Option<string>("--plannerplan-id", description: "key: id of plannerPlan"));
            command.AddOption(new Option<string>("--plannerbucket-id", description: "key: id of plannerBucket"));
            command.AddOption(new Option<string>("--plannertask-id", description: "key: id of plannerTask"));
            command.Handler = CommandHandler.Create<string, string, string, string>(async (groupId, plannerPlanId, plannerBucketId, plannerTaskId) => {
                var requestInfo = CreateDeleteRequestInformation();
                if (!String.IsNullOrEmpty(groupId)) requestInfo.PathParameters.Add("group_id", groupId);
                if (!String.IsNullOrEmpty(plannerPlanId)) requestInfo.PathParameters.Add("plannerPlan_id", plannerPlanId);
                if (!String.IsNullOrEmpty(plannerBucketId)) requestInfo.PathParameters.Add("plannerBucket_id", plannerBucketId);
                if (!String.IsNullOrEmpty(plannerTaskId)) requestInfo.PathParameters.Add("plannerTask_id", plannerTaskId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        public Command BuildDetailsCommand() {
            var command = new Command("details");
            var builder = new ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item.Details.DetailsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPatchCommand());
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildDeleteCommand());
            return command;
        }
        /// <summary>
        /// Read-only. Nullable. The collection of tasks in the bucket.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--group-id", description: "key: id of group"));
            command.AddOption(new Option<string>("--plannerplan-id", description: "key: id of plannerPlan"));
            command.AddOption(new Option<string>("--plannerbucket-id", description: "key: id of plannerBucket"));
            command.AddOption(new Option<string>("--plannertask-id", description: "key: id of plannerTask"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.AddOption(new Option<object>("--expand", description: "Expand related entities"));
            command.Handler = CommandHandler.Create<string, string, string, string, object, object>(async (groupId, plannerPlanId, plannerBucketId, plannerTaskId, select, expand) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(groupId)) requestInfo.PathParameters.Add("group_id", groupId);
                if (!String.IsNullOrEmpty(plannerPlanId)) requestInfo.PathParameters.Add("plannerPlan_id", plannerPlanId);
                if (!String.IsNullOrEmpty(plannerBucketId)) requestInfo.PathParameters.Add("plannerBucket_id", plannerBucketId);
                if (!String.IsNullOrEmpty(plannerTaskId)) requestInfo.PathParameters.Add("plannerTask_id", plannerTaskId);
                requestInfo.QueryParameters.Add("select", select);
                requestInfo.QueryParameters.Add("expand", expand);
                var result = await RequestAdapter.SendAsync<PlannerTask>(requestInfo);
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
        /// Read-only. Nullable. The collection of tasks in the bucket.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--group-id", description: "key: id of group"));
            command.AddOption(new Option<string>("--plannerplan-id", description: "key: id of plannerPlan"));
            command.AddOption(new Option<string>("--plannerbucket-id", description: "key: id of plannerBucket"));
            command.AddOption(new Option<string>("--plannertask-id", description: "key: id of plannerTask"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string, string, string, string>(async (groupId, plannerPlanId, plannerBucketId, plannerTaskId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<PlannerTask>();
                var requestInfo = CreatePatchRequestInformation(model);
                if (!String.IsNullOrEmpty(groupId)) requestInfo.PathParameters.Add("group_id", groupId);
                if (!String.IsNullOrEmpty(plannerPlanId)) requestInfo.PathParameters.Add("plannerPlan_id", plannerPlanId);
                if (!String.IsNullOrEmpty(plannerBucketId)) requestInfo.PathParameters.Add("plannerBucket_id", plannerBucketId);
                if (!String.IsNullOrEmpty(plannerTaskId)) requestInfo.PathParameters.Add("plannerTask_id", plannerTaskId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        public Command BuildProgressTaskBoardFormatCommand() {
            var command = new Command("progress-task-board-format");
            var builder = new ApiSdk.Groups.Item.Planner.Plans.Item.Buckets.Item.Tasks.Item.ProgressTaskBoardFormat.ProgressTaskBoardFormatRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPatchCommand());
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildDeleteCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new PlannerTaskRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public PlannerTaskRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/groups/{group_id}/planner/plans/{plannerPlan_id}/buckets/{plannerBucket_id}/tasks/{plannerTask_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Read-only. Nullable. The collection of tasks in the bucket.
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
        /// Read-only. Nullable. The collection of tasks in the bucket.
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
        /// Read-only. Nullable. The collection of tasks in the bucket.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(PlannerTask body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// Read-only. Nullable. The collection of tasks in the bucket.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateDeleteRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>
        /// Read-only. Nullable. The collection of tasks in the bucket.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<PlannerTask> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<PlannerTask>(requestInfo, responseHandler);
        }
        /// <summary>
        /// Read-only. Nullable. The collection of tasks in the bucket.
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(PlannerTask model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePatchRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>Read-only. Nullable. The collection of tasks in the bucket.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}