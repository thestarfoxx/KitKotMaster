using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour

{    //Bu değişkenler oyuncu objesinin x y z düzlemlerinde hareket edeceği hız faktörüdür. Aşağıda verdiğimiz x,y,z değerleriyle çarpılarak kullanılır   
    [SerializeField] float xSpeedFactor = 10f;  
    [SerializeField] float ySpeedFactor = 10f;
    [SerializeField] float zSpeedFactor = 10f;
    [SerializeField] float progress = 0f;

    [SerializeField] GameObject heart;
    [SerializeField] GameObject dislike;
    GameObject objectToDestroy;
    public Text likesText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == heart.tag)
        {
            Debug.Log("heart");
            progress += 1;
            objectToDestroy = other.gameObject;


        }
        if (other.tag == dislike.tag)
        {
            Debug.Log("dislike");
            progress -= 1;
            objectToDestroy = other.gameObject;
            //Destroy(other.gameObject);
        }
        likesText.text = progress.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == heart.tag || other.tag == dislike.tag)
        {
            //Destroy(other.gameObject);
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        likesText.text = "0";

    }

    // Update is called once per frame
    void Update()
    {    
        float xValueRaw = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeedFactor ;
        float xValue    = xValueRaw;
        
        float yValueRaw = 0;                                                                    ///// X düzleminde input alarak hareket ediyoruz. Time.deltaTime fonksiyonu
        float yValue    = yValueRaw;                                                            ///// framerate independent olması için kullanılıyor. Speed Factor değişkenleri
                                                                                                ///// hızı ayarlamak için

        float zValueRaw = 1f;                                                                   ///// Z düzleminde standart bir hareket hızıyla input almadan dümdüz ilerleniyor
        float zValue    =  zValueRaw * Time.deltaTime * zSpeedFactor;                           ///// Bu değişken zaman geçtikçe artırılabilir    

        
        
        
        
        transform.Translate(xValue,yValue,zValue) ;                                             ///// Hareket etmesi için gereken fonksiyon
        
        
                                                
        Vector3 clampedPosition = transform.position; 
        clampedPosition.x = Mathf.Clamp(clampedPosition.x,-4.2f,4.2f);                              ///// Mathf.Clamp ile hareketi platformun üzerine kısıtlayabiliriz        
        transform.position = clampedPosition;    
        
        if(objectToDestroy)
            Destroy(objectToDestroy.gameObject);

    }
}
