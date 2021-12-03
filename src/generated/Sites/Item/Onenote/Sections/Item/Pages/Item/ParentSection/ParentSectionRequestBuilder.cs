using ApiSdk.Models.Microsoft.Graph;
using ApiSdk.Sites.Item.Onenote.Sections.Item.Pages.Item.ParentSection.CopyToNotebook;
using ApiSdk.Sites.Item.Onenote.Sections.Item.Pages.Item.ParentSection.CopyToSectionGroup;
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
namespace ApiSdk.Sites.Item.Onenote.Sections.Item.Pages.Item.ParentSection {
    /// <summary>Builds and executes requests for operations under \sites\{site-id}\onenote\sections\{onenoteSection-id}\pages\{onenotePage-id}\parentSection</summary>
    public class ParentSectionRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildCopyToNotebookCommand() {
            var command = new Command("copy-to-notebook");
            var builder = new ApiSdk.Sites.Item.Onenote.Sections.Item.Pages.Item.ParentSection.CopyToNotebook.CopyToNotebookRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildCopyToSectionGroupCommand() {
            var command = new Command("copy-to-section-group");
            var builder = new ApiSdk.Sites.Item.Onenote.Sections.Item.Pages.Item.ParentSection.CopyToSectionGroup.CopyToSectionGroupRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// The section that contains the page. Read-only.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--site-id", description: "key: id of site"));
            command.AddOption(new Option<string>("--onenotesection-id", description: "key: id of onenoteSection"));
            command.AddOption(new Option<string>("--onenotepage-id", description: "key: id of onenotePage"));
            command.Handler = CommandHandler.Create<string, string, string>(async (siteId, onenoteSectionId, onenotePageId) => {
                var requestInfo = CreateDeleteRequestInformation();
                if (!String.IsNullOrEmpty(siteId)) requestInfo.PathParameters.Add("site_id", siteId);
                if (!String.IsNullOrEmpty(onenoteSectionId)) requestInfo.PathParameters.Add("onenoteSection_id", onenoteSectionId);
                if (!String.IsNullOrEmpty(onenotePageId)) requestInfo.PathParameters.Add("onenotePage_id", onenotePageId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// The section that contains the page. Read-only.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--site-id", description: "key: id of site"));
            command.AddOption(new Option<string>("--onenotesection-id", description: "key: id of onenoteSection"));
            command.AddOption(new Option<string>("--onenotepage-id", description: "key: id of onenotePage"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.AddOption(new Option<object>("--expand", description: "Expand related entities"));
            command.Handler = CommandHandler.Create<string, string, string, object, object>(async (siteId, onenoteSectionId, onenotePageId, select, expand) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(siteId)) requestInfo.PathParameters.Add("site_id", siteId);
                if (!String.IsNullOrEmpty(onenoteSectionId)) requestInfo.PathParameters.Add("onenoteSection_id", onenoteSectionId);
                if (!String.IsNullOrEmpty(onenotePageId)) requestInfo.PathParameters.Add("onenotePage_id", onenotePageId);
                requestInfo.QueryParameters.Add("select", select);
                requestInfo.QueryParameters.Add("expand", expand);
                var result = await RequestAdapter.SendAsync<OnenoteSection>(requestInfo);
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
        /// The section that contains the page. Read-only.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--site-id", description: "key: id of site"));
            command.AddOption(new Option<string>("--onenotesection-id", description: "key: id of onenoteSection"));
            command.AddOption(new Option<string>("--onenotepage-id", description: "key: id of onenotePage"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string, string, string>(async (siteId, onenoteSectionId, onenotePageId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<OnenoteSection>();
                var requestInfo = CreatePatchRequestInformation(model);
                if (!String.IsNullOrEmpty(siteId)) requestInfo.PathParameters.Add("site_id", siteId);
                if (!String.IsNullOrEmpty(onenoteSectionId)) requestInfo.PathParameters.Add("onenoteSection_id", onenoteSectionId);
                if (!String.IsNullOrEmpty(onenotePageId)) requestInfo.PathParameters.Add("onenotePage_id", onenotePageId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new ParentSectionRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ParentSectionRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/sites/{site_id}/onenote/sections/{onenoteSection_id}/pages/{onenotePage_id}/parentSection{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The section that contains the page. Read-only.
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
        /// The section that contains the page. Read-only.
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
        /// The section that contains the page. Read-only.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(OnenoteSection body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// The section that contains the page. Read-only.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateDeleteRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>
        /// The section that contains the page. Read-only.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<OnenoteSection> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<OnenoteSection>(requestInfo, responseHandler);
        }
        /// <summary>
        /// The section that contains the page. Read-only.
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(OnenoteSection model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePatchRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>The section that contains the page. Read-only.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}