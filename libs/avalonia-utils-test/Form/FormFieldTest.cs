using Projects.AvaloniaUtils.Form;

namespace Projects.AvaloniaUtils.Test.Form;

[TestFixture]
[TestOf(typeof(FormField<>))]
public class FormFieldTest
{

  [Test]
  public void should_update_IsDirty()
  {
    var field = new FormField<int>(42);
    field.IsDirty.Value.Should().BeFalse();

    field.Value.Set(43);
    field.IsDirty.Value.Should().BeTrue();
  }

  [Test]
  public void can_reset_field()
  {
    var field = new FormField<int>(42);
    field.Value.Set(43);
    field.ResetField();
    field.Value.Get().Should().Be(42);
    field.IsDirty.Get().Should().Be(false);
  }
}
