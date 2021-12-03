using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu_Scripts
{
    public class MainMenuButton : MonoBehaviour
    {
        public void OnClickMainMenuButton()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}
