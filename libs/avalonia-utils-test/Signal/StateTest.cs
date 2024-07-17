using FluentAssertions.Reactive;
using LanguageExt.ClassInstances;
using Projects.AvaloniaUtils.Signal;

namespace Projects.AvaloniaUtils.Test.Signal;

[TestFixture]
public class StateTest
{
  [Test]
  public void can_read()
  {
    var state = new State<int>(42);
    state.Value.Should().Be(42);
  }

  [Test]
  public void can_write()
  {
    var state = new State<int>(42);
    state.Value = 43;
    state.Value.Should().Be(43);
  }

  [Test]
  public void can_emits_change()
  {
    var state = new State<int>(42);
    using var monitored = state.Monitor();

    state.Value = 43;
    monitored.Should().RaisePropertyChangeFor(x => x.Value);
  }

  [Test]
  public void does_not_emits_change_if_value_is_the_same()
  {
    var state = new State<int>(42);
    using var monitored = state.Monitor();

    state.Value = 42;
    monitored.Should().NotRaisePropertyChangeFor(x => x.Value);
  }

  [Test]
  public void can_use_custom_equality()
  {
    var state = new State<int>(42,
      new SignalOptions<int> { Equal = new EqTrue<int>() });
    using var monitored = state.Monitor();

    state.Value = 43;
    monitored.Should().NotRaisePropertyChangeFor(x => x.Value);
  }


  [Test]
  public void can_be_converted_to_observable()
  {
    var state = new State<int>(42);
    using var observer = state.Observe();

    state.Value = 43;

    observer.RecordedMessages.Should().Equal([42, 43]);
  }
}
