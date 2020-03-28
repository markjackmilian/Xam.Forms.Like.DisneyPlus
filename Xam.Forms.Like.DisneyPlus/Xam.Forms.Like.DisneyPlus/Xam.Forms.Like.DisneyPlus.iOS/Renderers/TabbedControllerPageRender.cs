using System;
using UIKit;
using Xam.Forms.Like.DisneyPlus.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// [assembly: ExportRenderer(typeof(Shell), typeof(TabbedControllerPageRender))]
namespace Xam.Forms.Like.DisneyPlus.iOS.Renderers
{
    public class TabbedControllerPageRender : ShellRenderer
    {
        private IPageController PageController => this.Element as IPageController;



        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new CustomTabbarAppearance();
        }

        // protected override void OnElementChanged(VisualElementChangedEventArgs e)
        // {
        //     base.OnElementChanged(e);
        //     if (e.NewElement != null)
        //     {
        //         this.TabBar.Translucent = true;
        //
        //         var frame = this.View.Frame;
        //         Console.WriteLine("Page Controller Frame: " + frame);
        //         this.PageController.ContainerArea = new Rectangle(0, 0, frame.Width, frame.Height);
        //     }
        // }
    }
    
    public class CustomTabbarAppearance : IShellTabBarAppearanceTracker
    {
        public void Dispose()
        {

        }


        void IShellTabBarAppearanceTracker.SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            this.SetAppearance(controller, appearance);
        }

        void IShellTabBarAppearanceTracker.UpdateLayout(UITabBarController controller)
        {
            this.UpdateLayout(controller);
        }

        public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            UITabBar myTabBar = controller.TabBar;
            myTabBar.Translucent = true;

            // if (myTabBar.Items != null)
            // {
            //     UITabBarItem itemOne = myTabBar.Items[0];
            //
            //     itemOne.Image = UIImage.FromBundle("tab_about.png");
            //     itemOne.SelectedImage = UIImage.FromBundle("tab_feed.png");
            //
            //
            //     UITabBarItem itemTwo = myTabBar.Items[1];
            //
            //     itemTwo.Image = UIImage.FromBundle("tab_feed.png");
            //     itemTwo.SelectedImage = UIImage.FromBundle("tab_about.png");
            //
            //     //The same logic if you have itemThree, itemFour....
            // }

        }

        public void UpdateLayout(UITabBarController controller)
        {

        }

        public void ResetAppearance(UITabBarController controller)
        {
        }
    }
}