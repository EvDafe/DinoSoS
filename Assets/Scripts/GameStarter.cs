using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Animator _camera;

    public void StartTheGame()
    {
        _camera.SetTrigger("ToGame");
        HintsHider.Instance.Show();
        Destroy(GetComponent<Button>().gameObject);
    }
}
