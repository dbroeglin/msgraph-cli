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
namespace ApiSdk.Shares.Item.ListItem.DriveItem.Content {
    /// <summary>Builds and executes requests for operations under \shares\{sharedDriveItem-id}\listItem\driveItem\content</summary>
    public class ContentRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Get media content for the navigation property driveItem from shares
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Get media content for the navigation property driveItem from shares";
            // Create options for all the parameters
            var sharedDriveItemIdOption = new Option<string>("--shared-drive-item-id", description: "key: id of sharedDriveItem") {
            };
            sharedDriveItemIdOption.IsRequired = true;
            command.AddOption(sharedDriveItemIdOption);
            var fileOption = new Option<FileInfo>("--file");
            command.AddOption(fileOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            command.SetHandler(async (string sharedDriveItemId, FileInfo file, FormatterType output, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                var requestInfo = CreateGetRequestInformation(q => {
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                if (file == null) {
                    formatter.WriteOutput(response);
                }
                else {
                    using var writeStream = file.OpenWrite();
                    await response.CopyToAsync(writeStream);
                    Console.WriteLine($"Content written to {file.FullName}.");
                }
            }, sharedDriveItemIdOption, fileOption, outputOption);
            return command;
        }
        /// <summary>
        /// Update media content for the navigation property driveItem in shares
        /// </summary>
        public Command BuildPutCommand() {
            var command = new Command("put");
            command.Description = "Update media content for the navigation property driveItem in shares";
            // Create options for all the parameters
            var sharedDriveItemIdOption = new Option<string>("--shared-drive-item-id", description: "key: id of sharedDriveItem") {
            };
            sharedDriveItemIdOption.IsRequired = true;
            command.AddOption(sharedDriveItemIdOption);
            var bodyOption = new Option<Stream>("--file", description: "Binary request body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (string sharedDriveItemId, FileInfo file, IOutputFormatterFactory outputFormatterFactory, CancellationToken cancellationToken) => {
                using var stream = file.OpenRead();
                var requestInfo = CreatePutRequestInformation(stream, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, sharedDriveItemIdOption, bodyOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new ContentRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ContentRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/shares/{sharedDriveItem_id}/listItem/driveItem/content";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Get media content for the navigation property driveItem from shares
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
        /// Update media content for the navigation property driveItem in shares
        /// <param name="body">Binary request body</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePutRequestInformation(Stream body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PUT,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetStreamContent(body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
    }
}
