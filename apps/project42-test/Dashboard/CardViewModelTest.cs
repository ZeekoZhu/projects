using Projects.Project42.Dashboard;
using Projects.Project42.Extensions;

namespace Projects.Project42.Test.Dashboard;

[TestFixture]
public class CardViewModelTests
{
  [SetUp]
  public void SetUp()
  {
    _viewModel = new CardViewModel();
  }

  private CardViewModel _viewModel;

  [Test]
  public void MoveCard_ShouldUpdatePositionWithinBounds()
  {
    // Arrange
    var initialPosition = new Point(100, 100);
    _viewModel.Position.SetState(_ => initialPosition);
    var movePoint = new Point(50, 50);

    // Act
    _viewModel.MoveCard.Execute(movePoint).Subscribe();

    // Assert
    var expectedPosition = new Point(150, 150);
    Assert.That(_viewModel.Position.Current, Is.EqualTo(expectedPosition));
  }

  [Test]
  public void MoveCard_ShouldNotExceedMaximumBounds()
  {
    // Arrange
    var initialPosition =
      (DashboardCanvasConstants.CanvasSize - DashboardCanvasConstants.CardSize)
      .ToPoint();
    _viewModel.Position.SetState(_ => initialPosition);
    var movePoint = new Point(100, 100);

    // Act
    _viewModel.MoveCard.Execute(movePoint).Subscribe();

    // Assert
    var expectedPosition = initialPosition;
    Assert.That(_viewModel.Position.Current, Is.EqualTo(expectedPosition));
  }

  [Test]
  public void MoveCard_ShouldNotGoBelowMinimumBounds()
  {
    // Arrange
    var initialPosition = new Point(0, 0);
    _viewModel.Position.SetState(_ => initialPosition);
    var movePoint = new Point(-100, -100);

    // Act
    _viewModel.MoveCard.Execute(movePoint).Subscribe();

    // Assert
    var expectedPosition = new Point(0, 0);
    Assert.That(_viewModel.Position.Current, Is.EqualTo(expectedPosition));
  }
}
