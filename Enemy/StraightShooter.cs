using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace ShipGame.Enemies
{
    public class StraightShooter : Enemy
    {
        

        protected override void Move()
        {
            movement.Move();

            if(active)
                weapons.ElementAt(0).Shoot();
            
               
            
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
                Die();
            } 
        }

    }
}

