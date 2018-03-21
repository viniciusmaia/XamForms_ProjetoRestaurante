using System;

namespace VFood.Util
{
    public interface IDialogCarregamento
    {
        void Inicia(string titulo, string mensagem, bool cancelavel);
        void Inicia(string mensagem, bool cancelavel);
        void Finaliza();
    }
}
