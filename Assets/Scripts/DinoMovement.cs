using System;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    [SerializeField] private DinoAnimationController _animationController;

    public float Speed;

    private void Start() => 
        _animationController.SetIsRunning(true);

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        transform.position += Vector3.left * Speed * Time.fixedDeltaTime;
    }

    private void Jump() => 
        _animationController.Jump();
}
