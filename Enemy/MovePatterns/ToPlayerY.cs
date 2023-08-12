using ShipGame.Enemies.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace ShipGame.Enemies.Movement
{
    public class ToPlayerY : MovementPattern
    {
        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public override void Move()
        {
            if (!enemy.IsActivated())
            {
                rb.velocity = Vector3.SmoothDamp(rb.velocity, speed * transform.up, ref m_velocity, m_MovementSmoothing);
                return;
            }

            //Move in relation to player Y pos, shoot the weapon closest to playership
            Vector2 moveDir = new Vector2(0, (enemy.GetTarget().position - gameObject.transform.position).y);
            if (moveDir.magnitude > 0.5f)
            {
                rb.velocity = Vector3.SmoothDamp(rb.velocity, speed * moveDir.normalized, ref m_velocity, m_MovementSmoothing);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}

