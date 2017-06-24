using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CubeGazeActions : MonoBehaviour, IFocusable
{
    private Color defaultColor;
    void Start()
    {
        defaultColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    #region IFocusable
    public void OnFocusEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void OnFocusExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
    }
    #endregion IFocusable
}
