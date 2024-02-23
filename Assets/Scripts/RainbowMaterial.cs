using UnityEngine;

public class RainbowMaterial : MonoBehaviour
{
    [SerializeField] private Material _ranibow;

    private void Start() =>
        _ranibow.mainTextureOffset = new Vector2(0, 0);

    private void FixedUpdate() =>
        _ranibow.mainTextureOffset = new Vector2(_ranibow.mainTextureOffset.x + 0.01f, _ranibow.mainTextureOffset.y);

}
