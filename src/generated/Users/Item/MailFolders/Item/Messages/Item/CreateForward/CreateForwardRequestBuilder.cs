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
namespace ApiSdk.Users.Item.MailFolders.Item.Messages.Item.CreateForward {
    /// <summary>Builds and executes requests for operations under \users\{user-id}\mailFolders\{mailFolder-id}\messages\{message-id}\microsoft.graph.createForward</summary>
    public class CreateForwardRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke action createForward
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--user-id", description: "key: id of user"));
            command.AddOption(new Option<string>("--mailfolder-id", description: "key: id of mailFolder"));
            command.AddOption(new Option<string>("--message-id", description: "key: id of message"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string, string, string>(async (userId, mailFolderId, messageId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<CreateForwardRequestBody>();
                var requestInfo = CreatePostRequestInformation(model);
                if (!String.IsNullOrEmpty(userId)) requestInfo.PathParameters.Add("user_id", userId);
                if (!String.IsNullOrEmpty(mailFolderId)) requestInfo.PathParameters.Add("mailFolder_id", mailFolderId);
                if (!String.IsNullOrEmpty(messageId)) requestInfo.PathParameters.Add("message_id", messageId);
                var result = await RequestAdapter.SendAsync<CreateForwardResponse>(requestInfo);
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
        /// Instantiates a new CreateForwardRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public CreateForwardRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user_id}/mailFolders/{mailFolder_id}/messages/{message_id}/microsoft.graph.createForward";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke action createForward
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(CreateForwardRequestBody body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// Invoke action createForward
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<CreateForwardResponse> PostAsync(CreateForwardRequestBody model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePostRequestInformation(model, h, o);
            return await RequestAdapter.SendAsync<CreateForwardResponse>(requestInfo, responseHandler);
        }
        /// <summary>Union type wrapper for classes message</summary>
        public class CreateForwardResponse : IParsable {
            /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
            public IDictionary<string, object> AdditionalData { get; set; }
            /// <summary>Union type representation for type message</summary>
            public Message Message { get; set; }
            /// <summary>
            /// Instantiates a new createForwardResponse and sets the default values.
            /// </summary>
            public CreateForwardResponse() {
                AdditionalData = new Dictionary<string, object>();
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
                return new Dictionary<string, Action<T, IParseNode>> {
                    {"message", (o,n) => { (o as CreateForwardResponse).Message = n.GetObjectValue<Message>(); } },
                };
            }
            /// <summary>
            /// Serializes information the current object
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            /// </summary>
            public void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                writer.WriteObjectValue<Message>("message", Message);
                writer.WriteAdditionalData(AdditionalData);
            }
        }
    }
}