using Scripts.Saves;
using Scripts.Services;
using System;

namespace Scripts.Money
{
    public class Wallet : IService
    {
        private DataSource _dataSource;

        public Action MoneyChanged;
        public int Money => _dataSource.PlayerProgress.Money;

        public Wallet(DataSource dataSource) =>
            _dataSource = dataSource;

        public bool CanSpendMoney(int money) =>
            _dataSource.PlayerProgress.Money >= money;

        public void SpendMoney(int money)
        {
            _dataSource.PlayerProgress.Money -= money;
            MoneyChanged?.Invoke();
            _dataSource.Save();
        }

        public void AddMoney(int money)
        {
            _dataSource.PlayerProgress.Money += money;
            MoneyChanged?.Invoke();
            _dataSource.Save();
        }
    }
}
