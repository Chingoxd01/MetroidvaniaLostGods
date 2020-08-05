using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player_Movement : MonoBehaviour
{
    //Necesario para animaciones 2d
    private Rigidbody2D rg2d;
    private Animator myanimator; 

    //Variables del jugador
    public float speed = 2.0f;
    public float Xmovement;// = 1 [OR] -1 [OR] 0

    private bool Faceright = true;

    private void Start()
    {
        //Definicion de Objetos 2D del jugador
        rg2d = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
    
    }

    //Validacion de las fisicas
    private void Update()
    {
        //Si se puede mover el jugador a los lados (Instruccion)
        Xmovement = Input.GetAxis("Horizontal");
    }
    // Aplicacion de Fisicas
    private void FixedUpdate()
    {
        //Jugador moviendose a los lados (Aplicacion)
        rg2d.velocity = new Vector2(Xmovement * speed, rg2d.velocity.y); //Xmovement * Speed = "X" and rg2d.vel.y = "Y"
        Flip(Xmovement);
        myanimator.SetFloat("speed", Mathf.Abs(Xmovement));
    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && Faceright || horizontal > 0 && !Faceright) {
            //No importa la direccion anterior de la cara
            Faceright = !Faceright;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
