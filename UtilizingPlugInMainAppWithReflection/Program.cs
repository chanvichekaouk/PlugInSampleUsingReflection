using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilizingPlugInMainAppWithReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ourPlugInDLL = @"C:\temp\MyPlugIn.dll";
            // Note MyPlugIn.dll is the library .dll we compile from our earlier Library project MyPlugIn
            Assembly myPluginAssembly = Assembly.LoadFrom(ourPlugInDLL);

            if (myPluginAssembly == null)
            {
                Console.WriteLine($" Assembly {ourPlugInDLL} is not loaded. Please double check if DLL path is correct!");
                return;
            }

            // Next we will load our type from out plugin, instantiate it, and call Greet at runtime...
            // Note that we need to use full namespace.class where class has to be public access modifieer
            string typeName = "MyPlugIn.Greeting";
            Type myPluginType = myPluginAssembly.GetType(typeName);

            if (myPluginType == null)
            {
                Console.WriteLine($" Type {typeName} is not found.");
                return;
            }

            // instantiate our PlugIn 
            object myPluginInstance = Activator.CreateInstance(myPluginType);

            // Execute our PlugIn's action Greet(name)
            object msgFromPlugIn = myPluginType.GetMethod("Greet")?.Invoke(myPluginInstance, new object[] { "Vic" });
            Console.WriteLine(msgFromPlugIn);
            Console.WriteLine("Done");
        }
    }
}
