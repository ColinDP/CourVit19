using UnityEngine;

namespace DeathManagement
{
    public class KillOnCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("player") && !other.rigidbody.GetComponent<Player>().Invincible)
                other.rigidbody.GetComponent<IDeath>()?.OnDeath();
        }
    }
}
