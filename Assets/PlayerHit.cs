using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHit : MonoBehaviour
{
    // Use this for initialization
    public List<MoveData.MoveTypes> MoveSelection = new List<MoveData.MoveTypes>()
    {
        {MoveData.MoveTypes.Rock },
        {MoveData.MoveTypes.Lightning },
        {MoveData.MoveTypes.Ice },
        {MoveData.MoveTypes.Fire },
        { MoveData.MoveTypes.Storm}
    };
    public MoveData.MoveTypes CurrentMove = MoveData.MoveTypes.Storm;
    public int MoveSelectionCount;
    public int MoveSelectionMax;
    void Start()
    {
        MoveSelectionMax = MoveSelection.Count;
        MoveSelectionCount = MoveSelectionMax;
        CurrentMove = MoveSelection[MoveSelectionCount];
    }
    // Update is called once per frame
    void Update()
    {

    }
}
