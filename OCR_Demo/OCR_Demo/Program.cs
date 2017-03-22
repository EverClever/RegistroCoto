using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using MySql;

namespace OCR_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            /*string line = "<https://msdn.microsoft.com/en-us/library/fk49wtc1(v=vs.110).aspx>";
            string result = line.Replace("<https://msdn.microsoft.com/en-us/library/fk49wtc1(v=vs.110).aspx>", "HoLA");

            Console.WriteLine("String original: {0}", line);
            Console.WriteLine("String nuevo: {0}", result);*/

           /*Interfaz MainInterfaz=new Interfaz();
           MainInterfaz.Show();*/
           // MySQLconn mysqlconn = new MySQLconn();
            //mysqlconn.SP();
            Console.WriteLine();

            

            var test = @"C:\Users\poucel\Documents\ImagesTest\test3.jpg";

            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "spa_old", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(test))
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();

                            Console.WriteLine("Precision de: {0}", page.GetMeanConfidence());

                            Console.WriteLine("Texto: {0}", texto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }

            finally
            {
                Console.ReadLine();
            }
        }
    }
}
