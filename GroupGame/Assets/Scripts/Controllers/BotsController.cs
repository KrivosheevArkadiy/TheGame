using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Objects.Entities.Enemies;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Controller provides life to bots
    /// </summary>

    public sealed class BotsController : BaseController
    {
        private List<BaseEnemy> _botList = new List<BaseEnemy>();

        private int _counter = -1;

        #region Property

        public List<BaseEnemy> GetBotsList
        {
            get { return _botList; }
        }

        #endregion

        #region Methods

        public void AddBotToList(BaseEnemy enemy)
        {
            if (!GetBotsList.Contains(enemy))
            {
                _botList.Add(enemy);
                _counter++;
                _botList[_counter].GetNavMashAgent.avoidancePriority = _counter;
            }
        }

        public void RemoveBotFromList(BaseEnemy enemy)
        {
            if (GetBotsList.Contains(enemy))
            {
                _botList.Remove(enemy);
                _counter--;
            }
        }

        #endregion

    }
}
