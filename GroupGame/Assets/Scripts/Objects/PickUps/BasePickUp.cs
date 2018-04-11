using Assets.Scripts.Objects;
using UnityEngine;

namespace Assets.Scripts.PickUps
{
    [RequireComponent(typeof(Collider))]
    public abstract class BasePickUp : BaseObjectScene
    {
        protected abstract void OnTriggerEnter(Collider collision);
    }
}