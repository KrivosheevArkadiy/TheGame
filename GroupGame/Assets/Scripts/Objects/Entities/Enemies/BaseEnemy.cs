using UnityEngine;
using UnityEngine.AI;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Tools;

namespace Assets.Scripts.Objects.Entities.Enemies
{
    /// <summary>
    /// Base for all types of enemies 
    /// </summary>

    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class BaseEnemy : BaseObjectScene, ISetDamage
    {
        protected Transform _target;
        [SerializeField]
        protected float _hp = 100.0f;
        [SerializeField]
        protected float _moveSpeed;
        protected bool _isDeath = false;
        protected NavMeshAgent _navMashAgent;
        [SerializeField]
        protected float _stoppingDist = 3;
        [SerializeField]
        protected float _attackDist = 4.5f;
        protected Vision _vision;

        #region Properties

        public float GetHp
        {
            get { return _hp; }
        }

        public NavMeshAgent GetNavMashAgent
        {
            get { return _navMashAgent; }
        }

        #endregion

        #region UnityFunc

        protected virtual void Awake()
        {
            base.Awake();
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            _navMashAgent = GetComponent<NavMeshAgent>();
            _vision = new Vision();
        }

        protected virtual void Start()
        {
            Main.Instance.GetBotsController.AddBotToList(this);
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

        protected virtual void Death()
        {
            _isDeath = true;
            Main.Instance.GetBotsController.RemoveBotFromList(this);
            Destroy(_instanceObject);
        }

        protected abstract void AI();

        #endregion
    }
}
