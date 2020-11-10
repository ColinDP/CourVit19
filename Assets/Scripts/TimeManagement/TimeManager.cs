using System;
using UnityEngine;

namespace TimeManagement
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float _countDown;
        public float CountDown => _countDown;
        public Action<float> onCountDownChange;
        private void Awake()
        {
            // _countDown = 15;
        }

        private void Update()
        {
            if(_countDown <0.5)
                GameManager.GameManager.Instance.LoadScene("GameOver");
            else
                SetCountDown(-Time.deltaTime);
        }

        public void SetCountDown(float val)
        {
            _countDown += val;
            onCountDownChange(_countDown);
        }
    }
}
