using UnityEngine;
using UnityEngine.UI;

public class CameraFeedBackground : MonoBehaviour
{
    public RawImage rawImage;
    private WebCamTexture webcamTexture;

    void Start()
    {
        if (rawImage == null)
        {
            return;
        }

        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            return;
        }

        webcamTexture = new WebCamTexture(devices[0].name);
        rawImage.texture = webcamTexture;
        webcamTexture.Play();
    }

    void OnDisable()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
        }
    }
}
