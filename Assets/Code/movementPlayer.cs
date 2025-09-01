//Librerias - Funciones prestadas de otros scripts
using UnityEngine;


//Public - Da permiso de usar su información 
    //Class - La forma de declararla
        //movementPlayer - Nombre del Script
            // : - Herencia, permite usar las funciones y variables de MonoBehaviour
public class movementPlayer : MonoBehaviour
{
    //Variables
    public float numero = 0f;
    private int vidaPersonaje = 0;
   

    /* */

    //Donde empieza el frame 1. Frame 2 dejó de llamarse
    void Start()
    {
        print("miau start inicia aqui miau");
    }

    // Desde Frame 2 hasta que termine el juego
    //Loop que se llama todo el tiempo.
    //Funciona mejor o peor dependiente de la PC, no tiene la 
    void Update()
    {
        print("miau update inicia aqui miau");

        if( vidaPersonaje == 0) 
        {
            print("TE MORITES");
        }
    }

    //Tasa fija de Frames   
    private void FixedUpdate()
    {
        
    }
}
