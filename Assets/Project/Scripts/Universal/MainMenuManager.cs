using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Connect.Core
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Instance;

        [SerializeField]
        private GameObject _titlePanel;
        [SerializeField]
        private GameObject _stagePanel;
        [SerializeField]
        private GameObject _levelPanel;

        void Awake()
        {
            // if (Instance == null)
            // {
            //     Instance = this;
            //     DontDestroyOnLoad(gameObject);
            // }
            // else
            // {
            //     Destroy(gameObject);
            // }

            Instance = this;

            _titlePanel.SetActive(true);
            _stagePanel.SetActive(false);
            _levelPanel.SetActive(false);
        }

        public void ClickedPlay()
        {
            _titlePanel.SetActive(false);
            _stagePanel.SetActive(true);
        }

        public void ClickedBackToTitle()
        {
            _stagePanel.SetActive(false);
            _titlePanel.SetActive(true);
        }

        public void ClickedBackToStage()
        {
            _levelPanel.SetActive(false);
            _stagePanel.SetActive(true);
        }

        public UnityAction LevelOpened;

        [HideInInspector]
        public Color CurrentColor;

        [SerializeField]
        private TMP_Text _levelTitleText;
        [SerializeField]
        private Image _levelTitleImage;

        public void ClickedStage(string stageName, Color stageColor)
        {
            _stagePanel.SetActive(false);
            _levelPanel.SetActive(true);

            CurrentColor = stageColor;
            _levelTitleText.text = stageName;
            _levelTitleImage.color = CurrentColor;
            LevelOpened?.Invoke();
        }
    }
}
