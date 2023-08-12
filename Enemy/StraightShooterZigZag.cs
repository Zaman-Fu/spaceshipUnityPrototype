using ShipGame.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace ShipGame.Enemies
{
    public class StraightShooterZigZag : Enemy
    {
        int swapDir = 1;
        protected override void Move()
        {


            movement.Move();
            if (active)
            {
                weapons.ElementAt(0).Shoot();
                //Vector2 sideVelocity = Vector3.SmoothDamp(rb.velocity, speed * transform.right*swapDir, ref m_velocity, m_MovementSmoothing);//because of that ref it's all added together. where did I borrow this from? feels spaghetti.

            }
            //Vector2 forwardVelocity = Vector3.SmoothDamp(rb.velocity, speed*0.5f * transform.up, ref m_velocity, m_MovementSmoothing);

           // rb.velocity = forwardVelocity; 



        }

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            if (Vector2.Distance(Vector2.zero, transform.position) > 35)
            {
                Debug.Log("Max distance reached, destroying");
                Die();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("SideBorder"))
            {
                swapDir *= -1;
            }
        }
    }
}
