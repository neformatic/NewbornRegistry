using System.ComponentModel;

namespace NewbornRegistry.Common.Enums;

public enum Gender
{
    [Description("Male")]
    Male = 1,

    [Description("Female")]
    Female,

    [Description("Other")]
    Other,

    [Description("Unknown")]
    Unknown
}