using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkinChanger : MonoBehaviour //Enemybehavior 
{
    public Enemybehavior Skin;
    public Material[] Materials;
    public static int currentMaterials;
    private Scene scene;
    // private GameObject Test;
    //public Renderer childColor;
    //public Material demagedMaterial;
    void Start()
    {
        if (scene.name == "Stage2")
        {

            //Skin für den Boss zurücksetzten           
            currentMaterials = 5;

            //childColor = GetComponentInChildren<MeshRenderer>();
            //GameObject Unterobjekt = transform.GetChild("Test").gameObject;
            // Test = GameObject.Find("Test");
            // Test<Renderer>().material = Materials[currentMaterials];
            //Test.renderer.material = Materials[currentMaterials];
            GetComponent<MeshRenderer>().material = Materials[currentMaterials];
            //gameObject.GetComponent<MeshRenderer>().material = demagedMaterial;
            //childColor.material = demagedMaterial;



        }
    }


    // Update is called once per frame
    void Update()
    {
        
        Skin = GameObject.Find("FinalBossLaser 2 1 1 1").GetComponent<Enemybehavior>();
        //==
        if (Skin.health < 1200)
        {
            currentMaterials %= Materials.Length;
            GetComponent<Renderer>().material = Materials[currentMaterials];
        }

        if (Skin.health < 1000)
        {
            currentMaterials++;
            currentMaterials %= Materials.Length;
            GetComponent<Renderer>().material = Materials[currentMaterials];
        }

        if (Skin.health < 800)
        {
            currentMaterials++;
            currentMaterials %= Materials.Length;
            GetComponent<Renderer>().material = Materials[currentMaterials];
        }

        if (Skin.health < 600)//(health < 600 && 400 > health)
        {
            currentMaterials++;
            currentMaterials %= Materials.Length;

            GetComponent<Renderer>().material = Materials[currentMaterials];
        }

        if (Skin.health < 400)
        {
            currentMaterials++;
            currentMaterials %= Materials.Length;
            GetComponent<Renderer>().material = Materials[currentMaterials];
        }

        if (Skin.health < 200)
        {
            currentMaterials++;
            currentMaterials %= Materials.Length;
            GetComponent<Renderer>().material = Materials[currentMaterials];
        }
        
    }
}