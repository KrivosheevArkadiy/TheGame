using Assets.Scripts.Controllers;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Tools
{
    /// <summary>
    /// Start point of programm
    /// </summary>

    public sealed class Main : Singleton<Main>
    {
        private GameObject _controllersGameObject;
        private InputController _inputController;
        private PlayerController _playerController;
        private BotsController _botsController;

        public enum PhaseType {Dialog, Runner, Shooter};

        private void Awake()
        {
            _controllersGameObject = new GameObject() { name = "Controllers" };
            _inputController = _controllersGameObject.AddComponent<InputController>();
            _playerController = _controllersGameObject.AddComponent<PlayerController>();
            _botsController = _controllersGameObject.AddComponent<BotsController>();
        }

        #region Properties

        public InputController GetInputController
        {
            get { return _inputController; }
        }

        public PlayerController GetPlayerController
        {
            get { return _playerController; }
        }

        public BotsController GetBotsController
        {
            get { return _botsController; }
        }

        #endregion
    }
}