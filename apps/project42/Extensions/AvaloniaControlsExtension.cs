using DynamicData;

namespace Projects.Project42.Extensions;

public static class AvaloniaControlsExtension
{
  public static IDisposable ApplyChangesTo<T>(
    this IObservable<IChangeSet<T>> changeSets, AvaloniaList<T> list) where T : notnull
  {
    return changeSets
      .Subscribe(changeSet =>
      {
        foreach (var change in changeSet)
          switch (change.Reason)
          {
            case ListChangeReason.Add:
              list.Add(change.Item.Current);
              break;
            case ListChangeReason.Remove:
              list.Remove(change.Item.Current);
              break;
            case ListChangeReason.Replace:
              var index =
                list.IndexOf(change.Item.Previous.Value);
              if (index >= 0)
                list[index] = change.Item.Current;
              break;
            case ListChangeReason.Clear:
              list.Clear();
              break;
            case ListChangeReason.AddRange:
              list.AddRange(change.Range);
              break;
            case ListChangeReason.RemoveRange:
              list.RemoveMany(change.Range);
              break;
            case ListChangeReason.Refresh:
              break;
            case ListChangeReason.Moved:
              list.Move(change.Item.PreviousIndex,
                change.Item.CurrentIndex);
              break;
            default:
              throw new ArgumentOutOfRangeException(nameof(change.Reason));
          }
      });
  }
}
