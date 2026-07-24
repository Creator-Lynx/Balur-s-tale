using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public void SetLookSensivity(float t)
    {
        PlayerController.globalLookSpeedModifier = t;
    }

    public void SetLookSmooth(bool t)
    {
        PlayerController.enableMouseSmoothing = t;
    }

    [SerializeField] AudioMixer mixer;
    public void SetGlobalVolume(float t)
    {
        if(t <= 0) t = 0.0001f;
        mixer.SetFloat("MasterVolume", Mathf.Log10(t) * 20);
    }
}
