using System.Collections;
using System.Collections.Generic;
using Connect.Common;
using TMPro;
using UnityEngine;

namespace Connect.Core
{
    public class GameplayManager : MonoBehaviour
    {
        #region START_METHODS

        #region START_VARIABLES
        public static GameplayManager Instance;

        [HideInInspector]
        public bool hasGameFinished;

        [SerializeField]
        private TMP_Text _titleText;
        [SerializeField]
        private GameObject _winText;
        [SerializeField]
        private SpriteRenderer _clickHighlight;

        void Awake()
        {
            Instance = this;

            hasGameFinished = false;
            _winText.SetActive(false);
            _titleText.gameObject.SetActive(true);
            _titleText.text = GameManager.Instance.StageName + " - " + GameManager.Instance.CurrentLevel.ToString();

            SpawnBoard();

            SpawnNodes();
        }

        #endregion

        #region BOARD_SPAWN
        [SerializeField]
        private SpriteRenderer _boardPrefab, _bgCellPrefab;

        private void SpawnBoard()
        {
            int currentLevelSize = GameManager.Instance.CurrentStage + 4;

            var board = Instantiate(_boardPrefab, new Vector3(currentLevelSize / 2f, currentLevelSize / 2f, 0f), Quaternion.identity);
            board.size = new Vector2(currentLevelSize + 0.08f, currentLevelSize + 0.08f);

            for (int i = 0; i < currentLevelSize; i++)
            {
                for (int j = 0; j < currentLevelSize; j++)
                {
                    Instantiate(_bgCellPrefab, new Vector3(i + 0.5f, j + 0.5f, 0f), Quaternion.identity);
                }
            }

            Camera.main.orthographicSize = currentLevelSize + 2f;
            Camera.main.transform.position = new Vector3(currentLevelSize / 2f, currentLevelSize / 2f, -10f);
            _clickHighlight.size = new Vector2(currentLevelSize / 4f, currentLevelSize / 4f);
            _clickHighlight.transform.position = Vector3.zero;
            _clickHighlight.gameObject.SetActive(false);
        }
        #endregion

        #region NODE_SPAWN
        private LevelData CurrentLevelData;
        [SerializeField] private Node _nodePrefab;
        private List<Node> _nodes;

        public Dictionary<Vector2Int, Node> _nodeGrid;

        private void SpawnNodes()
        {

        }

        public List<Color> NodeColors;
        #endregion

        #endregion

        #region UPDATE_METHODS

        #endregion

        #region WIN_CONDITION

        #endregion

        #region BUTTON_FUNCTIONS
        public void ClickedBack()
        {
            GameManager.Instance.GoToMainMenu();
        }

        public void ClickedRestart()
        {
            GameManager.Instance.GoToGameplay();
        }

        public void ClickNextLevel()
        {
            if (!hasGameFinished) return;

            GameManager.Instance.GoToGameplay();
        }
        #endregion
    }
}
