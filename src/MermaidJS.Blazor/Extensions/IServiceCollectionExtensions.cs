using MermaidJS.Blazor;
using MermaidJS.Blazor.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// MermaidJS service collection extensions
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the necessary services for using the <see cref="MermaidDiagram"/> component.
        /// </summary>
        public static IServiceCollection AddMermaidJS(this IServiceCollection services, Action<MermaidOptions>? configure = default)
        {
            return services
                .AddOptions()
                .Configure<MermaidOptions>(options =>
                {
                    if (configure is not null)
                    {
                        configure(options);
                    }
                })
                .AddTransient<MermaidDiagramInterop>();
        }
    }
}
