using Scripts.Saves;
using Scripts.Services;
using TMPro;
using UnityEngine;

namespace Scripts.Scores
{
    [RequireComponent(typeof(TMP_Text))]
    public class BestText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private DataSource _data;

        private void OnValidate() =>
            _text ??= GetComponent<TMP_Text>();

        private void Start()
        {
            _data = AllServices.Container.GetSingleton<DataSource>();
            _text.text = "Best: " + _data.PlayerProgress.BestScore.ToString();
        }
    }
}
