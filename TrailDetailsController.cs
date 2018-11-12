using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using System.IO;
using System.Linq;

namespace HeritageWalk
{
    public partial class TrailDetailsControllerBum : UIViewController
    {
        public SoundPlayer soundPlayer = new SoundPlayer();
        private string pathToDatabase;
        List<string> imagelistCarousel= new List<string>();
        int count;
        float relativeFontConstant = 0.059f;
        double CurrentRewind = 0;
        double CurrentFastForward = 0;
        bool MusicStoped = false;



        public TrailDetailsControllerBum (IntPtr handle) : base (handle)
        {
            UIImage image = UIImage.FromBundle("Artboard 1.png");
            UIImageView TitleImage = new UIImageView(image);
            this.NavigationItem.TitleView= TitleImage;
            imagelistCarousel.Add("013939d.jpg");
            imagelistCarousel.Add("barrack st southbound.jpg");
            imagelistCarousel.Add("circa1890.jpg");
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            double width = UIScreen.MainScreen.Bounds.Size.Width / 4;
            double height = UIScreen.MainScreen.Bounds.Size.Height / 4;

            DisciptionTxt.Font = DisciptionTxt.Font.WithSize(DisciptionTxt.Frame.Height * relativeFontConstant);
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            pathToDatabase = NSBundle.MainBundle.PathForResource("HeritageWalkLite", "db");

            using (var connection = new SQLite.SQLiteConnection(pathToDatabase))
            {
                List<Trail> trails = connection.Table<Trail>().ToList();
                List<stop> stops = connection.Table<stop>().ToList();
                DisciptionTxt.Text = stops[0].description;
                TitleLBL.Text = stops[0].name;
            }

        }


        partial void LeftCarouselBtn_TouchUpInside(UIButton sender)
        {
            if (count >= imagelistCarousel.Count -1) 
            {
                count = 0; 
                Carousel.Image = UIImage.FromBundle(imagelistCarousel[count]);  
            }
            else 
            {
                count++;
                Carousel.Image = UIImage.FromBundle(imagelistCarousel[count]);


            }



        }

        partial void RightCarouselBtn_TouchUpInside(UIButton sender)
        {
            if (count <= 0) 
            {
                count = imagelistCarousel.Count-1; 
                Carousel.Image = UIImage.FromBundle(imagelistCarousel[count]); 
            }
            else 
            {
                count--; 
                Carousel.Image = UIImage.FromBundle(imagelistCarousel[count]); 
            }
        }
   
        partial void PlayBtn_TouchUpInside(UIButton sender)
        {

            MusicStoped =  soundPlayer.PlayMusic(MusicStoped);
        }

        partial void StopBtn_TouchUpInside(UIButton sender)
        {
            MusicStoped = soundPlayer.StopMusic();
        }

        partial void PauseBtn_TouchUpInside(UIButton sender)
        {
            soundPlayer.PauseMusic();
        }

        partial void Rewind_Down(UIButton sender)
        {
            if(soundPlayer.isPlaying()) 
            {
                double MaxRewind = 50;

                if (CurrentRewind < MaxRewind)
                {
                    CurrentRewind = CurrentRewind + 10;

                }
                soundPlayer.Rewind(CurrentRewind);
                
            }
          
        }

        partial void Rewind_TouchUpInside(UIButton sender)
        {
            CurrentRewind = 0;
        }

        partial void FastForward_TouchUpInside(UIButton sender)
        {
            CurrentFastForward = 0;
        }

        partial void FastForward_Down(UIButton sender)
        {
            if(soundPlayer.isPlaying()) 
            {
                double MaxFastForward = 50;

                if (CurrentFastForward < MaxFastForward)
                {
                    CurrentFastForward = CurrentFastForward + 10;

                }
                soundPlayer.FastFoward(CurrentFastForward);  
            }


            
        }



    }
}