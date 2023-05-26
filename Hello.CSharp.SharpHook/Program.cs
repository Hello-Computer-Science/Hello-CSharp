using SharpHook;


var hook = new TaskPoolGlobalHook();

hook.KeyTyped += (_, args) =>
{
    Console.WriteLine($"Typed: {args.Data.KeyCode}: {args.Data.KeyChar}");
};

hook.KeyPressed += (_, args) =>
{
    Console.WriteLine($"Pressed: {args.Data.KeyCode}: {args.Data.KeyChar}");
};

hook.KeyReleased += (_, args) =>
{
    Console.WriteLine($"Released: {args.Data.KeyCode}: {args.Data.KeyChar}");
};

hook.RunAsync();
