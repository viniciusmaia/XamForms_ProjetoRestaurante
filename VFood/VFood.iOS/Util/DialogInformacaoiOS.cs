using System;
using UIKit;
using VFood.iOS.Util;
using VFood.Util.Dialogs;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogInformacaoiOS))]
namespace VFood.iOS.Util
{
    public class DialogInformacaoiOS : IDialogInformacao
    {
        

        public void Abre(string mensagem)
        {
            var dialog = new UIAlertController();
            dialog.Message = mensagem;
            var okAction = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null);
            dialog.AddAction(okAction);
        }

        public void Abre(string mensagem, Action onClose)
        {
            var dialog = new UIAlertController();
            dialog.Message = mensagem;

            var okAction = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (alertAction) =>
            {
                onClose();
            });

            dialog.AddAction(okAction);

        }

        public void Abre(string titulo, string mensagem, Action onClose)
        {
            var dialog = new UIAlertController();
            dialog.Message = mensagem;
            dialog.Title = titulo;

            var okAction = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (alertAction) =>
            {
                onClose();
            });

            dialog.AddAction(okAction);
        }

        public void Abre(string titulo, string mensagem)
        {
            var dialog = new UIAlertController();
            dialog.Message = mensagem;
            dialog.Title = titulo;

            var okAction = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null);

            dialog.AddAction(okAction);
        }
    }
}