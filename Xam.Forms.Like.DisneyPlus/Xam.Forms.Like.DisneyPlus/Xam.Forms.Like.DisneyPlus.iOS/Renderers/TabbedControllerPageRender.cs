using System;
using CoreGraphics;
using UIKit;
using Xam.Forms.Like.DisneyPlus.iOS.Renderers;
using Xam.Forms.Like.DisneyPlus.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(TabbedControllerPageRender))]
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
            myTabBar.Opaque = true;
            myTabBar.BarTintColor = ((Color)Xamarin.Forms.Application.Current.Resources["TabBarColor"]).ToUIColor();
            myTabBar.SelectedImageTintColor = UIColor.White;


            if (myTabBar.Items != null)
            {
                ShowTabItem(myTabBar.Items[0],"home.png");
                ShowTabItem(myTabBar.Items[1],"search.png");
                ShowTabItem(myTabBar.Items[2],"download.png");


                var itemThree = myTabBar.Items[3];

                itemThree.Image = UIImage.FromBundle("avatar.png")
                    .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                itemThree.SelectedImage = UIImage.FromBundle("avatar.png")
                    .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

                itemThree.Title = string.Empty;
                itemThree.ImageInsets = new UIEdgeInsets(6, 0, -6, 0);



                // var theView = new ProfileTabItem(false);
                //
                // var view = ConvertFormsToNative(theView,
                //     new CGRect(myTabBar.Subviews[3].Frame.X, 6, 60, 60));
                //
                // myTabBar.AddSubview(view);


              
            }
        }

        /// <summary>
        /// Set appearance of this tabitem
        /// </summary>
        /// <param name="itemOne"></param>
        /// <param name="homePng"></param>
        private static void ShowTabItem(UITabBarItem itemOne, string homePng)
        {
            itemOne.Image = UIImage.FromBundle(homePng);
            itemOne.SelectedImage = UIImage.FromBundle(homePng);
            itemOne.Title = string.Empty;
            itemOne.ImageInsets = new UIEdgeInsets(6, 0, -6, 0);
        }

        public static UIView ConvertFormsToNative(Xamarin.Forms.View view, CGRect size)
        {
            var renderer = Platform.CreateRenderer(view);

            renderer.NativeView.Frame = size;

            renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
            renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

            renderer.Element.Layout(size.ToRectangle());

            var nativeView = renderer.NativeView;

            nativeView.SetNeedsLayout();

            return nativeView;
        }

        public void UpdateLayout(UITabBarController controller)
        {
        }

        public void ResetAppearance(UITabBarController controller)
        {
        }
    }
}