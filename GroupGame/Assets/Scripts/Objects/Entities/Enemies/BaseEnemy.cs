using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Objects.Weapons;

namespace Assets.Scripts.Objects.Entities.Enemies
{
    /// <summary>
    /// Base for all types of enemies 
    /// </summary>

    public abstract class BaseEnemy : BaseObjectScene, ISetDamage
    {
        protected GameObject _target;
        [SerializeField]
        protected float _hp = 100.0f;
        [SerializeField]
        protected float _brakeDamage;
        [SerializeField]
        protected float _moveSpeed;

        #region Properties

        public float GetBrakeDamage
        {
            get { return _brakeDamage; }
        }

        public float GetHp
        {
            get { return _hp; }
        }

        #endregion

        #region UnityFunc

        protected virtual void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player");
        }

        protected virtual void OnTriggerEnter(Collider collision)
        {
            var tempCollison = collision.gameObject;
            if (tempCollison.GetComponent<Player>() != null)
            {
                SetCollisionDamage(collision.gameObject.GetComponent<ISetDamage>());
            }
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

        protected virtual void SetCollisionDamage(ISetDamage obj)
        {
            if (obj == null) return;
            obj.SetDamage(_brakeDamage);
        }

        protected virtual void Death()
        {
            Destroy(_instanceObject);
        }

        protected abstract void AI();

        #endregion
    }
}
