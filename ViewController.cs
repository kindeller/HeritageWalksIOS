using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;

namespace HeritageWalk
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            UIImage image = UIImage.FromBundle("Artboard 1.png");
            UIImageView TitleImage = new UIImageView(image);
            this.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(0, 150, 136);
            this.NavigationController.NavigationBar.TintColor = UIColor.FromRGB(253, 201, 157);
            this.NavigationItem.TitleView = TitleImage;
          
         
            this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = UIColor.Orange,

            };
        
         

    
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

    }
}
