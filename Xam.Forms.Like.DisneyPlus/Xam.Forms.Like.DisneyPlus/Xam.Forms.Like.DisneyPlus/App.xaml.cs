using System;
using DryIoc;
using Xam.Zero;
using Xam.Zero.DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#if DEBUG
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
#endif

namespace Xam.Forms.Like.DisneyPlus
{
    public partial class App : Application
    {
        public static readonly Container Container = new Container();
        
        public App()
        {
            InitializeComponent();
            
            #if DEBUG
            HotReloader.Current.Run(this);
            #endif
            
            this.ConfigureContainer();
            ZeroApp.On(this)
                .WithContainer(DryIocZeroContainer.Build(Container))
                .RegisterShell(() => new AppShell())
                .StartWith<AppShell>();
        }

        private void ConfigureContainer()
        {
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}