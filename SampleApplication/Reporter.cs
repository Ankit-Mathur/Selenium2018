using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using System.Reflection;

namespace SampleApplication
{
    public static class Reporter
    {
        private static readonly Logger TheLogger = LogManager.GetCurrentClassLogger();
        private static ExtentReports ReportManager { get; set; }
        private static string ApplicationDebuggingFolder 
        {
            get
            {
                var outputDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var relativePath = @"..\..\..\SampleApplication\Reports";
                var applicationDebuggingFolderPath = Path.GetFullPath(Path.Combine(outputDirectoryPath, relativePath));
                return applicationDebuggingFolderPath;
               // return "c://temp/CreatingReports";
            }
        }

        private static string HtmlReportFullPath { get; set; }

        public static string LatestResultsReportFolder { get; set; }

        private static TestContext MyTestContext { get; set; }

        private static ExtentTest CurrentTestCase { get; set; }

        public static void StartReporter()
        {
            TheLogger.Trace("Starting a one time setup for the entire" +
                            " .CreatingReports namespace." +
                            "Going to initialize the reporter next...");

            CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            htmlReporter.Configuration().DocumentTitle = "SampleApplication|Test Report";
            htmlReporter.Configuration().ReportName = "SampleApplication Test Report".ToUpper();
            ReportManager = new ExtentReports();
            ReportManager.AttachReporter(htmlReporter);
        }

        private static void CreateReportDirectory()
        {
            var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
            LatestResultsReportFolder = Path.Combine(filePath, string.Format("{0}_Test Report", DateTime.Now.ToString("yyyy.MM.dd_HH.mm")));
            Directory.CreateDirectory(LatestResultsReportFolder);

            HtmlReportFullPath = LatestResultsReportFolder + "\\TestResults.html";
            TheLogger.Trace("Full path of HTML report=>" + HtmlReportFullPath);
        }

        public static void AddTestCaseMetadataToHtmlReport(TestContext testContext)
        {
            MyTestContext = testContext;
            CurrentTestCase = ReportManager.CreateTest(MyTestContext.TestName);
        }

        public static void LogPassingTestStepToBugLogger(string message)
        {
            TheLogger.Info(message);
            CurrentTestCase.Log(Status.Pass, message);
        }

        public static void ReportTestOutcome(string screenshotPath)
        {
            var status = MyTestContext.CurrentTestOutcome;

            switch (status)
            {
                case UnitTestOutcome.Failed:
                    TheLogger.Error("Test Failed {0}", MyTestContext.FullyQualifiedTestClassName);
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Fail("Test Failed");
                    break;
                case UnitTestOutcome.Inconclusive:
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Warning("Test Inconclusive");
                    break;
                case UnitTestOutcome.Unknown:
                    CurrentTestCase.Skip("Test skipped");
                    break;
                default:
                    CurrentTestCase.Pass("Test Passed");
                    break;
            }

            ReportManager.Flush();
        }

        public static void LogTestStepForBugLogger(Status status, string message)
        {
            TheLogger.Info(message);
            CurrentTestCase.Log(status, message);
        }
    }
}