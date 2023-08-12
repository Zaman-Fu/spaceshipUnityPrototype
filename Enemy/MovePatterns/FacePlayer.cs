using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ShipGame.Enemies.Movement

{
    public class FacePlayer : MovementPattern
    {
        public override void Move()
        {
            try
            {
                var direction = (enemy.GetTarget().position - transform.position).normalized;
                transform.up = direction;
            }
            catch (MissingReferenceException e)
            {
                Debug.LogWarning(e.ToString());
            }
            
        }

        // Start is called before the first frame update
        void Start()
        {
            enemy= gameObject.GetComponent<Enemy>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

