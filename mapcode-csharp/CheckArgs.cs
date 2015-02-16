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
    internal class CheckArgs
    {
        public static void checkRange(string param, double value, double min, double max)
        {
            if ((value < min) || (value > max))
            {
                throw new ArgumentOutOfRangeException(string.Format("Parameter {0} should be in range [{1}, {2}], but is {3}", param, min, max, value));
            }
        }

        public static void checkNonnull(string param, object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException(string.Format("Parameter {0} should not be null", param));
            }
        }
    }
}
