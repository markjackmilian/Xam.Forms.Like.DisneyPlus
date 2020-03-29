using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Forms.Like.DisneyPlus.Features.Home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

        }

        private void ItemsView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            Console.WriteLine($"{e.FirstVisibleItemIndex} - {e.LastVisibleItemIndex}");
            Console.WriteLine(e.FirstVisibleItemIndex);
        }


        private void CarouselView_OnPositionChanged(object sender, PositionChangedEventArgs e)
        {
            var carousel = (CarouselView) sender;
            ((Image) carousel.LogicalChildren[e.CurrentPosition]).HeightRequest = 50;
        }
    }
}