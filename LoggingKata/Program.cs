﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            if (lines.Count() == 0)
            {
                logger.LogError("0 lines read from CSV file");
            }
            else if (lines.Count() == 1)
            {
                logger.LogWarning("1 line read from CSV file");
            }

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable tacoBellA = null;
            ITrackable tacoBellB = null;

            double distance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int x = 1; x < locations.Length; x++)
                {
                    var locB = locations[x];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBellA = locA;
                        tacoBellB = locB;
                    }
                }
            }
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine("----------FURTHEST AWAY----------");
            Console.WriteLine("");
            Console.WriteLine($"{tacoBellA.Name} and {tacoBellB.Name} are the furthest aprt from each other.");
            Console.WriteLine(".");
            Console.WriteLine($"They're {Math.Round((distance / 1609.344), 2)} miles of each other.");
            Console.WriteLine(".");
            Console.WriteLine(".");

            //Going from meters to miles

            ITrackable tacoBellC = null;
            ITrackable tacoBellD = null;

            double shortDistance = 9999999999999999999;

            for (int r = 0; r < locations.Length; r++)
            {
                var locC = locations[r];
                var corC = new GeoCoordinate(locC.Location.Latitude, locC.Location.Longitude);

                for (int s = 1; s < locations.Length; s++)
                {
                    var locD = locations[s];
                    var corD = new GeoCoordinate(locD.Location.Latitude, locD.Location.Longitude);

                    if (corC.GetDistanceTo(corD) < shortDistance && corC.GetDistanceTo(corD) !=0)
                    {
                        shortDistance = corC.GetDistanceTo(corD);
                        tacoBellC = locC;
                        tacoBellD = locD;
                    }
                    
                }
            }

            Console.WriteLine("!");
            Console.WriteLine("!");
            Console.WriteLine(".");
            Console.WriteLine("----------CLOSES TO EACH OTHER----------");
            Console.WriteLine("");
            Console.WriteLine($"{tacoBellC.Name} and {tacoBellD.Name} are shorter miles from each other.");
            Console.WriteLine(".");
            Console.WriteLine($"They are {Math.Round((shortDistance/ 1609.344), 2)} miles from each other.");
            Console.WriteLine("!");
            Console.WriteLine(".");
            Console.WriteLine("!");
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }
    }
}
