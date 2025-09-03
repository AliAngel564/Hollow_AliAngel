//Librerias - Funciones prestadas de otros scripts
using UnityEngine;


//Public - Da permiso de usar su información 
//Class - La forma de declararla
//movementPlayer - Nombre del Script
// : - Herencia, permite usar las funciones y variables de MonoBehaviour

/// <summary>
/// Ali 03-09-25
/// Movimiento de jugador
/// 
/// </summary>
public class movementPlayer : MonoBehaviour
{
    //Variables
    public float numero = 0f;
    private int vidaPersonaje = 0;
    public Transform transformPlayer;
    public Rigidbody2D rigidBody2DPlayer;
   

    /* */

    //Donde empieza el frame 1. Frame 2 dejó de llamarse
    void Start()
    {
        //Jala el rb del objeto
       rigidBody2DPlayer = GetComponent<Rigidbody2D>(); 
    }

    // Desde Frame 2 hasta que termine el juego
    //Loop que se llama todo el tiempo.
    //Funciona mejor o peor dependiente de la PC, no tiene la 

    
    void Update()
    {
        

        //movimiento izq
        if(Input.GetKeyDown(KeyCode.A)) 
        {
            print("vamos a la izquierda");
            transformPlayer.position += Vector3.left;
        }

        //mov. derecha
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("vamos a la derecha");
            transformPlayer.position += Vector3.right;
        }


    }

    //Tasa fija de Frames   
    private void FixedUpdate()
    {
        
    }
}
