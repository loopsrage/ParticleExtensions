using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestMoveStructure : ScriptableObject
{
    string[] Layers = new string[] { "Players" };
    public enum TempMoves
    {
        Storm,
        Beam,
        Ball,
        Walk,
        Burst
    }
    public List<GameObject> GameObjects = new List<GameObject>();
    public List<GameObject> SubGameObjects = new List<GameObject>();
    public void AddObjectAndParticleSystem(Vector3 ObjectPosition, MoveData.MoveTypes moveType,TempMoves tempMoves, Vector3 StartPosition, Transform transformParent)
    {
        GameObject MoveObject = new GameObject();
        MoveObject.transform.SetParent(transformParent.parent);
        if (tempMoves == TempMoves.Beam)
        {
            MoveObject.transform.position = transformParent.position;
            MoveObject.transform.rotation = new Quaternion(0f,0f,0f,0f);
            MoveObject.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
        }
        if (tempMoves == TempMoves.Storm)
        {
            MoveObject.transform.position = ObjectPosition;
        }
        MoveObject.AddComponent<ParticleSystem>();
        GameObjects.Add(MoveObject);
        BaseMove(tempMoves,MoveObject,moveType);
    }
    public GameObject AddSubParticle(GameObject OriginalGameObject, MoveData.MoveTypes moveType, TempMoves tempMove)
    {
        GameObject SubObject = new GameObject();
        SubObject.transform.SetParent(OriginalGameObject.transform);
        SubObject.transform.position = OriginalGameObject.transform.position;
        SubObject.AddComponent<ParticleSystem>();
        SubGameObjects.Add(SubObject);
        SelectMaterials(SubObject,moveType,tempMove);
        return SubObject;
    }
    public void SelectMaterials(GameObject ThisObject, MoveData.MoveTypes MoveType, TempMoves tempMove)
    {
        ParticleSystem PS = ThisObject.GetComponent<ParticleSystem>();
        ParticleSystem.Burst[] Bursts;
        AnimationCurve EmissionCurve;
        AnimationCurve SizeCurve;

        switch (MoveType)
        {
            case MoveData.MoveTypes.Fire:
                if (tempMove == TempMoves.Storm)
                {
                    EmissionCurve = new AnimationCurve();
                    EmissionCurve.AddKey(0f, 10f);
                    Bursts = new ParticleSystem.Burst[]
                    {
                            new ParticleSystem.Burst(1f,5,6,1f)
                    };
                    PS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                    PS.ParticleMainSettings(true, 100f, 1f, 100f, 2f, 3f);
                    PS.ParticleNoiseSettings(true, 10, 15f, 10);
                    PS.ParticleShapeSettings(true, ParticleSystemShapeType.Sphere, ParticleSystemShapeMultiModeValue.Random, false, 0f, 0f, 10f);
                    PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 5f, false, false);
                    // Render Settings
                    PS.ParticleRendererSettings(true,"Capsule","Fire","Fire",ParticleSystemRenderMode.Mesh);
                    PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                        ParticleSystemCollisionType.World, true, true, Layers,1f,1f);
                }
                break;
            case MoveData.MoveTypes.Lightning:
                if (tempMove == TempMoves.Storm)
                {
                    EmissionCurve = new AnimationCurve();
                    EmissionCurve.AddKey(0f, 10f);
                    Bursts = new ParticleSystem.Burst[]
                    {
                        new ParticleSystem.Burst(1f,5,6,1f)
                    };
                    PS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                    PS.ParticleMainSettings(true, 100f, 1f, 50f, 2f, 3f);
                    PS.ParticleNoiseSettings(true, 10, 15f, 10);
                    PS.ParticleShapeSettings(true, ParticleSystemShapeType.Sphere, ParticleSystemShapeMultiModeValue.Random, false, 0f, 0f, 10f);
                    PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 5f, false, false);
                    PS.ParticleRendererSettings(true, "Capsule", "nomat", "BLT", ParticleSystemRenderMode.Stretch);
                    PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                        ParticleSystemCollisionType.World, true, true, Layers);
                }
                break;
            case MoveData.MoveTypes.Ice:
                if (tempMove == TempMoves.Storm)
                {
                    EmissionCurve = new AnimationCurve();
                    EmissionCurve.AddKey(0f, 10f);
                    Bursts = new ParticleSystem.Burst[]
                    {
                        new ParticleSystem.Burst(1f,5,6,1f)
                    };
                    PS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                    PS.ParticleMainSettings(true, 100f, 1f, 100f, 2f, 3f);
                    PS.ParticleNoiseSettings(true, 10, 15f, 10);
                    PS.ParticleShapeSettings(true, ParticleSystemShapeType.Sphere, ParticleSystemShapeMultiModeValue.Random, false, 0f, 0f, 10f);
                    PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 5f, false, false);
                    PS.ParticleRendererSettings(true, null, "ICE", "ICE", ParticleSystemRenderMode.Billboard);
                    PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                        ParticleSystemCollisionType.World, true, true, Layers, 1f, 1f);
                }
                break;
            case MoveData.MoveTypes.Rock:
                if (tempMove == TempMoves.Storm)
                {
                    EmissionCurve = new AnimationCurve();
                    EmissionCurve.AddKey(0f, 10f);
                    Bursts = new ParticleSystem.Burst[]
                    {
                        new ParticleSystem.Burst(1f,5,6,1f)
                    };
                    PS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                    PS.ParticleMainSettings(true, 1f, 2f, 6f, 4f, 3f);
                    PS.ParticleNoiseSettings(false, 10, 15f, 10);
                    PS.ParticleShapeSettings(true, ParticleSystemShapeType.Sphere, ParticleSystemShapeMultiModeValue.Random, false, 0f, 0f, 10f);
                    PS.ParticleTrailSettings(false, ParticleSystemTrailTextureMode.Stretch, 5f, false, false);
                    PS.ParticleRendererSettings(true, "Capsule", "RockMat", "RockMat", ParticleSystemRenderMode.Mesh);
                    PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                        ParticleSystemCollisionType.World, true, true, Layers, 0.5f, 0.5f);
                }
                break;
            default:
                break;
        }
    }
    public void MaterialSelection(MoveData.MoveTypes MoveType,GameObject ThisObject)
    {
        ParticleSystem PS = ThisObject.GetComponent<ParticleSystem>();
        switch (MoveType)
        {
            case MoveData.MoveTypes.Fire:
                PS.ParticleRendererSettings(true, "Capsule", "Fire", "Fire", ParticleSystemRenderMode.Mesh);
                break;
            case MoveData.MoveTypes.Lightning:
                PS.ParticleRendererSettings(true, "Capsule", "nomat", "BLT", ParticleSystemRenderMode.Mesh);
                break;
            case MoveData.MoveTypes.Ice:
                PS.ParticleRendererSettings(true, "Capsule", "nomat", "ICE", ParticleSystemRenderMode.Mesh);
                break;
            case MoveData.MoveTypes.Rock:
                PS.ParticleRendererSettings(true, "Capsule", "RockMat", "nomat", ParticleSystemRenderMode.Mesh);
                break;
            default:
                break;
        }
    }
    public void BaseMove(TempMoves tempMove, GameObject ThisObject, MoveData.MoveTypes moveTypes)
    {
        ParticleSystem PS = ThisObject.GetComponent<ParticleSystem>();
        ParticleSystem.Burst[] Bursts;
        AnimationCurve EmissionCurve;
        AnimationCurve SizeCurve;
        switch (tempMove)
        {
            case TempMoves.Storm:
                // Main Settings
                PS.ParticleMainSettings(false, 0f, 15f, 3f, 6f);

                // Emission Settings
                Bursts = new ParticleSystem.Burst[]
                {
                    new ParticleSystem.Burst(0.0f,3),
                    new ParticleSystem.Burst(0.1f,2),
                    new ParticleSystem.Burst(0.2f,1)
                };
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 3f);
                PS.ParticleEmissionSettings(true, 1f, true, true, Bursts);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 0f);
                SizeCurve.AddKey(0.5f, 15f);
                SizeCurve.AddKey(1f, 0f);

                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, false, 0f, 0f, 0f, 0f, 0f, 0f);

                // Collision Settings
                PS.ParticleCollisionSettings(false, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);
            
                // Sub Particle Settings
                PS.ParticleSubSettings(true, AddSubParticle(ThisObject,moveTypes,tempMove));

                // Rotation Settings
                PS.ParticleRotationSettings(true, 1, 0f, ParticleSystemCurveMode.TwoConstants);

                // Renderer
                PS.ParticleRendererSettings(true, null, "Smoke", "nomat", ParticleSystemRenderMode.HorizontalBillboard);

                break;
            case TempMoves.Beam:
                PS.ParticleMainSettings(false,0f,1f,10f,3f,0f);
                Bursts = new ParticleSystem.Burst[]
                {
                    new ParticleSystem.Burst(0.0f,3),
                    new ParticleSystem.Burst(0.1f,4),
                    new ParticleSystem.Burst(0.2f,5),
                    new ParticleSystem.Burst(0.4f,4),
                    new ParticleSystem.Burst(0.5f,3)
                };
                PS.ParticleEmissionSettings(true, 1f, true, false, null,null,ParticleSystemCurveMode.Constant,20);
                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 1f);
                SizeCurve.AddKey(0.5f, 3f);
                SizeCurve.AddKey(1f, 1f);
                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, false, 0f, 0f, 0f, 0f, 0f, 0f);
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);
                PS.ParticleSubSettings(false, AddSubParticle(ThisObject,moveTypes,tempMove));
                PS.ParticleTrailSettings(true,ParticleSystemTrailTextureMode.DistributePerSegment,1f,true,true);
                PS.ParticleRotationSettings(true, 1, 0f, ParticleSystemCurveMode.TwoConstants,100f,200f);
                MaterialSelection(moveTypes,ThisObject);
                break;
            case TempMoves.Ball:
                break;
            case TempMoves.Walk:
                break;
            case TempMoves.Burst:
                break;
            default:
                break;
        }
    }
}
