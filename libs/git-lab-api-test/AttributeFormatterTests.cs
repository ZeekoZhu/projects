using Projects.GitLabApi.Concrete;
using Snapshooter.NUnit;

namespace Projects.GitLabApiTest;

[TestFixture]
public class AttributeFormatterTests
{
  class RequestParams
  {
    public class HashParams
    {
      public string Key1 { get; set; }
      public string Key2 { get; set; }
    }

    public string SimpleString { get; set; }
    public string[] SimpleArray { get; set; }
    public DateTime SimpleDateTime { get; set; }
    public bool SimpleBool { get; set; }
    public int SimpleInt { get; set; }
    public long SimpleLong { get; set; }
    public double SimpleDouble { get; set; }
    public HashParams SimpleHash { get; set; }

    public List<HashParams> HashArray { get; set; }
  }

  [Test]
  public void CanFormatAttributes()
  {
    var formatter = new AttributeFormatter();
    var attributes = new RequestParams
    {
      SimpleString = "value1",
      SimpleArray = ["value1", "value2"],
      SimpleDateTime = new DateTime(2021, 1, 1),
      SimpleBool = true,
      SimpleInt = 1,
      SimpleLong = 1,
      SimpleDouble = 1,
      SimpleHash = new RequestParams.HashParams
      {
        Key1 = "value1",
        Key2 = "value2"
      },
      HashArray = new List<RequestParams.HashParams>
      {
        new()
        {
          Key1 = "value1",
          Key2 = "value2"
        },
        new()
        {
          Key1 = "value1",
          Key2 = "value2"
        }
      }
    };
    var formattedAttributes = formatter.FormatAttributes(attributes).ToList();

    Snapshot.Match(formattedAttributes);
  }

  class NullableTest
  {
    public int? NullableInt { get; set; }
    public string? NullableString { get; set; }
    public DateTime? NullableDateTime { get; set; }
    public bool? NullableBool { get; set; }
    public double? NullableDouble { get; set; }
    public RequestParams.HashParams? Params;
  }

  [Test]
  public void CanHandleNullableType()
  {
    var formatter = new AttributeFormatter();
    var attributes = new NullableTest
    {
      NullableInt = 1,
      NullableString = "value1",
      NullableDateTime = new DateTime(2021, 1, 1),
      NullableBool = true,
      NullableDouble = 1,
      Params = new RequestParams.HashParams
      {
        Key1 = "value1",
        Key2 = "value2"
      }
    };

    var formattedAttributes = formatter.FormatAttributes(attributes).ToList();

    Snapshot.Match(formattedAttributes);
  }

  [Test]
  public void ShouldIgnoreNullFields()
  {
    var formatter = new AttributeFormatter();
    var attributes = new NullableTest
    {
      NullableInt = 1,
      NullableString = null,
      NullableDateTime = new DateTime(2021, 1, 1),
      NullableBool = true,
      NullableDouble = 1,
      Params = null
    };

    var formattedAttributes = formatter.FormatAttributes(attributes).ToList();

    Snapshot.Match(formattedAttributes);
  }
}
