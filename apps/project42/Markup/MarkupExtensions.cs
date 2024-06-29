using FluentAvalonia.UI.Controls;
using Projects.MarkupViewExtension;
using Projects.Project42.Dashboard;

namespace Projects.Project42.Markup;

[MarkupViewGeneratorConfig]
[MarkupViewsInNamespace([
  typeof(NumberBox), typeof(DashboardCanvasView), typeof(CustomLabel)
])]
// ReSharper disable once UnusedType.Global
public class MarkupExtensionsConfig;
