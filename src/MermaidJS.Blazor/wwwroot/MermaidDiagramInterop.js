function initializeGlobals() {
    console.log("initializeGlobals", window.mermaidDiagramBlazorOptions);
    function loadMermaid() {
        return new Promise((resolve) => {
            if (!window.mermaid) {
                const script = document.createElement("script");

                script.src = "_content/MermaidJS.Blazor/lib/mermaid/mermaid.min.js";
                script.async = false;
                script.defer = false;
                script.onload = () => {
                    window.mermaid.mermaidAPI.initialize(window.mermaidDiagramBlazorOptions);

                    resolve();
                };

                document.body.appendChild(script);
            }

            else {
                resolve();
            }
        });
    }

    return loadMermaid().then(() => {
        if (!window.mermaidDiagramBlazorComponents) {
            window.mermaidDiagramBlazorComponents = new Map();
        }

        if (!window.onClickMermaidNode) {
            window.onClickMermaidNode = function (nodeId) {
                window.mermaidDiagramBlazorComponents.forEach((componentRef, componentId) => {
                    try {
                        componentRef.invokeMethodAsync("OnClickMermaidNode", nodeId);
                    }

                    catch (err) {
                        console.error(`Failed to invoke Mermaid node click handler for component: ${componentId}.`, err);
                    }
                });
            }
        }
    });
}

export function beginRender(componentId, definition) {
    initializeGlobals().then(() => {
        const componentRef = window.mermaidDiagramBlazorComponents.get(componentId);

        if (!componentRef) {
            return;
        }

        try {
            window.mermaid.mermaidAPI.render(`${componentId}-svg`, definition, (svg, bind) => {
                const host = document.getElementById(componentId);

                host.innerHTML = svg;

                bind(host);

                componentRef.invokeMethodAsync("OnRenderCompleted");
            });
        }

        catch (err) {
            componentRef.invokeMethodAsync("OnRenderFailed", err.message);
        }
    });
}

export function registerComponent(componentId, componentRef, options) {
    window.mermaidDiagramBlazorOptions = window.mermaidDiagramBlazorOptions || options;

    initializeGlobals().then(() => {
        window.mermaidDiagramBlazorComponents.set(componentId, componentRef);
    });
}

export function unregisterComponent(componentId) {
    window.mermaidDiagramBlazorComponents.delete(componentId);
}

