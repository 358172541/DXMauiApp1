﻿using DXMauiApp1.Models;
using DXMauiApp1.Services;

namespace DXMauiApp1.Pages
{
    public partial class ContactCreatePage : ContentPage
    {
        public ContactCreatePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Common.TextEditBaseRequired(TextEditName);
            Common.TextEditBaseRequired(TextEditNumber);
        }

        private void TextEditName_TextChanged(object sender, EventArgs e)
        {
            Common.TextEditBaseRequired(TextEditName);
        }

        private void TextEditNumber_TextChanged(object sender, EventArgs e)
        {
            Common.TextEditBaseRequired(TextEditNumber);
        }

        private async void ButtonSubmit_Clicked(object sender, EventArgs e)
        {
            if (Common.TextEditBaseRequired(TextEditName) &&
                Common.TextEditBaseRequired(TextEditNumber))
            {
                await ContactService.CreateAsync(
                    new ContactCreateModel
                    {
                        Name = TextEditName.Text,
                        Number = TextEditNumber.Text
                    });

                await Shell.Current.GoToAsync("..", true);
            }
        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}