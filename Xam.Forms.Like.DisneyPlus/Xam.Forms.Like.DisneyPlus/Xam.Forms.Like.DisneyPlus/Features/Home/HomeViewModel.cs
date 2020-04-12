using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using Xam.Forms.Like.DisneyPlus.Classes;
using Xam.Forms.Like.DisneyPlus.Features.Detail;
using Xam.Zero.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Xam.Forms.Like.DisneyPlus.Features.Home
{
    public class HomeViewModel : ZeroBaseModel
    {
        public ICommand GoToDetailCommand { get; set; }
        public CircularObservableCollection<HeaderItem> HeaderItems { get; set; }
        public HeaderItem CurrentHeaderItem { get; set; }

        public bool PageIsReady { get; set; }


        public HomeViewModel()
        {
            this.GoToDetailCommand = new Command(async ()=> await base.Push<DetailPage>());
        }

        /// <summary>
        /// Called automagically from PropertyChanged.Refit
        /// </summary>
        public void OnCurrentHeaderItemChanged()
        {
            this.HeaderItems.SetCurrentIndex(this.CurrentCenterIndex);
            this.HeaderItems.ForEach(f => f.Scale = 0.95);
            this.CurrentHeaderItem.Scale = 1;
            
            // this.HeaderItems = new CircularObservableCollection<HeaderItem>(this.HeaderItems.ToArray());
            // base.RaisePropertyChanged(()=> this.HeaderItems);
        }

        protected override void PrepareModel(object data)
        {
            base.PrepareModel(data);
            
            this.HeaderItems = new CircularObservableCollection<HeaderItem>(new List<HeaderItem>
            {
                new HeaderItem
                {
                    Source = "destiny.jpg"
                },
                new HeaderItem
                {
                    Source = "lion.jpg"
                }, new HeaderItem
                {
                    Source = "mandalorian.jpg"
                },
                new HeaderItem
                {
                    Source = "panther.jpg"
                },
                new HeaderItem
                {
                    Source = "dolphin.jpg"
                },
            }.ToArray()); 
        }

        private CarouselView Carousel => ((HomePage) this.CurrentPage).CarouselView;
        private int CurrentCenterIndex => this.HeaderItems.IndexOf(this.CurrentHeaderItem);

        protected override async void CurrentPageOnAppearing(object sender, EventArgs e)
        {
            await Task.Delay(50);
            await MainThread.InvokeOnMainThreadAsync(() => { this.Carousel.Position = 2; });
            this.PageIsReady = true;
            
            // Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            // {
            //     var nextPosition = ++this.Carousel.Position;
            //     this.Carousel.ScrollTo(this.HeaderItems[nextPosition]);
            //     return true;
            // } );
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class HeaderItem
    {
        public HeaderItem()
        {
            this.Scale = 0.95;
        }
        
        public string Source { get; set; }
        public double Scale { get; set; }
    }

   
}