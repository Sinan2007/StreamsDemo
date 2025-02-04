using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsDemo
{
    public class PositionExample
    {
        public static void Execute()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] data = Encoding.UTF8.GetBytes("Hello, MemoryStream!");
                ms.Write(data, 0, data.Length);

                //Reset position to start reading
                ms.Position = 0;

                byte[] buffer = new byte[ms.Length];
                ms.Read(buffer, 0, buffer.Length);

                string result = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(result);
            }
        }
            
    }
}
