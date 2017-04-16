using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Banana_Scripting
{
    static class BananaScript
    {

        static public List<GameObject> LoadGameObjects()
        {
            return null;
        }

        static public void Test()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
