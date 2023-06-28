using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.Security {
    public class Host : Artifact, IParsable {
        /// <summary>The components property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<HostComponent>? Components { get; set; }
#nullable restore
#else
        public List<HostComponent> Components { get; set; }
#endif
        /// <summary>The cookies property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<HostCookie>? Cookies { get; set; }
#nullable restore
#else
        public List<HostCookie> Cookies { get; set; }
#endif
        /// <summary>The firstSeenDateTime property</summary>
        public DateTimeOffset? FirstSeenDateTime { get; set; }
        /// <summary>The lastSeenDateTime property</summary>
        public DateTimeOffset? LastSeenDateTime { get; set; }
        /// <summary>The passiveDns property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PassiveDnsRecord>? PassiveDns { get; set; }
#nullable restore
#else
        public List<PassiveDnsRecord> PassiveDns { get; set; }
#endif
        /// <summary>The passiveDnsReverse property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PassiveDnsRecord>? PassiveDnsReverse { get; set; }
#nullable restore
#else
        public List<PassiveDnsRecord> PassiveDnsReverse { get; set; }
#endif
        /// <summary>The reputation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public HostReputation? Reputation { get; set; }
#nullable restore
#else
        public HostReputation Reputation { get; set; }
#endif
        /// <summary>The trackers property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<HostTracker>? Trackers { get; set; }
#nullable restore
#else
        public List<HostTracker> Trackers { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Host and sets the default values.
        /// </summary>
        public Host() : base() {
            OdataType = "#microsoft.graph.security.host";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Host CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.security.hostname" => new Hostname(),
                "#microsoft.graph.security.ipAddress" => new IpAddress(),
                _ => new Host(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"components", n => { Components = n.GetCollectionOfObjectValues<HostComponent>(HostComponent.CreateFromDiscriminatorValue)?.ToList(); } },
                {"cookies", n => { Cookies = n.GetCollectionOfObjectValues<HostCookie>(HostCookie.CreateFromDiscriminatorValue)?.ToList(); } },
                {"firstSeenDateTime", n => { FirstSeenDateTime = n.GetDateTimeOffsetValue(); } },
                {"lastSeenDateTime", n => { LastSeenDateTime = n.GetDateTimeOffsetValue(); } },
                {"passiveDns", n => { PassiveDns = n.GetCollectionOfObjectValues<PassiveDnsRecord>(PassiveDnsRecord.CreateFromDiscriminatorValue)?.ToList(); } },
                {"passiveDnsReverse", n => { PassiveDnsReverse = n.GetCollectionOfObjectValues<PassiveDnsRecord>(PassiveDnsRecord.CreateFromDiscriminatorValue)?.ToList(); } },
                {"reputation", n => { Reputation = n.GetObjectValue<HostReputation>(HostReputation.CreateFromDiscriminatorValue); } },
                {"trackers", n => { Trackers = n.GetCollectionOfObjectValues<HostTracker>(HostTracker.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<HostComponent>("components", Components);
            writer.WriteCollectionOfObjectValues<HostCookie>("cookies", Cookies);
            writer.WriteDateTimeOffsetValue("firstSeenDateTime", FirstSeenDateTime);
            writer.WriteDateTimeOffsetValue("lastSeenDateTime", LastSeenDateTime);
            writer.WriteCollectionOfObjectValues<PassiveDnsRecord>("passiveDns", PassiveDns);
            writer.WriteCollectionOfObjectValues<PassiveDnsRecord>("passiveDnsReverse", PassiveDnsReverse);
            writer.WriteObjectValue<HostReputation>("reputation", Reputation);
            writer.WriteCollectionOfObjectValues<HostTracker>("trackers", Trackers);
        }
    }
}
