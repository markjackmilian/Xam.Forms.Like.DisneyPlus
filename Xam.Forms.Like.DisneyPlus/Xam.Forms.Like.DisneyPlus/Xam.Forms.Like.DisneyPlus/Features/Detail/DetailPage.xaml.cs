using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Forms.Like.DisneyPlus.Features.Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine(this.Scroller.ScrollY);
            this.Scroller.SetScrolledPosition(0, 0);
            Console.WriteLine(this.Scroller.ScrollY);

        }

        private void ScrollView_OnScrolled(object sender, ScrolledEventArgs e)
        {
            
            var opacity = e.ScrollY / this.BackImage.Height;
            this.Spacer.Opacity = opacity;
            
            this.Logo.Opacity = 1 - e.ScrollY/100;
            this.Logo.Scale = 1 - e.ScrollY/100 > 1 ? 1 : e.ScrollY/100;
            
            this.Logo.TranslationY = e.ScrollY*-1;
        }
    }
}