using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UIScripts
{
    public class StartPanelScript : MonoBehaviour
    {
        [SerializeField]
        private GameObject _panel;
        [SerializeField]
        private FloorMoveContr _floorMoveContr;
        [SerializeField]
        private TMP_Text _text;

        private void Update()
        {
#if UNITY_IOS || UNITY_ANDROID
        TextOnPanel(true);
#elif UNITY_STANDALONE
            TextOnPanel(false);
#endif
        }

        public void PanelBtn()
        {
            _floorMoveContr.startMovement = true;
            _panel.SetActive(false);
        }

        private void TextOnPanel(bool phone)
        {
            if (phone)
            {
                _text.text = "Tap to start";
            }
            else
            {
                _text.text = "Click to start";
            }
        }
    }
}