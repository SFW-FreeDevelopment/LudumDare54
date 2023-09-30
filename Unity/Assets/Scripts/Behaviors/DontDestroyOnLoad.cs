using UnityEngine;

namespace LD54.Behaviors
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Start() => DontDestroyOnLoad(gameObject);
    }
}