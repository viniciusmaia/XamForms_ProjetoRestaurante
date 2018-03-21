using Ricardo.RMBProgressHUD.iOS;
using System;
using VFood.iOS.Util;
using VFood.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogCarregamentoiOS))]
namespace VFood.iOS.Util
{
    public class DialogCarregamentoiOS : IDialogCarregamento
    {
        private MBProgressHUD _progressDialog;
        private Action _onClose;

        public DialogCarregamentoiOS()
        {
            _progressDialog = new MBProgressHUD();
        }

        public void Finaliza()
        {
            _progressDialog.Hide(true);
        }

        public void Inicia(string titulo, string mensagem, bool cancelavel)
        {
            _progressDialog.Label.Text = titulo;

            Inicia(mensagem, cancelavel);
        }

        public void Inicia(string mensagem, bool cancelavel)
        {
            _progressDialog.DetailsLabel.Text = mensagem;
            _progressDialog.UserInteractionEnabled = cancelavel;
            _progressDialog.Show(true);
        }
    }
}