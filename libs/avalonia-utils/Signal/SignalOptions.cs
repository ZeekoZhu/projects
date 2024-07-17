using LanguageExt.ClassInstances;
using LanguageExt.TypeClasses;

namespace Projects.AvaloniaUtils.Signal;

public class SignalOptions<T>
{
  public Eq<T> Equal { get; set; } = EqDefault<T>.Inst;

  public SignalOptions<T> WithEqual(Eq<T> equal)
  {
    Equal = equal;
    return this;
  }
}
