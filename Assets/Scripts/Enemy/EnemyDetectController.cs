using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectController : MonoBehaviour
{
    private bool detect = false;

   public void playerDetect()
   {
        if(detect == false)
        {
            Debug.Log("Player detect");
            detect = true;
        }
   }
}
