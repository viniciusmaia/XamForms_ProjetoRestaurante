using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.IO;
using System.Text;
using System.Windows.Input;
using VFood.Modelo;
using VFood.Service;
using VFood.Util;
using VFood.Util.Dialogs;
using Xamarin.Forms;

namespace VFood.ViewModels
{
	public class GarcomEditViewModel : ViewModelBase
    {
        private GarcomService _service;
        private byte[] _iconePadrao;

        public Action ExibeOpcaoRemover { get; set; }

        private Garcom _garcom;
        public Garcom Garcom
        {
            get { return _garcom; }
            set { SetProperty(ref _garcom, value); }
        }

        private bool _isNomeObrigatorioVisivel;
        public bool IsNomeObrigatorioVisivel
        {
            get { return _isNomeObrigatorioVisivel; }
            set { SetProperty(ref _isNomeObrigatorioVisivel, value); }
        }

        private bool _isSobrenomeObrigatorioVisivel;
        public bool IsSobrenomeObrigatorioVisivel
        {
            get { return _isSobrenomeObrigatorioVisivel; }
            set { SetProperty(ref _isSobrenomeObrigatorioVisivel, value); }
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


        public GarcomEditViewModel(INavigationService navigationService) : base(navigationService)
        {
            _service = new GarcomService();
            OcultaMensagensCamposObrigatorios();
            Title = "Garçom";
            _iconePadrao = DependencyService.Get<IIconeImagemPadrao>().GetIcone();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null && parameters.ContainsKey("garcom"))
            {
                Garcom = parameters["garcom"] as Garcom;
                ExibeOpcaoRemover();
            }
            else
            {
                Garcom = new Garcom();
                Garcom.Foto = _iconePadrao;
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
            OcultaMensagensCamposObrigatorios();

            if (CanSalvar())
            {
                _service.Salva(Garcom);
                var parameters = new NavigationParameters();
                parameters.Add("reload", true);
                NavigationService.GoBackAsync(parameters);
            }
        }

        private void ExecuteRemoverCommand()
        {
            _service.Remove(Garcom);

            var parameters = new NavigationParameters();
            parameters.Add("reload", true);

            NavigationService.GoBackAsync(parameters);
        }

        private bool CanSalvar()
        {
            var mensagemErroBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Garcom.Nome))
            {
                mensagemErroBuilder.Append("- Preencha os campos obrigatórios.\n");
                IsNomeObrigatorioVisivel = true;
            }

            if (string.IsNullOrWhiteSpace(Garcom.Sobrenome))
            {
                IsSobrenomeObrigatorioVisivel = true;

                if (string.IsNullOrWhiteSpace(mensagemErroBuilder.ToString()))
                {
                    mensagemErroBuilder.Append("- Preencha os campos obrigatórios.\n");
                }
            }

            if (Garcom.Foto.Equals(_iconePadrao) || Garcom.Foto == null)
            {
                mensagemErroBuilder.Append("- Anexe uma foto.");
            }

            var mensagemErro = mensagemErroBuilder.ToString();

            if (!string.IsNullOrWhiteSpace(mensagemErro))
            {
                var informacaoDialog = DependencyService.Get<IDialogInformacao>();
                informacaoDialog.Abre("Erro", mensagemErro);

                return false;
            }

            return true;
        }

        private void OcultaMensagensCamposObrigatorios()
        {
            IsSobrenomeObrigatorioVisivel = IsNomeObrigatorioVisivel = false;
        }

        private void CarregaFoto(MediaFile arquivoFoto)
        {
            if (arquivoFoto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    arquivoFoto.GetStream().CopyTo(memoryStream);
                    Garcom.Foto = memoryStream.ToArray();
                    RaisePropertyChanged("Garcom");
                }
            }
        }
    }
}
