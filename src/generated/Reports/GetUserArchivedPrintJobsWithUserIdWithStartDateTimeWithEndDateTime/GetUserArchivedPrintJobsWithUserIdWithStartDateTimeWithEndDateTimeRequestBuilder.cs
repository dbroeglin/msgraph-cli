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
namespace ApiSdk.Reports.GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTime {
    /// <summary>Builds and executes requests for operations under \reports\microsoft.graph.getUserArchivedPrintJobs(userId='{userId}',startDateTime={startDateTime},endDateTime={endDateTime})</summary>
    public class GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTimeRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke function getUserArchivedPrintJobs
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--userid", description: "Usage: userId={userId}"));
            command.AddOption(new Option<DateTimeOffset?>("--startdatetime", description: "Usage: startDateTime={startDateTime}"));
            command.AddOption(new Option<DateTimeOffset?>("--enddatetime", description: "Usage: endDateTime={endDateTime}"));
            command.Handler = CommandHandler.Create<string, DateTimeOffset?, DateTimeOffset?>(async (userId, startDateTime, endDateTime) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(userId)) requestInfo.PathParameters.Add("userId", userId);
                requestInfo.PathParameters.Add("startDateTime", startDateTime);
                requestInfo.PathParameters.Add("endDateTime", endDateTime);
                var result = await RequestAdapter.SendCollectionAsync<ApiSdk.Reports.GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTime.GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTime>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteCollectionOfObjectValues(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTimeRequestBuilder and sets the default values.
        /// <param name="endDateTime">Usage: endDateTime={endDateTime}</param>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// <param name="startDateTime">Usage: startDateTime={startDateTime}</param>
        /// <param name="userId">Usage: userId={userId}</param>
        /// </summary>
        public GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTimeRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter, string userId = default, DateTimeOffset? startDateTime = default, DateTimeOffset? endDateTime = default) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/reports/microsoft.graph.getUserArchivedPrintJobs(userId='{userId}',startDateTime={startDateTime},endDateTime={endDateTime})";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            urlTplParams.Add("userId", userId);
            urlTplParams.Add("startDateTime", startDateTime);
            urlTplParams.Add("endDateTime", endDateTime);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke function getUserArchivedPrintJobs
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Invoke function getUserArchivedPrintJobs
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<IEnumerable<ApiSdk.Reports.GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTime.GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTime>> GetAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateGetRequestInformation(h, o);
            return await RequestAdapter.SendCollectionAsync<ApiSdk.Reports.GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTime.GetUserArchivedPrintJobsWithUserIdWithStartDateTimeWithEndDateTime>(requestInfo, responseHandler);
        }
    }
}