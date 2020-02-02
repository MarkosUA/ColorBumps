using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIScripts
{
    public class FinishPanel : MonoBehaviour
    {
        public void RestartBtn()
        {
            SceneController.LoadGameScene();
        }

        public void MenuBtn()
        {
            SceneController.LoadStartScene();
        }

        public void QuitBtn()
        {
            Application.Quit();
        }
    }
}
