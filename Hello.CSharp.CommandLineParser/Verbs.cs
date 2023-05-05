using CommandLine;

public class Verbs
{
    [Verb("add", HelpText = "Add two intergers.")]
    public class AddVerbOptions
    {
        //        [Value(0, MetaName = "int-a", HelpText = "Interger A")]
        [Option('a', "IntA", Default = 0, Required = true)]
        public int IntergerA { get; set; }

        //        [Value(1, MetaName = "int-b", HelpText = "Interger B")]
        [Option('b', "IntB", Default = 0, Required = true)]
        public int IntergerB { get; set; }
    }
}
