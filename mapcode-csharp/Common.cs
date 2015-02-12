﻿/*
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
    /// This class contains common data structures and methods used by the Mapcode implementation.
    /// </summary>
    /// <remarks>For internal use within the Mapcode implementation only.</remarks>
    internal class Common
    {
        public static readonly int[] nc = new int[] { 1, 31, 961, 29791, 923521, 28629151, 887503681 };
        public static readonly int[] xSide = new int[] { 0, 5, 31, 168, 961, 168 * 31, 29791, 165869, 923521, 5141947 };
        public static readonly int[] ySide = new int[] { 0, 6, 31, 176, 961, 176 * 31, 29791, 165869, 923521, 5141947 };
        private static readonly int[] xDivider19 = new int[] {360, 360, 360, 360, 360, 360, 361, 361, 361, 361, 362, 362, 362, 363,
            363, 363, 364, 364, 365, 366, 366, 367, 367, 368, 369, 370, 370, 371, 372, 373, 374, 375, 376, 377, 378,
            379, 380, 382, 383, 384, 386, 387, 388, 390, 391, 393, 394, 396, 398, 399, 401, 403, 405, 407, 409, 411, 413,
            415, 417, 420, 422, 424, 427, 429, 432, 435, 437, 440, 443, 446, 449, 452, 455, 459, 462, 465, 469, 473,
            476, 480, 484, 488, 492, 496, 501, 505, 510, 515, 520, 525, 530, 535, 540, 546, 552, 558, 564, 570, 577, 583,
            590, 598, 605, 612, 620, 628, 637, 645, 654, 664, 673, 683, 693, 704, 715, 726, 738, 751, 763, 777, 791,
            805, 820, 836, 852, 869, 887, 906, 925, 946, 968, 990, 1014, 1039, 1066, 1094, 1123, 1154, 1187, 1223,
            1260, 1300, 1343, 1389, 1438, 1490, 1547, 1609, 1676, 1749, 1828, 1916, 2012, 2118, 2237, 2370, 2521, 2691,
            2887, 3114, 3380, 3696, 4077, 4547, 5139, 5910, 6952, 8443, 10747, 14784, 23681, 59485};
        private const int bitShift = 19;

        /**
     * This method returns a divider for longitude (multiplied by 4), for a given latitude.
     *
     * @param minY Latitude.
     * @param maxY Longitude.
     * @return Divider.
     */

        ///
    public static int XDivider(int minY, int maxY)
    {
        if (minY >= 0)
        {
            // maxY > minY > 0
            return xDivider19[minY >> bitShift];
        }
        if (maxY >= 0)
        {
            // maxY > 0 > minY
            return xDivider19[0];
        }
        // 0 > maxY > minY
        return xDivider19[(-maxY) >> bitShift];
    }

    public static int CountCityCoordinatesForCountry(int sameCodex, int index, int firstCode)
    {
        int i = GetFirstNamelessRecord(sameCodex, index, firstCode);
        int e = index;
        while (Data.CalcCodex(e) == sameCodex)
        {
            e++;
        }
        return e - i;
    }

        public static int GetFirstNamelessRecord(int sameCodex, int index, int firstCode)
        {
            int i = index;
            while ((i >= firstCode) && Data.GetIsNameless(i) && (Data.CalcCodex(i) == sameCodex)) {
                i--;
            }
            i++;
            return i;
        }
    }
}
