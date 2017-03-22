using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using MySql;

namespace ConnectWebcam
{
    class OCR
    {
        public string OCRReader(string Picture) 
        {
            var test = Picture;
            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "spa_old", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(test))
                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();

                           // Console.WriteLine("Precision de: {0}", page.GetMeanConfidence());

                            return texto;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            finally
            {
                Console.ReadLine();
            }
        }
    }
}
