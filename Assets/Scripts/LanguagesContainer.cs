using Scripts.Services;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public enum Languages
{
    Russian = 0,
    English = 1,
    Turkish = 2
}

public enum TextKeys
{
    yourScore,
    best,
    gameOver,
    language,
    shop,
    back,
    set,
    buy,
    dino,
    pressToJump,
    pressToCrouch
}

public class LanguagesContainer : MonoBehaviour, IService
{
    private static Languages gameLanguage = Languages.Russian;
    public static Languages GameLanguage => gameLanguage;
    public Dictionary<Languages, Dictionary<TextKeys, string>> WordsDictionary { get; private set; }
    public UnityEvent LanguageChanged;

    private void Awake()
    {
        AllServices.Container.RegisterSingleton(this);
        FillWordsDictionary();
    }

    public void ChangeLanguage(Languages language)
    {
        gameLanguage = language;
        LanguageChanged?.Invoke();
    }

    public void SetToRussian() =>
        ChangeLanguage(Languages.Russian);

    public void SetToEnglish() =>
        ChangeLanguage(Languages.English);

    public void SetToTurkish() =>
        ChangeLanguage(Languages.Turkish);

    private void FillWordsDictionary()
    {
        WordsDictionary = new Dictionary<Languages, Dictionary<TextKeys, string>>()
        {
            [Languages.Russian] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.yourScore] = "СЧЁТ: ",
                [TextKeys.best] = "РЕКОРД: ",
                [TextKeys.gameOver] = "ИГРАОКОНЧЕНА",
                [TextKeys.language] = "Язык:",
                [TextKeys.shop] = "Магазин",
                [TextKeys.back] = "Назад",
                [TextKeys.set] = "Выбрать",
                [TextKeys.buy] = "Купить",
                [TextKeys.dino] = "Забег Нубика",
                [TextKeys.pressToJump] = "Нажми, чтобы\nпрыгнуть",
                [TextKeys.pressToCrouch] = "Нажми, чтобы\nпригнуться",

            },

            [Languages.English] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.yourScore] = "SCORE: ",
                [TextKeys.best] = "HI: ",
                [TextKeys.gameOver] = "GAME OVER",
                [TextKeys.language] = "Language:",
                [TextKeys.shop] = "Shop",
                [TextKeys.back] = "Back",
                [TextKeys.set] = "Set",
                [TextKeys.buy] = "Buy",
                [TextKeys.dino] = "Noob's Run",
                [TextKeys.pressToJump] = "Press to\njump",
                [TextKeys.pressToCrouch] = "Press to\nduck"
            },

            [Languages.Turkish] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.yourScore] = "Puanınız: ",
                [TextKeys.best] = "En iyisi: ",
                [TextKeys.gameOver] = "KAYBETTIN",
                [TextKeys.language] = "Dil:",
                [TextKeys.shop] = "Mağaza",
                [TextKeys.back] = "Geri",
                [TextKeys.set] = "Seçmek",
                [TextKeys.buy] = "Satın almak",
                [TextKeys.dino] = "Başlangıç ​​Yarışı",
                [TextKeys.pressToJump] = "Atlamak için\ntıklayın",
                [TextKeys.pressToCrouch] = "Eğilmek için\nbasın"

            }
        };
    }
}


