using UnityEngine;
using UnityEngine.Events;

namespace DeathManagement
{
    public class Death : MonoBehaviour, IDeath
    {
        [SerializeField] private UnityEvent onDeath;

        public void OnDeath()
        {
            onDeath?.Invoke();
        }
    }
}
