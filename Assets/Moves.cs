using UnityEngine;
using System.Collections;

public class Moves : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
public static class MoveData
{
    public enum MoveTypes
    {
        Fire,
        Lightning,
        Ice,
        Rock,
        Storm,
        FireBlast
    }
    public enum MoveBehaviorsGeneric
    {
        Ball,
        Stream,
        Burst,
        Enchant,
        Wall,
        Bolt
    }
}
