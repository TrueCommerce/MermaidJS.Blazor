namespace MermaidJS.Blazor
{
    /// <summary>
    /// Options used when initializing MermaidJS.
    /// </summary>
    public class MermaidOptions
    {
        /// <summary>
        /// Controls whether or arrow markers in html code are absolute paths or anchors.
        /// </summary>
        public bool ArrowMarkerAbsolute { get; set; }

        /// <summary>
        /// Specifies the font to be used in the rendered diagrams.
        /// </summary>
        public string FontFamily { get; set; } = "'trebuchet ms', verdana, arial, sans-serif;";

        /// <summary>
        /// This option decides the amount of logging to be used.
        /// </summary>
        public int LogLevel { get; set; } = 5;

        /// <summary>
        /// The maximum number of characters allowed in a diagram definition.
        /// </summary>
        public int MaxTextSize { get; set; } = 50000;

        /// <summary>
        /// This option controls which currentConfig keys are considered secure and can only be changed via call to mermaidAPI.initialize. Calls to mermaidAPI.reinitialize cannot make changes to the secure keys in the current currentConfig. This prevents malicious graph directives from overriding a site's default security.
        /// </summary>
        public List<string> Secure { get; set; } = new string[] { "secure", "securityLevel", "startOnLoad", "maxTextSize" }.ToList();

        /// <summary>
        /// Level of trust for parsed diagram.
        /// </summary>
        public string SecurityLevel { get; set; } = "strict";

        /// <summary>
        /// Dictates whether mermaid starts on Page load.
        /// </summary>
        public bool StartOnLoad { get; set; } = true;

        /// <summary>
        /// Name of a pre-defined MermaidJS theme.
        /// </summary>
        public string Theme { get; set; } = "dark";
    }
}
