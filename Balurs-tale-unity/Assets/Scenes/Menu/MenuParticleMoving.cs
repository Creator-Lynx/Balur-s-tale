using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuParticleMoving : MonoBehaviour
{
    Vector3 defaultPosition;
    [SerializeField] Vector2 shift;
    [SerializeField] float smoothtime = 0.2f;
    [SerializeField] Color defaultColor;
    [SerializeField] Color applyiedColor;
    [SerializeField] float colorModifier =6f;
    [SerializeField] float blinkTime = 0.1f;
    Material particleMaterial;
    
    void Start()
    {
        defaultPosition = transform.position;
        particleMaterial = GetComponent<ParticleSystemRenderer>().material;
    }

    Vector3 tmp;
    void Update()
    {
        var position = Mouse.current.position.ReadValue();
        float resX = Screen.currentResolution.width;
        float resY = Screen.currentResolution.height;
        position.x /= resX;
        position.y /= resY;

        Vector3 finalPos;
        finalPos.x = position.x * -shift.x;
        finalPos.y = position.y * -shift.y;
        finalPos.z = 0;

        finalPos += defaultPosition;

        transform.position = Vector3.SmoothDamp(transform.position, finalPos, ref tmp, smoothtime);
    }

    public void ColorBlink()
    {
        StartCoroutine(ColorBlinkCor());
    }

    IEnumerator ColorBlinkCor()
    {
        particleMaterial.SetColor("_EmissionColor", applyiedColor * colorModifier);
        float time = 0f;
        while (time < blinkTime)
        {
            yield return new WaitForEndOfFrame();
            Color tmpColor = Color.Lerp(applyiedColor, defaultColor,  time/blinkTime);
            particleMaterial.SetColor("_EmissionColor", tmpColor * colorModifier);
            time += Time.deltaTime;
        }

        

    }
}
