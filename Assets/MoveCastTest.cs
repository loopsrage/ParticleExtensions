using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCastTest : MonoBehaviour
{
    // Use this for initialization
    Camera fpsCam;
    RaycastHit Hit;
    public float weaponRange = 10f;
    public MoveData.MoveTypes Type = MoveData.MoveTypes.Fire;
    public TestMoveStructure.TempMoves MoveEffect = TestMoveStructure.TempMoves.Storm;
    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 TargetLocation = fpsCam.ViewportToWorldPoint(new Vector3(.5f,.5f,0f));
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (Physics.Raycast(TargetLocation, fpsCam.transform.forward, out Hit, weaponRange))
            {
                GameMaster.gameMaster.testMoveStructure.AddObjectAndParticleSystem(Hit.point,
                    Type, MoveEffect);
            }
            else
            {
                GameMaster.gameMaster.testMoveStructure.AddObjectAndParticleSystem(TargetLocation + (fpsCam.transform.forward * weaponRange),
                    Type, MoveEffect);
            }
        }
    }
}
