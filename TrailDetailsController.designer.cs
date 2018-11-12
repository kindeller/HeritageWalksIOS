// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace HeritageWalk
{
    [Register ("TrailDetailsControler")]
    partial class TrailDetailsController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Carousel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView DescriptionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton fastFowardBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LeftCarouselBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton pauseBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton playBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton rewindBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RightCarouselBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton stopBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem StopNameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar StopNameTitle { get; set; }

        [Action ("LeftCarouselBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LeftCarouselBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("PauseBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PauseBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("PlayBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PlayBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("RightCarouselBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void RightCarouselBtn_TouchUpInside (UIKit.UIButton sender);

        [Action ("StopBtn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StopBtn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Carousel != null) {
                Carousel.Dispose ();
                Carousel = null;
            }

            if (DescriptionText != null) {
                DescriptionText.Dispose ();
                DescriptionText = null;
            }

            if (fastFowardBtn != null) {
                fastFowardBtn.Dispose ();
                fastFowardBtn = null;
            }

            if (LeftCarouselBtn != null) {
                LeftCarouselBtn.Dispose ();
                LeftCarouselBtn = null;
            }

            if (pauseBtn != null) {
                pauseBtn.Dispose ();
                pauseBtn = null;
            }

            if (playBtn != null) {
                playBtn.Dispose ();
                playBtn = null;
            }

            if (rewindBtn != null) {
                rewindBtn.Dispose ();
                rewindBtn = null;
            }

            if (RightCarouselBtn != null) {
                RightCarouselBtn.Dispose ();
                RightCarouselBtn = null;
            }

            if (stopBtn != null) {
                stopBtn.Dispose ();
                stopBtn = null;
            }

            if (StopNameText != null) {
                StopNameText.Dispose ();
                StopNameText = null;
            }

            if (StopNameTitle != null) {
                StopNameTitle.Dispose ();
                StopNameTitle = null;
            }
        }
    }
}