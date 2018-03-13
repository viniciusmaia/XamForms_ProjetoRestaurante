using System;
using System.IO;
using VFood.DAO;
using VFood.iOS.DAO;
using VFood.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(ControleArquivoDBiOS))]
namespace VFood.iOS.DAO
{
    public class ControleArquivoDBiOS : IControleArquivoDB
    {
        public string Path
        {
            get
            {
                string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return System.IO.Path.Combine(libFolder, Constantes.NomeArquivoDB);
            }
        }
    }
}