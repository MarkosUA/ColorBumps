using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastPanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject _finishPanel;
    [SerializeField]
    private TMP_Text _text;

    public void ActivateFinishPanel(bool win)
    {
        _finishPanel.SetActive(true);
        TextOnFinishPanel(win);
    }

    private void TextOnFinishPanel(bool win)
    {
        if (win)
        {
            _text.text = "You win!";
        }
        else
        {
            _text.text = "You lose!";
        }
    }
}
