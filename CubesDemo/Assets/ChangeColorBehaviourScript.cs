using UnityEngine;

public class ChangeColorBehaviourScript : MonoBehaviour {

    Color _color;

    Material _material
    {
        get { return GetComponent<Renderer>().material; }
    }

	// Use this for initialization
	void Start () {
        _color = Random.ColorHSV();

        OnReset();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSelect()
    {
        _material.color = Color.cyan;
    }

    void OnReset()
    {
        _material.color = _color;
    }
}
