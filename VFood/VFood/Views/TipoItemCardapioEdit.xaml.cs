﻿using System;
using System.Diagnostics;
using VFood.ViewModels;
using Xamarin.Forms;

namespace VFood.Views
{
    public partial class TipoItemCardapioEdit : ContentPage
    {
        public TipoItemCardapioEdit()
        {
            InitializeComponent();

            var viewModel = BindingContext as TipoItemCardapioEditViewModel;

            viewModel.DisplayAlert = (titulo, mensagem, textoBotao) =>
            {
                DisplayAlert(titulo, mensagem, textoBotao);
            };

            viewModel.ExibeOpcaoRemover = () =>
            {
                var removeItem = new ToolbarItem();
                removeItem.Command = viewModel.RemoverCommand;
                removeItem.Priority = 0;
                removeItem.Order = ToolbarItemOrder.Primary;

                if (Device.RuntimePlatform == Device.iOS)
                {
                    removeItem.Name = "Trash";
                }
                else
                {
                    removeItem.Icon = "ic_delete.png";
                }

                ToolbarItems.Add(removeItem);
            };
        }
    }
}
