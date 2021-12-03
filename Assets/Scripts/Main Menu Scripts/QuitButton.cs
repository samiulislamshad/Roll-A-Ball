using UnityEngine;

namespace Main_Menu_Scripts
{
    public class QuitButton : MonoBehaviour
    {
        // Start is called before the first frame update

        public void OnClickQuitButton()
        {
            Application.Quit();
        }
    }
}
