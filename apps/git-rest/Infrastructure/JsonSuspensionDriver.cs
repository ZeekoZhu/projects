using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using ReactiveUI;
using Splat;

namespace GitRest.Infrastructure;

// infrastructure
public class JsonSuspensionDriver : ISuspensionDriver, IEnableLogger
{
  private readonly string _file;
  private readonly Type _appStateType;

  private readonly JsonSerializerOptions _settings = new()
  {
    WriteIndented = true,
    AllowTrailingCommas = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    Converters =
    {
      new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
    }
  };

  public JsonSuspensionDriver(string file, Type appStateType)
  {
    _file = file;
    _appStateType = appStateType;
  }

  public IObservable<Unit> InvalidateState()
  {
    if (File.Exists(_file))
      File.Delete(_file);
    return Observable.Return(Unit.Default);
  }

  public IObservable<object> LoadState()
  {
    var lines = File.ReadAllText(_file);
    var state = JsonSerializer.Deserialize(lines, _appStateType, _settings);
    if (state == null)
      throw new InvalidOperationException("Failed to deserialize state");
    return Observable.Return(state);
  }

  public IObservable<Unit> SaveState(object state)
  {
    this.Log().Debug("Saving state to {File}", _file);
    var lines = JsonSerializer.Serialize(state, _settings);
    File.WriteAllText(_file, lines);
    return Observable.Return(Unit.Default);
  }
}
