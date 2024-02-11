using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.GameOverScreen
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnValidate() => 
            _button ??= GetComponent<Button>();

        private void Start() =>
            _button.onClick.AddListener(RestartLevel);

        private void RestartLevel() => 
            SceneManager.LoadScene(0);
    }
}
