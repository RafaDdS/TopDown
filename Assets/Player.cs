using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instan;

    public float acel, maxVel, ajuste, dano;
    public Transform RegAt;

    int Dir = -1;
    bool Attacking;
    Animator anim;
    Rigidbody2D rb;

    void Awake()
    {
        if (Instan == null) Instan = this;
        else Destroy(gameObject);

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Movimentação
        int x = 0, y = 0;

        if (Input.GetKey(KeyCode.W)) y++;
        if (Input.GetKey(KeyCode.A)) x--;
        if (Input.GetKey(KeyCode.S)) y--;
        if (Input.GetKey(KeyCode.D)) x++;


        var vec = new Vector2(x, y);

        if (rb.velocity.magnitude < maxVel) rb.velocity += vec * acel;

        // Animação Movimentação

        if (x == 1 && y == 0) anim.SetInteger("Dir", 0);
        else if (x == 0 && y == 1) anim.SetInteger("Dir", 1);
        else if (x == -1 && y == 0) anim.SetInteger("Dir", 2);
        else if (x == 0 && y == -1) anim.SetInteger("Dir", 3);
        else if (rb.velocity.magnitude > 0.01f) anim.SetInteger("Dir", Dir);
        else anim.SetInteger("Dir", -1);

        Dir = anim.GetInteger("Dir");

        // Ataque

        if (Input.GetKeyDown(KeyCode.Return) && !Attacking) Ataque();
        else if (!Attacking)
        {
            RegAt.gameObject.SetActive(false);
            anim.SetBool("Atack", false);
        }

        if(rb.velocity.magnitude > 0.1f) RegAt.localPosition = rb.velocity.normalized * ajuste;



    }

    void Ataque()
    {
        Attacking = true;
        RegAt.gameObject.SetActive(true);
        anim.SetBool("Atack", true);
        Invoke("FimAtaque", 0.45f);
    }

    void FimAtaque()
    {
        Attacking = false;
    }

    
}
