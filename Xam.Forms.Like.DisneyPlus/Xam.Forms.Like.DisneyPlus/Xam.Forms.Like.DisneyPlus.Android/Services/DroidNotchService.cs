using Xam.Forms.Like.DisneyPlus.Services;

namespace Xam.Forms.Like.DisneyPlus.Android.Services
{
    public class DroidNotchService : INotchService
    {
        public bool DeviceHasNotch()
        {
            return false;
        }
    }
}