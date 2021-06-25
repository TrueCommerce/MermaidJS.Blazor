using MermaidJS.Blazor;
using MermaidJS.Blazor.Internal;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the necessary services for using the <see cref="MermaidDiagram"/> component.
        /// </summary>
        public static IServiceCollection AddMermaidJS(this IServiceCollection services)
        {
            return services.AddTransient<MermaidDiagramInterop>();
        }
    }
}
