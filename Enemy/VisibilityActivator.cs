using ShipGame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityActivator : MonoBehaviour
{

    private void OnBecameVisible()
    {
        GetComponentInParent<Enemy>().Activate();
    }
}
