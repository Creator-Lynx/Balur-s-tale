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
        mixer.SetFloat("MasterVolume", (t-1) * 80f);
    }
}
