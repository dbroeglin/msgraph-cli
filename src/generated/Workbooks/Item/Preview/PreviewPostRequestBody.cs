using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Workbooks.Item.Preview {
    /// <summary>Provides operations to call the preview method.</summary>
    public class PreviewPostRequestBody : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The page property</summary>
        public string Page { get; set; }
        /// <summary>The zoom property</summary>
        public double? Zoom { get; set; }
        /// <summary>
        /// Instantiates a new previewPostRequestBody and sets the default values.
        /// </summary>
        public PreviewPostRequestBody() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static PreviewPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PreviewPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"page", n => { Page = n.GetStringValue(); } },
                {"zoom", n => { Zoom = n.GetDoubleValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("page", Page);
            writer.WriteDoubleValue("zoom", Zoom);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
