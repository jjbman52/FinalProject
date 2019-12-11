using System;
using System.ComponentModel;
using FinalProject.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        Character character;

        public AboutPage()
        {
            InitializeComponent();
        }
    }
}