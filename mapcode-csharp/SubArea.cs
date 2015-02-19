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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapcode.com
{
    /// <summary>
    /// This class defines an area for local mapcodes.
    /// </summary>
    internal class SubArea
    {
        private static List<SubArea> subAreas = new List<SubArea>();
        private static Dictionary<int, List<SubArea>> lonMap = new Dictionary<int, List<SubArea>>();
        private static Dictionary<int, List<SubArea>> latMap = new Dictionary<int, List<SubArea>>();

        private static Range<int> latBoundingRange = new Range<int>(Point.LAT_MICRODEG_MIN, Point.LAT_MICRODEG_MAX);
        private static Range<int> lonBoundingRange = new Range<int>(Point.LON_MICRODEG_MIN, Point.LON_MICRODEG_MAX);

        public static SubArea GetArea(int i)
        {
            return null; // TODO subAreas.get(i);
        }

        private Range<int> latRange, lonRange;
        private List<Range<int>> boundedLatRange, boundedLonRange;
        private Territory parentTerritory;
        private int subAreaID;

        public int getMinX()
        {
            return lonRange.getMin();
        }

        public int getMinY()
        {
            return latRange.getMin();
        }

        public int getMaxX()
        {
            return lonRange.getMax();
        }

        public int getMaxY()
        {
            return latRange.getMax();
        }

        public Territory getParentTerritory()
        {
            return parentTerritory;
        }

        public int getSubAreaID()
        {
            return subAreaID;
        }

        private SubArea(int i, /*@Nonnull*/ Territory territory, /*@Nullable*/ SubArea territoryBounds)
        {
            minMaxSetup(i);
            parentTerritory = territory;
            subAreaID = i;
            boundedLonRange = new List<Range<int>>();
            boundedLatRange = new List<Range<int>>();

            // Mapcode areas are inclusive for the minimum bounds and exclusive for the maximum bounds
            // Trim max by 1, to address boundary cases.
            Range<int> trimmedLonRange = trimRange(lonRange);
            Range<int> trimmedLatRange = latRange;
            // Special handling for latitude +90.0 which should not be trimmed, in order to produce
            // mapcode AAA Z0000.010G for lat: 90.0 lon:180.0.
            if (latRange.getMax() != 90000000)
            {
                trimmedLatRange = trimRange(latRange);
            }
            List<Range<int>> normalisedLonRange = normaliseRange(trimmedLonRange, lonBoundingRange);
            List<Range<int>> normalisedLatRange = normaliseRange(trimmedLatRange, latBoundingRange);
            if (territoryBounds == null)
            {
                boundedLonRange = normalisedLonRange;
                boundedLatRange = normalisedLatRange;
            }
            else
            {
                foreach (Range<int> normalisedRange in normalisedLonRange)
                {
                    List<Range<int>> boundedRange = normalisedRange.constrain(territoryBounds.boundedLonRange);
                    if (boundedRange != null)
                    {
                        boundedLonRange.AddRange(boundedRange);
                    }
                }
                foreach (Range<int> normalisedRange in normalisedLatRange)
                {
                    List<Range<int>> boundedRange = normalisedRange.constrain(territoryBounds.boundedLatRange);
                    if (boundedRange != null)
                    {
                        boundedLatRange.AddRange(boundedRange);
                    }
                }
            }
        }

        /*@Nonnull*/
        private static List<Range<int>> normaliseRange(/*@Nonnull*/ Range<int> range, /*@Nonnull*/ Range<int> boundingRange)
        {
            List<Range<int>> ranges = new List<Range<int>>();

            Range<int> tempRange = range.constrain(boundingRange);
            if (tempRange != null)
            {
                ranges.Add(tempRange);
            }

            Range<int> normalisingRange = range;
            while (normalisingRange.getMin() < boundingRange.getMin())
            {
                normalisingRange = new Range<int>(normalisingRange.getMin() + boundingRange.getMax()
                    - boundingRange.getMin(), normalisingRange.getMax() + boundingRange.getMax()
                    - boundingRange.getMin());
                tempRange = normalisingRange.constrain(boundingRange);
                if (tempRange != null)
                {
                    ranges.Add(tempRange);
                }
            }

            normalisingRange = range;
            while (normalisingRange.getMax() > boundingRange.getMax())
            {
                normalisingRange = new Range<int>(normalisingRange.getMin() - boundingRange.getMax()
                    + boundingRange.getMin(), normalisingRange.getMax() - boundingRange.getMax()
                    + boundingRange.getMin());
                tempRange = normalisingRange.constrain(boundingRange);
                if (tempRange != null)
                {
                    ranges.Add(tempRange);
                }
            }

            return ranges;
        }

        private SubArea()
        {
            parentTerritory = null;
            subAreaID = 0; // JAVA null
        }

        public bool containsPoint(/*@Nonnull*/ Point point)
        {
            if (latRange.contains(point.getLatMicroDeg()) && containsLongitude(point.getLonMicroDeg()))
            {
                return true;
            }
            return false;
        }

        /*@Nonnull*/
        public SubArea extendBounds(int xExtension, int yExtension)
        {
            SubArea result = new SubArea();
            result.latRange = new Range<int>(this.getMinY() - yExtension, getMaxY() + yExtension);
            result.lonRange = new Range<int>(this.getMinX() - xExtension, getMaxX() + xExtension);
            return result;
        }

        public bool containsLongitude(int argLonMicroDeg)
        {
            int lonMicroDeg = argLonMicroDeg;
            if (this.lonRange.contains(lonMicroDeg))
            {
                return true;
            }
            if (lonMicroDeg < lonRange.getMin())
            {
                lonMicroDeg += 360000000;
            }
            else
            {
                lonMicroDeg -= 360000000;
            }
            if (this.lonRange.contains(lonMicroDeg))
            {
                return true;
            }
            return false;
        }

        private void minMaxSetup(int arg)
        {
            int i = arg * 20;
            int minX = DataAccess.AsLong(i);

            i += 4;
            int minY = DataAccess.AsLong(i);

            i += 4;
            int maxX = DataAccess.AsLong(i);

            i += 4;
            int maxY = DataAccess.AsLong(i);

            latRange = new Range<int>(minY, maxY);
            lonRange = new Range<int>(minX, maxX);
        }

        private static Range<int> trimRange(Range<int> range)
        {
            return new Range<int>(range.getMin(), range.getMax() - 1);
        }
    }
}
