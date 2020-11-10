using UnityEngine;

namespace OnEntry
{
    public class OnEntryLoadNextLevel : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.name == "Player")
                GameManager.GameManager.Instance.LoadNextScene();
        }
    }
}
