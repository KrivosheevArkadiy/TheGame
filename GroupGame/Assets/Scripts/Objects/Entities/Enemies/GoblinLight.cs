namespace Assets.Scripts.Objects.Entities.Enemies
{
    public sealed class GoblinLight : BaseEnemy
    {       
        #region UnityFunc

        private void Update()
        {
            AI();
        }

        #endregion
        
        #region Methods

        protected override void AI()
        {
            if (_isDeath) return;
            if (!_navMashAgent.hasPath)
            {
                _navMashAgent.SetDestination(_target.position);
                _navMashAgent.stoppingDistance = _stoppingDist;
            }
            if (_vision.VisionMath(_myTransform, _target))
            {
                Attack();
            }
        }

        private void Attack()
        {
            //
        }

        #endregion
    }
}
