using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;
using YamlConfigurator.Docx.Models;


namespace YamlConfigurator.Tests;


[TestFixture]
public class YamlConfigurationYAMLTests
{
    private IConfiguration _configuration;

    [SetUp]
    public void Setup()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddYamlFile("appsettings.yaml",optional: false, reloadOnChange: true)
            .Build();
    }

    [Test]
    public void TestStringValue()
    {
        var stringValue = _configuration["stringvalue"];
        Assert.That(stringValue, Is.EqualTo("teststring"));
    }

    [Test]
    public void TestIntValue()
    {
        var intValue = _configuration.GetValue<int>("intvalue");
        Assert.That(intValue, Is.EqualTo(99));
    }

    [Test]
    public void TestBoolValue()
    {
        var boolValue = _configuration.GetValue<bool>("boolvalue");
        Assert.That(boolValue, Is.EqualTo(false));
    }

    [Test]
    public void TestDoubleValue()
    {
        var doubleValue = _configuration.GetValue<double>("doublevalue");
        Assert.That(doubleValue, Is.EqualTo(122.03));
    }

    [Test]
    public void TestDateValue()
    {
        var dateValue = _configuration.GetValue<DateTime>("datevalue");
        Assert.That(dateValue, Is.EqualTo(new DateTime(2024, 1, 1)));
    }

    [Test]
    public void TestTimeValue()
    {
        var timeValue = _configuration.GetValue<TimeSpan>("timevalue");
        Assert.That(timeValue, Is.EqualTo(new TimeSpan(14, 33, 4)));
    }

    [Test]
    public void TestDateTimeValue()
    {
        var dateTimeValue = _configuration.GetValue<DateTime>("datetimevalue");
        Assert.That(dateTimeValue, Is.EqualTo(new DateTime(2024, 1, 1, 14, 33, 4)));
    }

    [Test]
    public void TestValueset()
    {
        dynamic valueset = new
        {
            stringvalue = _configuration["valueset:stringvalue"],
            intvalue = _configuration.GetValue<int>("valueset:intvalue"),
            boolvalue = _configuration.GetValue<bool>("valueset:boolvalue"),
            doublevalue = _configuration.GetValue<double>("valueset:doublevalue"),
            datevalue = _configuration.GetValue<DateTime>("valueset:datevalue"),
            timevalue = _configuration.GetValue<TimeSpan>("valueset:timevalue"),
            datetimevalue = _configuration.GetValue<DateTime>("valueset:datetimevalue")
        };

        Assert.AreEqual("teststring", valueset.stringvalue);
        Assert.AreEqual(99, valueset.intvalue);
        Assert.AreEqual(false, valueset.boolvalue);
        Assert.AreEqual(122.03, valueset.doublevalue);
        Assert.AreEqual(new DateTime(2024, 1, 1), valueset.datevalue);
        Assert.AreEqual(new TimeSpan(14, 33, 4), valueset.timevalue);
        Assert.AreEqual(new DateTime(2024, 1, 1, 14, 33, 4), valueset.datetimevalue);
    }

    //[Test]
    //public void TestDocxConfigurationLoading()
    //{
    //    var docxConfig =
    //        _configuration.GetSection("docx").Get<DocxConfiguration>()
    //        ?? new();
    //    var journalDoc = docxConfig.GetDocByName("journal");

    //    Assert.That(journalDoc, Is.Not.Null);
    //    Assert.Multiple(() =>
    //    {
    //        Assert.That(journalDoc.Name, Is.EqualTo("journal"));
    //        Assert.That(journalDoc.TitlePage.Title.Value, Is.EqualTo("LLM Comparison Journal"));
    //        Assert.That(journalDoc.TitlePage.Title.Style, Is.EqualTo("Title"));
    //    });

    //    var summaryPart = journalDoc.Parts.Find(part => part.Name == "summary");
    //    var qtablePart = journalDoc.Parts.Find(part => part.Name == "qtable");

    //    Assert.That(summaryPart, Is.Not.Null);
    //    Assert.Multiple(() =>
    //    {
    //        Assert.That(summaryPart.Title.Value, Is.EqualTo("Summary"));
    //        Assert.That(summaryPart.Title.Style, Is.EqualTo("Heading 2"));
    //        Assert.That(summaryPart.Text.Value, Is.EqualTo("Summarize this LlmComparison run"));
    //        Assert.That(summaryPart.Text.Style, Is.EqualTo("Normal"));
    //        Assert.That(qtablePart, Is.Not.Null);
    //    });
    //    Assert.Multiple(() =>
    //    {
    //        Assert.That(qtablePart.Title.Value, Is.EqualTo("Q-Table - Questions for LLMs"));
    //        Assert.That(qtablePart.Title.Style, Is.EqualTo("Heading 2"));
    //        Assert.That(qtablePart.Text.Value, Does.Contain("Q-Tables generate formatted questions"));
    //        Assert.That(qtablePart.Text.Style, Is.EqualTo("Normal"));
    //    });
    //}
}
