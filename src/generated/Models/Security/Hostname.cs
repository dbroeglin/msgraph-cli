using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.Security {
    public class Hostname : Host, IParsable {
        /// <summary>The registrant property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Registrant { get; set; }
#nullable restore
#else
        public string Registrant { get; set; }
#endif
        /// <summary>The registrar property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Registrar { get; set; }
#nullable restore
#else
        public string Registrar { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Hostname and sets the default values.
        /// </summary>
        public Hostname() : base() {
            OdataType = "#microsoft.graph.security.hostname";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Hostname CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Hostname();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"registrant", n => { Registrant = n.GetStringValue(); } },
                {"registrar", n => { Registrar = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("registrant", Registrant);
            writer.WriteStringValue("registrar", Registrar);
        }
    }
}
