using UnityEngine;

public class SkyBoxChanger : MonoBehaviour
{
    [SerializeField] private Material[] _skybox;

    private void Awake() =>
        RenderSettings.skybox = _skybox[Random.Range(0, _skybox.Length)];
}
