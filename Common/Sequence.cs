using System;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class Sequence : IEnumerable<int>
    {
        private readonly int _start, _stop, _step;
        //private readonly bool _startInclusive, _stopInclusive, _ignoreStep;
        private int _current;

        //public Range(int start, int stop, bool startInclusive = true, bool stopInclusive = false, int step = 1)
        public Sequence(int start, int stop, int step = 1)
        {
            _current = _start = start;
            _stop = stop;
            _step = step;
            //_startInclusive = startInclusive;
            //_stopInclusive = stopInclusive;

            //if (_stop < _start && _step > 0)
            //    _ignoreStep = false;
        }

        public IEnumerator<int> GetEnumerator()
        {
            while (_current != _stop)
            {
                yield return _current;
                _current += _step;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
