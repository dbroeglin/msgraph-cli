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
namespace ApiSdk.Education.Classes.Item.Assignments.Item.Submissions.Item.Resources.Item {
    /// <summary>Builds and executes requests for operations under \education\classes\{educationClass-id}\assignments\{educationAssignment-id}\submissions\{educationSubmission-id}\resources\{educationSubmissionResource-id}</summary>
    public class EducationSubmissionResourceRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Nullable.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--educationclass-id", description: "key: id of educationClass"));
            command.AddOption(new Option<string>("--educationassignment-id", description: "key: id of educationAssignment"));
            command.AddOption(new Option<string>("--educationsubmission-id", description: "key: id of educationSubmission"));
            command.AddOption(new Option<string>("--educationsubmissionresource-id", description: "key: id of educationSubmissionResource"));
            command.Handler = CommandHandler.Create<string, string, string, string>(async (educationClassId, educationAssignmentId, educationSubmissionId, educationSubmissionResourceId) => {
                var requestInfo = CreateDeleteRequestInformation();
                if (!String.IsNullOrEmpty(educationClassId)) requestInfo.PathParameters.Add("educationClass_id", educationClassId);
                if (!String.IsNullOrEmpty(educationAssignmentId)) requestInfo.PathParameters.Add("educationAssignment_id", educationAssignmentId);
                if (!String.IsNullOrEmpty(educationSubmissionId)) requestInfo.PathParameters.Add("educationSubmission_id", educationSubmissionId);
                if (!String.IsNullOrEmpty(educationSubmissionResourceId)) requestInfo.PathParameters.Add("educationSubmissionResource_id", educationSubmissionResourceId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Nullable.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--educationclass-id", description: "key: id of educationClass"));
            command.AddOption(new Option<string>("--educationassignment-id", description: "key: id of educationAssignment"));
            command.AddOption(new Option<string>("--educationsubmission-id", description: "key: id of educationSubmission"));
            command.AddOption(new Option<string>("--educationsubmissionresource-id", description: "key: id of educationSubmissionResource"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.AddOption(new Option<object>("--expand", description: "Expand related entities"));
            command.Handler = CommandHandler.Create<string, string, string, string, object, object>(async (educationClassId, educationAssignmentId, educationSubmissionId, educationSubmissionResourceId, select, expand) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(educationClassId)) requestInfo.PathParameters.Add("educationClass_id", educationClassId);
                if (!String.IsNullOrEmpty(educationAssignmentId)) requestInfo.PathParameters.Add("educationAssignment_id", educationAssignmentId);
                if (!String.IsNullOrEmpty(educationSubmissionId)) requestInfo.PathParameters.Add("educationSubmission_id", educationSubmissionId);
                if (!String.IsNullOrEmpty(educationSubmissionResourceId)) requestInfo.PathParameters.Add("educationSubmissionResource_id", educationSubmissionResourceId);
                requestInfo.QueryParameters.Add("select", select);
                requestInfo.QueryParameters.Add("expand", expand);
                var result = await RequestAdapter.SendAsync<EducationSubmissionResource>(requestInfo);
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
        /// Nullable.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--educationclass-id", description: "key: id of educationClass"));
            command.AddOption(new Option<string>("--educationassignment-id", description: "key: id of educationAssignment"));
            command.AddOption(new Option<string>("--educationsubmission-id", description: "key: id of educationSubmission"));
            command.AddOption(new Option<string>("--educationsubmissionresource-id", description: "key: id of educationSubmissionResource"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string, string, string, string>(async (educationClassId, educationAssignmentId, educationSubmissionId, educationSubmissionResourceId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<EducationSubmissionResource>();
                var requestInfo = CreatePatchRequestInformation(model);
                if (!String.IsNullOrEmpty(educationClassId)) requestInfo.PathParameters.Add("educationClass_id", educationClassId);
                if (!String.IsNullOrEmpty(educationAssignmentId)) requestInfo.PathParameters.Add("educationAssignment_id", educationAssignmentId);
                if (!String.IsNullOrEmpty(educationSubmissionId)) requestInfo.PathParameters.Add("educationSubmission_id", educationSubmissionId);
                if (!String.IsNullOrEmpty(educationSubmissionResourceId)) requestInfo.PathParameters.Add("educationSubmissionResource_id", educationSubmissionResourceId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new EducationSubmissionResourceRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public EducationSubmissionResourceRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/education/classes/{educationClass_id}/assignments/{educationAssignment_id}/submissions/{educationSubmission_id}/resources/{educationSubmissionResource_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Nullable.
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
        /// Nullable.
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
        /// Nullable.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(EducationSubmissionResource body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// Nullable.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateDeleteRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>
        /// Nullable.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<EducationSubmissionResource> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<EducationSubmissionResource>(requestInfo, responseHandler);
        }
        /// <summary>
        /// Nullable.
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(EducationSubmissionResource model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePatchRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>Nullable.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}