using Scripts.Services;
using UnityEditor;
using UnityEngine;

public class Tools
{
    [MenuItem("Tools/ClearData")]
    public static void ClearData() => 
        PlayerPrefs.DeleteAll();

    [MenuItem("Tools/Languages/SetRussian")]
    public static void SetRussian() =>
        AllServices.Container.GetSingleton<LanguagesContainer>().ChangeLanguage(Languages.Russian);

    [MenuItem("Tools/Languages/SetEnglish")]
    public static void SetEnglish() =>
        AllServices.Container.GetSingleton<LanguagesContainer>().ChangeLanguage(Languages.English);

    [MenuItem("Tools/Languages/SetTurkish")]
    public static void SetTurkish() =>
        AllServices.Container.GetSingleton<LanguagesContainer>().ChangeLanguage(Languages.Turkish);
}
