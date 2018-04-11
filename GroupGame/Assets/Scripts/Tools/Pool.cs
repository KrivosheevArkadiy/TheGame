using UnityEngine;

namespace Assets.Scripts.Tools
{
    /// <summary>
    /// Class for each pool obj
    /// </summary>

    [System.Serializable]
    public sealed class Pool
    {
        [SerializeField]
        private string _tag;
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private int _size;

        #region Properties

        public string GetTag
        {
            get { return _tag; }
        }

        public GameObject GetPrefab
        {
            get { return _prefab; }
        }

        public int GetSize
        {
            get { return _size; }
        }
        
        #endregion
    }
}
