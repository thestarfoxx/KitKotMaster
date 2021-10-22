using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Text progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void changeProgress(float amount)
    {
        progress.text += amount;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
