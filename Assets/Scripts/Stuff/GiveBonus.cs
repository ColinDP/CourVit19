using System;
using UnityEngine;
using Random = System.Random;

namespace Stuff
{
    public class GiveBonus : MonoBehaviour
    {

        private Bonus _bonus;

        private void Awake()
        {
            _bonus = GameObject.FindWithTag("gameManager").AddComponent<Bonus>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("player"))
            {
                GenerateRandomBonus(other.rigidbody.GetComponent<Player>());
            }
        }

        private void GenerateRandomBonus(Player player)
        {
            int positiveRandom = Mathf.Abs((int) DateTime.Now.Ticks - GetInstanceID());
            switch (positiveRandom % 4) //random 0 à 3
            {
                case 0 :
                    _bonus.GiveMoreTime();
                    break;
                case 1 :
                    _bonus.ReduceSpeed(player, gameObject);
                    break;
                case 2 :
                    _bonus.GiveInvincibility(player, gameObject);
                    break;
                case 3 :
                    _bonus.KillAllViruses(gameObject);
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
