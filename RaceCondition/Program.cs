int value = 0;
Parallel.ForEach(Enumerable.Range(1, 10000).ToList(), (x) =>
{
    value = x;
});

Console.WriteLine(value);