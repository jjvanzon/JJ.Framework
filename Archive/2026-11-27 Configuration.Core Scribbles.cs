
    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection(Assembly assembly)
    {
        string sectionName = ResolveSectionName(assembly);
        RefreshSection(sectionName);
    }

    /// <inheritdoc cref="_refreshsection" />
    public static void RefreshSection(string sectionName)
    {
        // TODO: With Type part of key (allowing multiple mappers for the same section),
        //  You can't offer the same kind of interface as the original ConfigurationManager?
        throw new NotImplementedException();
    }


/// <param name="encoding">
/// UTF8 is assumed by default, but you can provide your own encoding choice with this parameter if needed.
/// </param>
/// <param name="hasByteOrderMark">
/// Indicates whether a UTF8 encoded file to read is assumed to have a byte order mark (a little header).
/// Assumed false: no byte order mark, but use this parameter if you are expecting anything different.
/// </param>
