using UnityEngine;

public class GazeCursorBehaviourScript : MonoBehaviour {

    private MeshRenderer _meshRenderer;

    public GameObject FocusedObject { get; private set; }

    private string _resetMessageName = "OnReset";
    private string _selectMessageName = "OnSelect";

    // Use this for initialization
    void Start () {
        _meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();

        FocusedObject = null;
    }
	
	// Update is called once per frame
	void Update () {
        var headPos = Camera.main.transform.position;
        var gazePos = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPos, gazePos, out hitInfo))
        {
            _meshRenderer.enabled = true;
            this.transform.position = hitInfo.point;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            var newFocusedObject = hitInfo.collider.gameObject;
            if (FocusedObject != null && newFocusedObject != null)
            {
                FocusedObject.SendMessage(_resetMessageName);
            }

            FocusedObject = newFocusedObject;
            FocusedObject.SendMessage(_selectMessageName);
        } else
        {
            _meshRenderer.enabled = false;

            if (FocusedObject != null)
            {
                FocusedObject.SendMessage(_resetMessageName);
            }
            FocusedObject = null;
        }
    }
}
