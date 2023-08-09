
using System.Diagnostics;
using System.Drawing;

long FilesByte = 0;

Stopwatch sw = Stopwatch.StartNew();



sw.Start();
string picturesPath = "C:\\Users\\rhakc\\OneDrive\\Masaüstü\\Pictures";
var files = Directory.GetFiles(picturesPath);
Parallel.ForEach(files, (item) =>
{
    Console.WriteLine("thread no:" + Thread.CurrentThread.ManagedThreadId);
    FileInfo file = new FileInfo(item);
    Interlocked.Add(ref FilesByte, file.Length);
});

