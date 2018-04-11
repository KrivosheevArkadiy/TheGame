using UnityEngine;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Objects.Entities
{
    /// <summary>
    /// Player model
    /// </summary>

    public sealed class Player : BaseObjectScene, ISetDamage
    {
        [SerializeField]
        private float _hp = 100.0f;

        #region Properties

        public float GetHp
        {
            get { return _hp; }
        }

        #endregion

        #region Methods

        public void SetDamage(float damage)
        {
            _hp -= damage;
            if (_hp <= 0.0f)
            {
                Death();
            }
        }

        private void Death()
        {
            Destroy(_instanceObject);
        }

        #endregion

        #region ControlFuncs

        //There should be contoll void
        
        #endregion
    }
}
