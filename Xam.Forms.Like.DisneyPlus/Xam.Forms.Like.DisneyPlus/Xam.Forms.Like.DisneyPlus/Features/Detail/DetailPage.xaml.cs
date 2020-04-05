using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;

namespace Xam.Forms.Like.DisneyPlus.Features.Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        /// <summary>
        /// Scroll start (ex 44 case iphone with notch)
        /// </summary>
        private int _startValue;

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

            // manager start from under zero
            if (this._startValue == 0)
            {
                this._startValue = (int) e.ScrollY;
                return;
            }
            //
            // if (e.ScrollY < 0) return;
            
            this.Spacer.Opacity = e.ScrollY / this.BackImage.Height;


            var realScroll = e.ScrollY -this._startValue;
            // animation for ngLogo flatterized in 50
            var bigLogoOpacity = 1-realScroll/50;

            this.Logo.Opacity = bigLogoOpacity;
            this.Logo.Scale = bigLogoOpacity > 1 ? 1 : bigLogoOpacity;
            
            this.Logo.TranslationY = e.ScrollY*-1;

            this.ManageBlurOnIos(realScroll);
        }

        private void ManageBlurOnIos(double realScroll)
        {
            if (Device.RuntimePlatform == Device.Android) return;

            if (realScroll > 200)
            {
                this.NavBack.BackgroundColor = Color.Transparent;
                this.NavBack.On<iOS>().UseBlurEffect(BlurEffectStyle.Dark);
            }
            else
            {
                this.NavBack.BackgroundColor = (Color)Application.Current.Resources["DarkBackColor"];
                this.NavBack.On<iOS>().UseBlurEffect(BlurEffectStyle.None);
            }
        }
    }
}