using UnityEngine;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Base class for all controllers
    /// </summary>

    public abstract class BaseController : MonoBehaviour
    {
        private bool _enabled = true;

        #region Property

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        #endregion

        public virtual void On()
        {
            _enabled = true;
        }

        public virtual void Off()
        {
            _enabled = false;
        }
    }
}
