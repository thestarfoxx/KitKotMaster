 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{   public GameObject[] RoadPrefabs;        ///// Yol prefab listesi. Farklı tür yollar için kullanılabilir
    public float zSpawn=0;                  ///// Yolun geleceği nokta, her yol oluşturulduğunda artırılır
    public float RoadLength = 120;         ///// Yol uzunluğu, oyuncunun pozisyonuna göre yol oluşturup silmek için kullanılır
    public int numberofRoads = 3;           ///// Başlangıçta oluşturulacak yollar 
    public Transform playerTransform;       ///// Oyuncunun pozisyonu    
    private List<GameObject> activeRoads = new List<GameObject>();   ///// Oluşmuş yollar listesi. Her yol oluştuğunda bir önceki silinir.

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<numberofRoads;i++){
            if(i==0){SpawnRoad(0);}                                 /////// Oyun Başladığında  oluşturulan objeler için bir for döngüsü. Objeler kendi prefab listesinin içinden rastgele seçiliyor
            else{SpawnRoad(Random.Range(0,RoadPrefabs.Length));}
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z>zSpawn - 2*(RoadLength)){     /////// Oyuncu yeteri kadar ilerlediği zaman bir yol ve iki bina oluşuyor ve baştakiler siliniyor
            SpawnRoad(Random.Range(0,RoadPrefabs.Length));
            DeleteRoad();

        }
    }
    public void SpawnRoad(int RoadIndex){
        GameObject instantiatedtile = Instantiate(RoadPrefabs[RoadIndex],transform.forward*zSpawn,transform.rotation);  //// Bu fonksiyon objeyi oluşturuyor ve pozisyonunu    //// belirliyor, ondan sonra oluşmuş yola listeyi ekliyor
        activeRoads.Add(instantiatedtile);
        zSpawn += RoadLength;                                                                                           //// ve zSpawn'ı yol uzunluğuna göre increment ediyor                                
    }
    private void DeleteRoad(){
        Destroy(activeRoads[0]);                                                                                        //// Bu fonksiyon önceki yolu siliyor ve aktif yolu 0 index'ine alıyor
        activeRoads.RemoveAt(0);

    }

}
    