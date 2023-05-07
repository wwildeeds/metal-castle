using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Linq;

namespace wwild.controller.newgame
{
    using wwild.unit.newgame;

    public interface ISelection
    {
        ISelectorUnit SelectedUnit { get; }
        LayerMask CastableLayer { get; }
        bool IsUnitSelected { get; }
        void SetUnit(ISelectorUnit unit);
    }
    public class SelectionController : MonoBehaviour, ISelection, IDisposable
    {
        [SerializeField]
        private Camera m_camera;
        [SerializeField]
        private LayerMask m_castableLayer;

        public ISelectorUnit SelectedUnit { get; private set; }
        public LayerMask CastableLayer { get { return m_castableLayer; } }
        public bool IsUnitSelected { get { return SelectedUnit != null; } }

        public Action<string, string> OnSelectedUnit;

        public void SetUnit(ISelectorUnit unit)
        {
            if (IsUnitSelected)
            {
                if(unit != null)
                    if (SelectedUnit.InstanceID == unit.InstanceID) return;

                SelectedUnit.ToIdleState();
            }

            SelectedUnit = unit;
            SelectedUnit?.ToUniqueState();
            if (SelectedUnit == null)
            {
                OnSelectedUnit("", "");
            }
            else
            {
                OnSelectedUnit(SelectedUnit.UnitInfo, SelectedUnit.UnitDesc);
            }
        }

        void Update()
        {
            UpdateRaycasting();  
        }

        void OnDestroy()
        {
            Dispose();
        }

        private void UpdateRaycasting()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == true) return;

                CastUnit();
            }
        }

        private void CastUnit()
        {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, CastableLayer.value))
            {
                if (hit.collider == null)
                {
                    return;
                }
                var unit = hit.collider.GetComponent<ISelectorUnit>();
                SetUnit(unit);
            }
            else
            {
                SetUnit(null);
            }
        }

        public void Dispose()
        {
            OnSelectedUnit = null;
        }
    }
}