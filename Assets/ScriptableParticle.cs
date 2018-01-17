using UnityEngine;
using System.Collections;

public class ScriptableParticle : ScriptableObject
{
    GameObject SubObject = null;
    public void selectParticleEffects(GameObject ThisGameObject, MoveData.MoveTypes moveType, MoveData.MoveBehaviorsGeneric Behavior)
    {
        ParticleSystem PS = ThisGameObject.GetComponent<ParticleSystem>();
        AnimationCurve EmissionCurve;
        AnimationCurve SizeCurve;
        ParticleSystem SPS;
        AnimationCurve SPSCurve;
        ParticleSystem.Burst[] Bursts;
        string[] Layers = new string[] { "Players" };
        if (SubObject != null)
        {
            GameObject.Destroy(SubObject);
            SubObject = null;
        }
        SubObject = new GameObject();
        SubObject.AddComponent<ParticleSystem>();
        SubObject.transform.SetParent(PS.transform.parent);
        SubObject.transform.position = PS.transform.parent.position;
        SubObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        switch (moveType)
        {
            case MoveData.MoveTypes.Fire:
                // Main Settings
                PS.ParticleMainSettings(false, 0, 2f, 25f, 7f);

                // Emission Settings
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 1f);
                PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 3f);
                SizeCurve.AddKey(2f, 10f);
                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, false, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.DistributePerSegment, 2, true, false);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 0, 0f, 0);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");

                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "FireTrail", "nomat", ParticleSystemRenderMode.Mesh);

                // Velocity Settings
                PS.ParticleInheritVelocity();

                // Rotation Settings
                PS.ParticleRotationSettings(true, 1, 50f);
                // Sub Particle Settings
                SPS = SubObject.GetComponent<ParticleSystem>();
                SPSCurve = new AnimationCurve();
                SPSCurve.AddKey(0f, 10f);
                Bursts = new ParticleSystem.Burst[]
                {
                        new ParticleSystem.Burst(1f,5,1)
                };
                SPS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                SPS.ParticleMainSettings(true, 1f, 1f, 20f, 2f, 1f);
                SPS.ParticleNoiseSettings(true, 1, 0, 0);
                SPS.ParticleShapeSettings(true, ParticleSystemShapeType.Sphere, ParticleSystemShapeMultiModeValue.PingPong, false, 0f, 1f, 1f);
                SPS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 2f, false, false);
                SPS.ParticleRendererSettings(true, "Capsule", "Fire", "SMK", ParticleSystemRenderMode.Billboard);

                PS.ParticleSubSettings(true, SubObject);
                break;
            case MoveData.MoveTypes.Lightning:
                // Main Settings
                PS.ParticleMainSettings(false, 0, 1f, 300f, 1f);

                // Emission Settings
                Bursts = new ParticleSystem.Burst[]
                {
                    new ParticleSystem.Burst(0f,1,1,0.01f)
                };
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 1f);
                PS.ParticleEmissionSettings(true, 1, false, true, Bursts, null);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 4f);
                SizeCurve.AddKey(2f, 0f);
                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 6, true, true);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 6, 6, 6);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");



                // Rotation Settings:
                PS.ParticleRotationSettings();

                // Sub Particle Settings
                SPS = SubObject.GetComponent<ParticleSystem>();
                SPSCurve = new AnimationCurve();
                SPSCurve.AddKey(0f, 10f);
                Bursts = new ParticleSystem.Burst[]
                {
                        new ParticleSystem.Burst(1f,1,1)
                };
                SPS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                SPS.ParticleMainSettings(true, 0f, 1f, 1f, 0.5f, 3f);
                SPS.ParticleNoiseSettings(true, 10, 1, 10);
                SPS.ParticleShapeSettings(true, ParticleSystemShapeType.Donut, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);
                SPS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 0.1f, false, false);
                SPS.ParticleRendererSettings(true, "Capsule", "nomat", "BLT", ParticleSystemRenderMode.Stretch);

                PS.ParticleSubSettings(true, SubObject);

                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "nomat", "BLT", ParticleSystemRenderMode.Mesh);
                break;
            case MoveData.MoveTypes.Ice:
                // Main Settings
                PS.ParticleMainSettings(false, 0, 1f, 400f, 6f);

                // Emission Settings
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 2f);
                PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 1f);
                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 6, true, false);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 0, 0, 0);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");

                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "nomat", "ICE", ParticleSystemRenderMode.Mesh);

                // Rotation Settings:
                PS.ParticleRotationSettings();
                break;
            case MoveData.MoveTypes.Rock:
                // Main Settings
                PS.ParticleMainSettings(false, 0, 15f, 100f, 6f);

                // Emission Settings
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 1f);
                PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 1f);
                PS.ParticleSizeOverLifetimeSettings(false, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(false, ParticleSystemTrailTextureMode.Stretch, 1, true, false);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 0, 0, 0);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");

                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "RockMat", "RockTrailMat", ParticleSystemRenderMode.Mesh);

                // Rotation Settings:
                PS.ParticleRotationSettings();
                break;
            case MoveData.MoveTypes.Storm:
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
                SizeCurve.AddKey(0.5f, 30f);
                SizeCurve.AddKey(1f, 0f);

                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, false, 0f, 0f, 1f, 0f, 0f, 100f);

                // Trail Settings
                PS.ParticleTrailSettings(false, ParticleSystemTrailTextureMode.Stretch, 2, true, true);

                // Collision Settings
                PS.ParticleCollisionSettings(false, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(false, 6, 6, 6);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");




                // Sub Particle Settings
                SPS = SubObject.GetComponent<ParticleSystem>();
                selectParticleEffects(SubObject,MoveData.MoveTypes.Rock,MoveData.MoveBehaviorsGeneric.Ball);
                //SPSCurve = new AnimationCurve();
                //SPSCurve.AddKey(0f, 10f);
                //Bursts = new ParticleSystem.Burst[]
                //{
                //        new ParticleSystem.Burst(1f,1,1,1f)
                //};
                //SPS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                //SPS.ParticleMainSettings(true, 2f, 1f, 0f, 2f, 3f);
                //SPS.ParticleNoiseSettings(true, 10, 15f, 10);
                //SPS.ParticleShapeSettings(true, ParticleSystemShapeType.Circle, ParticleSystemShapeMultiModeValue.Loop, false, 0f, 0f, 5f);
                //SPS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 2f, false, false);
                //SPS.ParticleRendererSettings(true, "Capsule", "nomat", "BLT", ParticleSystemRenderMode.Stretch);

                PS.ParticleSubSettings(true, SubObject);

                //// Rotation Settings
                PS.ParticleRotationSettings(true, 1, 0f, ParticleSystemCurveMode.TwoConstants);

                //// Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "Smoke", "nomat", ParticleSystemRenderMode.HorizontalBillboard);
                break;
            default:
                break;
        }

    }
}
