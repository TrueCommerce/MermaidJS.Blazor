namespace MermaidJS.Blazor
{
    /// <summary>
    /// Acceptable values for the securityLevel initialization option.
    /// </summary>
    public static class MermaidSecurityLevels
    {
        /// <summary>
        /// HTML tags in text are allowed, (only script element is removed), click functionality is enabled.
        /// </summary>
        public const string AntiScript = "antiscript";

        /// <summary>
        /// Tags in text are allowed, click functionality is enabled.
        /// </summary>
        public const string Loose = "loose";

        /// <summary>
        /// Default. Tags in text are encoded, click functionality is disabled.
        /// </summary>
        public const string Strict = "strict";
    }
}
