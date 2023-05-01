using APP.Models;
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
    public partial class addPage : ContentPage
    {
        bool isNewUser;
        public addPage(bool isNew = true)
        {
            InitializeComponent();
            if (!isNew)
            {
                Titulo.Title = "Editar Usuario";
            }
            isNewUser = isNew;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            int result;
            try
            {
                if (isNewUser)
                {
                    var item = new UsuarioItem
                    {
                        Name = nombre.Text,
                        LastName = apellido.Text,
                        Phone = telefono.Text,
                        Email = correo.Text
                    };
                    result = await App.UsuarioManager.InsertUserAsync(item);
                } else
                {
                    var item = (UsuarioItem)BindingContext;
                    result = await App.UsuarioManager.UpdateUserAsync(item);
                }
                if (result == 1)
                {
                    await Navigation.PopAsync();
                } else
                {
                    await DisplayAlert("Error", "No se pudo crear el usuario", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}