using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu_Scripts
{
    public class PlayButton : MonoBehaviour
    {
        public void OnClickPlay()
        {
            SceneManager.LoadScene(1);
        }
    }
}
