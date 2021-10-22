using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{    //Bu değişkenler oyuncu objesinin x y z düzlemlerinde hareket edeceği hız faktörüdür. Aşağıda verdiğimiz x,y,z değerleriyle çarpılarak kullanılır   
     [SerializeField] float xSpeedFactor = 10f;  
     [SerializeField] float ySpeedFactor = 10f;
     [SerializeField] float zSpeedFactor = 10f;
 

    // Start is called before the first frame update
    void Start()
    {
        
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
        clampedPosition.x = Mathf.Clamp(clampedPosition.x,-5f,5f);                              ///// Mathf.Clamp ile hareketi platformun üzerine kısıtlayabiliriz        
        transform.position = clampedPosition;                                    
    }
}
