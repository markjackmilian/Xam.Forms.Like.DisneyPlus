using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Views;
using Xam.Forms.Like.DisneyPlus.Android.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(Shell), typeof(TabbedControllerPageRender))]
namespace Xam.Forms.Like.DisneyPlus.Android.Renderers
{
    public class TabbedControllerPageRender : ShellRenderer
    {
        private IPageController PageController => this.Element as IPageController;

        public TabbedControllerPageRender(Context context) : base(context)
        {
        }
        
        
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            var res = base.CreateShellItemRenderer(shellItem);


            return res;
        }

        protected override void OnElementSet(Shell shell)
        {
            base.OnElementSet(shell);

            
            for (int i = 0; i <= this.ViewGroup.ChildCount - 1; i++)
            {
                var childView = this.ViewGroup.GetChildAt(i);
                if (childView is ViewGroup viewGroup)
                {
                    childView.Background = new ColorDrawable(Color.Red);
                    // for (int j = 0; j <= viewGroup.ChildCount - 1; j++)
                    // {
                    //     var childRelativeLayoutView = viewGroup.GetChildAt(j);
                    //     if (childRelativeLayoutView is BottomNavigationView)
                    //     {
                    //         ((BottomNavigationView)childRelativeLayoutView).ItemIconTintList = null;
                    //     }
                    // }
                }
            }
        }
    }

    // public class TodoShellItemRenderer : ShellItemRenderer
    // {
    //     public TodoShellItemRenderer(TabbedControllerPageRender tabbedControllerPageRender) : base(tabbedControllerPageRender)
    //     { }
    //     
    //     public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    //     {
    //         var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);
    //         _bottomView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);
    //         _shellOverlay = outerlayout.FindViewById<FrameLayout>(Resource.Id.bottomtab_tabbar_container);
    //
    //         if (ShellItem is TodoTabBar todoTabBar && todoTabBar.LargeTab != null)
    //             SetupLargeTab();
    //
    //         return outerlayout;
    //     }
    //
    //
    //     public void Dispose()
    //     {
    //         
    //     }
    //
    //     public Fragment Fragment { get; }
    //     public ShellItem ShellItem { get; set; }
    //     public event EventHandler Destroyed;
    // }
}