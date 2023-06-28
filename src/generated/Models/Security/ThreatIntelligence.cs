using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.Security {
    public class ThreatIntelligence : Entity, IParsable {
        /// <summary>The articleIndicators property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ArticleIndicator>? ArticleIndicators { get; set; }
#nullable restore
#else
        public List<ArticleIndicator> ArticleIndicators { get; set; }
#endif
        /// <summary>The articles property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Article>? Articles { get; set; }
#nullable restore
#else
        public List<Article> Articles { get; set; }
#endif
        /// <summary>The hostComponents property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<HostComponent>? HostComponents { get; set; }
#nullable restore
#else
        public List<HostComponent> HostComponents { get; set; }
#endif
        /// <summary>The hostCookies property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<HostCookie>? HostCookies { get; set; }
#nullable restore
#else
        public List<HostCookie> HostCookies { get; set; }
#endif
        /// <summary>The hosts property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Host>? Hosts { get; set; }
#nullable restore
#else
        public List<Host> Hosts { get; set; }
#endif
        /// <summary>The hostTrackers property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<HostTracker>? HostTrackers { get; set; }
#nullable restore
#else
        public List<HostTracker> HostTrackers { get; set; }
#endif
        /// <summary>The intelligenceProfileIndicators property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<IntelligenceProfileIndicator>? IntelligenceProfileIndicators { get; set; }
#nullable restore
#else
        public List<IntelligenceProfileIndicator> IntelligenceProfileIndicators { get; set; }
#endif
        /// <summary>The intelProfiles property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<IntelligenceProfile>? IntelProfiles { get; set; }
#nullable restore
#else
        public List<IntelligenceProfile> IntelProfiles { get; set; }
#endif
        /// <summary>The passiveDnsRecords property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PassiveDnsRecord>? PassiveDnsRecords { get; set; }
#nullable restore
#else
        public List<PassiveDnsRecord> PassiveDnsRecords { get; set; }
#endif
        /// <summary>The vulnerabilities property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Vulnerability>? Vulnerabilities { get; set; }
#nullable restore
#else
        public List<Vulnerability> Vulnerabilities { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ThreatIntelligence CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ThreatIntelligence();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"articleIndicators", n => { ArticleIndicators = n.GetCollectionOfObjectValues<ArticleIndicator>(ArticleIndicator.CreateFromDiscriminatorValue)?.ToList(); } },
                {"articles", n => { Articles = n.GetCollectionOfObjectValues<Article>(Article.CreateFromDiscriminatorValue)?.ToList(); } },
                {"hostComponents", n => { HostComponents = n.GetCollectionOfObjectValues<HostComponent>(HostComponent.CreateFromDiscriminatorValue)?.ToList(); } },
                {"hostCookies", n => { HostCookies = n.GetCollectionOfObjectValues<HostCookie>(HostCookie.CreateFromDiscriminatorValue)?.ToList(); } },
                {"hosts", n => { Hosts = n.GetCollectionOfObjectValues<Host>(Host.CreateFromDiscriminatorValue)?.ToList(); } },
                {"hostTrackers", n => { HostTrackers = n.GetCollectionOfObjectValues<HostTracker>(HostTracker.CreateFromDiscriminatorValue)?.ToList(); } },
                {"intelligenceProfileIndicators", n => { IntelligenceProfileIndicators = n.GetCollectionOfObjectValues<IntelligenceProfileIndicator>(IntelligenceProfileIndicator.CreateFromDiscriminatorValue)?.ToList(); } },
                {"intelProfiles", n => { IntelProfiles = n.GetCollectionOfObjectValues<IntelligenceProfile>(IntelligenceProfile.CreateFromDiscriminatorValue)?.ToList(); } },
                {"passiveDnsRecords", n => { PassiveDnsRecords = n.GetCollectionOfObjectValues<PassiveDnsRecord>(PassiveDnsRecord.CreateFromDiscriminatorValue)?.ToList(); } },
                {"vulnerabilities", n => { Vulnerabilities = n.GetCollectionOfObjectValues<Vulnerability>(Vulnerability.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ArticleIndicator>("articleIndicators", ArticleIndicators);
            writer.WriteCollectionOfObjectValues<Article>("articles", Articles);
            writer.WriteCollectionOfObjectValues<HostComponent>("hostComponents", HostComponents);
            writer.WriteCollectionOfObjectValues<HostCookie>("hostCookies", HostCookies);
            writer.WriteCollectionOfObjectValues<Host>("hosts", Hosts);
            writer.WriteCollectionOfObjectValues<HostTracker>("hostTrackers", HostTrackers);
            writer.WriteCollectionOfObjectValues<IntelligenceProfileIndicator>("intelligenceProfileIndicators", IntelligenceProfileIndicators);
            writer.WriteCollectionOfObjectValues<IntelligenceProfile>("intelProfiles", IntelProfiles);
            writer.WriteCollectionOfObjectValues<PassiveDnsRecord>("passiveDnsRecords", PassiveDnsRecords);
            writer.WriteCollectionOfObjectValues<Vulnerability>("vulnerabilities", Vulnerabilities);
        }
    }
}
