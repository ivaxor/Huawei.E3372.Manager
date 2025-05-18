using System.Text.RegularExpressions;

namespace Huawei.E3372.Manager.Logic.Constants;

public static class RegexConstants
{
    public static readonly Regex PhoneNumberRegex = new Regex("\\+\\d{8,15}");
}