﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DIGICODE.Models;
using DIGICODE.ViewModels;

namespace DIGICODE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
          //  InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
          //  InitializeComponent();

            var item = new Item
            {
                nom = "Item 1",
                ville = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}