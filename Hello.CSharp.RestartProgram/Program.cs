using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

Console.Write("Press enter to generate dynamic assembly ...");

Console.ReadLine();

var assemblyName = new AssemblyName("DynamicAssembly");
var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);

var moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule", "DynamicAssembly.dll");

var typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);

var methodBuilder = typeBuilder.DefineMethod("DynamicMethod", MethodAttributes.Public | MethodAttributes.Static, typeof(void), null);

var ilGenerator = methodBuilder.GetILGenerator();

ilGenerator.Emit(OpCodes.Ldstr, "Hello, world!");
ilGenerator.Emit(OpCodes.Ldstr, "output.txt");

var writeLineMethod = typeof(File).GetMethod("AppendAllText", new[] { typeof(string) });
ilGenerator.EmitCall(OpCodes.Call, writeLineMethod, null);

ilGenerator.Emit(OpCodes.Ret);

var dynamicType = typeBuilder.CreateType();

assemblyBuilder.Save("DynamicAssembly.dll");

AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
{
    var dynamicAssembly = Assembly.LoadFrom("DynamicAssembly.dll");
    var dynamicTypeLoaded = dynamicAssembly.GetType("DynamicType");
    var dynamicMethodLoaded = dynamicTypeLoaded.GetMethod("DynamicMethod");
    dynamicMethodLoaded.Invoke(null, null);
};

Console.Write("Press enter to restart the program ...");

Console.ReadLine();

Environment.Exit(0);
