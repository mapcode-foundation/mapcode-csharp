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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapcode.com
{
    public class Decoder
    {
        private const int CCODE_EARTH = 540;

        private static readonly int[] decode_chars = new int[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, -1, -1, -1, -1, -1, -1, -1, -2, 10, 11, 12, -3, 13, 14, 15,
            1, 16, 17, 18, 19, 20, 0, 21, 22, 23, 24, 25, -4, 26, 27, 28, 29, 30, -1, -1, -1, -1, -1, -1, -2, 10, 11,
            12, -3, 13, 14, 15, 1, 16, 17, 18, 19, 20, 0, 21, 22, 23, 24, 25, -4, 26, 27, 28, 29, 30, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};

        private class Unicode2Ascii
        {
            public int    min { get; private set; }
            public int    max { get; private set; }
            public string convert { get; private set; }

            public Unicode2Ascii(int min, int max, string convert)
            {
                this.min = min;
                this.max = max;
                this.convert = convert;
            }
        }

        private static readonly Unicode2Ascii[] UNICODE2ASCII = new Unicode2Ascii[]
        {
            new Unicode2Ascii(0x0041, 0x005a, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"), // Roman
            new Unicode2Ascii(0x0391, 0x03a9, "ABGDFZHQIKLMNCOJP?STYVXRW"), // Greek
            new Unicode2Ascii(0x0410, 0x042f,
                "AZBGDEFNI?KLMHOJPCTYQXSVW????U?R"), // Cyrillic
            new Unicode2Ascii(0x05d0, 0x05ea, "ABCDFIGHJKLMNPQ?ROSETUVWXYZ"), // Hebrew
            new Unicode2Ascii(0x0905, 0x0939,
                "A?????????E?????B?CD?F?G??HJZ?KL?MNP?QU?RS?T?V??W??XY"), // Hindi
            new Unicode2Ascii(0x0d07, 0x0d39,
                "I?U?E??????A??BCD??F?G??HOJ??KLMNP?????Q?RST?VWX?YZ"), // Malai
            new Unicode2Ascii(0x10a0, 0x10bf,
                "AB?CE?D?UF?GHOJ?KLMINPQRSTVW?XYZ"), // Georgisch
            new Unicode2Ascii(
                0x30a2,
                0x30f2,
                "A?I?O?U?EB?C?D?F?G?H???J???????K??????L?M?N?????P??Q??R??S?????TV?????WX???Y????Z"), // Katakana
            new Unicode2Ascii(0x0e01, 0x0e32,
                "BC?D??FGHJ??O???K??L?MNP?Q?R????S?T?V?W????UXYZAIE"), // Thai
            new Unicode2Ascii(0x0e81, 0x0ec6,
                "BC?D??FG?H??J??????K??L?MN?P?Q??RST???V??WX?Y?ZA????????????U?????EI?O"), // Lao
            new Unicode2Ascii(0x0532, 0x0556,
                "BCDE??FGHI?J?KLM?N?U?PQ?R??STVWXYZ?OA"), // Armenian
            new Unicode2Ascii(0x0985, 0x09b9,
                "A??????B??E???U?CDF?GH??J??KLMNPQR?S?T?VW?X??Y??????Z"), // Bengali
            new Unicode2Ascii(0x0a05, 0x0a39,
                "A?????????E?????B?CD?F?G??HJZ?KL?MNP?QU?RS?T?V??W??XY"), // Gurmukhi
            new Unicode2Ascii(0x0f40, 0x0f66,
                "BCD?FGHJ??K?L?MN?P?QR?S?A?????TV?WXYEUZ"), // Tibetan

            new Unicode2Ascii(0x0966, 0x096f, ""), // Hindi
            new Unicode2Ascii(0x0d66, 0x0d6f, ""), // Malai
            new Unicode2Ascii(0x0e50, 0x0e59, ""), // Thai
            new Unicode2Ascii(0x09e6, 0x09ef, ""), // Bengali
            new Unicode2Ascii(0x0a66, 0x0a6f, ""), // Gurmukhi
            new Unicode2Ascii(0x0f20, 0x0f29, ""), // Tibetan

            // lowercase variants: greek, georgisch
            new Unicode2Ascii(0x03B1, 0x03c9, "ABGDFZHQIKLMNCOJP?STYVXRW"), // Greek
            // lowercase
            new Unicode2Ascii(0x10d0, 0x10ef,
                "AB?CE?D?UF?GHOJ?KLMINPQRSTVW?XYZ"), // Georgisch lowercase
            new Unicode2Ascii(0x0562, 0x0586,
                "BCDE??FGHI?J?KLM?N?U?PQ?R??STVWXYZ?OA"), // Armenian
            // lowercase
            new Unicode2Ascii(0, 0, null)
        };

        /*@Nonnull*/
    static Point decode(/*@Nonnull*/ string argMapcode, /*@Nonnull*/ Territory argTerritory)
        // throws UnknownMapcodeException 
    {
        Trace.TraceInformation("decode: mapcode={0}, territory={1}", argMapcode, argTerritory.ToString()); // JAVA name()

        string mapcode = argMapcode;
        Territory territory = argTerritory;

        // In case of error, result.isDefined() is false.
        Point result = Point.undefined();
        string extrapostfix = string.Empty;

        int minpos = mapcode.IndexOf('-');
        if (minpos > 0) 
        {
            extrapostfix = mapcode.Substring(minpos + 1).Trim();
            if (extrapostfix.Contains("Z"))
            {
                throw new UnknownMapcodeException("Invalid character Z");
            }
            mapcode = mapcode.Substring(0, minpos);
        }

        mapcode = aeuUnpack(mapcode).Trim();
        if (string.IsNullOrEmpty(mapcode))
        {
            return result; // failed to decode!
        }

        int incodexlen = mapcode.Length - 1;

        // *** long codes in states are handled by the country
        if (incodexlen >= 9)
        {
            territory = Territory.territories[Territory.Territories.AAA];
        }
        else
        {
            Territory parentTerritory = territory.getParentTerritory();
            if (incodexlen >= 8 &&
                (parentTerritory == Territory.territories[Territory.Territories.USA] ||
                 parentTerritory == Territory.territories[Territory.Territories.CAN] ||
                 parentTerritory == Territory.territories[Territory.Territories.AUS] ||
                 parentTerritory == Territory.territories[Territory.Territories.BRA] ||
                 parentTerritory == Territory.territories[Territory.Territories.CHN] ||
                 parentTerritory == Territory.territories[Territory.Territories.RUS])
                || incodexlen >= 7 &&
                (parentTerritory == Territory.territories[Territory.Territories.IND] ||
                 parentTerritory == Territory.territories[Territory.Territories.MEX]))
            {
                territory = parentTerritory;
            }
        }

        int ccode = territory.getTerritoryCode();

        int from = DataAccess.DataFirstRecord(ccode);
        if (DataAccess.DataFlags(from) == 0)
        {
            return Point.undefined(); // this territory is not in the current data
        }
        int upto = DataAccess.DataLastRecord(ccode);

        int incodexhi = mapcode.IndexOf('.');

        Data mapcoderData = new Data();

        for (int i = from; i <= upto; i++) 
        {
            mapcoderData.dataSetup(i);
            if (mapcoderData.PipeType == 0 && !mapcoderData.IsNameless
                && mapcoderData.CodexLen == incodexlen && mapcoderData.CodexHi == incodexhi)
            {
                result = decodeGrid(mapcode, mapcoderData.MapcoderRect.getMinX(), mapcoderData.MapcoderRect
                        .getMinY(), mapcoderData.MapcoderRect.getMaxX(), mapcoderData.MapcoderRect.getMaxY(),
                    i, extrapostfix);
                // RESTRICTUSELESS
                if (mapcoderData.IsUseless && result.isDefined())
                {
                    bool fitssomewhere = false;
                    int j;
                    for (j = upto - 1; j >= from; j--) { // look in previous
                        // rects
                        mapcoderData.dataSetup(j);
                        if (mapcoderData.IsUseless)
                        {
                            continue;
                        }
                        int xdiv8 = Common.XDivider(mapcoderData.MapcoderRect.getMinY(),
                            mapcoderData.MapcoderRect.getMaxY()) / 4;
                        if (mapcoderData.MapcoderRect.extendBounds(xdiv8, 60).containsPoint(result))
                        {
                            fitssomewhere = true;
                            break;
                        }
                    }
                    if (!fitssomewhere)
                    {
                        result.setUndefined();
                    }
                }
                break;
            }
            else if (mapcoderData.PipeType == 4 && mapcoderData.CodexLen + 1 == incodexlen
                && mapcoderData.CodexHi + 1 == incodexhi
                && mapcoderData.PipeLetter[0] == mapcode[0])
            {
                result = decodeGrid(mapcode.Substring(1), mapcoderData.MapcoderRect.getMinX(), mapcoderData
                    .MapcoderRect.getMinY(), mapcoderData.MapcoderRect.getMaxX(), mapcoderData
                    .MapcoderRect.getMaxY(), i, extrapostfix);
                break;
            }
            else if (mapcoderData.IsNameless && (mapcoderData.Codex == 21 && incodexlen == 4 && incodexhi == 2 ||
                mapcoderData.Codex == 22 && incodexlen == 5 && incodexhi == 3 ||
                mapcoderData.Codex == 13 && incodexlen == 5 && incodexhi == 2))
            {
                result = decodeNameless(mapcode, i, extrapostfix, mapcoderData);
                break;
            }
            else if (mapcoderData.PipeType > 4 && incodexlen == incodexhi + 3
                && mapcoderData.CodexLen + 1 == incodexlen)
            {
                result = decodeStarpipe(mapcode, i, extrapostfix, mapcoderData);
                break;
            }
        }

        if (result.isDefined())
        {
            if (result.getLonMicroDeg() > 180000000)
            {
                result = Point.fromMicroDeg(result.getLatMicroDeg(), result.getLonMicroDeg() - 360000000);
            }
            else if (result.getLonMicroDeg() < -180000000)
            {
                result = Point.fromMicroDeg(result.getLatMicroDeg(), result.getLonMicroDeg() + 360000000);
            }

            // LIMIT_TO_OUTRECT : make sure it fits the country
            if (ccode != CCODE_EARTH)
            {
                SubArea mapcoderRect = SubArea.GetArea(upto); // find
                // encompassing
                // rect
                int xdiv8 = Common.XDivider(mapcoderRect.getMinY(), mapcoderRect.getMaxY()) / 4;
                // should be /8 but there's some extra margin
                if (!mapcoderRect.extendBounds(xdiv8, 60).containsPoint(result))
                {
                    result.setUndefined(); // decodes outside the official territory
                    // limit
                }
            }
        }

        Trace.TraceInformation("decode: result=({0}, {1})",
            result.isDefined() ? result.getLatDeg() : Double.NaN,
            result.isDefined() ? result.getLonDeg() : Double.NaN);
        result = Point.restrictLatLon(result);
        return result;
    }

        private static String aeuUnpack(string str)
        {
            // unpack encoded into all-digit
            // (assume str already uppercase!), returns "" in case of error
            str = decodeUTF16(str);
            bool voweled = false;
            int lastpos = str.Length - 1;
            int dotpos = str.IndexOf('.');
            if (dotpos < 2 || lastpos < dotpos + 2)
            {
                return string.Empty; // Error: no dot, or less than 2 letters before dot, or
            }
            // less than 2 letters after dot

            if (str[0] == 'A')
            {
                voweled = true;
                str = str.Substring(1);
                dotpos--;
            }
            else {
                int v = str[lastpos - 1];
                if (v == 'A')
                {
                    v = 0;
                }
                else if (v == 'E')
                {
                    v = 34;
                }
                else if (v == 'U')
                {
                    v = 68;
                }
                else
                {
                    v = -1;
                }
                if (v >= 0)
                {
                    char e = str[lastpos];
                    if (e == 'A')
                    {
                        v += 31;
                    }
                    else if (e == 'E')
                    {
                        v += 32;
                    }
                    else if (e == 'U')
                    {
                        v += 33;
                    }
                    else {
                        int ve = decode_chars[(int) str[lastpos]];
                        if (ve < 0)
                        {
                            return string.Empty;
                        }
                        v += ve;
                    }
                    if (v >= 100)
                    {
                        return "";
                    }
                    voweled = true;
                    str = str.Substring(0, lastpos - 1) + Data.ENCODE_CHARS[v / 10]
                        + Data.ENCODE_CHARS[v % 10];
                }
            }

            if (dotpos < 2 || dotpos > 5)
            {
                return string.Empty;
            }

            for (int v = 0; v <= lastpos; v++)
            {
                if (v != dotpos)
                {
                    if (decode_chars[(int) str[v]] < 0)
                    {
                        return string.Empty; // bad char!
                    }
                    else if (voweled && decode_chars[(int) str[v]] > 9)
                    {
                        return string.Empty; // nonodigit!
                    }
                }
            }

            return str;
        }

        /*@Nonnull*/
        private static Point decodeGrid(string str, int minx, int miny, int maxx, int maxy, int m, string extrapostfix)
        {
            // for a well-formed result, and integer variables
            string result = str;
            int relx, rely;
            int codexlen = result.Length - 1; // length ex dot
            int dc = result.IndexOf('.'); // dotposition

            if (dc == 1 && codexlen == 5)
            {
                dc++;
                result = result.Substring(0, 1) + result[2] + '.' + result.Substring(3);
            }
            int codexlow = codexlen - dc;
            int codex = 10 * dc + codexlow;

            int divx;
            int divy;
            divy = DataAccess.SmartDiv(m);
            if (divy == 1)
            {
                divx = Common.xSide[dc];
                divy = Common.ySide[dc];
            }
            else
            {
                divx = Common.nc[dc] / divy;
            }

            if (dc == 4 && divx == Common.xSide[4] && divy == Common.ySide[4])
            {
                result = result.Substring(0, 1) + result[2] + result[1] + result.Substring(3);
            }

            int v = fastDecode(result);

            if (divx != divy && codex > 24) // D==6
            {
                Point d = decode6(v, divx, divy);
                relx = d.getLonMicroDeg();
                rely = d.getLatMicroDeg();
            }
            else
            {
                relx = v / divy;
                rely = v % divy;
                rely = divy - 1 - rely;
            }

            int ygridsize = (maxy - miny + divy - 1) / divy;
            int xgridsize = (maxx - minx + divx - 1) / divx;

            rely = miny + rely * ygridsize;
            relx = minx + relx * xgridsize;

            int dividery = (ygridsize + Common.ySide[codexlow] - 1) / Common.ySide[codexlow];
            int dividerx = (xgridsize + Common.xSide[codexlow] - 1) / Common.xSide[codexlow];

            String rest = result.Substring(dc + 1);

            // decoderelative (postfix vs rely,relx)
            int difx;
            int dify;
            int nrchars = rest.Length;

            if (nrchars == 3)
            {
                Point d = decodeTriple(rest);
                difx = d.getLonMicroDeg();
                dify = d.getLatMicroDeg();
            }
            else
            {
                if (nrchars == 4)
                {
                    rest = Convert.ToInt32(rest[0]).ToString() + rest[2] + rest[1] + rest[3];
                }
                v = fastDecode(rest);
                difx = v / Common.ySide[nrchars];
                dify = v % Common.ySide[nrchars];
            }

            dify = Common.ySide[nrchars] - 1 - dify;

            int cornery = rely + dify * dividery;
            int cornerx = relx + difx * dividerx;
            return add2res(cornery, cornerx, dividerx << 2, dividery, 1, extrapostfix);
        }

        /*@Nonnull*/
        private static Point decodeNameless(string str, int firstrec, string extrapostfix, Data mapcoderData)
        {
            String result = str;
            if (mapcoderData.Codex == 22)
            {
                result = result.Substring(0, 3) + result.Substring(4);
            }
            else {
                result = result.Substring(0, 2) + result.Substring(3);
            }

            int a = Common.CountCityCoordinatesForCountry(mapcoderData.Codex, firstrec, firstrec);
            if (a < 2)
            {
                a = 1; // paranoia
            }

            int p = 31 / a;
            int r = 31 % a;
            int v = 0;
            int nrX;
            bool swapletters = false;

            if (mapcoderData.Codex != 21 && a <= 31)
            {
                int offset = decode_chars[(int) result[0]];

                if (offset < r * (p + 1))
                {
                    nrX = offset / (p + 1);
                }
                else
                {
                    swapletters = p == 1 && mapcoderData.Codex == 22;
                    nrX = r + (offset - r * (p + 1)) / p;
                }
            }
            else if (mapcoderData.Codex != 21 && a < 62)
            {
                nrX = decode_chars[(int) result[0]];
                if (nrX < (62 - a))
                {
                    swapletters = mapcoderData.Codex == 22;
                }
                else
                {
                    nrX = nrX + nrX - 62 + a;
                }
            }
            else
            {
                // codex==21 || A>=62
                int basePower = (mapcoderData.Codex == 21) ? 961 * 961 : 961 * 961 * 31;
                int basePowerA = basePower / a;
                if (a == 62)
                {
                    basePowerA++;
                }
                else
                {
                    basePowerA = 961 * (basePowerA / 961);
                }

                // decode and determine x
                v = fastDecode(result);
                nrX = v / basePowerA;
                v %= basePowerA;
            }

            if (swapletters && !Data.GetIsSpecialShape(firstrec + nrX))
            {
                result = result.Substring(0, 2) + result[3] + result[2] + result[4];
            }

            if (mapcoderData.Codex != 21 && a <= 31)
            {
                v = fastDecode(result);
                if (nrX > 0)
                {
                    v -= (nrX * p + (nrX < r ? nrX : r)) * 961 * 961;
                }
            }
            else if (mapcoderData.Codex != 21 && a < 62)
            {
                v = fastDecode(result.Substring(1));
                if (nrX >= (62 - a) && v >= (16 * 961 * 31))
                {
                    v -= 16 * 961 * 31;
                    nrX++;
                }
            }

            if (nrX > a)
            {
                return Point.undefined(); // return undefined (past end!)
            }
            mapcoderData.dataSetup(firstrec + nrX);

            int side = DataAccess.SmartDiv(firstrec + nrX);
            int xSIDE = side;

            int maxy = mapcoderData.MapcoderRect.getMaxY();
            int minx = mapcoderData.MapcoderRect.getMinX();
            int miny = mapcoderData.MapcoderRect.getMinY();

            int dx;
            int dy;

            if (mapcoderData.IsSpecialShape)
            {
                xSIDE *= side;
                side = 1 + (maxy - miny) / 90;
                xSIDE = xSIDE / side;

                Point d = decode6(v, xSIDE, side);
                dx = d.getLonMicroDeg();
                dy = side - 1 - d.getLatMicroDeg();
            }
            else
            {
                dy = v % side;
                dx = v / side;
            }

            if (dx >= xSIDE) // else out-of-range!
            {
                return Point.undefined(); // return undefined (out of range!)
            }

            int dividerx4 = Common.XDivider(miny, maxy); // 4 times too large!
            int dividery = 90;

            int cornerx = minx + (dx * dividerx4) / 4; // FIRST multiply, THEN
            // divide!
            int cornery = maxy - dy * dividery;
            return add2res(cornery, cornerx, dividerx4, dividery, -1, extrapostfix);
        }

        /*@Nonnull*/
        private static Point decodeStarpipe(string input, int firstindex, string extrapostfix,
            /*@Nonnull*/ Data mapcoderData)
        {
            // returns Point.isUndefined() in case or error
            int storageStart = 0;
            int thiscodexlen = mapcoderData.CodexLen;

            int value = fastDecode(input); // decode top (before dot)
            value *= 961 * 31;
            Point triple = decodeTriple(input.Substring(input.Length - 3));
            // decode bottom 3 chars

            int i;
            for (i = firstindex; ; i++)
            {
                if (Data.CalcCodexLen(i) != thiscodexlen)
                {
                    return Point.undefined(); // return undefined
                }
                if (i > firstindex)
                {
                    mapcoderData.dataSetup(i);
                }

                int maxx = mapcoderData.MapcoderRect.getMaxX();
                int maxy = mapcoderData.MapcoderRect.getMaxY();
                int minx = mapcoderData.MapcoderRect.getMinX();
                int miny = mapcoderData.MapcoderRect.getMinY();

                int h = (maxy - miny + 89) / 90;
                int xdiv = Common.XDivider(miny, maxy);
                int w = ((maxx - minx) * 4 + xdiv - 1) / xdiv;

                h = 176 * ((h + 176 - 1) / 176);
                w = 168 * ((w + 168 - 1) / 168);

                int product = (w / 168) * (h / 176) * 961 * 31;

                int goodRounder = mapcoderData.Codex >= 23 ? 961 * 961 * 31 : 961 * 961;
                if (mapcoderData.PipeType == 8)
                {
                    // *+
                    product = ((storageStart + product + goodRounder - 1) / goodRounder) * goodRounder - storageStart;
                }

                if (value >= storageStart && value < storageStart + product)
                {
                    // code belongs here?
                    int dividerx = (maxx - minx + w - 1) / w;
                    int dividery = (maxy - miny + h - 1) / h;

                    value -= storageStart;
                    value = value / (961 * 31);
                    // PIPELETTER DECODE
                    int vx = value / (h / 176);
                    vx = vx * 168 + triple.getLonMicroDeg();
                    int vy = (value % (h / 176)) * 176 + triple.getLatMicroDeg();

                    int cornery = maxy - vy * dividery;
                    int cornerx = minx + vx * dividerx;

                    /*
                     * Sri Lanka Defect (v1.1)
                     * {
                     *   int c1 = (zonedata == 0) ? -1 : decode_chars[(int) input .charAt(input.length() - 3)];
                     *   Point zd = addzonedata(cornery + (triple.getY() - 176) dividery,
                     *     cornerx - triple.getX() * dividerx, 176 * dividery, 168 * dividerx, c1, dividerx,
                     *     dividery);
                     *   cornery = zd.getY();
                     *   cornerx = zd.getX();
                     * }
                     */

                    Point retval = add2res(cornery, cornerx, dividerx << 2, dividery, -1, extrapostfix);

                    return retval;
                }
                storageStart += product;
            }
            // unreachable
        }
        
        /// <summary>
        /// This method decodes a Unicode string to ASCII.
        /// </summary>
        /// <param name="str">Unicode string.</param>
        /// <remarks>Package private for access by other modules.</remarks>
        /// <returns><ASCII stringASCII string../returns>
        static string decodeUTF16(string str)
        {
            StringBuilder asciibuf = new StringBuilder();
            for (int index = 0; index < str.Length; index++)
            {
                if (str[index] == '.')
                {
                    asciibuf.Append(str[index]);
                }
                else if (str[index] >= 1 && str[index] <= 'z')
                {
                    // normal ascii
                    asciibuf.Append(str[index]);
                }
                else {
                    bool found = false;
                    for (int i = 0; UNICODE2ASCII[i].min != 0; i++)
                    {
                        if (str[index] >= UNICODE2ASCII[i].min
                            && str[index] <= UNICODE2ASCII[i].max)
                        {
                            String convert = UNICODE2ASCII[i].convert;
                            if (convert == null)
                            {
                                convert = "0123456789";
                            }
                            asciibuf.Append(convert[(int) str[index]] - UNICODE2ASCII[i].min);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        asciibuf.Append('?');
                        break;
                    }
                }
            }

            return asciibuf.ToString();
        }

        /*@Nonnull*/
        private static Point decodeTriple(string str)
        {
            //noinspection NumericCastThatLosesPrecision
            byte c1 = (byte) decode_chars[(int) str[0]];
            int x = fastDecode(str.Substring(1));
            if (c1 < 24)
            {
                return Point.fromMicroDeg(c1 / 6 * 34 + x % 34, (c1 % 6) * 28 + x / 34);
            }
            return Point.fromMicroDeg(x % 40 + 136, x / 40 + 24 * (c1 - 24));
        }

        /*@Nonnull*/
        private static Point decode6(int v, int width, int height)
        {
            int d = 6;
            int col = v / (height * 6);
            int maxcol = (width - 4) / 6;
            if (col >= maxcol) {
                col = maxcol;
                d = width - maxcol * 6;
            }
            int w = v - col * height * 6;
            return Point.fromMicroDeg(height - 1 - w / d, col * 6 + w % d);
        }

        // / lowest level encode/decode routines
        private static int fastDecode(string code)
        // decode up to dot or EOS;
        // returns negative in case of error
        {
            int value = 0;
            int i;
            for (i = 0; i < code.Length; i++)
            {
                int c = (int) code[i];
                if (c == 46) // dot!
                {
                    return value;
                }
                if (decode_chars[c] < 0)
                {
                    return -1;
                }
                value = value * 31 + decode_chars[c];
            }
            return value;
        }

        /*@Nonnull*/
        private static Point add2res(int y, int x, int dividerx4, int dividery, int ydirection, String extrapostfix)
        {
            if (!string.IsNullOrEmpty(extrapostfix))
            {
                int c1 = (int) extrapostfix[0];
                c1 = decode_chars[c1];
                if (c1 < 0)
                {
                    c1 = 0;
                }
                else if (c1 > 29)
                {
                    c1 = 29;
                }
                int y1 = c1 / 5;
                int x1 = c1 % 5;
                int c2 = (extrapostfix.Length == 2) ? (int) extrapostfix[1] : 72; // 72='H'=code
                // 15=(3+2*6)
                c2 = decode_chars[c2];
                if (c2 < 0)
                {
                    c2 = 0;
                }
                else if (c2 > 29)
                {
                    c2 = 29;
                }
                int y2 = c2 / 6;
                int x2 = c2 % 6;

                int extrax = ((x1 * 12 + 2 * x2 + 1) * dividerx4 + 120) / 240;
                int extray = ((y1 * 10 + 2 * y2 + 1) * dividery + 30) / 60;

                return Point.fromMicroDeg(y + extray * ydirection, x + extrax);
            }
            return Point.fromMicroDeg(y + (dividery / 2) * ydirection, x + dividerx4 / 8);
        }
    }
}
