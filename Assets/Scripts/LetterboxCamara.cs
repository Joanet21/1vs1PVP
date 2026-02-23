using UnityEngine;

[ExecuteAlways]
[DisallowMultipleComponent]
public class LetterboxCamera : MonoBehaviour
{
    [Tooltip("Aspecte objectiu (16:9 = 1.777...)")]
    public float targetAspect = 16f / 9f;

    [Tooltip("Càmera a ajustar. Si és null, agafa la del mateix GameObject.")]
    public Camera cam;

    void OnEnable()
    {
        Apply();
    }

    void Update()
    {
        // A editor i en runtime, per si canvies resolució o mida finestra.
        Apply();
    }

    void Apply()
    {
        if (cam == null) cam = GetComponent<Camera>();
        if (cam == null) return;

        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // Letterbox (barres a dalt/baix)
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            cam.rect = rect;
        }
        else
        {
            // Pillarbox (barres a esquerra/dreta)
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}