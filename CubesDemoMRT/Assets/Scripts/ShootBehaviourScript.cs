using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ShootBehaviourScript : MonoBehaviour, IInputHandler {
    public float ForceMagnitude = 300f;

    void Start () {

    }

    public void OnFire()
    {
        var ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        var rigidBody = ball.AddComponent<Rigidbody>();
        rigidBody.mass = 0.5f;
        rigidBody.position = Camera.main.transform.position;

        var transformForward = Camera.main.transform.forward;
        transformForward = Quaternion.AngleAxis(-10, transform.right) * transformForward;
        rigidBody.AddForce(transformForward * ForceMagnitude);
    }

    private Vector3 CalculatePositionDeadAhead()
    {
        var gazeOrigin = Camera.main.transform.position;
        return gazeOrigin + Camera.main.transform.forward * 3.5f;
    }

    // Update is called once per frame
    void Update () {		
	}

    public void OnInputDown(InputEventData eventData)
    {
        OnFire();
    }

    public void OnInputUp(InputEventData eventData)
    {
    }
}
