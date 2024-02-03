using Scripts.Services;
using TMPro;
using UnityEngine;

namespace Scripts.Scores
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private ScoreSchetchik _schetchik;

        private void OnValidate() => 
            _text ??= GetComponent<TMP_Text>();

        private void Start() => 
            _schetchik = AllServices.Container.GetSingleton<ScoreSchetchik>();

        private void Update() => 
            _text.text = Mathf.RoundToInt(_schetchik.GetCurrentScore()).ToString();
    }
}
