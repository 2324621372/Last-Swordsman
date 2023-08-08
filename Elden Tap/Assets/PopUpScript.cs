using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpScript : MonoBehaviour
{
   public void CreateText(Transform transform, float damage)
   {
    Instantiate(this.gameObject, transform.position, Quaternion.identity);
    GetComponent<TextMeshPro>().text = damage.ToString();
   }

   void Start()
   {
     Destroy(this.gameObject, 0.5f);
   }

   private void Update()
   {
      transform.position += new Vector3(0,0.02f);
   }


}
