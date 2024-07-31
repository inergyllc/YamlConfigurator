using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using YamlConfigurator.Files.Models;
using Microsoft.Extensions.Configuration.Yaml;

namespace YamlConfigurator.Files.Tests
{
    [TestFixture]
    public class YamlConfiguratorFilesTests
    {
        private IConfiguration _configuration;
        private FilesManagerConfiguration _filesManagerConfiguration;

        [SetUp]
        public void Setup()
        {
            var basePath = TestContext.CurrentContext.TestDirectory;
            var yamlFilePath = Path.Combine(basePath, "appsettings.yaml");

            _configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddYamlFile(yamlFilePath, optional: false, reloadOnChange: true)
                .Build();

            _filesManagerConfiguration = _configuration.GetFilesManagerConfiguration();
        }

        [Test]
        public void TestFilesManagerConfigurationLoaded()
        {
            Assert.That(_filesManagerConfiguration, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(_filesManagerConfiguration.Folder, Is.EqualTo(".\\"));
                Assert.That(_filesManagerConfiguration.Timestamp, Is.EqualTo(true));
                Assert.That(_filesManagerConfiguration.Force, Is.EqualTo(true));
                Assert.That(_filesManagerConfiguration.Append, Is.EqualTo(false));
            });
        }

        [Test]
        public void TestGetFileByName_Existing()
        {
            var fileConfig = _filesManagerConfiguration.GetFileByName("results");
            Assert.That(fileConfig, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(fileConfig.Name, Is.EqualTo("results"));
                Assert.That(fileConfig.Type, Is.EqualTo("excel"));
                Assert.That(fileConfig.Root, Is.EqualTo("TabulatedResults"));
                Assert.That(fileConfig.Extension, Is.EqualTo(".xlsx"));
            });
        }

        [Test]
        public void TestGetFileByName_NonExisting()
        {
            var ex = Assert.Throws<KeyNotFoundException>(() => _filesManagerConfiguration.GetFileByName("nonexistent"));
            Assert.That(ex.Message, Is.EqualTo("File configuration with name 'nonexistent' not found."));
        }

        [Test]
        public void TestGetFileByIndex_Existing()
        {
            var fileConfig = _filesManagerConfiguration.GetFileByIndex(0);
            Assert.That(fileConfig, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(fileConfig.Name, Is.EqualTo("results"));
                Assert.That(fileConfig.Type, Is.EqualTo("excel"));
                Assert.That(fileConfig.Root, Is.EqualTo("TabulatedResults"));
                Assert.That(fileConfig.Extension, Is.EqualTo(".xlsx"));
            });
        }

        [Test]
        public void TestGetFileByIndex_NonExisting()
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() => _filesManagerConfiguration.GetFileByIndex(10));
            Assert.That(ex.Message, Is.EqualTo("Index '10' is out of range."));
        }

        [Test]
        public void TestIndexerByName_Existing()
        {
            var fileConfig = _filesManagerConfiguration["results"];
            Assert.That(fileConfig, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(fileConfig.Name, Is.EqualTo("results"));
                Assert.That(fileConfig.Type, Is.EqualTo("excel"));
                Assert.That(fileConfig.Root, Is.EqualTo("TabulatedResults"));
                Assert.That(fileConfig.Extension, Is.EqualTo(".xlsx"));
            });
        }

        [Test]
        public void TestIndexerByName_NonExisting()
        {
            var ex = Assert.Throws<KeyNotFoundException>(() =>
            {
                var _ = _filesManagerConfiguration["nonexistent"];
            });
            Assert.That(ex.Message, Is.EqualTo("File configuration with name 'nonexistent' not found."));
        }


        [Test]
        public void TestIndexerByIndex_Existing()
        {
            var fileConfig = _filesManagerConfiguration[0];
            Assert.That(fileConfig, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(fileConfig.Name, Is.EqualTo("results"));
                Assert.That(fileConfig.Type, Is.EqualTo("excel"));
                Assert.That(fileConfig.Root, Is.EqualTo("TabulatedResults"));
                Assert.That(fileConfig.Extension, Is.EqualTo(".xlsx"));
            });
        }

        [Test]
        public void TestIndexerByIndex_NonExisting()
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var _ = _filesManagerConfiguration[10];
            });
            Assert.That(ex.Message, Is.EqualTo("Index '10' is out of range."));
        }

        [Test]
        public void TestFileConfigurationPath_WithTimestamp()
        {
            var fileConfig = _filesManagerConfiguration.GetFileByName("results");
            var expectedRoot = "TabulatedResults";
            var expectedExtension = ".xlsx";
            var path = fileConfig.Path;

            Assert.That(path, Does.Contain(expectedRoot));
            Assert.That(path, Does.Contain(expectedExtension));
            Assert.That(path, Does.Contain(DateTime.Now.ToString("yyyyMMddHHmmss")[..12])); // Check timestamp without seconds part
        }

        [Test]
        public void TestFileConfigurationPath_WithoutTimestamp()
        {
            var fileConfig = _filesManagerConfiguration.GetFileByName("journal");
            fileConfig.Timestamp = false;
            var expectedPath = Path.Combine(".\\", "OngoingWorkJournal.docx");

            Assert.That(fileConfig.Path, Is.EqualTo(expectedPath));
        }

        [Test]
        public void TestFileConfigurationCondition()
        {
            var fileConfig = _filesManagerConfiguration.GetFileByName("results");
            fileConfig.Condition();

            Assert.Multiple(() =>
            {
                Assert.That(Directory.Exists(fileConfig.Folder), Is.True);
                Assert.That(File.Exists(fileConfig.Path), Is.False);
            });
        }

        [Test]
        public void TestFileConfigurationCondition_FileExists()
        {
            var fileConfig = _filesManagerConfiguration.GetFileByName("journal");
            var path = fileConfig.Path;

            // Create the file to simulate it already exists
            Directory.CreateDirectory(fileConfig.Folder);
            File.WriteAllText(path, "dummy content");

            var ex = Assert.Throws<InvalidOperationException>(() => fileConfig.Condition());
            Assert.That(ex.Message, Is.EqualTo($"File {path} already exists and Force not specified as true"));

            // Cleanup
            File.Delete(path);
        }
    }
}
