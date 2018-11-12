using System;
using MapKit;
using CoreLocation;
namespace Map
{
    public class PinLocation
    {
        double Latitude { get; }
        double Longtitude { get; }
        string Name { get; }
        string Description { get; }

        public PinLocation(double lo, double la, string name, string desc )
        {
            Latitude = la;
            Longtitude = lo;
            Name = name;
            Description = desc;
        }

        public PinLocation(){
            Latitude = 0;
            Longtitude = 0;
            Name = "";
            Description = "";
        }

        public MKPointAnnotation GetAnnotationView(){
            MKPointAnnotation view = new MKPointAnnotation();

            view.Title = this.Name;
            view.Coordinate = new CLLocationCoordinate2D(Latitude, Longtitude);


            return view;
        }

        public string GetName(){
            return Name;
        }

        public CLLocationCoordinate2D GetCoordinates(){
            return new CLLocationCoordinate2D(Latitude, Longtitude);
        }
    }
}
