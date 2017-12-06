using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace workshop02
{

    public class Voxel : MonoBehaviour
    {
        /* potential variables


        */



        public Mesh[] MeshTable;
        private MeshFilter _filter;

        private void Awake()
        {
            _filter = GetComponent<MeshFilter>();
            Debug.Assert(_filter != null);
        }

        //VARIABLES
        //elementary
        private bool _state;
        private bool _futureState;
        private int _age = 0;
        // material property block for setting material properties with renderer
        private MaterialPropertyBlock _propblock;
        private new MeshRenderer _renderer;

        // >>>
        int type;
        public Vector3 address;

        //density 
        private int _density3dMO = 0;
        private int _density3dVN = 0;

        //neighbors
        private Voxel[] _neighbors3dMO = new Voxel[26];

        private Voxel[] _neighbors3dVN = new Voxel[6];

        private Voxel _voxelAbove;
        private Voxel _voxelBelow;
        private Voxel _voxelRight;
        private Voxel _voxelLeft;
        private Voxel _voxelFront;
        private Voxel _voxelBack;

        //Functions

        public void SetupVoxel(int i, int j, int k, int type)
        {
            //reference to time end
            // _propertyblock = new MaterialPropertyBlock();
            _renderer = gameObject.GetComponent<MeshRenderer>();
            _renderer.enabled = false;
            address = new Vector3(i, j, k);
            _filter.mesh = MeshTable[type];

        }

        public void UpdateVoxel()
        {
            _state = _futureState;
            if (_state == true)
            {
                _age++;
            }
            else
            {
                _age = 0;
            }

        }

        //Setters and getters - allowing to access and set private variables
        // >>> CHECK!!!
        public void SetState(bool state)
        {
            _state = state;
        }

        public void SetAge(int age)
        {
            _age = age;
        }

        public bool GetState()
        {
            return _state;
        }

        public int GetAge()
        {
            return _age;
        }

        //density
        public void SetDensity3dMO(int density3dMO)
        {
            _density3dMO = density3dMO;
        }

        public int GetDensity3dMO()
        {
            return _density3dMO;
        }

        public void SetDensity3dVN(int density3dVN)
        {
            _density3dVN = density3dVN;
        }

        public int GetDensity3dVN()
        {
            return _density3dVN;
        }

        //Voxel neighborhood getters/setters

        //Moores neighbors - 26 per voxel
        public void SetNeighbors3dMO(Voxel[] setNeighbors3dMO)
        {
            _neighbors3dMO = setNeighbors3dMO;
        }

        public Voxel[] GetNeighbors3dMO()
        {
            return _neighbors3dMO;
        }


        //Von Neumann neighbors - 6 per voxel
        public void SetNeighbors3dVN(Voxel[] setNeighbors3dVN)
        {
            _neighbors3dVN = setNeighbors3dVN;
        }

        public Voxel[] GetNeighbors3dVN()
        {
            return _neighbors3dVN;
        }

        //voxel below this
        public void SetVoxelBelow(Voxel voxelBelow)
        {
            _voxelBelow = voxelBelow;
        }

        public Voxel GetVoxelBelow()
        {
            return _voxelBelow;
        }

        //voxel right of this
        public void SetVoxelRight(Voxel voxelRight)
        {
            _voxelRight = voxelRight;
        }

        public Voxel GetVoxelRight()
        {
            return _voxelRight;
        }

        //voxel left of this
        public void SetVoxelLeft(Voxel voxelLeft)
        {
            _voxelLeft = voxelLeft;
        }

        public Voxel GetVoxelLeft()
        {
            return _voxelLeft;
        }

        //voxel in front of this
        public void SetVoxelFront(Voxel voxelFront)
        {
            _voxelFront = voxelFront;
        }

        public Voxel GetVoxelFront()
        {
            return _voxelFront;
        }

        //voxel in back of this
        public void SetVoxelBack(Voxel voxelBack)
        {
            _voxelBack = voxelBack;
        }

        public Voxel GetVoxelBack()
        {
            return _voxelBack;
        }

        public void VoxelDisplay()
        {
            if (_state == true)
            {
                // Set Color
                Color col = new Color(1, 0, 0, 1);
                _propblock.SetColor("_Color", col);
                // Updated the mesh renderer color
                _renderer.enabled = true;
                _renderer.SetPropertyBlock(_propblock);
            }

            if (_state == false)
            {
                _renderer.enabled = false;
            }
        }
        /*
         public void VoxelDisplay(int _r, int _g, int _b)
        {
            if (_state == true)
            {
                // Set Color
                Color col = new Color(_r, _g, _b, 1);
                _propblock.SetColor("_Color", col);
                // Updated the mesh renderer color
                _renderer.enabled = true;
                _renderer.SetPropertyBlock(_propblock);
            }

            if (state == false)
            {
                _renderer.enabled = false;
            }
        }

        /// <summary>
        /// Create Color Gradient Between 2 Colors by Age
        /// </summary>
        /// <param name="_maxAge"></param>
        public void VoxelDisplayAge(int _maxAge)
        {

            if (age % 2 == 0)
            {
                MeshFilter setMesh = gameObject.GetComponent<MeshFilter>();
                setMesh = type1Mesh;
            }


            if (state == true)
            {
                // Remap the age value relative to maxage to range of 0,1
                float mappedvalue = Remap(age, 0, _maxAge, 0.0f, 1.0f);
                //two colors to interpolate between
                Color color1 = new Color(1, 1, 1, 1);
                Color color2 = new Color(1, 1, 0, 1);
                //interpolate color from mapped value
                Color mappedcolor = Color.Lerp(color1, color2, mappedvalue);
                _propblock.SetColor("_Color", mappedcolor);
                // Updated the mesh renderer color
                _renderer.enabled = true;
                _renderer.SetPropertyBlock(_propblock);
            }
            if (state == false)
            {
                _renderer.enabled = false;
            }
            */
    }



}


