using FernandoOleaDev.FyreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("First object to be Ignited")] 
    [SerializeField] private GameObject classA;
    [SerializeField] private GameObject classB;
    [SerializeField] private GameObject classC;
    [SerializeField] private GameObject classD;
    private GameObject[] classFire;

    void Start()
    {
        classFire = new GameObject[4];
        classFire[0] = classA;
        classFire[1] = classB;
        classFire[2] = classC;
        classFire[3] = classD;
        
        int i = Random.Range(0, 3);
        Debug.Log(i);
        classFire[i].GetComponent<BurnableObject>().FirstIgnition();

        

    }

}
