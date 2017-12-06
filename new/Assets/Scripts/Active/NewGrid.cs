using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrid : MonoBehaviour
{
    public Texture2D seedImage;

    bool pause = false;

    public int timeEnd = 50;
    int currentFrame = 0;

    //GameObject voxel;
    public GameObject voxelPrefab;

    int width;
    int height;
    int length;

    int addition = 1;

    float spacing = 1;

    // Array for storing voxels
    GameObject[,,] voxelGrid;

    // Setup Different Game of Life Rules
    // GOLRule deathrule = new GOLRule();
    GOLRule rule1 = new GOLRule();
    GOLRule rule2 = new GOLRule();
    GOLRule rule3 = new GOLRule();


    // Use this for initialization
    void Start()
    {
        width = seedImage.width;
        length = seedImage.height;
        height = timeEnd;

        //Setup GOL Rules
        rule1.setupRule(2, 3, 3, 3);
        rule2.setupRule(2, 6, 4, 5);
        rule3.setupRule(3, 6, 3, 6);

        CreateVoxelGrid();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentFrame < timeEnd-2)
        {
            if(pause==false)
            {
                for (int k=1; k<height; k++)
                {
                    CalculateCA(k - 1, k);

                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            GameObject currentVoxel = voxelGrid[i, j, k-1];
                            currentVoxel.GetComponent<Voxel>().UpdateVoxel();
                        }

                    }
                }

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        for (int k = 1; k < height; k++)
                        {
                            voxelGrid[i, j, k].GetComponent<Voxel>().VoxelDisplay();
                            //voxelGrid[i, j, k].GetComponent<Voxel>().VoxelDisplayAge(maxAge);
                            //voxelGrid[i, j, k].GetComponent<Voxel>().VoxelDisplayDensity3dMO(maxDensity3dMO);
                            //voxelGrid[i, j, k].GetComponent<Voxel>().VoxelDisplayDensity3dJS(maxDensity3dJS);
                        }
                    }
                }
            }
        }
        
    
    }

    void CreateVoxelGrid()
    {
        voxelGrid = new GameObject[width, length, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                for (int k = 0; k < height; k++)
                {
                    Vector3 currentVoxelPos = new Vector3(i * spacing, k * spacing, j * spacing);                     Quaternion currentVoxelRot = Quaternion.identity;
                    GameObject currentVoxelObj = Instantiate(voxelPrefab, currentVoxelPos, currentVoxelRot);
                    currentVoxelObj.GetComponent<Voxel>().SetupVoxel(i, j, k, 1);
                    float t = seedImage.GetPixel(i, j).grayscale;                      if (k == 0)
                    {
                        // black - > alive
                        if (t > 0.5f)
                        { currentVoxelObj.GetComponent<Voxel>().SetState(false);}                         else
                        { currentVoxelObj.GetComponent<Voxel>().SetState(true);}

                        currentVoxelObj.GetComponent<MeshRenderer>().enabled = currentVoxelObj.GetComponent<Voxel>().GetState();
                    }                      /*                     if (k > 0)
                    {
                        CalculateCA(k-1, k);
                    }
                    */
                                     
                    

                    voxelGrid[i, j, k] = currentVoxelObj;
                    currentVoxelObj.transform.parent = gameObject.transform;
                    
                }
            }
        }

    }

    void CalculateCA(int now, int future)
    {
        // Go over all the voxels stored in the voxels array
        for (int i = 1; i < width - 1; i++)
        {
            for (int j = 1; j < length - 1; j++)
            {
                //for (int k = 1; k < height; k++)
                {
                    
                    GameObject currentVoxelObj = voxelGrid[i, j, now];
                    bool currentVoxelState = currentVoxelObj.GetComponent<Voxel>().GetState();
                    int aliveNeighbours = 0;

                    // Calculate how many alive neighbours are around the current voxel
                    for (int x = -1; x < 2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            GameObject currentNeigbour = voxelGrid[i + x, j + y, now];
                            bool currentNeigbourState = currentNeigbour.GetComponent<Voxel>().GetState();

                            aliveNeighbours += BoolToCount(currentNeigbourState);
                            // >>> Counting until 9
                            //Debug.Log("alive neighbours : " + aliveNeighbours);
                        }
                    }

                    aliveNeighbours -= BoolToCount(currentVoxelState);

                    //CHANGE RULE BASED ON CONDITIONS HERE:
                    //GOLRule currentRule = rule1;
                    GOLRule currentRule = rule2;
                    //CHANGE RULE BASED ON CONDITIONS HERE:
                    //..........

                    if (currentFrame > width / 4 && currentFrame < width / 2) currentRule = rule1;
                    //if (currentFrame > width/3 && currentFrame < width/2) currentRule = rule2;
                    if (currentFrame > width / 2 && currentFrame < 0.75 * width) currentRule = rule2;
                    if (currentFrame > 0.8 * width) currentRule = rule3;

                    //get the instructions
                    int inst0 = currentRule.getInstruction(0);
                    int inst1 = currentRule.getInstruction(1);
                    int inst2 = currentRule.getInstruction(2);
                    int inst3 = currentRule.getInstruction(3);

                    // Rule Set 1: for voxels that are alive
                    if (currentVoxelState == true)
                    {
                        // If there are less than two neighbours I am going to die
                        if (aliveNeighbours < inst0)
                        {
                            currentVoxelObj.GetComponent<Voxel>().SetFutureState(false);
                        }
                        // If there are two or three neighbours alive I am going to stay alive
                        if (aliveNeighbours >= inst0 && aliveNeighbours <= inst1)
                        {
                            currentVoxelObj.GetComponent<Voxel>().SetFutureState(true);
                        }
                        // If there are more than three neighbours I am going to die
                        if (aliveNeighbours > inst1)
                        {
                            currentVoxelObj.GetComponent<Voxel>().SetFutureState(false);
                        }
                    }
                    // Rule Set 2: for voxels that are death
                    if (currentVoxelState == false)
                    {
                        // If there are exactly three alive neighbours I will become alive
                        if (aliveNeighbours >= inst2 && aliveNeighbours <= inst3)
                        {
                            currentVoxelObj.GetComponent<Voxel>().SetFutureState(true);
                        }
                    }

                    if (currentVoxelObj.GetComponent<Voxel>().GetFutureState() == true)
                    {
                        Vector3 futureVoxelPos = new Vector3(i * spacing, future * spacing, j * spacing);
                        Quaternion futureVoxelRot = Quaternion.identity;
                        GameObject futureVoxelObj = Instantiate(voxelPrefab, futureVoxelPos, futureVoxelRot);
                    }
                    currentVoxelObj.GetComponent<MeshRenderer>().enabled = currentVoxelObj.GetComponent<Voxel>().GetState();
                }
            }

        }
    }
    

    public int BoolToCount(bool stateOf)
    {
        if (stateOf == true) addition = 1;
        else addition = 0;

        return addition;
    }

}