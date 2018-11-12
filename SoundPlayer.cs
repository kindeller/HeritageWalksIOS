using System;
using UIKit; using AVFoundation; using AudioToolbox;   using Foundation;
namespace HeritageWalk
{
    public class SoundPlayer
    {
          AVAudioPlayer player;
          public float MusicVolume { get; set; } = 0.5f;
          public bool MusicOn { get; set; } = true;
       
          public SoundPlayer()
          {



          }
            public void PlayMusic() 
            {  
                NSUrl songURL;  
                if (!MusicOn) return;  
                //Song url from your local Resource  
                songURL = new NSUrl("Sound.aiff");  
                NSError err;  
                player = new AVAudioPlayer(songURL, "Song", out err);  
                player.Volume = MusicVolume;  
                player.FinishedPlaying += delegate {  
                // backgroundMusic.Dispose();  
                    player = null;  
                } ;  
                //Background Music play  
                player.Play();  
            } 
            
        public void StopMusic()
        {
            player.Stop();
        }
        public void PauseMusic()
        {
            player.Pause();
        }
        public void FastFoward(Double Timeheld)
        {
            double CurrentTime = player.CurrentTime;
            double NewTime = CurrentTime + Timeheld;
            player.PlayAtTime(NewTime);
            
        }
        public void Rewind(Double Timeheld)
        {
            double CurrentTime = player.CurrentTime;
            double NewTime = CurrentTime - Timeheld;
            player.PlayAtTime(NewTime);
            
        }
    
      
   




    }
}
