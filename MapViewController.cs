using System;
using UIKit;
using MapKit;
using CoreLocation;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace HeritageWalk
{
    public partial class MapViewController : UIViewController
    {
        List<stop> stops = new List<stop>();
        List<HeritageAnnotation> RouteAnnotations = new List<HeritageAnnotation>();
        MKMapView map;

        stop currentStop;

        protected MapViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //Grab data from database
            //var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //String pathToDatabase = NSBundle.MainBundle.PathForResource("HeritageWalkLite", "db");

            //using (var connection = new SQLite.SQLiteConnection(pathToDatabase))
            //{
            //    stops = connection.Table<stop>().ToList();
            //}
 
            //old test annotations initialisation
            //RouteAnnotations = new List<HeritageAnnotation>(){
            //    new HeritageAnnotation("Perth Town Hall", "The Perth town hall officially opened on June 1, 1870 and is the only capital city town hall in Australia to be built by convicts. Major restoration...", new CLLocationCoordinate2D(-31.955, 115.860556),"townHall.jpeg", 1),
            //    new HeritageAnnotation("McNess Royal Arcade", "testdesc", new CLLocationCoordinate2D(-31.9546161, 115.8602917),"mcness.jpg",2),
            //    new HeritageAnnotation("Albany Bell Tea Rooms", "Still recognisable in Barrack Street is the classically inspired facade of the Albany...", new CLLocationCoordinate2D(-31.9538135, 115.860374),"alb.jpg", 3),
            //    new HeritageAnnotation("Kings Park", "Kings park Description", new CLLocationCoordinate2D(-31.958867, 115.843972),"mcness.jpg",4)
            //};

            RouteAnnotations = new List<HeritageAnnotation>();
            foreach (stop stop in stops)
            {
                RouteAnnotations.Add(HeritageAnnotation.GetHeritageAnnotation(stop));
            }

            map = new MKMapView(UIScreen.MainScreen.Bounds);
            View = map;
            map.Delegate = new MapDelegate(this);
            map.ShowsUserLocation = true;
            CLLocationManager locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            MKCoordinateRegion region = new MKCoordinateRegion();
            region.Center = new CLLocationCoordinate2D(-31.9546161, 115.8602917);
            region.Span = new MKCoordinateSpan(0.002, 0.002);
            map.SetRegion(region, true);

            //TODO: Add check to make sure internet/routes available 

            //if there are routes
            if (RouteAnnotations.Count > 0)
            {
                getRoute(0, 0, null);
                map.AddAnnotations(RouteAnnotations.ToArray());
            }else{
                RouteAnnotations = new List<HeritageAnnotation>();
                RouteAnnotations.Add(new HeritageAnnotation("Error! No Trail Information!", "", new CLLocationCoordinate2D(-31.9546161, 115.8602917), "townHall.jpeg", 0));
                map.AddAnnotations(RouteAnnotations.ToArray());
            }

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //used by the MapDelegate to change the selected stop and therefore move to the appropriate details stop page.
        public void SetCurrentStop(int id){
            foreach (var stop in stops)
            {
                if (stop.id == id)
                {
                    currentStop = stop;
                    break;
                }
            }
        }

        void getRoute(int index, double time, MKRoute[] routes){

            //Convert Annotation data into Direction Data +  Set up
            MKDirectionsRequest request = new MKDirectionsRequest();
            request.Source = new MKMapItem(new MKPlacemark(RouteAnnotations[index].Coordinate));
            request.Destination = new MKMapItem(new MKPlacemark(RouteAnnotations[index+1].Coordinate));
            request.RequestsAlternateRoutes = true;
            request.TransportType = MKDirectionsTransportType.Walking;
            MKDirections directions = new MKDirections(request);

            //calculate Directions
            directions.CalculateDirections((MKDirectionsResponse response, Foundation.NSError error) =>
            {
                MKRoute[] routeresponse = response.Routes;
                MKRoute routeToAdd;

                //if only one route, add this.
                if (response.Routes.Length == 1)
                {
                    routeToAdd = routeresponse[0];

                }else{
                    //otherwise sort route to find quickest
                    Array.Sort(routeresponse, (x, y) => x.ExpectedTravelTime.CompareTo(y.ExpectedTravelTime));
                    routeToAdd = routeresponse[0];
                     
                }

                //if this isnt the first route, resize and add the route to the array..
                if (routes != null){
                     Array.Resize<MKRoute>(ref routes, routes.Length + 1);
                    routes[routes.Length-1] = routeToAdd;
                }
                else
                {
                    //otherwise initialise the route array..
                    routes = new MKRoute[] { routeToAdd };
                }
                //add the estimated route time together ( can be used later for estimated route time displayed).
                time += routeToAdd.ExpectedTravelTime;

                //check if we're at the end of the array.
                if ((index+2) < RouteAnnotations.Count)
                {
                    //if not, recursively call the function again increasing the index Until the route is at the end.
                    getRoute(index + 1,time,routes);
                }else{
                    
                    /** Completed Recurring Route **/

                    //if at the end finished recursion, and completed route.
                    if (routes.Length > 0)
                    {
                        //Add each route onto the map using the poly line, increasing the view bounding map rect each time.
                        foreach (MKRoute route in routes)
                        {
                            map.AddOverlay(route.Polyline);
                            if (map.Overlays.Length == 1)
                            {
                                //if one polyline, set visible map rect
                                map.SetVisibleMapRect(routes[0].Polyline.BoundingMapRect, new UIEdgeInsets(10, 10, 10, 10), false);
                            }
                            else
                            {
                                //if more than one merge the route + and current view rect + set
                                map.SetVisibleMapRect(MKMapRect.Union(map.VisibleMapRect, route.Polyline.BoundingMapRect), new UIEdgeInsets(10, 10, 10, 10), false);
                               
                            }
                        }
                    }
                }
            });
        }

        //returns the current list of stops.
        public List<stop> GetStops(){
            return stops;
        }


        //This function must be called in the Previous View Controllers PrepareForSegue in order to update the map with the stops to be shown.
        public void SetStops(List<stop> _stops){
            stops = _stops;
            currentStop = stops[0];
        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if (segue.DestinationViewController is TrailDetailsController)
            {
                ((TrailDetailsController)segue.DestinationViewController).SetStopDetails(currentStop);
            }
        }

    }
}
