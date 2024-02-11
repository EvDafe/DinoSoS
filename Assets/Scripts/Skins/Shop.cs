using Scripts.Money;
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

        private Wallet _wallet;

        public UnityEvent BoughtSkin;

        private void Awake() => 
            _wallet = AllServices.Container.GetSingleton<Wallet>();

        public bool BuySkin(int id)
        {
            if (_wallet.CanSpendMoney(GetSkinCost(id)))
            {
                Buy(id);
                return true;
            }
            return false;
        }

        private void Buy(int id)
        {
            _wallet.SpendMoney(GetSkinCost(id));
            _container.Unlock(id);
            BoughtSkin?.Invoke();
        }

        private int GetSkinCost(int id) =>
            _container.Datas.ElementAt(id).Cost;
    }
}
