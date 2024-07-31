using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

using YamlConfigurator.Docx;
using YamlConfigurator.Docx.Models;
using Microsoft.Extensions.Configuration.Yaml;

namespace YamlConfigurator.Tests;

[TestFixture]
public class YamlConfiguratorDocxTests
{
    private IConfiguration _configuration;
    private DocxConfiguration _docxConfiguration;

    [SetUp]
    public void Setup()
    {
        var basePath = TestContext.CurrentContext.TestDirectory;
        var yamlFilePath = Path.Combine(basePath, "appsettings.yaml");

        _configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddYamlFile(yamlFilePath, optional: false, reloadOnChange: true)
            .Build();

        _docxConfiguration = _configuration.GetDocxConfiguration() ?? new();
    }

    [Test]
    public void TestDocxConfigurationLoaded()
    {
        Assert.That(_docxConfiguration, Is.Not.Null);
        Assert.That(_docxConfiguration.Docs, Is.Not.Empty);
    }

    [Test]
    public void TestGetDocByName_Existing()
    {
        var docConfig = _docxConfiguration.GetDocByName("journal");
        Assert.That(docConfig, Is.Not.Null);
        Assert.That(docConfig.Name, Is.EqualTo("journal"));
    }

    [Test]
    public void TestGetDocByName_NonExisting()
    {
        var docConfig = _docxConfiguration.GetDocByName("nonexistent");
        Assert.That(docConfig, Is.Not.Null); // Returns empty DocConfiguration
        Assert.That(docConfig.Name, Is.EqualTo(string.Empty));
    }

    [Test]
    public void TestIndexerByName_Existing()
    {
        var docConfig = _docxConfiguration["journal"];
        Assert.That(docConfig, Is.Not.Null);
        Assert.That(docConfig.Name, Is.EqualTo("journal"));
    }

    [Test]
    public void TestIndexerByName_NonExisting()
    {
        var docConfig = _docxConfiguration["nonexistent"];
        Assert.That(docConfig, Is.Not.Null); // Returns empty DocConfiguration
        Assert.That(docConfig.Name, Is.EqualTo(string.Empty));
    }

    [Test]
    public void TestIndexerByIndex_Existing()
    {
        var docConfig = _docxConfiguration[0];
        Assert.That(docConfig, Is.Not.Null);
        Assert.That(docConfig.Name, Is.EqualTo("journal"));
    }

    [Test]
    public void TestIndexerByIndex_NonExisting()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var _ = _docxConfiguration[10];
        });
        Assert.That(ex.Message, Is.EqualTo("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')"));
    }


    [Test]
    public void TestPartConfiguration()
    {
        var docConfig = _docxConfiguration.GetDocByName("journal");
        var partConfig = docConfig.GetPartByName("summary");

        Assert.That(partConfig, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(partConfig.Name, Is.EqualTo("summary"));
            Assert.That(partConfig.Title.Value, Is.EqualTo("Summary"));
            Assert.That(partConfig.Text.Value, Is.EqualTo("Summarize this LlmComparison run"));
        });
    }

    [Test]
    public void TestTitlePageConfiguration()
    {
        var docConfig = _docxConfiguration.GetDocByName("journal");
        var titlePage = docConfig.TitlePage;

        Assert.That(titlePage, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(titlePage.Title.Value, Is.EqualTo("LLM Comparison Journal"));
            Assert.That(titlePage.Title.Style, Is.EqualTo("Title"));
        });
    }
}
