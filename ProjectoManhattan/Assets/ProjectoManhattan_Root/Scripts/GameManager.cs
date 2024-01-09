using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Inicio del Singleton
    private static GameManager instance; //Variable que almacena la info del GameManager (Base de Datos)
    public static GameManager Instance    //Llave de la base de datos
    {
        get
        {
            if (instance == null) //Si no hay Game manager
            {
                Debug.Log("Game Manager is null");
            }
            return instance;
        }

    }
    //Fin de la declaración de Singleton

    //Se declaran todas los datos de la base de datos
    //Todas las variables han de ser PÚBLICAS
    public int points;
    public int winPoints;

    private void Awake()
    {
        instance = this; //Decirle a la variable base de datos que tienes ESTOS DATOS
        DontDestroyOnLoad(this);
    }

    //Se pueden declarar acciones públicas que pueden ser llamadas por cualquier objeto
    public void PointsUp(int pointsToAdd)
    {

        points += pointsToAdd;
    }

    public void PointsDown(int pointsToSubtract)
    {

        points -= pointsToSubtract;
    } 

}
