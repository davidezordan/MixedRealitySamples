using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class GazeCursorBehaviourScript : MonoBehaviour {
    public GameObject FocusedObject { get; private set; }

    private string _resetMessageName = "OnReset";
    private string _selectMessageName = "OnSelect";

    // Use this for initialization
    void Start () {
        FocusedObject = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (GazeManager.Instance.HitObject != null)
        {
            var newFocusedObject = GazeManager.Instance.HitObject;
            if (FocusedObject != null && newFocusedObject != null)
            {
                FocusedObject.SendMessage(_resetMessageName);
            }

            FocusedObject = newFocusedObject;
            FocusedObject.SendMessage(_selectMessageName);
        } else
        {
            if (FocusedObject != null)
            {
                FocusedObject.SendMessage(_resetMessageName);
            }
            FocusedObject = null;
        }
    }
}
