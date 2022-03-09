using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    public abstract class Component
    {
        public ulong entity;
    }

    public class TransformComponent : Component
    {
        public Transform Transform
        {
            get
            {
                GetTransform_Native(entity, out Transform result);
                result.layer = GetTransformZDepth_Native(entity);
                return result;
            }

            set
            {
                SetTransform_Native(entity, ref value);
                SetTransformZDepth_Native(entity, value.layer);
            }
        }

        public Transform GlobalTransform
        {
            get
            {
                GetGlobalTransform_Native(entity, out Transform result);
                result.layer = GetTransformZDepth_Native(entity);
                return result;
            }
        }

        public Vector2 Position
        {
            get
            {
                GetTransformPosition_Native(entity, out Vector2 result);
                return result;
            }

            set
            {
                SetTransformPosition_Native(entity, ref value);
            }
        }

        public float Rotation
        {
            get
            {
                return GetTransformRotation_Native(entity);
            }

            set
            {
                SetTransformRotation_Native(entity, value);
            }
        }

        public Vector2 Scale
        {
            get
            {
                GetTransformScale_Native(entity, out Vector2 result);
                return result;
            }

            set
            {
                SetTransformScale_Native(entity, ref value);
            }
        }

        public string Layer
        {
            get
            {
                return GetTransformZDepth_Native(entity);
            }

            set
            {
                SetTransformZDepth_Native(entity, value);
            }
        }

        public void Translate(Vector2 translation)
        {
            Translate_Native(entity, ref translation);
        }

        public void Rotate(float rotation)
        {
            Rotate_Native(entity, rotation);
        }

        public void ScaleUp(Vector2 scale)
        {
            ScaleUp_Native(entity, ref scale);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTransform_Native(ulong entity, out Transform outTransform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetGlobalTransform_Native(ulong entity, out Transform outTransform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTransform_Native(ulong entity, ref Transform inTransform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTransformPosition_Native(ulong entity, out Vector2 outPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTransformPosition_Native(ulong entity, ref Vector2 inPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetTransformRotation_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTransformRotation_Native(ulong entity, float inRotation);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTransformScale_Native(ulong entity, out Vector2 outScale);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTransformScale_Native(ulong entity, ref Vector2 inScale);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string GetTransformZDepth_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTransformZDepth_Native(ulong entity, string inZDepth);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Translate_Native(ulong entity, ref Vector2 inTranslation);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Rotate_Native(ulong entity, float inRotate);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ScaleUp_Native(ulong entity, ref Vector2 inScale);
    }

    public class UITransformComponent : Component
    {
        public UITransform UITransform
        {
            get
            {
                GetUITransform_Native(entity, out UITransform result);
                return result;
            }

            set
            {
                SetUITransform_Native(entity, ref value);
            }
        }

        public UITransform UIGlobalTransform
        {
            get
            {
                GetGlobalUITransform_Native(entity, out UITransform result);
                return result;
            }
        }

        public Vector2 Position
        {
            get
            {
                GetUITransformPosition_Native(entity, out Vector2 result);
                return result;
            }

            set
            {
                SetUITransformPosition_Native(entity, ref value);
            }
        }

        public float Rotation
        {
            get
            {
                return GetUITransformRotation_Native(entity);
            }

            set
            {
                SetUITransformRotation_Native(entity, value);
            }
        }

        public Vector2 Scale
        {
            get
            {
                GetUITransformScale_Native(entity, out Vector2 result);
                return result;
            }

            set
            {
                SetUITransformScale_Native(entity, ref value);
            }
        }

        public void Translate(Vector2 translation)
        {
            Translate_Native(entity, ref translation);
        }

        public void Rotate(float rotation)
        {
            Rotate_Native(entity, rotation);
        }

        public void ScaleUp(Vector2 scale)
        {
            ScaleUp_Native(entity, ref scale);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetUITransform_Native(ulong entity, out UITransform outTransform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetGlobalUITransform_Native(ulong entity, out UITransform outTransform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetUITransform_Native(ulong entity, ref UITransform inTransform);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetUITransformPosition_Native(ulong entity, out Vector2 outPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetUITransformPosition_Native(ulong entity, ref Vector2 inPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetUITransformRotation_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetUITransformRotation_Native(ulong entity, float inRotation);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetUITransformScale_Native(ulong entity, out Vector2 outScale);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetUITransformScale_Native(ulong entity, ref Vector2 inScale);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Translate_Native(ulong entity, ref Vector2 inTranslation);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Rotate_Native(ulong entity, float inRotate);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ScaleUp_Native(ulong entity, ref Vector2 inScale);
    }

    public class QuadShearComponent : Component
    {
        public QuadShear QuadShear
        {
            get
            {
                GetQuadShear_Native(entity, out QuadShear result);
                return result;
            }

            set
            {
                SetQuadShear_Native(entity, ref value);
            }
        }

        public SHEAR_DIRECTION Direction
        {
            get
            {
                return GetQuadShearDirection_Native(entity);
            }

            set
            {
                SetQuadShearDirection_Native(entity, value);
            }
        }

        public float Magnitude
        {
            get
            {
                return GetQuadShearMagnitude_Native(entity);
            }

            set
            {
                SetQuadShearMagnitude_Native(entity, value);
            }
        }

        public SHEARED_VERTICES ShearedVertex
        {
            get
            {
                return GetQuadShearShearedVertex_Native(entity);
            }

            set
            {
                SetQuadShearShearedVertex_Native(entity, value);
            }
        }

        public void AddMagnitude(float magnitude)
        {
            AddMagnitude_Native(entity, magnitude);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetQuadShear_Native(ulong entity, out QuadShear outQuadShear);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetQuadShear_Native(ulong entity, ref QuadShear inQuadShear);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern SHEAR_DIRECTION GetQuadShearDirection_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetQuadShearDirection_Native(ulong entity, SHEAR_DIRECTION inDirection);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetQuadShearMagnitude_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetQuadShearMagnitude_Native(ulong entity, float inMagnitude);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern SHEARED_VERTICES GetQuadShearShearedVertex_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetQuadShearShearedVertex_Native(ulong entity, SHEARED_VERTICES inShearedVertices);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void AddMagnitude_Native(ulong entity, float magnitude);
    }

    public class TextureComponent : Component
    {
        public Texture Texture
        {
            get
            {
                GetTexture_Native(entity, out Texture result);
                result.DrawProperties.Shader = GetTextureShader_Native(entity);
                result.ImagePath = GetTextureImagePath_Native(entity);
                return result;
            }

            set
            {
                SetTexture_Native(entity, ref value);
                SetTextureShader_Native(entity, value.DrawProperties.Shader);
                SetTextureImagePath_Native(entity, value.ImagePath);
            }
        }

        public TextureData TextureData
        {
            get
            {
                GetTextureTextureData_Native(entity, out TextureData result);
                return result;
            }
        }

        public bool Enabled
        {
            get
            {
                return GetTextureEnabled_Native(entity);
            }

            set
            {
                SetTextureEnabled_Native(entity, value);
            }
        }

        public SpriteSheet SpriteSheet
        {
            get
            {
                GetTextureSpriteSheet_Native(entity, out SpriteSheet result);
                return result;
            }

            set
            {
                SetTextureSpriteSheet_Native(entity, ref value);
            }
        }


        public int Width
        {
            get
            {
                return GetTextureWidth_Native(entity);
            }

            set
            {
                SetTextureWidth_Native(entity, value);
            }
        }

        public int Height
        {
            get
            {
                return GetTextureHeight_Native(entity);
            }

            set
            {
                SetTextureHeight_Native(entity, value);
            }
        }

        public bool FlippedX
        {
            get
            {
                return GetTextureFlippedX_Native(entity);
            }
            set
            {
                SetTextureFlippedX_Native(entity, value);
            }
        }

        public bool FlippedY
        {
            get
            {
                return GetTextureFlippedY_Native(entity);
            }
            set
            {
                SetTextureFlippedY_Native(entity, value);
            }
        }

        public Vector4 Color
        {
            get
            {
                GetTextureColor_Native(entity, out Vector4 result);
                return result;
            }

            set
            {
                SetTextureColor_Native(entity, ref value);
            }
        }

        public int PixelsPerUnit
        {
            get
            {
                return GetTexturePixelsPerUnit_Native(entity);
            }

            set
            {
                SetTexturePixelsPerUnit_Native(entity, value);
            }
        }

        public DrawProperties DrawProperties
        {
            get
            {
                GetTextureDrawProperties_Native(entity, out DrawProperties result);
                result.Shader = GetTextureShader_Native(entity);
                return result;
            }

            set
            {
                SetTextureDrawProperties_Native(entity, ref value);
                SetTextureShader_Native(entity, value.Shader);
            }
        }


        public string ImagePath
        {
            get
            {
                return GetTextureImagePath_Native(entity);
            }

            set
            {
                SetTextureImagePath_Native(entity, value);
            }
        }

        public void LoadAssetPath()
        {
            LoadAssetPath_Native(entity);
        }

        public void SetAsTileSheet(int frameWidth, int frameHeight, int rows, int columns)
        {
            SetAsTileSheet_Native(entity, frameWidth, frameHeight, rows, columns);
        }


        public void SetAnimationFrames(int startFrame, int endFrame, float frameDelay, bool loop = true, int currentFrame = -1)
        {
            if (currentFrame <= -1) currentFrame = startFrame;
            SetAnimationFrames_Native(entity, startFrame, endFrame, frameDelay, loop, currentFrame);
        }

        public void ResetSpriteSheet()
        {
            ResetSpriteSheet_Native(entity);
        }

        public void SetTransparency(float alpha)
        {
            SetTransparency_Native(entity, alpha);
        }

        public void SetCustomPercentage(float widthStart = 0, float heightStart = 0, float widthEnd = 100, float heightEnd = 100)
        {
            SetCustomPercentage_Native(entity, widthStart, heightStart, widthEnd, heightEnd);
        }

        public void SetCustomPercentage_Width(float widthStart, float widthEnd)
        {
            SetCustomPercentageWidth_Native(entity, widthStart, widthEnd);
        }

        public void SetCustomPercentage_Height(float heightStart, float heightEnd)
        {
            SetCustomPercentageHeight_Native(entity, heightStart, heightEnd);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTexture_Native(ulong entity, out Texture outTexture);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTexture_Native(ulong entity, ref Texture inTexture);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTextureTextureData_Native(ulong entity, out TextureData outTextureData);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetTextureEnabled_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureEnabled_Native(ulong entity, bool inEnabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTextureSpriteSheet_Native(ulong entity, out SpriteSheet outSpriteSheet);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureSpriteSheet_Native(ulong entity, ref SpriteSheet inSpriteSheet);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int GetTextureWidth_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureWidth_Native(ulong entity, int inWidth);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int GetTextureHeight_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureHeight_Native(ulong entity, int inHeight);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetTextureFlippedX_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureFlippedX_Native(ulong entity, bool inFlippedX);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetTextureFlippedY_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureFlippedY_Native(ulong entity, bool inFlippedY);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTextureColor_Native(ulong entity, out Vector4 outColor);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureColor_Native(ulong entity, ref Vector4 inColor);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int GetTexturePixelsPerUnit_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTexturePixelsPerUnit_Native(ulong entity, int inPixelsPerUnit);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTextureDrawProperties_Native(ulong entity, out DrawProperties outDrawProperties);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureDrawProperties_Native(ulong entity, ref DrawProperties inDrawProperties);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string GetTextureShader_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureShader_Native(ulong entity, string inShader);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string GetTextureImagePath_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextureImagePath_Native(ulong entity, string inImagePath);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void LoadAssetPath_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAsTileSheet_Native(ulong entity, int frameWidth, int frameHeight, int rows, int columns);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAnimationFrames_Native(ulong entity, int startFrame, int endFrame, float frameDelay, bool loop, int currentFrame);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ResetSpriteSheet_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTransparency_Native(ulong entity, float alpha);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCustomPercentage_Native(ulong entity, float widthStart, float heightStart, float widthEnd, float heightEnd);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCustomPercentageWidth_Native(ulong entity, float widthStart, float widthEnd);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCustomPercentageHeight_Native(ulong entity, float heightStart, float heightEnd);

    }

    public class TextObjectComponent : Component
    {
        public TextObject TextObject
        {
            get
            {
                GetTextObject_Native(entity, out TextObject result);
                result.DrawProperties.Shader = GetTextObjectShader_Native(entity);
                result.FontPath = GetTextObjectFontPath_Native(entity);
                result.Text = GetTextObjectText_Native(entity);
                return result;
            }

            set
            {
                SetTextObject_Native(entity, ref value);
                SetTextObjectShader_Native(entity, value.DrawProperties.Shader);
                SetTextObjectFontPath_Native(entity, value.FontPath);
                SetTextObjectText_Native(entity, value.Text);
            }
        }

        public bool Enabled
        {
            get
            {
                return GetTextObjectEnabled_Native(entity);
            }

            set
            {
                SetTextObjectEnabled_Native(entity, value);
            }
        }

        public LeftAlignment LeftAlignment
        {
            get
            {
                return GetTextObjectLeftAlignment_Native(entity);
            }

            set
            {
                SetTextObjectLeftAlignment_Native(entity, value);
            }
        }

        public TopAlignment TopAlignment
        {
            get
            {
                return GetTextObjectTopAlignment_Native(entity);
            }

            set
            {
                SetTextObjectTopAlignment_Native(entity, value);
            }
        }

        public float Scale
        {
            get
            {
                return GetTextObjectScale_Native(entity);
            }

            set
            {
                SetTextObjectScale_Native(entity, value);
            }
        }

        public bool AutoSize
        {
            get
            {
                return GetTextObjectAutoSize_Native(entity);
            }

            set
            {
                SetTextObjectAutoSize_Native(entity, value);
            }
        }

        public float Width
        {
            get
            {
                return GetTextObjectWidth_Native(entity);
            }

            set
            {
                SetTextObjectWidth_Native(entity, value);
            }
        }

        public float Height
        {
            get
            {
                return GetTextObjectHeight_Native(entity);
            }

            set
            {
                SetTextObjectHeight_Native(entity, value);
            }
        }

        public Vector4 TextColor
        {
            get
            {
                GetTextObjectTextColor_Native(entity, out Vector4 result);
                return result;
            }

            set
            {
                SetTextObjectTextColor_Native(entity, ref value);
            }
        }

        public DrawProperties DrawProperties
        {
            get
            {
                GetTextObjectDrawProperties_Native(entity, out DrawProperties result);
                return result;
            }

            set
            {
                SetTextObjectDrawProperties_Native(entity, ref value);
            }
        }

        public string FontPath
        {
            get
            {
                return GetTextObjectFontPath_Native(entity);
            }

            set
            {
                SetTextObjectFontPath_Native(entity, value);
            }
        }

        public string Text
        {
            get
            {
                return GetTextObjectText_Native(entity);
            }

            set
            {
                SetTextObjectText_Native(entity, value);
            }
        }

        public void LoadAssetPath()
        {
            LoadAssetPath_Native(entity);
        }


        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTextObject_Native(ulong entity, out TextObject outTextObject);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObject_Native(ulong entity, ref TextObject inTextObject);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetTextObjectEnabled_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectEnabled_Native(ulong entity, bool inEnabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern LeftAlignment GetTextObjectLeftAlignment_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectLeftAlignment_Native(ulong entity, LeftAlignment inLeftAlignment);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern TopAlignment GetTextObjectTopAlignment_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectTopAlignment_Native(ulong entity, TopAlignment inTopAlignment);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetTextObjectScale_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectScale_Native(ulong entity, float inScale);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetTextObjectAutoSize_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectAutoSize_Native(ulong entity, bool inAutoSize);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetTextObjectWidth_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectWidth_Native(ulong entity, float inWidth);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetTextObjectHeight_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectHeight_Native(ulong entity, float inHeight);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTextObjectTextColor_Native(ulong entity, out Vector4 outTextColor);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectTextColor_Native(ulong entity, ref Vector4 inTextColor);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetTextObjectDrawProperties_Native(ulong entity, out DrawProperties outDrawProperties);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectDrawProperties_Native(ulong entity, ref DrawProperties inDrawProperties);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string GetTextObjectShader_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectShader_Native(ulong entity, string inShader);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string GetTextObjectFontPath_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectFontPath_Native(ulong entity, string inFontPath);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string GetTextObjectText_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetTextObjectText_Native(ulong entity, string inText);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void LoadAssetPath_Native(ulong entity);
    }

    public class CameraComponent : Component
    {
        public Camera Camera
        {
            get
            {
                GetCamera_Native(entity, out Camera result);
                return result;
            }
            set
            {
                SetCamera_Native(entity, ref value);
            }
        }

        public float CameraHeight
        {
            get
            {
                return GetCameraHeight_Native(entity);
            }
            set
            {
                SetCameraHeight_Native(entity, value);
            }
        }

        public float MinCameraHeight
        {
            get
            {
                return GetCameraMinCameraHeight_Native(entity);
            }
            set
            {
                SetCameraMinCameraHeight_Native(entity, value);
            }
        }

        public float MaxCameraHeight
        {
            get
            {
                return GetCameraMaxCameraHeight_Native(entity);
            }
            set
            {
                SetCameraMaxCameraHeight_Native(entity, value);
            }
        }
        public Vector2 ViewportPosition
        {
            get
            {
                GetCameraViewportPosition_Native(entity, out Vector2 result);
                return result;
            }
            set
            {
                SetCameraViewportPosition_Native(entity, ref value);
            }
        }

        public Vector2 ViewportSize
        {
            get
            {
                GetCameraViewportSize_Native(entity, out Vector2 result);
                return result;
            }
            set
            {
                SetCameraViewportSize_Native(entity, ref value);
            }
        }

        public float Smoothness
        {
            get
            {
                return GetCameraSmoothness_Native(entity);
            }
            set
            {
                SetCameraSmoothness_Native(entity, value);
            }
        }

        public GameObject GoFollowing
        {
            get
            {
                return new GameObject(GetCameraGOFollowing_Native(entity));
            }
            set
            {
                SetCameraGOFollowing_Native(entity, value.ID);
            }
        }

        public bool ToRender
        {
            get
            {
                return GetCameraToRender_Native(entity);
            }
            set
            {
                SetCameraToRender_Native(entity, value);
            }
        }

        public void ZoomIn(float z)
        {
            ZoomIn_Native(entity, z);
        }

        public void ZoomOut(float z)
        {
            ZoomOut_Native(entity, z);
        }

        public void Shake(Vector2 dir, float intensity, float fade = 1.0f)
        {
            Shake_Native(entity, ref dir, intensity, fade);
        }

        public Vector2 ScreenToWorld(Vector2 position)
        {
            ScreenToWorld_Native(entity, position, out Vector2 result);
            return result;
        }

        public Vector2 WorldToScreen(Vector2 position)
        {
            WorldToScreen_Native(entity, position, out Vector2 result);
            return result;
        }

        public bool IsInScreen(bool isWorld, Vector2 topLeft, Vector2 topRight, Vector2 btmRight, Vector2 btmLeft)
        {
            return IsInScreen_Native(entity, isWorld, ref topLeft, ref topRight, ref btmRight, ref btmLeft);
        }


        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetCamera_Native(ulong entity, out Camera outCamera);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCamera_Native(ulong entity, ref Camera inCamera);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetCameraPosition_Native(ulong entity, out Vector2 outPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraPosition_Native(ulong entity, ref Vector2 inPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetCameraRotation_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraRotation_Native(ulong entity, float inRotation);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetCameraHeight_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraHeight_Native(ulong entity, float inZoom);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetCameraMinCameraHeight_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraMinCameraHeight_Native(ulong entity, float inMinZoom);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetCameraMaxCameraHeight_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraMaxCameraHeight_Native(ulong entity, float inMaxZoom);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetCameraViewportPosition_Native(ulong entity, out Vector2 outViewportPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraViewportPosition_Native(ulong entity, ref Vector2 inViewportPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetCameraViewportSize_Native(ulong entity, out Vector2 outViewportSize);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraViewportSize_Native(ulong entity, ref Vector2 inViewportSize);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetCameraSmoothness_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraSmoothness_Native(ulong entity, float inSmoothness);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ulong GetCameraGOFollowing_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraGOFollowing_Native(ulong entity, ulong intGOFollowing);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetCameraToRender_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCameraToRender_Native(ulong entity, bool inToRender);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void MoveUp_Native(ulong entity, float dist);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void MoveDown_Native(ulong entity, float dist);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void MoveLeft_Native(ulong entity, float dist);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void MoveRight_Native(ulong entity, float dist);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Rotate_Native(ulong entity, float r);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ZoomIn_Native(ulong entity, float z);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ZoomOut_Native(ulong entity, float z);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Shake_Native(ulong entity, ref Vector2 dir, float intensity, float fade);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ScreenToWorld_Native(ulong entity, Vector2 position, out Vector2 outWorldCoords);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void WorldToScreen_Native(ulong entity, Vector2 position, out Vector2 outScreenCoords);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool IsInScreen_Native(ulong entity, bool isWorld, ref Vector2 topLeft, ref Vector2 topRight, ref Vector2 btmRight, ref Vector2 btmLeft);

    }

    public class AudioObjectComponent : Component
    {
        public AudioObject AudioObject
        {
            get
            {
                GetAudioObject_Native(entity, out AudioObject result);
                result.SoundFile = GetAudioObjectSoundFile_Native(entity);
                return result;
            }
            set
            {
                SetAudioObject_Native(entity, ref value);
                SetAudioObjectSoundFile_Native(entity, value.SoundFile);
            }
        }

        public string SoundFile
        {
            get
            {
                return GetAudioObjectSoundFile_Native(entity);
            }
            set
            {
                SetAudioObjectSoundFile_Native(entity, value);
            }
        }

        public bool Enabled
        {
            get
            {
                return GetAudioObjectEnabled_Native(entity);
            }
            set
            {
                SetAudioObjectEnabled_Native(entity, value);
            }
        }

        public bool Loop
        {
            get
            {
                return GetAudioObjectLoop_Native(entity);
            }
            set
            {
                SetAudioObjectLoop_Native(entity, value);
            }
        }

        public bool AutoPlay
        {
            get
            {
                return GetAudioObjectAutoPlay_Native(entity);
            }
            set
            {
                SetAudioObjectAutoPlay_Native(entity, value);
            }
        }

        public bool StereoSound
        {
            get
            {
                return GetAudioObjectStereoSound_Native(entity);
            }
            set
            {
                SetAudioObjectStereoSound_Native(entity, value);
            }
        }

        public float Volume
        {
            get
            {
                return GetAudioObjectVolume_Native(entity);
            }

            set
            {
                SetAudioObjectVolume_Native(entity, value);
            }
        }

        public SOUND_GROUP SoundGroup
        {
            get
            {
                return GetAudioObjectSoundGroup_Native(entity);
            }

            set
            {
                SetAudioObjectSoundGroup_Native(entity, value);
            }
        }

        public EQ_GROUP EQGroup
        {
            get
            {
                return GetAudioObjectEQGroup_Native(entity);
            }

            set
            {
                SetAudioObjectEQGroup_Native(entity, value);
            }
        }

        public void LoadAssetPath()
        {
            LoadAssetPath_Native(entity);
        }

        public void Play()
        {
            Play_Native(entity);
        }

        public void Pause()
        {
            Pause_Native(entity);
        }

        public void UnPause()
        {
            UnPause_Native(entity);
        }

        public void Stop()
        {
            Stop_Native(entity);
        }

        public void Mute()
        {
            Mute_Native(entity);
        }

        public void UnMute()
        {
            UnMute_Native(entity);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetAudioObject_Native(ulong entity, out AudioObject outAudioObject);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObject_Native(ulong entity, ref AudioObject inAudioObject);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string GetAudioObjectSoundFile_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObjectSoundFile_Native(ulong entity, string inSoundFile);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetAudioObjectEnabled_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObjectEnabled_Native(ulong entity, bool inEnabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetAudioObjectLoop_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObjectLoop_Native(ulong entity, bool inLoop);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetAudioObjectAutoPlay_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObjectAutoPlay_Native(ulong entity, bool inLoop);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetAudioObjectStereoSound_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObjectStereoSound_Native(ulong entity, bool inStereoSound);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetAudioObjectVolume_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObjectVolume_Native(ulong entity, float inLoop);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern SOUND_GROUP GetAudioObjectSoundGroup_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObjectSoundGroup_Native(ulong entity, SOUND_GROUP inSoundGroup);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern EQ_GROUP GetAudioObjectEQGroup_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAudioObjectEQGroup_Native(ulong entity, EQ_GROUP inSoundGroup);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void LoadAssetPath_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Play_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Pause_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void UnPause_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Stop_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Mute_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void UnMute_Native(ulong entity);
    }

    public class RigidBodyComponent : Component
    {
        public RigidBody RigidBody
        {
            get
            {
                GetRigidBody_Native(entity, out RigidBody result);
                return result;
            }
        }

        public Material Material
        {
            get
            {
                GetRigidBodyMaterial_Native(entity, out Material result);
                return result;
            }

            set
            {
                SetRigidBodyMaterial_Native(entity, ref value);
            }
        }

        public Vector2 Velocity
        {
            get
            {
                GetRigidBodyVelocity_Native(entity, out Vector2 result);
                return result;
            }
            set
            {
                SetRigidBodyVelocity_Native(entity, ref value);
            }
        }

        public Vector2 Gravity
        {
            get
            {
                GetRigidBodyGravity_Native(entity, out Vector2 result);
                return result;
            }
            set
            {
                SetRigidBodyGravity_Native(entity, ref value);
            }
        }

        public float Angular_Velocity
        {
            get
            {
                return GetRigidBodyAngular_Velocity_Native(entity);
            }
            set
            {
                SetRigidBodyAngular_Velocity_Native(entity, value);
            }
        }

        public float Mass
        {
            get
            {
                return GetRigidBodyMass_Native(entity);
            }
            set
            {
                SetRigidBodyMass_Native(entity, value);
            }
        }

        public bool Fixed_Rotation
        {
            get
            {
                return GetRigidBodyFixedRotation_Native(entity);
            }
            set
            {
                SetRigidBodyFixedRotation_Native(entity, value);
            }
        }

        public bool Is_Static
        {
            get
            {
                return GetRigidBodyIs_Static_Native(entity);
            }
            set
            {
                SetRigidBodyIs_Static_Native(entity, value);
            }
        }

        public void ApplyForce(Vector2 force, Vector2 point, Vector2 position, bool wakeup = true)
        {
            ApplyForce_Native(entity, ref force, ref point, ref position, wakeup);
        }

        public void ApplyLinearForce(Vector2 force, bool wakeup = true)
        {
            ApplyLinearForce_Native(entity, ref force, wakeup);
        }

        public void ApplyTorque(float torque, bool wakeup = true)
        {
            ApplyTorque_Native(entity, torque, wakeup);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetRigidBody_Native(ulong entity, out RigidBody outAudioObject);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetRigidBodyMaterial_Native(ulong entity, out Material outMaterial);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetRigidBodyMaterial_Native(ulong entity, ref Material inMaterial);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetRigidBodyVelocity_Native(ulong entity, out Vector2 outVelocity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetRigidBodyVelocity_Native(ulong entity, ref Vector2 inVelocity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetRigidBodyGravity_Native(ulong entity, out Vector2 outGravity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetRigidBodyGravity_Native(ulong entity, ref Vector2 inGravity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetRigidBodyAngular_Velocity_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetRigidBodyAngular_Velocity_Native(ulong entity, float inAngularVelocity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetRigidBodyMass_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetRigidBodyMass_Native(ulong entity, float inMass);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetRigidBodyFixedRotation_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetRigidBodyFixedRotation_Native(ulong entity, bool inMass);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetRigidBodyIs_Static_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetRigidBodyIs_Static_Native(ulong entity, bool inMass);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ApplyForce_Native(ulong entity, ref Vector2 force, ref Vector2 point, ref Vector2 position, bool wakeup);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ApplyLinearForce_Native(ulong entity, ref Vector2 force, bool wakeup);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void ApplyTorque_Native(ulong entity, float torque, bool wakeup);
    }

    public class CircleCollider2DComponent : Component
    {
        public CircleCollider2D CircleCollider2D
        {
            get
            {
                GetCircleCollider2D_Native(entity, out CircleCollider2D result);
                return result;
            }
        }

        public float Radius
        {
            get
            {
                return GetCircleCollider2DRadius_Native(entity);
            }
            set
            {
                SetCircleCollider2DRadius_Native(entity, value);
            }
        }

        public bool Enabled
        {
            get
            {
                return GetCircleCollider2DEnabled_Native(entity);
            }
            set
            {
                SetCircleCollider2DEnabled_Native(entity, value);
            }
        }

        public bool IsTrigger
        {
            get
            {
                return GetCircleCollider2DIsTrigger_Native(entity);
            }
            set
            {
                SetCircleCollider2DIsTrigger_Native(entity, value);
            }
        }

        public bool Triggered
        {
            get
            {
                return GetCircleCollider2DTriggered_Native(entity);
            }
        }

        public Vector2 Offset
        {
            get
            {
                GetCircleCollider2DOffset_Native(entity, out Vector2 result);
                return result;
            }
            set
            {
                SetCircleCollider2DOffset_Native(entity, ref value);
            }
        }

        public bool CollidedWithLayer(string Layer)
        {
            return CircleCollider2D_CollidedWithLayer_Native(entity, Layer);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetCircleCollider2D_Native(ulong entity, out CircleCollider2D outCircleCollider2D);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetCircleCollider2DRadius_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCircleCollider2DRadius_Native(ulong entity, float inRadius);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetCircleCollider2DEnabled_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCircleCollider2DEnabled_Native(ulong entity, bool inEnabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetCircleCollider2DIsTrigger_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCircleCollider2DIsTrigger_Native(ulong entity, bool inIsTrigger);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetCircleCollider2DTriggered_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetCircleCollider2DOffset_Native(ulong entity, out Vector2 outOffset);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetCircleCollider2DOffset_Native(ulong entity, ref Vector2 inOffset);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool CircleCollider2D_CollidedWithLayer_Native(ulong entity, string Layer);
    }

    public class BoxCollider2DComponent : Component
    {
        public BoxCollider2D BoxCollider2D
        {
            get
            {
                GetBoxCollider2D_Native(entity, out BoxCollider2D result);
                return result;
            }
        }

        public Vector2 Offset
        {
            get
            {
                GetBoxCollider2DOffset_Native(entity, out Vector2 result);
                return result;
            }
            set
            {
                SetBoxCollider2DOffset_Native(entity, ref value);
            }
        }

        public Vector2 Size
        {
            get
            {
                GetBoxCollider2DSize_Native(entity, out Vector2 result);
                return result;
            }
            set
            {
                SetBoxCollider2DSize_Native(entity, ref value);
            }
        }

        public bool Enabled
        {
            get
            {
                return GetBoxCollider2DEnabled_Native(entity);
            }
            set
            {
                SetBoxCollider2DEnabled_Native(entity, value);
            }
        }

        public bool IsTrigger
        {
            get
            {
                return GetBoxCollider2DIsTrigger_Native(entity);
            }
            set
            {
                SetBoxCollider2DIsTrigger_Native(entity, value);
            }
        }

        public bool Triggered
        {
            get
            {
                return GetBoxCollider2DTriggered_Native(entity);
            }
        }

        public bool CollidedWithLayer(string Layer)
        {
            return BoxCollider2D_CollidedWithLayer_Native(entity, Layer);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetBoxCollider2D_Native(ulong entity, out BoxCollider2D outBoxCollider2D);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetBoxCollider2DOffset_Native(ulong entity, out Vector2 outOffset);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetBoxCollider2DOffset_Native(ulong entity, ref Vector2 inOffset);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void GetBoxCollider2DSize_Native(ulong entity, out Vector2 outSize);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetBoxCollider2DSize_Native(ulong entity, ref Vector2 inSize);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetBoxCollider2DEnabled_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetBoxCollider2DEnabled_Native(ulong entity, bool inEnabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetBoxCollider2DIsTrigger_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetBoxCollider2DIsTrigger_Native(ulong entity, bool inIsTrigger);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetBoxCollider2DTriggered_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool BoxCollider2D_CollidedWithLayer_Native(ulong entity, string Layer);
    }

    public class ParticleEngineComponent : Component
    {
        public bool EmitterEnabled
        {
            get
            {
                return GetParticleEngineEmitterEnabled_Native(entity);
            }
            set
            {
                SetParticleEngineEmitterEnabled_Native(entity, value);
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetParticleEngineEmitterEnabled_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetParticleEngineEmitterEnabled_Native(ulong entity, bool inEmitterEnabled);
    }

    public class LightSourceComponent : Component
    {
        public float Intensity
        {
            get
            {
                return GetLightSourceIntensity_Native(entity);
            }
            set
            {
                SetLightSourceIntensity_Native(entity, value);
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetLightSourceIntensity_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetLightSourceIntensity_Native(ulong entity, float inIntensity);

    }

    public class SpriteLightComponent : Component
    {
        public float Intensity
        {
            get
            {
                return GetSpriteLightIntensity_Native(entity);
            }
            set
            {
                SetSpriteLightIntensity_Native(entity, value);
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float GetSpriteLightIntensity_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetSpriteLightIntensity_Native(ulong entity, float inIntensity);

    }

    public class AnimControllerComponent : Component
    {
        public AnimController AnimController
        { 
            get
            {
                AnimController a = new AnimController();
                a.enabled = GetAnimControllerEnabled_Native(entity);
                a.controller_name = GetAnimControllerControllerName_Native(entity);
                return a;
            }
        }
        public bool Enabled
        {
            get
            {
                return GetAnimControllerEnabled_Native(entity);
            }
            set
            {
                SetAnimControllerEnabled_Native(entity, value);
            }
        }
        public string ControllerName
        {
            get
            {
                return GetAnimControllerControllerName_Native(entity);
            }
        }

        public void SetCondition(string condName, bool val)
        {
            AnimController_SetCondition(entity, condName, val);
        }

        public string GetCurrentState()
        {
            return AnimController_GetCurrentState(entity);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool GetAnimControllerEnabled_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void SetAnimControllerEnabled_Native(ulong entity, bool inenabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string GetAnimControllerControllerName_Native(ulong entity);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void AnimController_SetCondition(ulong entity, string condName, bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string AnimController_GetCurrentState(ulong entity);
    }
}
