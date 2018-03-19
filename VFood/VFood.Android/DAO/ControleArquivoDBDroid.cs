using System;
using VFood.DAO;
using VFood.Droid.DAO;
using VFood.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(ControleArquivoDBDroid))]
namespace VFood.Droid.DAO
{
    public class ControleArquivoDBDroid : IControleArquivoDB
    {
        public string Path
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                return System.IO.Path.Combine(path, Constantes.NomeArquivoDB);
            }
        }
    }
}