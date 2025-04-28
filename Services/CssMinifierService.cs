using NUglify;
using System;
using System.IO;

public class CssMinifierService
{
    public static void MinifyCss(string inputFile, string outputFile)
    {
        try
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Soubor {inputFile} neexistuje.");
                return;
            }

            string cssContent = File.ReadAllText(inputFile);
            UglifyResult minified = Uglify.Css(cssContent);

            if (minified.HasErrors)
            {
                Console.WriteLine("Chyba při minimalizaci CSS:");
                foreach (var error in minified.Errors)
                {
                    Console.WriteLine(error.Message);
                }
                return;
            }

            File.WriteAllText(outputFile, minified.Code);
            Console.WriteLine($"Minimalizovaný soubor vytvořen: {outputFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Chyba: {ex.Message}");
        }
    }
}
