using Shinpan;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Process process = new Process();

process.StartInfo.FileName = app.Environment.ContentRootPath + "/Tests/testapp";
process.StartInfo.RedirectStandardOutput = true;
process.StartInfo.RedirectStandardInput = true;

Test test = new Test(process, "./Tests/testfile");

string outp = new StreamReader("./Tests/output").ReadToEnd();

app.MapGet("/", () => outp);

app.Run();
