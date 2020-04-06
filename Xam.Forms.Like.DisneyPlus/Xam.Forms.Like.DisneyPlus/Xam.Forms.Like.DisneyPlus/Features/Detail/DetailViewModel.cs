using System.Windows.Input;
using Xam.Forms.Like.DisneyPlus.Services;
using Xam.Zero.ViewModels;
using Xamarin.Forms;

namespace Xam.Forms.Like.DisneyPlus.Features.Detail
{
    public class DetailViewModel : ZeroBaseModel
    {
        private readonly INotchService _notchService;
        public ICommand BackCommand { get; set; }

        
        private bool _hasNotch;
        public bool HasNotch
        {
            get => this._hasNotch;
            set
            {
                this._hasNotch = value;
                // base.RaisePropertyChanged();
            }
        }


        public DetailViewModel(INotchService notchService)
        {
            this._notchService = notchService;
            this.BackCommand = new Command(async ()=> await this.Pop());
        }


        protected override void PrepareModel(object data)
        {
            this.HasNotch = this._notchService.DeviceHasNotch();
        }
    }
}