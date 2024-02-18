using Scripts.Saves;
using Scripts.Services;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Best2YAGEY : LocalizedText, IService
{
    private DataSource _data;

    public override void Start()
    {
        _data = AllServices.Container.GetSingleton<DataSource>();
        base.Start();
    }

    protected override void UpdateText() =>
        _selfText.text = AllServices.Container.GetSingleton<LanguagesContainer>().WordsDictionary[LanguagesContainer.GameLanguage][TextKeys.best] + string.Format("{0:d6}", Mathf.RoundToInt(_data.PlayerProgress.BestScore));
}