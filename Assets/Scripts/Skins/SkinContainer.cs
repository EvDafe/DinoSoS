﻿using Scripts.Services;
using Scripts.Saves;
using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Skins
{
    public class SkinContainer : MonoBehaviour
    {
        [SerializeField] private List<SkinData> _datas = new();
        [SerializeField] private DinoView _view;

        private DataSource _dataSource;
        private List<int> UnlockedSkins => _dataSource.PlayerProgress.UnlockedSkins;

        public IReadOnlyCollection<SkinData> Datas => _datas;

        private void Start()
        {
            _dataSource = AllServices.Container.GetSingleton<DataSource>();
            _view.SetSkin(_datas[_dataSource.PlayerProgress.LastSkinIndex]);
        }

        public void Unlock(int id)
        {
            if (UnlockedSkins.Contains(id))
                return;

            UnlockedSkins.Add(id);

            SetSkin(id);
            _dataSource.Save();
        }

        public void SetSkin(int id)
        {
            if (UnlockedSkins.Contains(id))
                _view.SetSkin(_datas[id]);

            _dataSource.PlayerProgress.LastSkinIndex = id;
            _dataSource.Save();
        }
    }
}
