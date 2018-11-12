using System;
using CoreGraphics;
using MapKit;
using UIKit;

namespace HeritageWalk
{
    public class MapDelegate : MKMapViewDelegate
    {


        static string annotationId = "HeritageAnnotation";
        MapViewController Controller;

        public Action HandleAction { get; private set; }

        public MapDelegate(UIViewController controller)
        {
            Controller = controller as MapViewController;
        }

        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;

            if (annotation is MKUserLocation)
                return null;
            
            if (annotation is HeritageAnnotation)
            {
                annotationView = mapView.DequeueReusableAnnotation(annotationId);

                if (annotationView == null)
                    annotationView = new MKAnnotationView(annotation, annotationId);
                
                //adds image as pin
                //annotationView.Image = UIImage.FromFile(((HeritageAnnotation)annotation).Image);
                annotationView.Image = UIImage.FromFile("pin.png");
                annotationView.Frame = new CGRect(-5, -5, 25, 25);
                UITextView textView = new UITextView(new CGRect(0, 0, 35, 35));

                if(((HeritageAnnotation)annotation).StepNumber != 0){
                    textView.Text = ((HeritageAnnotation)annotation).StepNumber.ToString();
                    textView.Font = UIFont.PreferredBody;
                    textView.TextColor = UIColor.Brown;
                    textView.BackgroundColor = null;
                    textView.Editable = false;
                    textView.Selectable = false;
                    annotationView.AddSubview(textView); 
                }


                UIButton button = new UIButton(UIButtonType.InfoDark);
                button.SetTitle(" More Info...", UIControlState.Normal);
                button.Frame = new CGRect(0, 0, 300, 150);
                button.TouchUpInside += (sender, e) => {
                    
                    Controller.SetCurrentStop(((HeritageAnnotation)annotation).StepNumber);
                    Controller.PerformSegue("Details", this);
                    //old Alert Details
                    //UIAlertController alert = UIAlertController.Create(annotation.GetTitle(), annotation.GetSubtitle(), UIAlertControllerStyle.Alert);
                    //alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
                    //Controller.PresentViewController(alert, true, null);
                };
                UIImageView imageView = new UIImageView(UIImage.FromFile(((HeritageAnnotation)annotation).Image));
                imageView.Frame = new CGRect(0, 0, annotationView.Frame.Width, annotationView.Frame.Height);
                imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                annotationView.LeftCalloutAccessoryView = imageView;
                annotationView.DetailCalloutAccessoryView = button;
                annotationView.CanShowCallout = true;

            }

            return annotationView;
        }

        public override void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView view)
        {
            if (view.Annotation is HeritageAnnotation)
            {
                //view.Image = UIImage.FromFile(((HeritageAnnotation)view.Annotation).Image);

            }
        }

        public override void DidDeselectAnnotationView(MKMapView mapView, MKAnnotationView view)
        {
            if (view.Annotation is HeritageAnnotation)
            {
                //return null;
            }
        }

        public override MKOverlayRenderer OverlayRenderer(MKMapView mapView, IMKOverlay overlay)
        {
            
            if (overlay is MKPolyline)
            {
                MKPolylineRenderer renderer = new MKPolylineRenderer((MKPolyline)overlay);
                renderer.LineWidth = 5;
                renderer.StrokeColor = UIColor.FromRGB(0, 150, 136);
                return renderer;
            }

            return base.OverlayRenderer(mapView, overlay);

        }
    }


}
