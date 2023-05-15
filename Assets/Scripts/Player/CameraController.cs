using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wwild.controller
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera m_playerCam;
        [SerializeField]
        private Transform m_target;

        [SerializeField]
        private float m_rotSpeed;
        [SerializeField]
        private float m_rotClamp;
        [SerializeField]
        private float m_moveSpeed;
        [SerializeField]
        private float m_lerpSpeed;
        [SerializeField]
        private float m_finalDistance;
        
        [SerializeField]
        private float m_minDistance;
        [SerializeField]
        private float m_maxDistance;

        private float m_rotX;
        private float m_rotY;

        private Vector3 m_finalDir;
        private Vector3 m_normalizedDir;

        private void Start()
        {
            //m_target = FindObjectOfType<PlayerController>().transform;

            m_rotX = transform.rotation.eulerAngles.x;
            m_rotY = transform.rotation.eulerAngles.y;

            m_normalizedDir = m_playerCam.transform.localPosition.normalized;
            m_finalDistance = m_playerCam.transform.localPosition.magnitude;
        }

        private void Update()
        {
            Rotatement();
        }

        private void LateUpdate()
        {
            Movement();
        }

        private void Rotatement()
        {
            //if (Input.GetKey(KeyCode.Mouse1))
            //{
            //    m_rotX += -(Input.GetAxis("Mouse Y")) * m_rotSpeed * Time.deltaTime;
            //    m_rotY += Input.GetAxis("Mouse X") * m_rotSpeed * Time.deltaTime;

            //    m_rotX = Mathf.Clamp(m_rotX, -m_rotClamp, m_rotClamp);
            //    var rot = Quaternion.Euler(m_rotX, m_rotY, 0f);
            //    transform.rotation = rot;

            //}

        }

        private void Movement()
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target.position, m_moveSpeed * Time.deltaTime);

            m_finalDir = transform.TransformPoint(m_normalizedDir * m_maxDistance);

            if (Physics.Linecast(transform.localPosition, m_finalDir, out var hit))
            {
                m_finalDistance = Mathf.Clamp(hit.distance, m_minDistance, m_maxDistance);
            }
            else
            {
                m_finalDistance = m_maxDistance;
            }

            m_playerCam.transform.localPosition = Vector3.Lerp(m_playerCam.transform.localPosition, m_normalizedDir * m_finalDistance, m_lerpSpeed * Time.deltaTime);
        }
    }
}
