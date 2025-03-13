using localscrape.Browser;
using localscrape.Debug;
using localscrape.Helpers;
using localscrape.Manga;
using localscrape.Models;
using localscrape.Repo;
using localscrape.SpeedTest;

DebugService debug = new(new FileHelper());
BrowserService edgeBrowser = new(BrowserType.Edge);
BrowserService chromeBrowser = new(BrowserType.Chrome);

MangaRepo asuraRepo = new("AsuraScans");
RestService restService = new("http://192.168.50.11");
MangaReaderRepo readerRepo = new(restService);
AsuraScansService asuraScans = new(asuraRepo, chromeBrowser, debug, readerRepo);
asuraScans.RunDebug = false;
asuraScans.RunProcess();

//SpeedtestService speedtestService = new();
//var json = speedtestService.RunSpeedTest();
//var speed = speedtestService.ParseSpeed(json);
//Console.WriteLine($"Download speed: {speed} Mbps");

MangaRepo weebCentralRepo = new("WeebCentral");
edgeBrowser.SetTimeout(15);
WeebCentralService weebCentralService = new(weebCentralRepo, edgeBrowser, debug);
weebCentralService.RunDebug = false;
weebCentralService.RunProcess();

MangaRepo flameScansRepo = new("FlameScans");
edgeBrowser = new(BrowserType.Edge);
FlameScansService flameScansService = new(flameScansRepo, edgeBrowser, debug);
flameScansService.RunDebug = false;
flameScansService.RunProcess();