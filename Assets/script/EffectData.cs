using UnityEngine;
public enum EffectType { InstantDeath, Debuff }
[System.Serializable]
public class EffectDataContents
{
    public EffectType type;
    public string sourceName;
    public float value;
}
public class EffectData : MonoBehaviour
{
    public EffectDataContents myEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}