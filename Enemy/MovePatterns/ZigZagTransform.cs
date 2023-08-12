using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipGame.Enemies.Movement
{
    public class ZigZagTransform : MovementPattern
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
                return;
            }

            if (transform.position.y > 10)
            {
                transform.position = transform.position + new Vector3(0, speed * Time.deltaTime * -1, 0);
                return;
            }



            if (transform.position.x > xRightLimit)
            {
                dir = -1;
            }
            if (transform.position.x < xLeftLimit)
            {
                dir = 1;
            }

            transform.position = transform.position + new Vector3(speed*dir*Time.deltaTime, 0, 0);
        }
    }
}