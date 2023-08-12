using ShipGame.Enemies;
using ShipGame.Enemies.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Enemies.Movement
{
    public class ZigZag : MovementPattern
    {
        // Start is called before the first frame update
        [SerializeField]
        float xLeftLimit;
        [SerializeField]
        float xRightLimit;

        int dir = 1;
        void Start()
        {
            enemy = GetComponent<Enemy>();
            rb = enemy.gameObject.GetComponent<Rigidbody2D>();
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

          
            
            if (transform.position.x>xRightLimit)
            {
                dir = -1;
            }
            if(transform.position.x<xLeftLimit)
            {
                dir = 1;
            }

            rb.velocity = Vector3.SmoothDamp(rb.velocity, speed * transform.right * dir, ref m_velocity, m_MovementSmoothing);
        }
    }
}

