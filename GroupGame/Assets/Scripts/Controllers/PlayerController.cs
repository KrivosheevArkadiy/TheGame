using UnityEngine;
using Assets.Scripts.Objects.Entities;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Controlls player
    /// </summary>

    public class PlayerController : BaseController
    {
        private Player _player;

        #region UnityFunc

        private void Update()
        {
            InputAxisVertical();
            InputAxisHorizontal();
        }

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        #endregion
        
        //Надо перенести в класс player
        #region Methods

        private void InputAxisVertical()
        {
            //_player.Move(0, Input.GetAxis("Vertical"));
            //реализовать смещение по координатам а не через физику используя лерп или дотвин
            //(смотри в класс Player)
        }

        private void InputAxisHorizontal()
        {
            //_player.Move(Input.GetAxis("Horizontal"), 0);
        }
        
        #endregion
    }
}
