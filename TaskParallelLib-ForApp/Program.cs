//long totalByte = 0;
//var files = Directory.GetFiles("C:\\Users\\rhakc\\OneDrive\\Masaüstü\\Pictures");

//Parallel.For(0, files.Length, (index) =>
//{
//    var file = new FileInfo(files[index]);
//    Interlocked.Add(ref totalByte, file.Length);
//});


//Console.WriteLine("Total byte:" + totalByte);


int total = 0;
Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0, (x, loop, subtotal) =>
{
    subtotal += x;
    return subtotal;
}, (y) => Interlocked.Add(ref total, y));

Console.WriteLine(total);