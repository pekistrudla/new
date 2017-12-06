using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace workshop02
{
    /*
    public class Voxel_Grid : MonoBehaviour
    {

        bool pause = false;

        // Use this for initialization
        void Start()
        {
            CreateTheStartingNeighborhood();

            CreateGrid();


        }

        // Update is called once per frame
        void Update()
        {
            // Calculate the CA state, save the new state, display the CA and increment time frame
            if (currentFrame < timeEnd)
            {
                if (pause == false)
                {
                    // Calculate the future state of the voxels
                    CalculateCA();

                    // Update the voxels that are printing
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < length; j++)
                        {
                            GameObject currentVoxel = voxelGrid[i, j, 0];
                            currentVoxel.GetComponent<Voxel>().UpdateVoxel();
                        }
                    }

                    // Save the CA state
                    SaveCA();

                    //Update 3d Densities
                    updateDensities3d();
                    // Increment the current frame count
                    currentFrame++;
                    Debug.Log("Current itteration: " + currentFrame);
                }



            }

            void CreateTheStartingNeighborhood()
            {
                if (k == 0)
                {
                    // Create a new state based on the input image
                    int currentVoxelState = (int)seedImage.GetPixel(i, j).grayscale;
                    voxel.SetState(currentVoxelState);
                }
                else
                {

                    // Set the state to death
                    currentVoxelObj.GetComponent<MeshRenderer>().enabled = false;
                    voxel.SetState(0);
                }

                // Save the current voxel in the voxelGrid array
                voxelGrid[i, j, k] = currentVoxelObj;
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
                            var currentVoxelObj = Instantiate(voxelPrefab, transform);
                        }
                    }
                }

                var voxel = currentVoxelObj.GetComponent<Voxel>();
                voxel.SetupVoxel(i, j, k, 1);
            }

            void StarterRule()
            {
                if (currentVoxelState = true)
                {
                    if (neighborsCount < 2)
                    {
                        grid[i, j].GetComponent<CA_Cube>().SetFutureState(0);
                        futureState = false;
                    }
                    if (neighborsCount == 2 || neighborsCount == 3)
                    {
                        grid[i, j].GetComponent<CA_Cube>().SetFutureState(1);
                        futureState = true;
                    }
                    if (neighborsCount > 3)
                    {
                        grid[i, j].GetComponent<CA_Cube>().SetFutureState(0);
                        futureState = 0;
                    }
                }

                // Rule 2: for cells that are dead
                if (currentVoxelState == false)
                {
                    if (neighborsCount == 3)
                    {
                        grid[i, j].GetComponent<CA_Cube>().SetFutureState(1);
                        futureState = true;
                    }
                }

                // Update how many are alive
                alive += futureState;
            }

            int CountNeighborsVN(int i, int j, int k)
            {
                int result = 0;
                if ()



                    return result;
            }

        }
    }*/
}