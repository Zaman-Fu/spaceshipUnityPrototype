using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShipGame.Enemies
{

    public class Broadsider : Enemy
    {
        

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }
        protected override void Initialize()
        {
            base.Initialize();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }
        protected override void Move()
        {
            movement.Move(); 
            if(active)
            {
                Shoot();
            }
            
            

        }

        protected override void Shoot()
        {
            if (Vector2.Distance(target.position, weapons[1].transform.position)< Vector2.Distance(target.position, weapons[0].transform.position))
            {
                weapons.ElementAt(1).Shoot();
            }
            else
            {
                weapons.ElementAt(0).Shoot();
            }
        }

    }
}

