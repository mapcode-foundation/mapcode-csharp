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

namespace mapcode.com
{
    internal class Range<T> where T:IComparable
    {
        private readonly T min;
        private readonly T max;

        public Range(T min, T max)
        {
            System.Diagnostics.Debug.Assert(min != null);
            System.Diagnostics.Debug.Assert(max != null);
            this.min = min;
            this.max = max;
        }

        public Range(Range<T> range)
        {
            System.Diagnostics.Debug.Assert(range != null);
            this.min = range.min;
            this.max = range.max;
        }

        public T getMin()
        {
            System.Diagnostics.Debug.Assert(min != null);
            return min;
        }

        public T getMax()
        {
            System.Diagnostics.Debug.Assert(max != null);
            return max;
        }

        public bool contains(T value)
        {
            System.Diagnostics.Debug.Assert(value != null);
            return (value.CompareTo(min) >= 0) && (value.CompareTo(max) <= 0);
        }

        public bool containsRange(Range<T> range)
        {
            System.Diagnostics.Debug.Assert(range != null);
            return this.min.CompareTo(range.getMin()) <= 0 && this.max.CompareTo(range.getMax()) >= 0;
        }

        public bool intersects(Range<T> range)
        {
            System.Diagnostics.Debug.Assert(range != null);
            return range.contains(min) || range.contains(max) || contains(range.max) || contains(range.min);
        }

        public Range<T> constrain(Range<T> constrainingRange)
        {
            System.Diagnostics.Debug.Assert(constrainingRange != null);
            T newMin = this.min;
            T newMax = this.max;
            if (newMin.CompareTo(constrainingRange.getMin()) < 0)
            {
                newMin = constrainingRange.getMin();
            }
            if (newMax.CompareTo(constrainingRange.getMax()) > 0)
            {
                newMax = constrainingRange.getMax();
            }

            if (newMax.CompareTo(newMin) <= 0)
            {
                return null;
            }

            return new Range<T>(newMin, newMax);
        }

        public List<Range<T>> constrain(List<Range<T>> constrainingRanges)
        {
            System.Diagnostics.Debug.Assert(constrainingRanges != null);
            List<Range<T>> rv = null;
            List<Range<T>> resultRanges = new List<Range<T>>();
            foreach (Range<T> range in constrainingRanges)
            {
                Range<T> constrainedRange = constrain(range);
                if (constrainedRange != null)
                {
                    resultRanges.Add(constrainedRange);
                }
            }
            if (resultRanges.Count != 0)
            {
                rv = resultRanges;
            }
            return rv;
        }
    }
}
