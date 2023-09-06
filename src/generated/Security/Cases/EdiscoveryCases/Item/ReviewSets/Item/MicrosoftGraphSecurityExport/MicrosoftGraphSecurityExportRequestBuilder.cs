// <auto-generated/>
using ApiSdk.Models.ODataErrors;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Cli.Commons.Extensions;
using Microsoft.Kiota.Cli.Commons.IO;
using Microsoft.Kiota.Cli.Commons;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ApiSdk.Security.Cases.EdiscoveryCases.Item.ReviewSets.Item.MicrosoftGraphSecurityExport {
    /// <summary>
    /// Provides operations to call the export method.
    /// </summary>
    public class MicrosoftGraphSecurityExportRequestBuilder : BaseCliRequestBuilder {
        /// <summary>
        /// Initiate an export from a ediscoveryReviewSet. For details, see Export documents from a review set in eDiscovery (Premium).
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/security-ediscoveryreviewset-export?view=graph-rest-1.0" />
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            command.Description = "Initiate an export from a ediscoveryReviewSet. For details, see Export documents from a review set in eDiscovery (Premium).\n\nFind more info here:\n  https://learn.microsoft.com/graph/api/security-ediscoveryreviewset-export?view=graph-rest-1.0";
            var ediscoveryCaseIdOption = new Option<string>("--ediscovery-case-id", description: "The unique identifier of ediscoveryCase") {
            };
            ediscoveryCaseIdOption.IsRequired = true;
            command.AddOption(ediscoveryCaseIdOption);
            var ediscoveryReviewSetIdOption = new Option<string>("--ediscovery-review-set-id", description: "The unique identifier of ediscoveryReviewSet") {
            };
            ediscoveryReviewSetIdOption.IsRequired = true;
            command.AddOption(ediscoveryReviewSetIdOption);
            var bodyOption = new Option<string>("--body", description: "The request body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (invocationContext) => {
                var ediscoveryCaseId = invocationContext.ParseResult.GetValueForOption(ediscoveryCaseIdOption);
                var ediscoveryReviewSetId = invocationContext.ParseResult.GetValueForOption(ediscoveryReviewSetIdOption);
                var body = invocationContext.ParseResult.GetValueForOption(bodyOption) ?? string.Empty;
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ExportPostRequestBody>(ExportPostRequestBody.CreateFromDiscriminatorValue);
                if (model is null) return; // Cannot create a POST request from a null model.
                var requestInfo = ToPostRequestInformation(model, q => {
                });
                if (ediscoveryCaseId is not null) requestInfo.PathParameters.Add("ediscoveryCase%2Did", ediscoveryCaseId);
                if (ediscoveryReviewSetId is not null) requestInfo.PathParameters.Add("ediscoveryReviewSet%2Did", ediscoveryReviewSetId);
                requestInfo.SetContentFromParsable(reqAdapter, "application/json", model);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await reqAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new MicrosoftGraphSecurityExportRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        public MicrosoftGraphSecurityExportRequestBuilder(Dictionary<string, object> pathParameters) : base("{+baseurl}/security/cases/ediscoveryCases/{ediscoveryCase%2Did}/reviewSets/{ediscoveryReviewSet%2Did}/microsoft.graph.security.export", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new MicrosoftGraphSecurityExportRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public MicrosoftGraphSecurityExportRequestBuilder(string rawUrl) : base("{+baseurl}/security/cases/ediscoveryCases/{ediscoveryCase%2Did}/reviewSets/{ediscoveryReviewSet%2Did}/microsoft.graph.security.export", rawUrl) {
        }
        /// <summary>
        /// Initiate an export from a ediscoveryReviewSet. For details, see Export documents from a review set in eDiscovery (Premium).
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(ExportPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(ExportPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new RequestConfiguration<DefaultQueryParameters>();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
    }
}