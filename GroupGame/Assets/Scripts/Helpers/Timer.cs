using System;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Timer script
    /// </summary>

    public sealed class Timer
    {
        private DateTime _start;
        private float _elapsed = -1;

        public TimeSpan Duratiom { get; private set; }

        public void Start(float elapsed)
        {
            _elapsed = elapsed;
            _start = DateTime.Now;
            Duratiom = TimeSpan.Zero;
        }

        public void Update()
        {
            if (_elapsed > 0)
            {
                Duratiom = DateTime.Now - _start;

                if (Duratiom.TotalSeconds > _elapsed)
                    _elapsed = 0;
            }
            else if (_elapsed == 0)
            {
                _elapsed = -1;
            }
        }

        public bool IsEvent()
        {
            return _elapsed == 0;
        }
    }
}