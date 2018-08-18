using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aleatorium : MonoBehaviour {

    public GameObject[] siege;
    public GameObject[] perso;

    float num;

    /* 
     * AMELIORATION POSSIBLE :
     * 

    faire un rangement 
    -tag par fauteuil
    -tag par enfants
    
    tous les fauteuils et enfant en child de ce script

        faire une boucle sur les enfant en cherchant le tag et les placer dans le array ...
    */

    void Start () {
        num = Random.Range(1,siege.Length);
        Debug.Log(num);
        int siegenum = (int)num;

        siege[siegenum].tag = "SiegeVide" ;
        perso[siegenum].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
