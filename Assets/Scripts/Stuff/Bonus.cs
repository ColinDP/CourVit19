using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = System.Random;

namespace Stuff
{
    public class Bonus : MonoBehaviour
    {
        private Random _random;
        // private const float _interval = 7;
        private RawImage icon;
        private Texture transpImage;
        private Texture trollImage;
        private Texture timerImage;
        private Texture maskImage;
        private Texture sprayImage;
        private SpriteRenderer playerSprite;

        private void Awake()
        {
            _random = new Random();
            icon = GameObject.FindWithTag("icon").GetComponent<RawImage>();
        }

        private void Start()
        {
            transpImage = Resources.Load("Sprites/transp") as Texture;
            trollImage = Resources.Load("Sprites/troll-face") as Texture;
            timerImage = Resources.Load("Sprites/timer") as Texture;
            maskImage = Resources.Load("Sprites/mask") as Texture;
            sprayImage = Resources.Load("Sprites/spray") as Texture;
        }

        public void GiveMoreTime()
        {
            GameManager.GameManager.Instance.TimeManager.SetCountDown(20);
            icon.texture = timerImage;
            StartCoroutine(CoroutineGiveMoreTime());
        }

        public void KillAllViruses(GameObject go)
        {
            var allViruses = GameObject.FindGameObjectsWithTag("virusagent");
            foreach (var virus in allViruses)
            {
               Destroy(virus);
            }
            icon.texture = sprayImage;
            StartCoroutine(CoroutineKillAllViruses());
        }
        
        public void ReduceSpeed(Player player, GameObject bonusCollided)
        {
            bonusCollided.GetComponent<MeshRenderer>().enabled = false;
            bonusCollided.GetComponent<SphereCollider>().enabled = false;
            icon.texture = trollImage;
            StartCoroutine(CoroutineReduceSpeed(player));
        }

        public void GiveInvincibility(Player player, GameObject bonusCollided)
        {
            bonusCollided.GetComponent<MeshRenderer>().enabled = false;
            bonusCollided.GetComponent<SphereCollider>().enabled = false;
            icon.texture = maskImage;
            StartCoroutine(CoroutineGiveInvincibility(player));
        }
        
        private IEnumerator CoroutineGiveMoreTime()
        {
            yield return new WaitForSeconds(2);
            icon.texture = transpImage;
        }
        
        private IEnumerator CoroutineKillAllViruses()
        {
            yield return new WaitForSeconds(2);
            icon.texture = transpImage;
        }
        
        private IEnumerator CoroutineReduceSpeed(Player player)
        {
            var initialSpeed = player.Speed;
            player.Speed -= 2;
            playerSprite = player.transform.GetChild(0).GetComponent<SpriteRenderer>();
            playerSprite.color = Color.red;
            yield return new WaitForSeconds(3);
            StartCoroutine(colorBackToNormal(playerSprite));
            yield return new WaitForSeconds(2);
            player.Speed = initialSpeed;
            icon.texture = transpImage;
        }

        private IEnumerator CoroutineGiveInvincibility(Player player)
        {
            player.Invincible = true;
            playerSprite = player.transform.GetChild(0).GetComponent<SpriteRenderer>();
            playerSprite.color = Color.cyan;
            yield return new WaitForSeconds(8);
            StartCoroutine(colorBackToNormal(playerSprite));
            yield return new WaitForSeconds(2);
            player.Invincible = false;
            icon.texture = transpImage;
        }

        private IEnumerator colorBackToNormal(SpriteRenderer sprite)
        {
            Color current = sprite.color;
            Color normal = Color.white;
            sprite.color = normal;
            yield return new WaitForSeconds(0.5f);
            sprite.color = current;
            yield return new WaitForSeconds(0.5f);
            sprite.color = normal;
            yield return new WaitForSeconds(0.5f);
            sprite.color = current;
            yield return new WaitForSeconds(0.5f);
            sprite.color = normal;
        }
    }
}