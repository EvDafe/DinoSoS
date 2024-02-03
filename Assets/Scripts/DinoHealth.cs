using Scripts.Services;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class DinoHealth : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Obstacle obstacle))
                AllServices.Container.GetSingleton<GameStateTransmiter>().OnDinoDied();
        }
    }
}
