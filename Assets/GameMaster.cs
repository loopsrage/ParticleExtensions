using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gameMaster;
    public ScriptableParticle ParticleSystemSelector;
    public TestMoveStructure testMoveStructure;
    public void OnEnable()
    {
        ParticleSystemSelector = ScriptableObject.CreateInstance<ScriptableParticle>();
        testMoveStructure = ScriptableObject.CreateInstance<TestMoveStructure>();
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
