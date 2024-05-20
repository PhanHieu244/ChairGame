using ChuongCustom;
using TMPro;
using UnityEngine;

namespace TextDisplay
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HighScoreText : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            GameAction.OnHighScoreChange += Show;
            Show(0);
        }

        private void Show(int value)
        {
            var textValue = GameDataManager.Instance.playerData.HighScore;
            var a = textValue / 10;
            var b = textValue - a * 10;
            _text.SetText($"{a}.{b}m");
        }
    }
}