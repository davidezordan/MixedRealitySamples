using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class TapBehaviour : MonoBehaviour {

    GestureRecognizer _gr;

	// Use this for initialization
	void Start () {
        _gr = new GestureRecognizer();
        _gr.TappedEvent += _gr_TappedEvent;
        _gr.StartCapturingGestures();
	}

    private void _gr_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        var contentPage = AppViewManager.Views["ContentPage"];
        if (contentPage != null)
        {
           contentPage.SwitchAndConsolidate(contentPage, Windows.UI.ViewManagement.ApplicationViewSwitchingOptions.SkipAnimation);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
