using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using System.IO;
using System.Linq;

namespace HeritageWalk
{
    public partial class TrailDetailsController : UIViewController
    {
        public SoundPlayer soundPlayer = new SoundPlayer();
        private string pathToDatabase;
        List<string> ImageList = new List<string>();
        int count;
        stop Stop;

        public TrailDetailsController (IntPtr handle) : base (handle)
        {
            UIImage image = UIImage.FromBundle("Artboard 1.png");
            UIImageView TitleImage = new UIImageView(image);
            this.NavigationItem.TitleView= TitleImage;
            ImageList.Add("013939d.jpg");
            ImageList.Add("barrack st southbound.jpg");
            ImageList.Add("circa1890.jpg");
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DescriptionText.Text = Stop.description;
            StopNameText.Title = Stop.name;
        }

        public void SetStopDetails(stop stop){
            this.Stop = stop;
        }

        partial void LeftCarouselBtn_TouchUpInside(UIButton sender)
        {
            if (count >= ImageList.Count -1) 
            {
                count = 0; 
                Carousel.Image = UIImage.FromBundle(ImageList[count]);  
            }
            else 
            {
                count++;
                Carousel.Image = UIImage.FromBundle(ImageList[count]);


            }



        }

        partial void RightCarouselBtn_TouchUpInside(UIButton sender)
        {
            if (count <= 0) 
            {
                count = ImageList.Count-1; 
                Carousel.Image = UIImage.FromBundle(ImageList[count]); 
            }
            else 
            {
                count--; 
                Carousel.Image = UIImage.FromBundle(ImageList[count]); 
            }
        }
   
        partial void PlayBtn_TouchUpInside(UIButton sender)
        {

            soundPlayer.PlayMusic();
        }

        partial void StopBtn_TouchUpInside(UIButton sender)
        {
            soundPlayer.StopMusic();
        }

        partial void PauseBtn_TouchUpInside(UIButton sender)
        {
            soundPlayer.PauseMusic();
        }
    }
}