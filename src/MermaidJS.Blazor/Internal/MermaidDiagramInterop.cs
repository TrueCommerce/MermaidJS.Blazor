using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace MermaidJS.Blazor.Internal
{
    internal class MermaidDiagramInterop
    {
        private readonly IOptionsSnapshot<MermaidOptions> _mermaidOptions;
        private readonly Lazy<Task<IJSObjectReference>> _jsModule;

        public MermaidDiagramInterop(IJSRuntime jsRuntime, IOptionsSnapshot<MermaidOptions> mermaidOptions)
        {
            _mermaidOptions = mermaidOptions;
            _jsModule = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/MermaidJS.Blazor/MermaidDiagramInterop.js").AsTask());
        }

        public async ValueTask BeginRender(MermaidDiagram component)
        {
            var jsModule = await _jsModule.Value;

            await jsModule.InvokeVoidAsync("beginRender", component.Id, component.Definition);
        }

        public async Task<DotNetObjectReference<MermaidDiagram>> RegisterComponent(MermaidDiagram component)
        {
            var jsModule = await _jsModule.Value;
            var componentRef = DotNetObjectReference.Create(component);

            await jsModule.InvokeVoidAsync("registerComponent", component.Id, componentRef, _mermaidOptions.Value);

            return componentRef;
        }

        public async ValueTask UnregisterComponent(MermaidDiagram component)
        {
            var jsModule = await _jsModule.Value;

            await jsModule.InvokeVoidAsync("unregisterComponent", component.Id);
        }
    }
}
