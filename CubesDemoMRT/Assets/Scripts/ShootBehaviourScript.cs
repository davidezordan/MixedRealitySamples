using System;
using UnityEngine;

using UnityEngine.Windows.Speech;

public class ShootBehaviourScript : MonoBehaviour {

    UnityEngine.XR.WSA.Input.GestureRecognizer _recognizer;
    public float ForceMagnitude = 300f;

    private KeywordRecognizer _keywordRecognizer;
    public string FireCommand = "fire";

    void Start () {
        _recognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
        _recognizer.TappedEvent += _recognizer_TappedEvent;
        _recognizer.StartCapturingGestures();

        _keywordRecognizer = new KeywordRecognizer(new[] { FireCommand });
        _keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        _keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        var cmd = args.text;

        if (cmd == FireCommand)
        {
            this.BroadcastMessage("OnFire");
        }

        //if (cmd == GoToStartCommand)
        //{
        //    if (GazeManager.Instance.HitObject != null)
        //    {
        //        GazeManager.Instance.HitInfo.collider.gameObject.SendMessage("OnRevert", true);
        //    }
        //}
    }

    private void _recognizer_TappedEvent(UnityEngine.XR.WSA.Input.InteractionSourceKind source, int tapCount, Ray headRay)
    {
        OnFire();
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
}
