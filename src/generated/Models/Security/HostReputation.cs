using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.Security {
    public class HostReputation : Entity, IParsable {
        /// <summary>The classification property</summary>
        public HostReputationClassification? Classification { get; set; }
        /// <summary>The rules property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<HostReputationRule>? Rules { get; set; }
#nullable restore
#else
        public List<HostReputationRule> Rules { get; set; }
#endif
        /// <summary>The score property</summary>
        public int? Score { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new HostReputation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new HostReputation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"classification", n => { Classification = n.GetEnumValue<HostReputationClassification>(); } },
                {"rules", n => { Rules = n.GetCollectionOfObjectValues<HostReputationRule>(HostReputationRule.CreateFromDiscriminatorValue)?.ToList(); } },
                {"score", n => { Score = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<HostReputationClassification>("classification", Classification);
            writer.WriteCollectionOfObjectValues<HostReputationRule>("rules", Rules);
            writer.WriteIntValue("score", Score);
        }
    }
}
