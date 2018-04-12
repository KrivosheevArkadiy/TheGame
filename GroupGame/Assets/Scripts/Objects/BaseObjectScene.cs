using UnityEngine;

namespace Assets.Scripts.Objects
{
    /// <summary>
    /// Base class for all objects
    /// </summary>

    public class BaseObjectScene : MonoBehaviour
    {
        protected int _layer;
        protected Transform _myTransform;
        protected Vector3 _position;
        protected Quaternion _rotation;
        protected Vector3 _scale;
        protected GameObject _instanceObject;
        protected Rigidbody _rigidbody;
        protected string _name;
        protected bool _isVisible;
        protected bool _isFreezed;
        protected bool _isPhysicsOn;

        #region Property

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                InstanceObject.name = _name;
            }
        }

        public int Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;

                if (_instanceObject != null)
                {
                    _instanceObject.layer = _layer;
                    AskLayer(GetTransform, value);
                }
            }
        }

        public Vector3 Position
        {
            get
            {
                if (InstanceObject != null)
                    _position = GetTransform.position;

                return _position;
            }
            set
            {
                _position = value;
                if (InstanceObject != null)
                    GetTransform.position = _position;
            }
        }

        public Vector3 Scale
        {
            get
            {
                if (InstanceObject != null)
                    _scale = GetTransform.localScale;
                return _scale;
            }
            set
            {
                _scale = value;
                if (InstanceObject != null)
                    GetTransform.localScale = _scale;
            }
        }

        public Quaternion Rotation
        {
            get
            {
                if (_instanceObject != null)
                    _rotation = GetTransform.rotation;
                return _rotation;
            }
            set
            {
                _rotation = value;
                if (InstanceObject != null)
                    GetTransform.rotation = _rotation;
            }
        }

        public Rigidbody GetRigidbody
        {
            get { return _rigidbody; }
        }

        public GameObject InstanceObject
        {
            get { return _instanceObject; }
        }

        public Transform GetTransform
        {
            get { return _myTransform; }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                if (_instanceObject.GetComponent<MeshRenderer>())
                    _instanceObject.GetComponent<MeshRenderer>().enabled = _isVisible;
                if (_instanceObject.GetComponent<SkinnedMeshRenderer>())
                    _instanceObject.GetComponent<SkinnedMeshRenderer>().enabled = _isVisible;
            }
        }

        public bool IsFreezed
        {
            get { return _isFreezed; }
            set
            {
                _isFreezed = value;
                if (InstanceObject != null)
                    _instanceObject.isStatic = _isFreezed;
            }
        }

        public bool IsPhysicsOn
        {
            get { return _isPhysicsOn; }
            set
            {
                _isPhysicsOn = value;
                if (InstanceObject != null && GetRigidbody != null)
                    _instanceObject.GetComponent<Rigidbody>().isKinematic = _isPhysicsOn;
            }
        }
        #endregion

        #region UnityFunction

        protected virtual void Awake()
        {
            _instanceObject = gameObject;
            _name = _instanceObject.name;
            _rigidbody = _instanceObject.GetComponent<Rigidbody>();
            _myTransform = _instanceObject.transform;
            _isFreezed = false;
            IsPhysicsOn = true;
        }
        #endregion

        #region PrivateFunction

        private void AskLayer(Transform obj, int layer)
        {
            obj.gameObject.layer = layer;
            if (obj.childCount > 0)
                foreach (Transform o in obj)
                {
                    AskLayer(o, layer);
                }
        }

        private void AskColor(Transform obj, Color color)
        {
            obj.GetComponent<Renderer>().material.color = color;
            if (obj.childCount > 0)
                foreach (Transform o in obj)
                {
                    AskColor(o, color);
                }
        }
        #endregion
    }
}
