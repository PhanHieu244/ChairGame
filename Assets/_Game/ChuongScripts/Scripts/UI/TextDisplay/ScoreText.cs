using ChuongCustom;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TextDisplay
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreText : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private int textValue = 0;
        
        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            ScoreManager.OnScoreChange += Show;
            textValue = ScoreManager.Score;
            var a = textValue / 10;
            var b = textValue - a * 10;
            _text.SetText($"{a}.{b}m");
        }

        private void OnDisable()
        {
            ScoreManager.OnScoreChange -= Show;
        }

        private void Show(int value)
        {
            Show(value, 0.7f);
        }
        
        private Tween Show(int value, float duration)
        {
            transform.DOComplete(true);
            return DOTween.To(() => textValue, x => textValue = x, value, duration).OnUpdate(() =>
            {
                var a = textValue / 10;
                var b = textValue - a * 10;
                _text.SetText($"{a}.{b}m");
            }).OnComplete(() =>
            {
                textValue = value;
            }).SetTarget(transform);
        }
    }
}