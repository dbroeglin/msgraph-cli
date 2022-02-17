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
namespace ApiSdk.Users.Item.Insights.Trending.Item.Resource.WorkbookRange.OffsetRangeWithRowOffsetWithColumnOffset {
    /// <summary>Builds and executes requests for operations under \users\{user-id}\insights\trending\{trendingItem-Id}\resource\microsoft.graph.workbookRange\microsoft.graph.offsetRange(rowOffset={rowOffset},columnOffset={columnOffset})</summary>
    public class OffsetRangeWithRowOffsetWithColumnOffsetRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke function offsetRange
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Invoke function offsetRange";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var trendingItemIdOption = new Option<string>("--trending-item-id", description: "key: id of trending") {
            };
            trendingItemIdOption.IsRequired = true;
            command.AddOption(trendingItemIdOption);
            var rowOffsetOption = new Option<int?>("--row-offset", description: "Usage: rowOffset={rowOffset}") {
            };
            rowOffsetOption.IsRequired = true;
            command.AddOption(rowOffsetOption);
            var columnOffsetOption = new Option<int?>("--column-offset", description: "Usage: columnOffset={columnOffset}") {
            };
            columnOffsetOption.IsRequired = true;
            command.AddOption(columnOffsetOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            command.SetHandler(async (string userId, string trendingItemId, int? rowOffset, int? columnOffset, FormatterType output, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                var requestInfo = CreateGetRequestInformation(q => {
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                formatter.WriteOutput(response);
            }, userIdOption, trendingItemIdOption, rowOffsetOption, columnOffsetOption, outputOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new OffsetRangeWithRowOffsetWithColumnOffsetRequestBuilder and sets the default values.
        /// <param name="columnOffset">Usage: columnOffset={columnOffset}</param>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// <param name="rowOffset">Usage: rowOffset={rowOffset}</param>
        /// </summary>
        public OffsetRangeWithRowOffsetWithColumnOffsetRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter, int? rowOffset = default, int? columnOffset = default) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user_id}/insights/trending/{trendingItem_Id}/resource/microsoft.graph.workbookRange/microsoft.graph.offsetRange(rowOffset={rowOffset},columnOffset={columnOffset})";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            urlTplParams.Add("rowOffset", rowOffset);
            urlTplParams.Add("columnOffset", columnOffset);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke function offsetRange
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
        /// <summary>Union type wrapper for classes workbookRange</summary>
        public class OffsetRangeWithRowOffsetWithColumnOffsetResponse : IParsable {
            /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
            public IDictionary<string, object> AdditionalData { get; set; }
            /// <summary>Union type representation for type workbookRange</summary>
            public ApiSdk.Models.Microsoft.Graph.WorkbookRange WorkbookRange { get; set; }
            /// <summary>
            /// Instantiates a new offsetRangeWithRowOffsetWithColumnOffsetResponse and sets the default values.
            /// </summary>
            public OffsetRangeWithRowOffsetWithColumnOffsetResponse() {
                AdditionalData = new Dictionary<string, object>();
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
                return new Dictionary<string, Action<T, IParseNode>> {
                    {"workbookRange", (o,n) => { (o as OffsetRangeWithRowOffsetWithColumnOffsetResponse).WorkbookRange = n.GetObjectValue<ApiSdk.Models.Microsoft.Graph.WorkbookRange>(); } },
                };
            }
            /// <summary>
            /// Serializes information the current object
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            /// </summary>
            public void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                writer.WriteObjectValue<ApiSdk.Models.Microsoft.Graph.WorkbookRange>("workbookRange", WorkbookRange);
                writer.WriteAdditionalData(AdditionalData);
            }
        }
    }
}
