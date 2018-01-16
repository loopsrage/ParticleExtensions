using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ParticleExtensions : ScriptableObject
{

}
public static class ParticleExten
{
    private static Object LoadResource(string ResourcePath)
    {
        return Resources.Load(ResourcePath);
    }
    private static int GetLayer(string[] LayerNames)
    {
        if (LayerNames == null)
        {
            LayerNames = new string[] { "Default" };
        }
        return LayerMask.GetMask(LayerNames);
    }
    public static void SwitchPower(this ParticleSystem PS)
    {
        ParticleSystemRenderer renderer = PS.GetComponent<ParticleSystemRenderer>();
        if (renderer.enabled)
        {
            PS.Stop();
        }
        else
        {
            PS.Play();
        }
    }
    public static void ParticleVelocityOverTimeSettings(this ParticleSystem PS,
        bool enabled = true,
        ParticleSystemSimulationSpace space = ParticleSystemSimulationSpace.World,
        float scalar = 0.0f,
        AnimationCurve X = null, // Set Externally 
        AnimationCurve Y = null, // Set Externally 
        AnimationCurve Z = null // Set Externally 
        )
    {
        // Crashes for some reason
        //ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = PS.velocityOverLifetime;
        //// Velocity Settings
        //velocityOverLifetimeModule.enabled = enabled;
        //velocityOverLifetimeModule.space = space;
        //if (X != null)
        //{
        //    ParticleSystem.MinMaxCurve VelocityCurveX = new ParticleSystem.MinMaxCurve(scalar, X);
        //    velocityOverLifetimeModule.x = VelocityCurveX;
        //}
        //if (Y != null)
        //{
        //    ParticleSystem.MinMaxCurve VelocityCurveY = new ParticleSystem.MinMaxCurve(scalar, Y);
        //    velocityOverLifetimeModule.y = VelocityCurveY;
        //}
        //if (Z != null)
        //{
        //    ParticleSystem.MinMaxCurve VelocityCurveZ = new ParticleSystem.MinMaxCurve(scalar, Z);
        //    velocityOverLifetimeModule.z = VelocityCurveZ;
        //}
    }
    public static void ParticleRendererSettings(this ParticleSystem PS,
        bool enabled = true,
        string Resources_MeshObject = null,
        string Resources_Material = null,
        string Resources_TrailMaterial = null,
        ParticleSystemRenderMode RenderMode = ParticleSystemRenderMode.Stretch,
        ParticleSystemSortMode SortMode = ParticleSystemSortMode.Distance,
        int NormalDirection = 1,
        int MaxParticleSize = 30
        )
    {
        // Call Last
        ParticleSystemRenderer PR = PS.GetComponent<ParticleSystemRenderer>();
        // Renderer Settings
        PR.enabled = enabled;
        PR.normalDirection = NormalDirection;
        // Mesh Options / Material Options
        if (RenderMode == ParticleSystemRenderMode.Mesh)
        {
            GameObject ResourceMesh = (GameObject)LoadResource(Resources_MeshObject);
            PR.mesh = ResourceMesh.GetComponent<MeshFilter>().sharedMesh;
        }
        if (Resources_Material != null)
        {
            PR.material = (Material)LoadResource(Resources_Material);
        }
        if (Resources_TrailMaterial != null)
        {
            PR.trailMaterial = (Material)LoadResource(Resources_TrailMaterial);
        }
        // Mode Settings
        PR.maxParticleSize = MaxParticleSize;
        PR.renderMode = RenderMode;
        PR.sortMode = SortMode;
    }
    public static void ParticleMainSettings(this ParticleSystem PS,
        bool LoopParticle = true,
        float GravityModifier = 0.0f,
        float StartSize = 0.0f,
        float StartSpeed = 0.0f,
        float StartLifetime = 0.0f,
        float Delay = 0.0f,
        float StartRotation = 90f)
    {
        ParticleSystem.MainModule main = PS.main;
        // Main Settings
        main.loop = LoopParticle;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.gravityModifier = GravityModifier;
        main.startSize = StartSize;
        main.startSpeed = StartSpeed;
        main.startDelay = Delay;
        main.startLifetime = StartLifetime;
        main.startRotationY = StartRotation;
    }
    public static void ParticleColorOverLifetimeSettings(this ParticleSystem PS,
        bool enabled = true,
        Gradient gradient = null // Set Externally
        )
    {
        ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = PS.colorOverLifetime;
        // ColorOverLifetime Settings
        colorOverLifetimeModule.enabled = enabled;
        colorOverLifetimeModule.color = new ParticleSystem.MinMaxGradient(gradient);
    }
    public static void ParticleSizeOverLifetimeSettings(this ParticleSystem PS,
        bool enabled = true,
        float scalar = 0.0f,
        AnimationCurve animationCurve = null // Set Externally
        )
    {
        ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = PS.sizeOverLifetime;
        // Size over Lifetime Settings
        ParticleSystem.MinMaxCurve Curve = new ParticleSystem.MinMaxCurve(scalar, animationCurve);
        sizeOverLifetimeModule.enabled = enabled;
        sizeOverLifetimeModule.size = Curve;
    }
    public static void ParticleShapeSettings(this ParticleSystem PS,
        bool enabled = true,
        ParticleSystemShapeType ShapeType = ParticleSystemShapeType.Cone,
        ParticleSystemShapeMultiModeValue RadiusMode = ParticleSystemShapeMultiModeValue.Loop,
        bool AlignDirection = false,
        float Angle = 0f,
        float Arc = 0f,
        float Radius = 0f,
        float X = 0f,
        float Y = 0f,
        float Z = 0f
        )
    {
        ParticleSystem.ShapeModule shapeModule = PS.shape;
        // Shape settings
        shapeModule.shapeType = ShapeType;
        shapeModule.arcMode = ParticleSystemShapeMultiModeValue.Loop;
        shapeModule.radiusMode = RadiusMode;
        shapeModule.alignToDirection = AlignDirection;
        shapeModule.angle = Angle;
        shapeModule.arc = Arc;
        shapeModule.radius = Radius;
        shapeModule.position = new Vector3(X, Y, Z);
    }
    public static void ParticleEmissionSettings(this ParticleSystem PS,
        bool enabled = true,
        float scalar = 0.0f,
        bool RateOverTime = false,
        bool Burst = false,
        ParticleSystem.Burst[] BurstSettings = null, // Set Externally
        AnimationCurve animationCurve = null, // Set Externally
        ParticleSystemCurveMode CurveMode = ParticleSystemCurveMode.Constant,
        int rate = 0
        )
    {
        ParticleSystem.MinMaxCurve EmissionCurve;
        ParticleSystem.EmissionModule emissionModule = PS.emission;
        // Emission Settings
        emissionModule.enabled = enabled;
        if (RateOverTime)
        {
            EmissionCurve = new ParticleSystem.MinMaxCurve(scalar, animationCurve);
            EmissionCurve.mode = CurveMode;
            emissionModule.rateOverTime = EmissionCurve;
        }
        if (Burst)
        {
            emissionModule.SetBursts(BurstSettings);
        }
        emissionModule.rateOverTime = rate;
    }
    public static void ParticleCollisionSettings(this ParticleSystem PS,
        bool enabled = true,
        float ColliderForce = 0f,
        float RadiusScale = 0f,
        ParticleSystemCollisionMode Mode = ParticleSystemCollisionMode.Collision3D,
        ParticleSystemCollisionQuality Quality = ParticleSystemCollisionQuality.High,
        ParticleSystemCollisionType Type = ParticleSystemCollisionType.World,
        bool DynamicColliders = true,
        bool SendMessages = true,
        string[] MaskNames = null // Set Outside, selects Default if none)
        )
    {
        ParticleSystem.CollisionModule collisionModule = PS.collision;
        // Collision Settings
        collisionModule.enabled = enabled;
        collisionModule.colliderForce = ColliderForce;
        collisionModule.radiusScale = RadiusScale;
        collisionModule.mode = Mode;
        collisionModule.quality = Quality;
        collisionModule.type = Type;
        collisionModule.collidesWith = GetLayer(MaskNames);
        collisionModule.enableDynamicColliders = DynamicColliders;
        collisionModule.sendCollisionMessages = SendMessages;
    }
    public static void ParticleTriggerSettings(this ParticleSystem PS,
        bool enabled = true)
    {
        ParticleSystem.TriggerModule triggerModule = PS.trigger;
        // Trigger Settings
        triggerModule.enabled = enabled;
    }
    public static void ParticleRotationSettings(this ParticleSystem PS,
        bool enabled = true,
        float Scalar = 1.0f,
        float Velocity = 100f,
        ParticleSystemCurveMode curveMode = ParticleSystemCurveMode.Constant,
        float CurveMin = 45f,
        float CurveMax = 114f
        )
    {
        ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = PS.rotationOverLifetime;
        // Rotation settings
        rotationOverLifetimeModule.enabled = enabled;
        if (curveMode == ParticleSystemCurveMode.Constant)
        {
            ParticleSystem.MinMaxCurve RotationCurveConst = new ParticleSystem.MinMaxCurve(Velocity);
            RotationCurveConst.mode = curveMode;
            rotationOverLifetimeModule.z = RotationCurveConst;
        }
        if (curveMode == ParticleSystemCurveMode.TwoConstants)
        {
            rotationOverLifetimeModule.z = new ParticleSystem.MinMaxCurve(1f, 3f);
        }
    }
    public static void ParticleNoiseSettings(this ParticleSystem PS,
        bool enabled = true,
        int Octaves = 0,
        float ScrollSpeed = 0.0f,
        int Strength = 0)
    {
        ParticleSystem.NoiseModule noiseModule = PS.noise;
        // Noise settings
        noiseModule.enabled = enabled;
        noiseModule.octaveCount = Octaves;
        noiseModule.scrollSpeed = ScrollSpeed;
        noiseModule.strength = Strength;
    }
    public static void ParticleLightSettings(this ParticleSystem PS,
        bool enabled = true,
        float scalar = 0.0f,
        AnimationCurve animationCurve = null, // Set outside
        string LightPrefab = null
        )
    {
        ParticleSystem.LightsModule lightsModule = PS.lights;
        // Light Settings
        lightsModule.enabled = enabled;
        GameObject LightObject = (GameObject)LoadResource(LightPrefab);
        Light light = LightObject.GetComponent<Light>();
        lightsModule.light = light;

        ParticleSystem.MinMaxCurve LightCurve = new ParticleSystem.MinMaxCurve(scalar, animationCurve);
        lightsModule.intensity = LightCurve;
        lightsModule.range = 100;
        lightsModule.useRandomDistribution = false;
        lightsModule.ratio = 1;
        lightsModule.useParticleColor = false;
        lightsModule.intensity = 1;
        lightsModule.maxLights = 3;

    }
    public static void ParticleTrailSettings(this ParticleSystem PS,
        bool enabled = true,
        ParticleSystemTrailTextureMode TrailMode = ParticleSystemTrailTextureMode.Stretch,
        float TailWidth = 10,
        bool SizeAffectsWidth = false,
        bool DieWithParticle = false)
    {
        ParticleSystem.TrailModule trailModule = PS.trails;
        // Trail Settings
        trailModule.enabled = enabled;
        trailModule.textureMode = TrailMode;
        trailModule.widthOverTrail = TailWidth;
        trailModule.sizeAffectsWidth = SizeAffectsWidth;
        trailModule.dieWithParticles = DieWithParticle;
    }
    public static void ParticleInheritVelocity(this ParticleSystem PS,
        bool enabled = true,
        ParticleSystemInheritVelocityMode Mode = ParticleSystemInheritVelocityMode.Initial)
    {
        ParticleSystem.InheritVelocityModule inheritVelocityModule = PS.inheritVelocity;
        // Velocity Settings
        inheritVelocityModule.enabled = enabled;
        inheritVelocityModule.mode = ParticleSystemInheritVelocityMode.Initial;
    }
    public static void ParticleSubSettings(this ParticleSystem PS,
        bool enabled = true,
        GameObject SPSContainer = null, // Contains Particle System
        ParticleSystemSubEmitterType Mode = ParticleSystemSubEmitterType.Birth,
        ParticleSystemSubEmitterProperties Inherit = ParticleSystemSubEmitterProperties.InheritNothing
        )
    { // In progress
        ParticleSystem.SubEmittersModule subEmittersModule = PS.subEmitters;
        // Sub Emitters
        subEmittersModule.enabled = enabled;
        ParticleSystem SPS = SPSContainer.GetComponent<ParticleSystem>();

        subEmittersModule.AddSubEmitter(SPS, Mode, Inherit);
    }
}
