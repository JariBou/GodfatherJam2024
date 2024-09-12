using System.Collections;
using UnityEngine;

namespace _project.Scripts
{
    public class ParticleScript : MonoBehaviour
    {
        [SerializeField] private float _delayBeforeDestroy = 2f;

        private void Awake()
        {
            StartCoroutine(DelayedDestroy());
        }

        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(_delayBeforeDestroy);
            Destroy(gameObject);
        }
    }
}
