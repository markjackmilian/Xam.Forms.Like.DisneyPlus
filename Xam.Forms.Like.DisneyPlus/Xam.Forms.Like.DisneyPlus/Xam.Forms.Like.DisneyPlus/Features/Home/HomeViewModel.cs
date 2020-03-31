using System.Collections.Generic;
using PropertyChanged;
using Xam.Zero.ViewModels;
using Xamarin.Forms;

namespace Xam.Forms.Like.DisneyPlus.Features.Home
{
    public class HomeViewModel : ZeroBaseModel
    {
        public List<HeaderItem> HeaderItems { get; set; }
        public HeaderItem CurrentHeaderItem { get; set; }

        public void OnCurrentHeaderItemChanged()
        {
            this.HeaderItems.ForEach(f => f.Scale = 0.8);
            this.CurrentHeaderItem.Scale = 1;
        }
      

        protected override void PrepareModel(object data)
        {
            base.PrepareModel(data);
            
            this.HeaderItems = new List<HeaderItem>
            {
                new HeaderItem
                {
                    Source = "mandalorian.jpg"
                },
                new HeaderItem
                {
                    Source = "mandalorian.jpg"
                }, new HeaderItem
                {
                    Source = "mandalorian.jpg"
                },
            };
            
        }

    }

    [AddINotifyPropertyChangedInterface]
    public class HeaderItem
    {
        public HeaderItem()
        {
            this.Scale = 0.98;
        }
        
        public string Source { get; set; }
        public double Scale { get; set; }
    }

   
}