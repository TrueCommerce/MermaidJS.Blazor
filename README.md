# MermaidJS.Blazor

A simple MermaidDiagram component for Blazor.

## Getting Started

* Install the `MermaidJS.Blazor` NuGet package.

  ```bash
  > dotnet add package MermaidJS.Blazor
  ```

* Add `builder.Services.AddMermaidJS()` to your `Program.cs`.

  ```csharp
  using Microsoft.Extensions.DependencyInjection;

  // ... //

  builder.Services.AddMermaidJS();
  ```

* Use the `MermaidDiagram` component in your app.

  ```html
  @using MermaidJS.Blazor

  <!-- ... -->

  <MermaidDiagram Definition="@diagramDefinition" OnClick="OnClickNode" />

  @code
  {
      string diagramDefinition = "graph TB\nA-->B";

      void OnClickNode(string nodeId)
      {
          // TODO: do something with nodeId
      }
  }
  ```

## Handling Node Clicks

To raise node click events back to your blazor component, set your click callback to `onClickMermaidNode`:

```mermaid
graph TB
A--B
click A onClickMermaidNode
```
