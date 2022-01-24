// from https://gist.github.com/Glynn-Taylor/8ad1125ea7ef5aba1fa0374e80ac2c0d#file-lightingpreset-cs
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
public class LightingPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
}