List<int> numbers = new() { 1, 3, 11, 13, 20, 37 };

List<int> newNumbers = new();

for (int i = 0; i < numbers.Count(); i++)
{
    if (numbers.Count() > i + 1)
    {
        var r = numbers[i + 1] - numbers[i];
        for (int x = 1; x <= r; x++)
        {
            var y = numbers[i] + x;
            if (y % 2 != 0 && numbers[i + 1] != y)
                newNumbers.Add(y);
        }
    }
}

foreach (var n in newNumbers)
{
    Console.WriteLine(n);
}