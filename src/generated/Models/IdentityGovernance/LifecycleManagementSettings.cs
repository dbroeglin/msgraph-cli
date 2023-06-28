using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.IdentityGovernance {
    public class LifecycleManagementSettings : Entity, IParsable {
        /// <summary>The emailSettings property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ApiSdk.Models.EmailSettings? EmailSettings { get; set; }
#nullable restore
#else
        public ApiSdk.Models.EmailSettings EmailSettings { get; set; }
#endif
        /// <summary>The interval in hours at which all workflows running in the tenant should be scheduled for execution. This interval has a minimum value of 1 and a maximum value of 24. The default value is 3 hours.</summary>
        public int? WorkflowScheduleIntervalInHours { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new LifecycleManagementSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LifecycleManagementSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"emailSettings", n => { EmailSettings = n.GetObjectValue<ApiSdk.Models.EmailSettings>(ApiSdk.Models.EmailSettings.CreateFromDiscriminatorValue); } },
                {"workflowScheduleIntervalInHours", n => { WorkflowScheduleIntervalInHours = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ApiSdk.Models.EmailSettings>("emailSettings", EmailSettings);
            writer.WriteIntValue("workflowScheduleIntervalInHours", WorkflowScheduleIntervalInHours);
        }
    }
}
