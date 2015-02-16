/*
 * Copyright (C) 2014-2015 Stichting Mapcode Foundation (http://www.mapcode.com)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;

namespace mapcode.com
{
    /// <summary>
    /// This class defines a class for lat/lon points.
    /// </summary>
    internal class Point
    {
        // Latitude and longitude ranges.
        public static readonly double LON_DEG_MIN = -180.0;
        public static readonly double LON_DEG_MAX = 180.0;
        public static readonly double LAT_DEG_MIN = -90.0;
        public static readonly double LAT_DEG_MAX = 90.0;

        public static readonly int LON_MICRODEG_MIN = degToMicroDeg(LON_DEG_MIN);
        public static readonly int LON_MICRODEG_MAX = degToMicroDeg(LON_DEG_MAX);
        public static readonly int LAT_MICRODEG_MIN = degToMicroDeg(LAT_DEG_MIN);
        public static readonly int LAT_MICRODEG_MAX = degToMicroDeg(LAT_DEG_MAX);

        public static readonly double MICRODEG_TO_DEG_FACTOR = 1000000.0;

        // Radius of Earth.
        public static readonly double EARTH_RADIUS_X_METERS = 6378137.0;
        public static readonly double EARTH_RADIUS_Y_METERS = 6356752.3;

        // Circumference of Earth.
        public static readonly double EARTH_CIRCUMFERENCE_X = EARTH_RADIUS_X_METERS * 2.0 * Math.PI;
        public static readonly double EARTH_CIRCUMFERENCE_Y = EARTH_RADIUS_Y_METERS * 2.0 * Math.PI;

        // Meters per degree latitude is fixed. For longitude: use factor * cos(midpoint of two degree latitudes).
        public static readonly double METERS_PER_DEGREE_LAT = EARTH_CIRCUMFERENCE_Y / 360.0;
        public static readonly double METERS_PER_DEGREE_LON_EQUATOR = EARTH_CIRCUMFERENCE_X / 360.0; // * cos(deg(lat)).


        // Private data.
        private double latDeg = 0.0;     // Latitude, normal range -90..90, but not enforced.
        private double lonDeg = 0.0;     // Longitude, normal range -180..180, but not enforced.

        /// <summary>
        /// Points can be "undefined" within the mapcode implementation, but never outside of that.
        /// Any methods creating or setting undefined points must be package private and external
        /// interfaces must never pass undefined points to callers. 
        /// </summary>
        private bool defined = false;

        /**
         * Create a point from lat/lon in degrees.
         *
         * @param latDeg Longitude in degrees.
         * @param lonDeg Latitude in degrees.
         * @return A defined point.
         */
        public static Point fromDeg(double latDeg, double lonDeg)
        {
            return new Point(latDeg, lonDeg);
        }

        /// <summary>
        /// reate a point from lat/lon in micro-degrees (i.e. degrees * 1,000,000).
        /// </summary>
        /// <param name="latMicroDeg">Longitude in microdegrees</param>
        /// <param name="lonMicroDeg">Latitude in microdegrees.</param>
        /// <returns>A defined point</returns>
        public static Point fromMicroDeg(int latMicroDeg, int lonMicroDeg)
        {
            return new Point(microDegToDeg(latMicroDeg), microDegToDeg(lonMicroDeg));
        }

        /// <summary>
        /// Get the latitude in microdegrees.
        /// </summary>
        /// <returns>Latitude in microdegrees. No range is enforced.</returns>
        public int getLatMicroDeg()
        {
            System.Diagnostics.Debug.Assert(defined);
            return degToMicroDeg(latDeg);
        }

        /// <summary>
        /// Get the longitude in microdegrees.
        /// </summary>
        /// <returns>Longitude in microdegrees. No range is enforced.</returns>
        public int getLonMicroDeg()
        {
            System.Diagnostics.Debug.Assert(defined);
            return degToMicroDeg(lonDeg);
        }

        /// <summary>
        /// Get the latitude in degrees. 
        /// </summary>
        /// <returns>Latitude in degrees. No range is enforced.</returns>
        public double getLatDeg()
        {
            System.Diagnostics.Debug.Assert(defined);
            return latDeg;
        }

        /// <summary>
        /// Get the longitude in degrees.
        /// </summary>
        /// <returns>Longitude in degrees. No range is enforced.</returns>
        public double getLonDeg()
        {
            System.Diagnostics.Debug.Assert(defined);
            return lonDeg;
        }

        public override string ToString()
        {
            return "(" + latDeg + ", " + lonDeg + ')';
        }

        public static int degToMicroDeg(double deg)
        {
            //noinspection NumericCastThatLosesPrecision
            return (int) Math.Round(deg * MICRODEG_TO_DEG_FACTOR);
        }

        public static double microDegToDeg(int microDeg)
        {
            return ((double) microDeg) / MICRODEG_TO_DEG_FACTOR;
        }

        /* @Nonnull */
        public static Point restrictLatLon(/*@Nonnull*/ Point point)
        {
            if (!point.defined) {
                return undefined();
            }
            double latDeg = Math.Max(Math.Min(LAT_DEG_MAX, point.getLatDeg()), LAT_DEG_MIN);
            double lonDeg = Math.Max(Math.Min(LON_DEG_MAX, point.getLonDeg()), LON_DEG_MIN);
            return new Point(latDeg, lonDeg);
        }

        /// <summary>
        /// Create a random point, uniformly distributed over the surface of the Earth. 
        /// </summary>
        /// <param name="randomGenerator">Random generator used to create a point. @Nonnull</param>
        /// <returns>Random point with uniform distribution over the sphere. @Nonnull</returns>
        public static Point fromUniformlyDistributedRandomPoints(Random randomGenerator)
        {
            CheckArgs.checkNonnull("randomGenerator", randomGenerator);

            // Calculate uniformly distributed 3D point on sphere (radius = 1.0):
            // http://mathproofs.blogspot.co.il/2005/04/uniform-random-distribution-on-sphere.html
            double unitRand1 = randomGenerator.NextDouble();
            double unitRand2 = randomGenerator.NextDouble();
            double theta0 = (2.0 * Math.PI) * unitRand1;
            double theta1 = Math.Acos(1.0 - (2.0 * unitRand2));
            double x = Math.Sin(theta0) * Math.Sin(theta1);
            double y = Math.Cos(theta0) * Math.Sin(theta1);
            double z = Math.Cos(theta1);

            // Convert Carthesian 3D point into lat/lon (radius = 1.0):
            // http://stackoverflow.com/questions/1185408/converting-from-longitude-latitude-to-cartesian-coordinates
            double latRad = Math.Asin(z);
            double lonRad = Math.Atan2(y, x);

            // Convert radians to degrees.
            System.Diagnostics.Debug.Assert(!Double.IsNaN(latRad));
            System.Diagnostics.Debug.Assert(!Double.IsNaN(lonRad));
            double lat = RadianToDegree(latRad); 
            double lon = RadianToDegree(lonRad);
            return fromMicroDeg(degToMicroDeg(lat), degToMicroDeg(lon));
        }

        /// <summary>
        /// Calculate the distance between two points. This algorithm does not take the curvature of the Earth into
        /// account, so it only works for small distance up to, say 200 km, and not too close to the poles.
        /// </summary>
        /// <param name="p1">Point 1. @Nonnull</param>
        /// <param name="p2">Point 2. @Nonnull</param>
        /// <returns>Straight distance between p1 and p2. Only accurate for small distances up to 200 km.</returns>
        public static double distanceInMeters(Point p1, Point p2)
        {
            CheckArgs.checkNonnull("p1", p1);
            CheckArgs.checkNonnull("p2", p2);

            Point from;
            Point to;
            if (p1.lonDeg <= p2.lonDeg)
            {
                from = p1;
                to = p2;
            }
            else
            {
                from = p2;
                to = p1;
            }

            // Calculate mid point of 2 latitudes.
            double avgLat = from.latDeg + ((to.latDeg - from.latDeg) / 2.0);

            double deltaLonDeg360 = Math.Abs(to.lonDeg - from.lonDeg);
            double deltaLonDeg = ((deltaLonDeg360 <= 180.0) ? deltaLonDeg360 : (360.0 - deltaLonDeg360));
            double deltaLatDeg = Math.Abs(to.latDeg - from.latDeg);

            // Meters per longitude is fixed; per latitude requires * cos(avg(lat)).
            double deltaXMeters = degreesLonToMetersAtLat(deltaLonDeg, avgLat);
            double deltaYMeters = degreesLatToMeters(deltaLatDeg);

            // Calculate length through Earth. This is an approximation, but works fine for short distances.
            double lenMeters = Math.Sqrt((deltaXMeters * deltaXMeters) + (deltaYMeters * deltaYMeters));
            return lenMeters;
        }

        public static double degreesLatToMeters(double latDegrees)
        {
            return latDegrees * METERS_PER_DEGREE_LAT;
        }

        public static double degreesLonToMetersAtLat(double lonDegrees, double lat)
        {
            return lonDegrees * METERS_PER_DEGREE_LON_EQUATOR * Math.Cos(DegreeToRadian(lat));
        }

        public static double metersToDegreesLonAtLat(double eastMeters, double lat)
        {
            return (eastMeters / METERS_PER_DEGREE_LON_EQUATOR) / Math.Cos(DegreeToRadian(lat));
        }

         /// Private constructors
        private Point()
        {
            latDeg = Double.NaN;
            lonDeg = Double.NaN;
            defined = false;
        }

        private Point(double latDeg, double lonDeg)
        {
            // These assertions are not valid, as the ranges cannot be enforced currently:
            // assert (LON_DEG_MIN <= lonDeg) && (lonDeg <= LON_DEG_MAX) : "lon [-180..180]: " + lonDeg;
            // assert (LAT_DEG_MIN <= latDeg) && (latDeg <= LAT_DEG_MAX) : "lat [-90..90]: " + latDeg;
            this.latDeg = latDeg;
            this.lonDeg = lonDeg;
            this.defined = true;
        }

        #region Private methods. Only used in the mapcode implementation modules.

        /// <summary>
        /// Create an undefined point. No latitude or longitude can be obtained from it.
        /// Only within the mapcode implementation points can be undefined, so this methods is private.
        /// </summary>
        /// <returns>Undefined point @Nonnull</returns>
        private static Point undefined()
        {
            return new Point();
        }

        /// <summary>
        /// Set a point to be undefined, invalidating the latitude and longitude.
        /// Only within the mapcode implementation points can be undefined, so this methods is private.
        /// </summary>
        private void setUndefined()
        {
            latDeg = Double.NaN;
            lonDeg = Double.NaN;
            defined = false;
        }

        /// <summary>
        /// Return whether the point is defined or not.
        /// Only within the mapcode implementation points can be undefined, so this methods is private.
        /// </summary>
        /// <returns>True if defined. If false, no lat/lon is available.</returns>
        private bool isDefined()
        {
            return defined;
        }

        private static double DegreeToRadian(double angle)
        {
            return angle * (Math.PI / 180.0);
        }

        private static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        #endregion
    }
}
