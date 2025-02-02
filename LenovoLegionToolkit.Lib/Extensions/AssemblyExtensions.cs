﻿using System;
using System.Globalization;
using System.Reflection;

namespace LenovoLegionToolkit.Lib.Extensions;

public static class AssemblyExtensions
{
    public static DateTime? GetBuildDateTime(this Assembly assembly)
    {
        const string buildVersionMetadataPrefix = "+build";

        var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        if (attribute?.InformationalVersion == null)
            return null;

        var value = attribute.InformationalVersion;
        var index = value.IndexOf(buildVersionMetadataPrefix, StringComparison.InvariantCultureIgnoreCase);
        if (index <= 0)
            return null;

        value = value[(index + buildVersionMetadataPrefix.Length)..];
        if (DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            return result;

        return null;
    }
}
