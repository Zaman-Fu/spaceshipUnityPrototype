using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ShipGame.Enemies
{
    public class FrigateBoss : Enemy
    {
        protected override void Initialize()
        {
            base.Initialize();
            //Set up healthbar
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
        }


        protected override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}

