using Android.App;
using Plugin.CurrentActivity;
using System;
using VFood.Droid.Util.Dialogs;
using VFood.Util.Dialogs;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogInformacaoDroid))]
namespace VFood.Droid.Util.Dialogs
{
    public class DialogInformacaoDroid : IDialogInformacao
    {
        private AlertDialog _dialog;

        public DialogInformacaoDroid()
        {
            var dialogBuilder = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
            _dialog = dialogBuilder.Create();
        }

        public void Abre(string mensagem)
        {
            _dialog.SetMessage(mensagem);
            _dialog.SetButton("Ok", (sender, args) =>
           {
               _dialog.Dismiss();
           });
            _dialog.Show();
        }

        public void Abre(string mensagem, Action onClose)
        {
            _dialog.DismissEvent += (sender, args) =>
            {
                onClose();
            };

            Abre(mensagem);
        }

        public void Abre(string titulo, string mensagem, Action onClose)
        {
            _dialog.DismissEvent += (sender, args) =>
            {
                onClose();
            };
        }

        public void Abre(string titulo, string mensagem)
        {
            _dialog.SetTitle(titulo);
            Abre(mensagem);
        }
    }
}