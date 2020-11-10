using TMPro;
using UnityEngine;

namespace TimeManagement
{
    [RequireComponent(typeof(TMP_Text))]
    public class TimeText : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            UpdateTime(GameManager.GameManager.Instance.TimeManager.CountDown);
            GameManager.GameManager.Instance.TimeManager.onCountDownChange += UpdateTime;
        }

        private void UpdateTime(float value)
        {
            text.text = value.ToString("f0");
            if ((int) value < 10)
            {
                text.color = Color.red;
                text.fontStyle = FontStyles.Bold;
            }
        }
    }
}
