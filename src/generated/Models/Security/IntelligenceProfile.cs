using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.Security {
    public class IntelligenceProfile : Entity, IParsable {
        /// <summary>The aliases property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Aliases { get; set; }
#nullable restore
#else
        public List<string> Aliases { get; set; }
#endif
        /// <summary>The countriesOrRegionsOfOrigin property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<IntelligenceProfileCountryOrRegionOfOrigin>? CountriesOrRegionsOfOrigin { get; set; }
#nullable restore
#else
        public List<IntelligenceProfileCountryOrRegionOfOrigin> CountriesOrRegionsOfOrigin { get; set; }
#endif
        /// <summary>The description property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public FormattedContent? Description { get; set; }
#nullable restore
#else
        public FormattedContent Description { get; set; }
#endif
        /// <summary>The firstActiveDateTime property</summary>
        public DateTimeOffset? FirstActiveDateTime { get; set; }
        /// <summary>The indicators property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<IntelligenceProfileIndicator>? Indicators { get; set; }
#nullable restore
#else
        public List<IntelligenceProfileIndicator> Indicators { get; set; }
#endif
        /// <summary>The kind property</summary>
        public IntelligenceProfileKind? Kind { get; set; }
        /// <summary>The summary property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public FormattedContent? Summary { get; set; }
#nullable restore
#else
        public FormattedContent Summary { get; set; }
#endif
        /// <summary>The targets property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Targets { get; set; }
#nullable restore
#else
        public List<string> Targets { get; set; }
#endif
        /// <summary>The title property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Title { get; set; }
#nullable restore
#else
        public string Title { get; set; }
#endif
        /// <summary>The tradecraft property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public FormattedContent? Tradecraft { get; set; }
#nullable restore
#else
        public FormattedContent Tradecraft { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new IntelligenceProfile CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IntelligenceProfile();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"aliases", n => { Aliases = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"countriesOrRegionsOfOrigin", n => { CountriesOrRegionsOfOrigin = n.GetCollectionOfObjectValues<IntelligenceProfileCountryOrRegionOfOrigin>(IntelligenceProfileCountryOrRegionOfOrigin.CreateFromDiscriminatorValue)?.ToList(); } },
                {"description", n => { Description = n.GetObjectValue<FormattedContent>(FormattedContent.CreateFromDiscriminatorValue); } },
                {"firstActiveDateTime", n => { FirstActiveDateTime = n.GetDateTimeOffsetValue(); } },
                {"indicators", n => { Indicators = n.GetCollectionOfObjectValues<IntelligenceProfileIndicator>(IntelligenceProfileIndicator.CreateFromDiscriminatorValue)?.ToList(); } },
                {"kind", n => { Kind = n.GetEnumValue<IntelligenceProfileKind>(); } },
                {"summary", n => { Summary = n.GetObjectValue<FormattedContent>(FormattedContent.CreateFromDiscriminatorValue); } },
                {"targets", n => { Targets = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"title", n => { Title = n.GetStringValue(); } },
                {"tradecraft", n => { Tradecraft = n.GetObjectValue<FormattedContent>(FormattedContent.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfPrimitiveValues<string>("aliases", Aliases);
            writer.WriteCollectionOfObjectValues<IntelligenceProfileCountryOrRegionOfOrigin>("countriesOrRegionsOfOrigin", CountriesOrRegionsOfOrigin);
            writer.WriteObjectValue<FormattedContent>("description", Description);
            writer.WriteDateTimeOffsetValue("firstActiveDateTime", FirstActiveDateTime);
            writer.WriteCollectionOfObjectValues<IntelligenceProfileIndicator>("indicators", Indicators);
            writer.WriteEnumValue<IntelligenceProfileKind>("kind", Kind);
            writer.WriteObjectValue<FormattedContent>("summary", Summary);
            writer.WriteCollectionOfPrimitiveValues<string>("targets", Targets);
            writer.WriteStringValue("title", Title);
            writer.WriteObjectValue<FormattedContent>("tradecraft", Tradecraft);
        }
    }
}
