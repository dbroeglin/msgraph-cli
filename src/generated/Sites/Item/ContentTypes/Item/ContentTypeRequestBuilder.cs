using ApiSdk.Models.Microsoft.Graph;
using ApiSdk.Sites.Item.ContentTypes.Item.AssociateWithHubSites;
using ApiSdk.Sites.Item.ContentTypes.Item.Base;
using ApiSdk.Sites.Item.ContentTypes.Item.BaseTypes;
using ApiSdk.Sites.Item.ContentTypes.Item.ColumnLinks;
using ApiSdk.Sites.Item.ContentTypes.Item.ColumnPositions;
using ApiSdk.Sites.Item.ContentTypes.Item.Columns;
using ApiSdk.Sites.Item.ContentTypes.Item.CopyToDefaultContentLocation;
using ApiSdk.Sites.Item.ContentTypes.Item.IsPublished;
using ApiSdk.Sites.Item.ContentTypes.Item.Publish;
using ApiSdk.Sites.Item.ContentTypes.Item.Unpublish;
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
namespace ApiSdk.Sites.Item.ContentTypes.Item {
    /// <summary>Builds and executes requests for operations under \sites\{site-id}\contentTypes\{contentType-id}</summary>
    public class ContentTypeRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildAssociateWithHubSitesCommand() {
            var command = new Command("associate-with-hub-sites");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.AssociateWithHubSites.AssociateWithHubSitesRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildBaseCommand() {
            var command = new Command("base");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.@Base.BaseRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildUnpublishCommand());
            command.AddCommand(builder.BuildCopyToDefaultContentLocationCommand());
            command.AddCommand(builder.BuildAssociateWithHubSitesCommand());
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildRefCommand());
            command.AddCommand(builder.BuildPublishCommand());
            return command;
        }
        public Command BuildBaseTypesCommand() {
            var command = new Command("base-types");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.BaseTypes.BaseTypesRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildRefCommand());
            command.AddCommand(builder.BuildAddCopyCommand());
            return command;
        }
        public Command BuildColumnLinksCommand() {
            var command = new Command("column-links");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.ColumnLinks.ColumnLinksRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildListCommand());
            command.AddCommand(builder.BuildCreateCommand());
            foreach (var cmd in builder.BuildCommand()) {
                command.AddCommand(cmd);
            }
            return command;
        }
        public Command BuildColumnPositionsCommand() {
            var command = new Command("column-positions");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.ColumnPositions.ColumnPositionsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildRefCommand());
            return command;
        }
        public Command BuildColumnsCommand() {
            var command = new Command("columns");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.Columns.ColumnsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildListCommand());
            command.AddCommand(builder.BuildCreateCommand());
            foreach (var cmd in builder.BuildCommand()) {
                command.AddCommand(cmd);
            }
            return command;
        }
        public Command BuildCopyToDefaultContentLocationCommand() {
            var command = new Command("copy-to-default-content-location");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.CopyToDefaultContentLocation.CopyToDefaultContentLocationRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// The collection of content types defined for this site.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--site-id", description: "key: id of site"));
            command.AddOption(new Option<string>("--contenttype-id", description: "key: id of contentType"));
            command.Handler = CommandHandler.Create<string, string>(async (siteId, contentTypeId) => {
                var requestInfo = CreateDeleteRequestInformation();
                if (!String.IsNullOrEmpty(siteId)) requestInfo.PathParameters.Add("site_id", siteId);
                if (!String.IsNullOrEmpty(contentTypeId)) requestInfo.PathParameters.Add("contentType_id", contentTypeId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// The collection of content types defined for this site.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--site-id", description: "key: id of site"));
            command.AddOption(new Option<string>("--contenttype-id", description: "key: id of contentType"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.AddOption(new Option<object>("--expand", description: "Expand related entities"));
            command.Handler = CommandHandler.Create<string, string, object, object>(async (siteId, contentTypeId, select, expand) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(siteId)) requestInfo.PathParameters.Add("site_id", siteId);
                if (!String.IsNullOrEmpty(contentTypeId)) requestInfo.PathParameters.Add("contentType_id", contentTypeId);
                requestInfo.QueryParameters.Add("select", select);
                requestInfo.QueryParameters.Add("expand", expand);
                var result = await RequestAdapter.SendAsync<ContentType>(requestInfo);
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
        /// The collection of content types defined for this site.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--site-id", description: "key: id of site"));
            command.AddOption(new Option<string>("--contenttype-id", description: "key: id of contentType"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string, string>(async (siteId, contentTypeId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ContentType>();
                var requestInfo = CreatePatchRequestInformation(model);
                if (!String.IsNullOrEmpty(siteId)) requestInfo.PathParameters.Add("site_id", siteId);
                if (!String.IsNullOrEmpty(contentTypeId)) requestInfo.PathParameters.Add("contentType_id", contentTypeId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        public Command BuildPublishCommand() {
            var command = new Command("publish");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.Publish.PublishRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildUnpublishCommand() {
            var command = new Command("unpublish");
            var builder = new ApiSdk.Sites.Item.ContentTypes.Item.Unpublish.UnpublishRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new ContentTypeRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ContentTypeRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/sites/{site_id}/contentTypes/{contentType_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The collection of content types defined for this site.
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
        /// The collection of content types defined for this site.
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
        /// The collection of content types defined for this site.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(ContentType body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// The collection of content types defined for this site.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateDeleteRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>
        /// The collection of content types defined for this site.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<ContentType> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<ContentType>(requestInfo, responseHandler);
        }
        /// <summary>
        /// Builds and executes requests for operations under \sites\{site-id}\contentTypes\{contentType-id}\microsoft.graph.isPublished()
        /// </summary>
        public IsPublishedRequestBuilder IsPublished() {
            return new IsPublishedRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// The collection of content types defined for this site.
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(ContentType model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePatchRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler);
        }
        /// <summary>The collection of content types defined for this site.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}