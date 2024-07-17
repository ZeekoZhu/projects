using FluentAssertions.Reactive;
using LanguageExt.ClassInstances;
using Projects.AvaloniaUtils.Signal;

namespace Projects.AvaloniaUtils.Test.Signal;

[TestFixture]
public class ComputedTest
{
  [Test]
  public void can_read()
  {
    var state = new State<int>(5);

    using var computed = new Computed<int>(state.Select(it => it + 1));

    computed.Value.Should().Be(6);
  }

  [Test]
  public void can_combine_multiple_states()
  {
    var state1 = new State<int>(5);
    var state2 = new State<int>(6);

    using var computed = new Computed<int>(
      from s1 in state1
      from s2 in state2
      select s1 + s2);

    computed.Value.Should().Be(11);
  }

  [Test]
  public void can_be_updated()
  {
    var state = new State<int>(5);
    using var computed = new Computed<int>(state.Select(it => it + 1));

    state.Value = 6;
    computed.Value.Should().Be(7);
  }

  [Test]
  public void should_raise_property_changed()
  {
    var state = new State<int>(5);
    using var computed = new Computed<int>(state.Select(it => it + 1));
    using var monitored = computed.Monitor();

    state.Value = 6;
    monitored.Should().RaisePropertyChangeFor(x => x.Value);
  }

  [Test]
  public void can_be_converted_to_observable()
  {
    var state = new State<int>(42);
    using var computed = new Computed<int>(state.Select(it => it + 1));
    using var observer = computed.Observe();

    observer.RecordedMessages.Should().Equal([43]);
  }

  [Test]
  public void should_ignore_same_value()
  {
    var state = new State<int>(42);
    using var computed = new Computed<int>(state.Select(it => it + 1),
      new SignalOptions<int>().WithEqual(new EqTrue<int>()));
    using var observer = computed.Observe();

    state.Value = 233;
    observer.RecordedMessages.Should().Equal([43]);
  }
}
