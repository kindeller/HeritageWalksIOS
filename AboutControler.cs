using Foundation;
using System;
using System.Drawing;
using CoreGraphics;
using UIKit;

namespace HeritageWalk
{
    public partial class AboutControler : UIViewController
    {
        public AboutControler (IntPtr handle) : base (handle)
        {
            UIImage image = UIImage.FromBundle("Artboard 1.png");
            UIImageView TitleImage = new UIImageView (
            );
            TitleImage.Image = image;
            this.NavigationItem.TitleView = TitleImage;


        }
    }
}