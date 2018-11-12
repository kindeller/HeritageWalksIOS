using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace HeritageWalk
{
    public partial class ViewController : UIViewController
    {
        List<stop> stops;
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

            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String pathToDatabase = NSBundle.MainBundle.PathForResource("HeritageWalkLite", "db");

            using (var connection = new SQLite.SQLiteConnection(pathToDatabase))
            {
                stops = connection.Table<stop>().ToList();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if (segue.DestinationViewController is MapViewController)
            {
                ((MapViewController)segue.DestinationViewController).SetStops(stops);
            }
        }
    }
}
