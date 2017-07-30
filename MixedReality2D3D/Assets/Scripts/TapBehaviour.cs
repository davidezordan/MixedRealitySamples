using System;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class TapBehaviour : MonoBehaviour, IInputClickHandler {

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var contentPage = AppViewManager.Views["ContentPage"];
        if (contentPage != null)
        {
            contentPage.SwitchAndConsolidate(contentPage);
        }
    }
}
