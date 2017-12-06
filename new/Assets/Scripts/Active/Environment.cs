using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace workshop02
{

    public class Environment : MonoBehaviour
    {
        bool pause = false;

        //placing the variables

        public Texture2D seedImage;

        public int timeEnd = 50;
        int currentFrame = 0;

        //GameObject voxel;

        int width;
        int height;
        int length;

        public GameObject voxelPrefab;
        GameObject[,,] voxelGrid;
        
        //spacing between voxels
        float spacing = 1.0f;

        //Layer densities
        int totalAliveCells = 0;
        float layerdensity = 0;
        float[] layerDensities;

        List<List<GameObject>> voxelsByDensity = new List<List<GameObject>>();
        bool haveSeparatedByDensity = false;
        int currentDensityToDisplay = 0;


        //Max 
        int maxAge;
        int maxDensity3dMo = 0;
        int maxDensity3dVN = 0;

        // >>>
        //Setupfor different GOL rules
        //GOLRule rule = new GOLRule;
        GOLRule rule1 = new GOLRule();
        GOLRule rule2 = new GOLRule();
        GOLRule rule3 = new GOLRule();
        GOLRule rule4 = new GOLRule();
        GOLRule rule5 = new GOLRule();
        GOLRule deathrule = new GOLRule();



        // Use this for initialization
        void Start()
        {
            width = seedImage.width;
            length = seedImage.height;
            height = timeEnd;


            //CreateTheStartingNeighborhood();

            CreateGrid();

            rule1.setupRule(2, 3, 3, 3);
            rule2.setupRule(2, 6, 4, 5);
            rule3.setupRule(3, 3, 4, 4);
            rule4.setupRule(5, 6, 4, 4);
            rule5.setupRule(5, 6, 6, 6);
            deathrule.setupRule(0, 0, 0, 0);

            layerDensities = new float[timeEnd];


        }

        // Update is called once per frame
        void Update()
        {


            //SET RULE BASED ON CONDITIONS HERE:
            //GOLRule currentRule = rule1;
            GOLRule currentRule = rule2;



            //CHANGE RULE BASED ON CONDITIONS HERE:
            //if (currentFrame > width/4 && currentFrame < width/2) currentRule = rule1;

            //if (currentFrame > width/3 && currentFrame < width/2) currentRule = rule2;

            if (currentFrame > width / 2 && currentFrame < 0.8 * width) currentRule = rule1;
            if (currentFrame > 0.8 * width) currentRule = rule3;

            //if (currentVoxelObj.GetComponent<Voxel>().GetAge() == 10) currentRule = rule2;

            if (Input.GetKeyDown(KeyCode.Keypad1)) currentRule = rule1;
            if (Input.GetKeyDown(KeyCode.Keypad2)) currentRule = rule2;
            if (Input.GetKeyDown(KeyCode.Keypad3)) currentRule = rule3;
            if (Input.GetKeyDown(KeyCode.Keypad4)) currentRule = rule4;



            // Spin the CA if spacebar is pressed (be careful, GPU instancing will be lost!)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (gameObject.GetComponent<ModelDisplay>() == null)
                {
                    gameObject.AddComponent<ModelDisplay>();
                }
                else
                {
                    Destroy(gameObject.GetComponent<ModelDisplay>());
                }
            }

            //toggle pause with "p" key
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (pause == false)
                {
                    pause = true;
                }
                else
                {
                    pause = false;
                }
            }




            currentFrame++;
        }

        void CreateGrid()
        {
            // Allocate space in memory for the array
            voxelGrid = new GameObject[width, length, height];
            
            // Populate the array with voxels from a base image
            for (int k = 1; k < height; k++)
            {
                for (int j = 0; j < length; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        //create the game object of the voxel
                        GameObject currentVoxelObj = Instantiate(voxelPrefab, transform);
                        var voxel = currentVoxelObj.GetComponent<Voxel>();
                    }
                }
            }

            //voxel.SetupVoxel(i, j, k, 1);
        }


    
       
  


    }
}