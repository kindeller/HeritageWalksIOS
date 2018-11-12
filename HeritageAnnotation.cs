using System;
using CoreLocation;
using MapKit;
using UIKit;

namespace HeritageWalk
{
    public class HeritageAnnotation : MKAnnotation
    {
        string title;
        string description;
        CLLocationCoordinate2D coordinates;
        string imageFileName;
        int stepNumber;


        public HeritageAnnotation(string title, string desc,CLLocationCoordinate2D coord, string img, int step)
        {
            this.title = title;
            this.description = desc;
            this.stepNumber = step;
            coordinates = coord;
            imageFileName = img;


        }

        public override string Subtitle{
            get{
                return description;
            }
        }

        public override string Description{
            get{
                return description;
            }
        }

        public override string Title{
            get{
                return title;
            }
        }

        public string Image{
            get{
                return imageFileName;
            }
        }

        public override CLLocationCoordinate2D Coordinate{
            get{
                return coordinates;
            }
        }

        public MKPlacemark Placemark{
            get{
                return new MKPlacemark(coordinates);
            }
        }

        public int StepNumber
        {
            get
            {
                return stepNumber;
            }
        }

        static public HeritageAnnotation GetHeritageAnnotation(Trail trail)
        {
            return new HeritageAnnotation(trail.name, trail.description, new CLLocationCoordinate2D(), trail.photoName, 0);
        }

        static public HeritageAnnotation GetHeritageAnnotation(stop stop){
            return new HeritageAnnotation(stop.name, stop.description, new CLLocationCoordinate2D(stop.latitude, stop.longitude), stop.photoName, stop.id);
        }
    }
}
