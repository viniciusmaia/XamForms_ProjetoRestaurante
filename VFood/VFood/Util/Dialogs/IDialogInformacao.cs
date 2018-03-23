using System;

namespace VFood.Util.Dialogs
{
    public interface IDialogInformacao
    {
        void Abre(string mensagem);
        void Abre(string mensagem, Action onClose);
        void Abre(string titulo, string mensage, Action onClose);
        void Abre(string titulo, string mensagem);
    }
}
