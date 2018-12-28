using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoTeste : MonoBehaviour {

    public float vida;

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D ou)
    {
        if(ou.tag == "Player")
        {
            Dano(Player.Instan.dano);
        }
    }

    void Dano(float d)
    {
        vida -= d;
        if (vida <= 0) Destroy(gameObject);
    }

}
