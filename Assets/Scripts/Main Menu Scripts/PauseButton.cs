using UnityEngine;

namespace Main_Menu_Scripts
{
    public class PauseButton : MonoBehaviour
    {
        public GameObject scorePanel;
        public GameObject optionPanel;
        private void Start()
        {
            optionPanel.SetActive(false);
        }

        public void OnClickPauseButton()
        {
            Time.timeScale = 0;
            optionPanel.SetActive(true);
            scorePanel.SetActive(false);
        }
    }
}
