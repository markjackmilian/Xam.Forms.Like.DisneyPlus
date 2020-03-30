using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Forms.Like.DisneyPlus.Views
{
    public partial class ProfileTabItem : ContentView
    {
        public ProfileTabItem()
        {
            InitializeComponent();
        }

        public ProfileTabItem(bool isSelected)
        {
            InitializeComponent();
            this.PancakeView.BackgroundColor = isSelected ? Color.White : Color.Red;
        }

        
    }
}