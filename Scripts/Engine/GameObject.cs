using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GSEngine
{
    public class GameObject
    {
        const ulong NIL = 0;
        private readonly ulong ID = 0;
        public GameObject(ulong e)
        {
            ID = e;
        }

        public string Name
        {
            get
            {
                return GetEntityNameByID_Native(ID);
            }
        }

        public void EnableEntity(ulong ent = NIL)
        {
            if (ent == NIL)
                EnableEntity_Native(ID, true);
            else
                EnableEntity_Native(ent, true);
        }

        public void DisableEntity(ulong ent = NIL)
        {
            if (ent == NIL)
                EnableEntity_Native(ID, false);
            else
                EnableEntity_Native(ent, false);
        }

        /**
         * Checks if Component Exists in Current Entity
         * 
         * 
         * \return bool
         */
        public bool HasComponent<T>() where T : Component, new()
        {
            return HasComponent_Native(ID, typeof(T));
        }
        /**
         * Checks if Component Exists in An Entity
         * 
         * \param ent
         * \return smth
         */
        public bool HasComponent<T>(ulong ent) where T : Component, new()
        {
            return HasComponent_Native(ent, typeof(T));
        }

        public T AddComponent<T>() where T : Component, new()
        {
            if (!HasComponent<T>())
            {
                AddComponent_Native(ID, typeof(T));
                T component = new T();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public T AddComponent<T>(ulong ent) where T : Component, new()
        {
            if (!HasComponent<T>(ent))
            {
                AddComponent_Native(ent, typeof(T));
                T component = new T()
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public TransformComponent AddComponent(Transform intransform)
        {
            if (!HasComponent<TransformComponent>())
            {
                AddTransformComponent_Native(ID, ref intransform);
                TransformComponent component = new TransformComponent();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public TransformComponent AddComponent(ulong ent, Transform intransform)
        {
            if (!HasComponent<TransformComponent>(ent))
            {
                AddTransformComponent_Native(ent, ref intransform);
                TransformComponent component = new TransformComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public UITransformComponent AddComponent(UITransform intransform)
        {
            if (!HasComponent<UITransformComponent>())
            {
                AddUITransformComponent_Native(ID, ref intransform);
                UITransformComponent component = new UITransformComponent();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public UITransformComponent AddComponent(ulong ent, UITransform intransform)
        {
            if (!HasComponent<UITransformComponent>(ent))
            {
                AddUITransformComponent_Native(ent, ref intransform);
                UITransformComponent component = new UITransformComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public QuadShearComponent AddComponent(QuadShear inquadshear)
        {
            if (!HasComponent<QuadShearComponent>())
            {
                AddQuadShearComponent_Native(ID, ref inquadshear);
                QuadShearComponent component = new QuadShearComponent();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public TextureComponent AddComponent(Texture intexture)
        {
            if (!HasComponent<TextureComponent>())
            {
                AddTextureComponent_Native(ID, ref intexture);
                TextureComponent component = new TextureComponent();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public TextureComponent AddComponent(ulong ent, Texture intexture)
        {
            if (!HasComponent<TextureComponent>(ent))
            {
                AddTextureComponent_Native(ent, ref intexture);
                TextureComponent component = new TextureComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public TextObjectComponent AddComponent(TextObject intextobject)
        {
            if (!HasComponent<TextObjectComponent>())
            {
                AddTextObjectComponent_Native(ID, ref intextobject);
                TextObjectComponent component = new TextObjectComponent();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public TextObjectComponent AddComponent(ulong ent, TextObject intextobject)
        {
            if (!HasComponent<TextObjectComponent>(ent))
            {
                AddTextObjectComponent_Native(ent, ref intextobject);
                TextObjectComponent component = new TextObjectComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public CameraComponent AddComponent(Camera incamera)
        {
            if (!HasComponent<CameraComponent>())
            {
                AddCameraComponent_Native(ID, ref incamera);
                CameraComponent component = new CameraComponent();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public CameraComponent AddComponent(ulong ent, Camera incamera)
        {
            if (!HasComponent<CameraComponent>(ent))
            {
                AddCameraComponent_Native(ent, ref incamera);
                CameraComponent component = new CameraComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public AudioObjectComponent AddComponent(AudioObject inaudioobject)
        {
            if (!HasComponent<AudioObjectComponent>())
            {
                AddAudioObjectComponent_Native(ID, ref inaudioobject);
                AudioObjectComponent component = new AudioObjectComponent();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public AudioObjectComponent AddComponent(ulong ent, AudioObject inaudioobject)
        {
            if (!HasComponent<AudioObjectComponent>(ent))
            {
                AddAudioObjectComponent_Native(ent, ref inaudioobject);
                AudioObjectComponent component = new AudioObjectComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public RigidBodyComponent AddComponent(ulong ent, RigidBody inrigidbody)
        {
            if (!HasComponent<AudioObjectComponent>(ent))
            {
                AddRigidBodyComponent_Native(ent, ref inrigidbody);
                RigidBodyComponent component = new RigidBodyComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public CircleCollider2DComponent AddComponent(ulong ent, CircleCollider2D incirclecollider2D)
        {
            if (!HasComponent<CircleCollider2DComponent>(ent))
            {
                AddCircleCollider2DComponent_Native(ent, ref incirclecollider2D);
                CircleCollider2DComponent component = new CircleCollider2DComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public BoxCollider2DComponent AddComponent(ulong ent, BoxCollider2D inboxcollider2D)
        {
            if (!HasComponent<BoxCollider2DComponent>(ent))
            {
                AddBoxCollider2DComponent_Native(ent, ref inboxcollider2D);
                BoxCollider2DComponent component = new BoxCollider2DComponent
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public T GetComponent<T>() where T : Component, new()
        {
            if (HasComponent<T>())
            {
                T component = new T();
                component.entity = ID;
                return component;
            }
            return null;
        }

        public T GetComponent<T>(ulong ent) where T : Component, new()
        {
            if (HasComponent<T>(ent))
            {
                T component = new T()
                {
                    entity = ent
                };
                return component;
            }
            return null;
        }

        public TransformComponent transform
        {
            get
            {
                return GetComponent<TransformComponent>();
            }
        }
        public UITransformComponent uiTransform
        {
            get
            {
                return GetComponent<UITransformComponent>();
            }
        }
        public QuadShearComponent quadshear
        {
            get
            {
                return GetComponent<QuadShearComponent>();
            }
        }
        public TextureComponent texture
        {
            get
            {
                return GetComponent<TextureComponent>();
            }
        }
        public TextObjectComponent textobject
        {
            get
            {
                return GetComponent<TextObjectComponent>();
            }
        }
        public CameraComponent camera
        {
            get
            {
                return GetComponent<CameraComponent>();
            }
        }
        public AudioObjectComponent audioobject
        {
            get
            {
                return GetComponent<AudioObjectComponent>();
            }
        }
        public RigidBodyComponent rigidbody
        {
            get
            {
                return GetComponent<RigidBodyComponent>();
            }
        }
        public CircleCollider2DComponent circlecollider2D
        {
            get
            {
                return GetComponent<CircleCollider2DComponent>();
            }
        }
        public BoxCollider2DComponent boxcollider2D
        {
            get
            {
                return GetComponent<BoxCollider2DComponent>();
            }
        }
        public ParticleEngineComponent particleengine
        {
            get
            {
                return GetComponent<ParticleEngineComponent>();
            }
        }
        public LightSourceComponent lightsource
        {
            get
            {
                return GetComponent<LightSourceComponent>();
            }
        }

        public static GameObject Instantiate(string name = "", bool isUI = false)
        {
            ulong id = CreateEntity_Native(name, isUI);
            return new GameObject(id);
        }

        public static void Destroy(GameObject obj)
        {
            DestroyEntity_Native(obj.ID);
        }

        public static GameObject GetEntityIDByName(string name)
        {
            ulong id = GetEntityIDByName_Native(name);
            return new GameObject(id);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ulong CreateEntity_Native(string name, bool isUI);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void DestroyEntity_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ulong GetEntityIDByName_Native(string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern string GetEntityNameByID_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void EnableEntity_Native(ulong entity, bool isEnabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool HasComponent_Native(ulong entity, Type type);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool AddComponent_Native(ulong entity, Type type);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddTransformComponent_Native(ulong entity, ref Transform intransform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddUITransformComponent_Native(ulong entity, ref UITransform intransform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddQuadShearComponent_Native(ulong entity, ref QuadShear inquadshear);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddTextureComponent_Native(ulong entity, ref Texture intexture);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddTextObjectComponent_Native(ulong entity, ref TextObject intextobject);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddCameraComponent_Native(ulong entity, ref Camera incamera);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddAudioObjectComponent_Native(ulong entity, ref AudioObject inaudioobject);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddRigidBodyComponent_Native(ulong entity, ref RigidBody inrigidbody);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddCircleCollider2DComponent_Native(ulong entity, ref CircleCollider2D incirclecollider2D);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void AddBoxCollider2DComponent_Native(ulong entity, ref BoxCollider2D inboxcollider2D);

    }
}
