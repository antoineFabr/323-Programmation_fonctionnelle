using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class Trackpoint
{
    private double _latitude;
    private double _longitude;
    private double _elevation;

    public double Latitude => _latitude;
    public double Longitude => _longitude;
    public double Elevation => _elevation;

    public Trackpoint(double latitude, double longitude, double elevation)
    {
        _latitude = latitude;
        _longitude = longitude;
        _elevation = elevation;
    }

    public override string ToString()
    {
        return $"Lat: {_latitude}, Lon: {_longitude}, Ele: {_elevation}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string gpxFilePath = "./gpx/Ballade_châtaignère_🌰.gpx";

        List<Trackpoint> trackpoints = LireTrackpoints(gpxFilePath);
        var filter = trackpoints.Where((tp, id) => id % 5 == 0).ToList();
        filter.ForEach(x => Console.WriteLine(x));
       
    }

    static List<Trackpoint> LireTrackpoints(string filePath)
    {
        XDocument doc = XDocument.Load(filePath);

        XNamespace ns = "http://www.topografix.com/GPX/1/1";

        // Rechercher les <trkpt>
        var points = doc.Descendants(ns + "trkpt")
            .Select(trkpt => new Trackpoint(
                double.Parse(trkpt.Attribute("lat").Value, System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(trkpt.Attribute("lon").Value, System.Globalization.CultureInfo.InvariantCulture),
                double.Parse(trkpt.Element(ns + "ele").Value, System.Globalization.CultureInfo.InvariantCulture)
            ))
            .ToList();

        return points;
    }
}