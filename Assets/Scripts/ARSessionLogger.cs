using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionLogger : MonoBehaviour
{
    void Update()
    {
        Debug.Log("ARSession state: " + ARSession.state);
    }
}
