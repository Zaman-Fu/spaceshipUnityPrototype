using ShipGame.Enemies.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFlight : MovementPattern
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
        rb.velocity = Vector3.SmoothDamp(rb.velocity, speed * transform.up, ref m_velocity, m_MovementSmoothing);
    }
}
