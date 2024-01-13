using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class DinoHealth : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Obstacle obstacle))
            {
                Death();
            }
        }

        private void Death()
        {
            Debug.Log("Yes");
        }
    }
}
