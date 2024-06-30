using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour
{
    public UIManager ui;
    public RectTransform testButtons;

    public void ToggleTestButtonPanel()
    {
        if (testButtons.gameObject.activeSelf == false)
            ui.PanelAppear(testButtons, true);
        else
            ui.PanelAppear(testButtons, false);
    }
}
