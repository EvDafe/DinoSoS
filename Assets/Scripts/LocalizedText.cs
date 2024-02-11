using Scripts.Services;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] private TextKeys _key;
    protected TMP_Text _selfText;

    public virtual void Start()
    {
        AllServices.Container.GetSingleton<LanguagesContainer>().LanguageChanged.AddListener(UpdateText);
        _selfText ??= GetComponent<TMP_Text>();
        UpdateText();
    }

    protected virtual void UpdateText() =>
        _selfText.text = AllServices.Container.GetSingleton<LanguagesContainer>().WordsDictionary[LanguagesContainer.GameLanguage][_key];
}

