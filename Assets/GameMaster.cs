using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gameMaster;
    public ScriptableParticle ParticleSystemSelector;
    public void OnEnable()
    {
        ParticleSystemSelector = ScriptableObject.CreateInstance<ScriptableParticle>();
        if (gameMaster == null)
        {
            gameMaster = this;
            DontDestroyOnLoad(gameObject);
        } else if (gameMaster != this)
        {
            Destroy(gameObject);
        }
    }
}
