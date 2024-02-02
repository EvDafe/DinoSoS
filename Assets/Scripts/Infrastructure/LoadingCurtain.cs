using System.Collections;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class LoadingCurtain : MonoBehaviour
    {
        private const float FadeOut = 0.03f;

        [SerializeField] private CanvasGroup _curtain;

        private void Awake() =>
            DontDestroyOnLoad(this);

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }

        public void Hide() =>
            StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= FadeOut;
                yield return new WaitForSeconds(FadeOut);
            }

            gameObject.SetActive(false);
        }
    }
}
