
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.IO;
using System.Text;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;

namespace VFood.ViewModels
{
	public class TipoItemCardapioEditViewModel : ViewModelBase
	{
        private TipoItemCardapioService _service;

        public Action ExibeOpcaoRemover { get; set; }
        public Action<string, string, string> DisplayAlert;

        private TipoItemCardapio _tipoItemCardapio;
        public TipoItemCardapio TipoItemCardapio
        {
            get { return _tipoItemCardapio; }
            set { SetProperty(ref _tipoItemCardapio, value); }
        }

        private bool _isNomeObrigatorioVisivel;
        public bool IsNomeObrigatorioVisivel
        {
            get { return _isNomeObrigatorioVisivel; }
            set { SetProperty(ref _isNomeObrigatorioVisivel, value); }
        }

        private ICommand _cameraCommand;
        public ICommand CameraCommand
        {
            get
            {
                if (_cameraCommand == null)
                {
                    _cameraCommand = new DelegateCommand(ExecuteCameraCommand);
                }

                return _cameraCommand;
            }
        }

        private ICommand _galeriaCommand;
        public ICommand GaleriaCommand
        {
            get
            {
                if (_galeriaCommand == null)
                {
                    _galeriaCommand = new DelegateCommand(ExecuteGaleriaCommand);
                }

                return _galeriaCommand;
            }
        }

        private ICommand _salvarCommand;
        public ICommand SalvarCommand
        {
            get
            {
                if (_salvarCommand == null)
                {
                    _salvarCommand = new DelegateCommand(ExecuteSalvarCommand);
                }

                return _salvarCommand;
            }
        }

        private ICommand _removerCommand;
        public ICommand RemoverCommand
        {
            get
            {
                if (_removerCommand == null)
                {
                    _removerCommand = new DelegateCommand(ExecuteRemoverCommand);
                }

                return _removerCommand;
            }
        }


        public TipoItemCardapioEditViewModel(INavigationService navigationService) : base(navigationService)
        {
            _service = new TipoItemCardapioService();
            IsNomeObrigatorioVisivel = false;
            Title = "Item do Cardápio";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("itemCardapio"))
            {
                TipoItemCardapio = parameters["itemCardapio"] as TipoItemCardapio;
                ExibeOpcaoRemover();
            }
            else
            {
                TipoItemCardapio = new TipoItemCardapio();
            }
        }

        private async void ExecuteCameraCommand()
        {
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {

                var arquivoFoto = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "VFoodProjectPhotos",
                    SaveToAlbum = true
                });

                CarregaFoto(arquivoFoto);
            }            
        }

        private async void ExecuteGaleriaCommand()
        {
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                var arquivoFoto = await CrossMedia.Current.PickPhotoAsync();

                CarregaFoto(arquivoFoto);
            }
        }

        private void ExecuteSalvarCommand()
        {
            IsNomeObrigatorioVisivel = false;

            if (CanSalvar())
            {
                _service.Salva(TipoItemCardapio);
                var parameters = new NavigationParameters();
                parameters.Add("reload", true);
                NavigationService.GoBackAsync(parameters);
            }
        }

        private void ExecuteRemoverCommand()
        {
            _service.Remove(TipoItemCardapio);

            var parameters = new NavigationParameters();
            parameters.Add("reload", true);

            NavigationService.GoBackAsync(parameters);
        }

        private bool CanSalvar()
        {
            var mensagemErroBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TipoItemCardapio.Nome))
            {
                mensagemErroBuilder.Append("- Preencha os campos obrigatórios.");
                IsNomeObrigatorioVisivel = true;
            }

            if (TipoItemCardapio.Foto == null)
            {
                mensagemErroBuilder.Append("\n");
                mensagemErroBuilder.Append("- Anexe uma foto.");
            }

            var mensagemErro = mensagemErroBuilder.ToString();

            if (!string.IsNullOrWhiteSpace(mensagemErro))
            {
                DisplayAlert("Erro", mensagemErro, "Ok");

                return false;
            }

            return true;
        }

        private void CarregaFoto(MediaFile arquivoFoto)
        {
            if (arquivoFoto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    arquivoFoto.GetStream().CopyTo(memoryStream);
                    TipoItemCardapio.Foto = memoryStream.ToArray();
                    RaisePropertyChanged("TipoItemCardapio");
                }
            }
        }
    }
}
