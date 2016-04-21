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
    /// This class the data class for Mapcode codex items.
    /// </summary>
    /// <remarks>For internal use within the Mapcode implementation only.</remarks>
    internal class Data
    {
        private static readonly char[] ENCODE_CHARS =
            new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'B', 'C', 'D', 'F',
            'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'};

        private int flags = 0;
        private int codex = 0;
        private int codexLo = 0;
        private int codexHi = 0;
        private int codexLen = 0;
        private bool nameless = false;
        private bool useless = false;
        private bool specialShape = false;
        private int  pipeType = 0;
        private string pipeLetter = null;
        private bool starPipe = false;
        private SubArea mapcoderRect = null;
        private bool initialized = false;

        public int Flags
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return flags;
            }
        }

        public int Codex
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return codex;
            }
        }

        public int CodexLo
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return codexLo;
            }
        }

        public int CodexHi
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return codexHi;
            }
        }

        public int CodexLen
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return codexLen;
            }
        }

        public bool IsNameless
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return nameless;
            }
        }

        public bool IsUseless
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return useless;
            }
        }

        public bool IsSpecialShape
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return specialShape;
            }
        }

        public int PipeType
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return pipeType;
            }
        }

        public string PipeLetter
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                System.Diagnostics.Debug.Assert(pipeLetter != null);
                return pipeLetter as string;
            }
        }

        public bool IsStarPipe
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                return starPipe;
            }
        }

        public SubArea MapcoderRect
        {
            get
            {
                System.Diagnostics.Debug.Assert(initialized);
                System.Diagnostics.Debug.Assert(mapcoderRect != null);
                return mapcoderRect;
            }
        }

        Data(int i)
        {
            dataSetup(i);
        }

        Data()
        {
            initialized = false;
        }

        private void dataSetup(int i)
        {
            flags = DataAccess.DataFlags(i);
            codexHi = CalcCodexHi(flags);
            codexLo = CalcCodexLo(flags);
            codexLen = CalcCodexLen(codexHi, codexLo);
            codex = CalcCodex(codexHi, codexLo);
            nameless = GetIsNameless(i);
            useless = (flags & 512) != 0;
            specialShape = GetIsSpecialShape(i);
            pipeType = (flags >> 5) & 12; // 4=pipe 8=plus 12=star
            if (pipeType == 4)
            {
                pipeLetter = (ENCODE_CHARS[(flags >> 11) & 31]).ToString();
            }
            else
            {
                pipeLetter = string.Empty;
            }
            if ((codex == 21) && !nameless)
            {
                codex++;
                codexLo++;
                codexLen++;
            }
            starPipe = CalcStarPipe(i);
            mapcoderRect = SubArea.GetArea(i);
            initialized = true;
        }

        public static bool GetIsNameless(int i)
        {
            return (DataAccess.DataFlags(i) & 64) != 0;
        }

        public static bool GetIsSpecialShape(int i)
        {
            return (DataAccess.DataFlags(i) & 1024) != 0;
        }

        public static int CalcCodex(int i)
        {
            int flags = DataAccess.DataFlags(i);
            return CalcCodex(CalcCodexHi(flags), CalcCodexLo(flags));
        }

        public static int CalcCodexLen(int i)
        {
            int flags = DataAccess.DataFlags(i);
            return CalcCodexLen(CalcCodexHi(flags), CalcCodexLo(flags));
        }

        public static bool CalcStarPipe(int i)
        {
            return (DataAccess.DataFlags(i) & (8 << 5)) != 0;
        }

        private static int CalcCodexHi(int flags)
        {
            return (flags & 31) / 5;
        }

        private static int CalcCodexLo(int flags)
        {
            return ((flags & 31) % 5) + 1;
        }

        private static int CalcCodex(int codexhi, int codexlo)
        {
            return (10 * codexhi) + codexlo;
        }

        private static int CalcCodexLen(int codexhi, int codexlo)
        {
            return codexhi + codexlo;
        }
    }
}
