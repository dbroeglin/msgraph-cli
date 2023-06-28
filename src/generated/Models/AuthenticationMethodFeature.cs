using System.Runtime.Serialization;
using System;
namespace ApiSdk.Models {
    public enum AuthenticationMethodFeature {
        [EnumMember(Value = "ssprRegistered")]
        SsprRegistered,
        [EnumMember(Value = "ssprEnabled")]
        SsprEnabled,
        [EnumMember(Value = "ssprCapable")]
        SsprCapable,
        [EnumMember(Value = "passwordlessCapable")]
        PasswordlessCapable,
        [EnumMember(Value = "mfaCapable")]
        MfaCapable,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
