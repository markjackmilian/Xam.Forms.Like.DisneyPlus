using System.Windows.Input;
using Xam.Zero.ViewModels;
using Xamarin.Forms;

namespace Xam.Forms.Like.DisneyPlus.Features.Detail
{
    public class DetailViewModel : ZeroBaseModel
    {
        public ICommand BackCommand { get; set; }


        public DetailViewModel()
        {
            this.BackCommand = new Command(async ()=> await this.Pop());
        }
    }
}