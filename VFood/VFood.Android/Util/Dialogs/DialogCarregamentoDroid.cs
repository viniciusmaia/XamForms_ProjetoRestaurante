using Android.App;
using Android.Content;
using Plugin.CurrentActivity;
using VFood.Droid.Util.Dialogs;
using VFood.Util.Dialogs;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogCarregamentoDroid))]
namespace VFood.Droid.Util.Dialogs
{
    public class DialogCarregamentoDroid : IDialogCarregamento
    {
        private Context _context;
        private ProgressDialog _progressDialog;

        public DialogCarregamentoDroid()
        {
            _context = CrossCurrentActivity.Current.Activity;
        }

        public void Finaliza()
        {
            if (_progressDialog != null)
            {
                _progressDialog.Dismiss();
            }
        }

        public void Inicia(string mensagem, bool cancelavel)
        {
            _progressDialog = new ProgressDialog(_context);
            _progressDialog.SetMessage(mensagem);
            _progressDialog.SetCancelable(cancelavel);
            _progressDialog.Show();

        }

        public void Inicia(string titulo, string mensagem, bool cancelavel)
        {
            _progressDialog = new ProgressDialog(_context);
            _progressDialog.SetTitle(titulo);
            _progressDialog.SetMessage(mensagem);
            _progressDialog.SetCancelable(cancelavel);
            _progressDialog.Show();
        }
    }
}