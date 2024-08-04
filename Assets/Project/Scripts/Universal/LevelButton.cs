using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Connect.Core
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private Color _inactiveColor;

        private bool isLevelUnlcoked;
        private int currentLevel;

        void Awake()
        {
            _button.onClick.AddListener(Clicked);
        }

        void OnEnable()
        {
            MainMenuManager.Instance.LevelOpened += LevelOpened;
        }

        void OnDisable()
        {
            MainMenuManager.Instance.LevelOpened -= LevelOpened;
        }

        private void LevelOpened()
        {
            string gameObjectName = gameObject.name;
            string[] parts = gameObjectName.Split('_');
            _levelText.text = parts[parts.Length - 1];
            currentLevel = int.Parse(_levelText.text);
            isLevelUnlcoked = GameManager.Instance.IsLevelUnlocked(currentLevel);

            _image.color = isLevelUnlcoked ? MainMenuManager.Instance.CurrentColor : _inactiveColor;
        }

        private void Clicked()
        {
            if (!isLevelUnlcoked)
                return;

            GameManager.Instance.CurrentLevel = currentLevel;
            GameManager.Instance.GoToGameplay();
        }
    }
}
