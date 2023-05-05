using CommandLine;

Parser.Default.ParseArguments<Options>(Environment.GetCommandLineArgs())
    .WithParsed<Options>(options =>
    {
        if (options.Verbose)
        {
            Console.WriteLine($"Verbose output enabled. Current Arguments: -v {options.Verbose}");
            Console.WriteLine("Quick Start Example! App is in Verbose mode!");
        }
        else
        {
            Console.WriteLine($"Current Arguments: -v {options.Verbose}");
            Console.WriteLine("Quick Start Example!");
        }
    })
    .WithNotParsed(errs => Console.WriteLine("Failed to parse options."));

var result = Parser.Default.ParseArguments<Verbs.AddVerbOptions>(Environment.GetCommandLineArgs())
    .WithNotParsed(errs => Console.WriteLine("Failed to parse verbs."))
    .MapResult(
        options => options.IntergerA + options.IntergerB,
        errs => 1
    );

Console.WriteLine(result);
