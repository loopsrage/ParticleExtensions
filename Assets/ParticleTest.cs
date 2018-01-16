using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour {

    // Use this for initialization
    private ParticleSystem PS;
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public Rigidbody RB;
    public MoveData.MoveTypes MoveType = MoveData.MoveTypes.Fire;
    public MoveData.MoveBehaviorsGeneric MoveBehavior = MoveData.MoveBehaviorsGeneric.Stream;
    void Start()
    {
        gameObject.AddComponent<ParticleSystem>();
        PS = gameObject.GetComponent<ParticleSystem>();
        InitPS();
        // Particle Collision
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();

        // Freeze Rotation and Float
        RB = GetComponent<Rigidbody>();
        RB.constraints = RigidbodyConstraints.FreezePositionY;
    }
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;
        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }
    }
    private void InitPS()
    {
        // Init Particle Settings
        GameMaster.gameMaster.ParticleSystemSelector.selectParticleEffects(gameObject, MoveType, MoveBehavior);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PS.Play();
        }
        Input.GetMouseButtonDown(0);
        // transform.LookAt(Target.transform);
        if (MoveType != GetComponentInParent<PlayerHit>().CurrentMove)
        {
            PS.Clear();
            MoveType = GetComponentInParent<PlayerHit>().CurrentMove;
            InitPS();
        }
    }
}
