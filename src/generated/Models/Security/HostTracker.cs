using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.Security {
    public class HostTracker : Artifact, IParsable {
        /// <summary>The firstSeenDateTime property</summary>
        public DateTimeOffset? FirstSeenDateTime { get; set; }
        /// <summary>The host property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ApiSdk.Models.Security.Host? Host { get; set; }
#nullable restore
#else
        public ApiSdk.Models.Security.Host Host { get; set; }
#endif
        /// <summary>The kind property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Kind { get; set; }
#nullable restore
#else
        public string Kind { get; set; }
#endif
        /// <summary>The lastSeenDateTime property</summary>
        public DateTimeOffset? LastSeenDateTime { get; set; }
        /// <summary>The value property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Value { get; set; }
#nullable restore
#else
        public string Value { get; set; }
#endif
        /// <summary>
        /// Instantiates a new hostTracker and sets the default values.
        /// </summary>
        public HostTracker() : base() {
            OdataType = "#microsoft.graph.security.hostTracker";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new HostTracker CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new HostTracker();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"firstSeenDateTime", n => { FirstSeenDateTime = n.GetDateTimeOffsetValue(); } },
                {"host", n => { Host = n.GetObjectValue<ApiSdk.Models.Security.Host>(ApiSdk.Models.Security.Host.CreateFromDiscriminatorValue); } },
                {"kind", n => { Kind = n.GetStringValue(); } },
                {"lastSeenDateTime", n => { LastSeenDateTime = n.GetDateTimeOffsetValue(); } },
                {"value", n => { Value = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("firstSeenDateTime", FirstSeenDateTime);
            writer.WriteObjectValue<ApiSdk.Models.Security.Host>("host", Host);
            writer.WriteStringValue("kind", Kind);
            writer.WriteDateTimeOffsetValue("lastSeenDateTime", LastSeenDateTime);
            writer.WriteStringValue("value", Value);
        }
    }
}
