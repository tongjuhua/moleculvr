﻿//========= Copyright 2016, HTC Corporation. All rights reserved. ===========

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HTC.UnityPlugin.Pointer3D
{
    [AddComponentMenu("HTC/Pointer3D/Graphic Raycast Method")]
    public class GraphicRaycastMethod : BaseRaycastMethod
    {
        [SerializeField]
        private Canvas m_Canvas;
        [SerializeField]
        private bool m_IgnoreReversedGraphics = true;

        public Canvas canvas { get { return m_Canvas; } set { m_Canvas = value; } }
        public bool ignoreReversedGraphics { get { return m_IgnoreReversedGraphics; } set { m_IgnoreReversedGraphics = value; } }
#if UNITY_EDITOR
        protected virtual void Reset()
        {
            if (m_Canvas == null)
            {
                m_Canvas = FindObjectOfType<Canvas>();
            }
        }
#endif
        public override void Raycast(BaseRaycaster module, Vector2 position, Camera eventCamera, List<RaycastResult> raycastResults)
        {
            CanvasRaycastMethod.Raycast(canvas, ignoreReversedGraphics, module, position, eventCamera, raycastResults);
        }
    }
}