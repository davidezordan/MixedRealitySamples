using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CubeAirtapActions : MonoBehaviour, IInputClickHandler
{
    #region IInputClickHandler
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (gameObject.GetComponent<MeshRenderer>().material.color != Color.red)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 255, 255);
        }
    }
    #endregion IInputClickHandler
}