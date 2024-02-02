using System.Collections;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
