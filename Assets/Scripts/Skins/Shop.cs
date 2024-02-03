
using Scripts.Saves;
using Scripts.Services;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Skins
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private SkinContainer _container;

        private DataSource _data;

        public UnityEvent BuyedSkin;

        private void Awake() => 
            _data = AllServices.Container.GetSingleton<DataSource>();

        public void BuySkin(int id)
        {
            if(_data.PlayerProgress.Money >= GetSkinCost(id))
                Buy(id);
        }

        private void Buy(int id)
        {
            _data.PlayerProgress.Money -= GetSkinCost(id);
            _container.Unlock(id);
            BuyedSkin?.Invoke();
        }

        private int GetSkinCost(int id) =>
            _container.Datas.ElementAt(id).Cost;
    }
}
