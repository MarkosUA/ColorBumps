using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIScripts
{
    public class StartMenuScript : MonoBehaviour
    {
        [SerializeField]
        private ActiveSettingsMenu _activeSettingsMenu;

        public void StartBtn()
        {
            SceneController.LoadGameScene();
        }

        public void ExitBtn()
        {
            Application.Quit();
        }

        public void SettingsBtn()
        {
            _activeSettingsMenu.ActiveSetngs();
        }

        public void BackBtn()
        {
            _activeSettingsMenu.DisactiveSetngs();
        }
    }
}
