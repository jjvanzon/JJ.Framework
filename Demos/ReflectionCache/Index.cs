using System.Collections.Generic;
using JetBrains.Annotations;

namespace JJ.Demos.ReflectionCache
{
    // Index<T1, T2>

    [PublicAPI]
    public class Index<T1, T2>
    {
        private readonly Dictionary<T1, T2> _dictionary = new Dictionary<T1, T2>();

        public T2 this[T1 x]
        {
            get
            {
                if (_dictionary.ContainsKey(x))
                {
                    return _dictionary[x];
                }

                return default(T2);
            }
            set => _dictionary[x] = value;
        }

        public bool Contains(T1 x) => _dictionary.ContainsKey(x);
    }

    // Index<T1, T2, T3>

    [PublicAPI]
    public class Index<T1, T2, T3>
    {
        private readonly Index<T1, Index<T2, T3>> _base = new Index<T1, Index<T2, T3>>();

        public T3 this[T1 x, T2 y]
        {
            get
            {
                if (Contains(x, y)) return _base[x][y];
                return default(T3);
            }
            set
            {
                Index<T2, T3> entry;

                if (_base.Contains(x))
                {
                    entry = _base[x];
                }
                else
                {
                    entry = new Index<T2, T3>();
                    _base[x] = entry;
                }

                entry[y] = value;
            }
        }

        public bool Contains(T1 x, T2 y)
        {
            if (_base.Contains(x)) return _base[x].Contains(y);
            return false;
        }
    }

    // Index<T1, T2, T3, T4> 

    [PublicAPI]
    public class Index<T1, T2, T3, T4>
    {
        private readonly Index<T1, Index<T2, T3, T4>> _base =
            new Index<T1, Index<T2, T3, T4>>();

        public T4 this[T1 a, T2 b, T3 c]
        {
            get
            {
                if (Contains(a, b, c)) return _base[a][b, c];
                return default(T4);
            }
            set
            {
                Index<T2, T3, T4> entry;

                if (_base.Contains(a))
                {
                    entry = _base[a];
                }
                else
                {
                    entry = new Index<T2, T3, T4>();
                    _base[a] = entry;
                }

                entry[b, c] = value;
            }
        }

        public bool Contains(T1 a, T2 b, T3 c)
        {
            if (_base.Contains(a)) return _base[a].Contains(b, c);
            return false;
        }
    }

    // Index<T1, T2, T3, T4, T5>

    [PublicAPI]
    public class Index<T1, T2, T3, T4, T5>
    {
        private readonly Index<T1, Index<T2, T3, T4, T5>> _base =
            new Index<T1, Index<T2, T3, T4, T5>>();

        public T5 this[T1 a, T2 b, T3 c, T4 d]
        {
            get
            {
                if (Contains(a, b, c, d)) return _base[a][b, c, d];
                return default(T5);
            }
            set
            {
                Index<T2, T3, T4, T5> entry;

                if (_base.Contains(a))
                {
                    entry = _base[a];
                }
                else
                {
                    entry = new Index<T2, T3, T4, T5>();
                    _base[a] = entry;
                }

                entry[b, c, d] = value;
            }
        }

        public bool Contains(T1 a, T2 b, T3 c, T4 d)
        {
            if (_base.Contains(a)) return _base[a].Contains(b, c, d);
            return false;
        }
    }

    // Index<T1, T2, T3, T4, T5, T6>

    [PublicAPI]
    public class Index<T1, T2, T3, T4, T5, T6>
    {
        private readonly Index<T1, Index<T2, T3, T4, T5, T6>> _base =
            new Index<T1, Index<T2, T3, T4, T5, T6>>();

        public T6 this[T1 a, T2 b, T3 c, T4 d, T5 e]
        {
            get
            {
                if (Contains(a, b, c, d, e)) return _base[a][b, c, d, e];
                return default(T6);
            }
            set
            {
                Index<T2, T3, T4, T5, T6> entry;

                if (_base.Contains(a))
                {
                    entry = _base[a];
                }
                else
                {
                    entry = new Index<T2, T3, T4, T5, T6>();
                    _base[a] = entry;
                }

                entry[b, c, d, e] = value;
            }
        }

        public bool Contains(T1 a, T2 b, T3 c, T4 d, T5 e)
        {
            if (_base.Contains(a)) return _base[a].Contains(b, c, d, e);
            return false;
        }
    }

    // Index<T1, T2, T3, T4, T5, T6, T7>

    [PublicAPI]
    public class Index<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly Index<T1, Index<T2, T3, T4, T5, T6, T7>> _base =
            new Index<T1, Index<T2, T3, T4, T5, T6, T7>>();

        public T7 this[T1 a, T2 b, T3 c, T4 d, T5 e, T6 f]
        {
            get
            {
                if (Contains(a, b, c, d, e, f)) return _base[a][b, c, d, e, f];
                return default(T7);
            }
            set
            {
                Index<T2, T3, T4, T5, T6, T7> entry;

                if (_base.Contains(a))
                {
                    entry = _base[a];
                }
                else
                {
                    entry = new Index<T2, T3, T4, T5, T6, T7>();
                    _base[a] = entry;
                }

                entry[b, c, d, e, f] = value;
            }
        }

        public bool Contains(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
        {
            if (_base.Contains(a)) return _base[a].Contains(b, c, d, e, f);
            return false;
        }
    }

    // public class Index<T1, T2, T3, T4, T5, T6, T7, T8>

    [PublicAPI]
    public class Index<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly Index<T1, Index<T2, T3, T4, T5, T6, T7, T8>> _base =
            new Index<T1, Index<T2, T3, T4, T5, T6, T7, T8>>();

        public T8 this[T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g]
        {
            get
            {
                if (Contains(a, b, c, d, e, f, g)) return _base[a][b, c, d, e, f, g];
                return default(T8);
            }
            set
            {
                Index<T2, T3, T4, T5, T6, T7, T8> entry;

                if (_base.Contains(a))
                {
                    entry = _base[a];
                }
                else
                {
                    entry = new Index<T2, T3, T4, T5, T6, T7, T8>();
                    _base[a] = entry;
                }

                entry[b, c, d, e, f, g] = value;
            }
        }

        public bool Contains(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g) => _base.Contains(a) && _base[a].Contains(b, c, d, e, f, g);
    }
}