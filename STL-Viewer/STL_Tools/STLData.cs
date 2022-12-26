/**
  ******************************************************************************
  * @file    STLData.cs
  * @author  Ali Batuhan KINDAN
  * @date    26.12.2022
  * @brief   
  ******************************************************************************
  */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL_Tools
{
    public class STLData
    {
        public List<TriangleMesh> meshList;
        public Vector3 maxVec = new Vector3(); // max position of model
        public Vector3 minVec = new Vector3(); // min position of model
        public int numberOfTriangles;
        StlFileType fileType = StlFileType.NONE;
        string filePath;

        /// <summary>
        /// Default constructor of STLData class.
        /// </summary>
        public STLData()
        {
            meshList = new List<TriangleMesh>();
        }

        /// <summary>
        /// Constructor of STLdata class with pre allocation.
        /// </summary>
        /// <param name="num_of_mesh"> 
        /// number of triangles for pre-allocation 
        /// </param>
        public STLData(int num_of_mesh)
        {
            meshList = new List<TriangleMesh>(num_of_mesh);
        }
    }
}
