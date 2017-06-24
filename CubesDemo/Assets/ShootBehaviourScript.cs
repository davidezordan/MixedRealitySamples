using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class ShootBehaviourScript : MonoBehaviour {

    GestureRecognizer _recognizer;
    public float ForceMagnitude = 300f;

	// Use this for initialization
	void Start () {
        _recognizer = new GestureRecognizer();
        _recognizer.TappedEvent += _recognizer_TappedEvent;
        _recognizer.StartCapturingGestures();
    }

    private void _recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        var ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        var rigidBody = ball.AddComponent<Rigidbody>();
        rigidBody.mass = 0.5f;
        rigidBody.position = transform.position;

        var transformForward = transform.forward;
        transformForward = Quaternion.AngleAxis(-10, transform.right) * transformForward;
        rigidBody.AddForce(transformForward * ForceMagnitude);
    }

    // Update is called once per frame
    void Update () {		
	}
}
