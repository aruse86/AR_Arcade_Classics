using UnityEngine;
using UnityEngine.Android;

public class CameraPermissionRequester : MonoBehaviour
{
    void Start()
    {
        // Check if camera permission is already granted
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            // Request camera permission from the user
            Permission.RequestUserPermission(Permission.Camera);
        }
    }
}

