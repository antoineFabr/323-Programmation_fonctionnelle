using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Xml.Linq;

namespace Rando
{
    public partial class Rando : Form
    {
        public Rando()
        {
            InitializeComponent();
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            string gpxFilePath = "./gpx/loechegemmi.gpx";

            List<Trackpoint> trackpoints = LireTrackpoints(gpxFilePath);
            //1 point sur  5 retenu
            List<Trackpoint> filter = trackpoints.Where((t, id) => id % 5 == 0).ToList();
           
            List<Point> points = filter.Select(t => new Point((int)((t.lat-46.3)*5000), (int)((t.lon-7.6)*5000))).ToList();

            var pointXmax = points.Max(t => t.X);
            var pointXmin = points.Min(t => t.X);
            var diffXminmax = pointXmax - pointXmin;

            var pointYmax = points.Max(t => t.Y);
            var pointYmin = points.Min(t => t.Y);
            var diffYminmax = pointYmax - pointYmin;




            MessageBox.Show(Convert.ToString(diffXminmax ), Convert.ToString(diffYminmax));
            Pen myPen = new Pen(Color.SaddleBrown);
            myPen.Width = 1;
         
            this.CreateGraphics().DrawLines(myPen, points.ToArray());
        }


        //ChatGPT
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



    class Trackpoint
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public double ele { get; set; }

        public Trackpoint(double lat, double lon, double ele)
        {
            this.lat = lat;
            this.lon = lon;
            this.ele = ele;
        }

        public override string ToString()
        {
            return $"lat: {this.lat} lon: {this.lon} ele: {this.ele}";
        }
    }
}
