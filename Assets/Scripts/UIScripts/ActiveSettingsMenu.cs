using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIScripts
{
    public class ActiveSettingsMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _mainMenu;
        [SerializeField]
        private GameObject _settingsMenu;

        public void ActiveSetngs()
        {
            _settingsMenu.SetActive(true);
            _mainMenu.SetActive(false);
        }

        public void DisactiveSetngs()
        {
            _settingsMenu.SetActive(false);
            _mainMenu.SetActive(true);
        }
    }
}

