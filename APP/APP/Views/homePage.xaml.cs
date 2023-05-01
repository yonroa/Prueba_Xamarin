﻿using APP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class homePage : ContentPage
    {
        public homePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

        private async void LoadItems()
        {
            lista_usuarios.ItemsSource = await App.UsuarioManager.GetUsersAsync();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addPage());
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmacion", "Estas seguro de eliminar el usuario?", "Si", "No"))
            {
                var item = (UsuarioItem)(sender as MenuItem).CommandParameter;
                var result = await App.UsuarioManager.DeleteUserAsync(item);
                if (result == 1)
                {
                    LoadItems();
                }
            }
        }
    }
}