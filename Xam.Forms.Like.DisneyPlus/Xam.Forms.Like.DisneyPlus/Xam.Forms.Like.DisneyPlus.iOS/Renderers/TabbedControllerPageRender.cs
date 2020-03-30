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
            myTabBar.BarTintColor = UIColor.Black; // todo

            myTabBar.Subviews.ForEach(f =>
            {
                var ff = f.Frame;
                var fff = f.GetFrame();
            });


            if (myTabBar.Items != null)
            {
                var itemOne = myTabBar.Items[3];

                itemOne.Image = UIImage.FromBundle("face.png")
                    .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                itemOne.SelectedImage = UIImage.FromBundle("face.png")
                    .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

                itemOne.Title = string.Empty;

                itemOne.ImageInsets = new UIEdgeInsets(6, 0, -6, 0);



                // var theView = new ProfileTabItem(false);
                //
                // var view = ConvertFormsToNative(theView,
                //     new CGRect(myTabBar.Subviews[3].Frame.X, 6, 60, 60));
                //
                // myTabBar.AddSubview(view);


              
            }
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