/**
  ******************************************************************************
  * @file    STLData.cs
  * @author  Ali Batuhan KINDAN
  * @date    26.12.2022
  * @brief   
  ******************************************************************************
  */
using System.Collections.Generic;

namespace STL_Tools
{
    public class StlData
    {
        public List<TriangleMesh> meshList;
        public Vector3 maxVec = new Vector3(); // max position of model
        public Vector3 minVec = new Vector3(); // min position of model
        public StlFileType fileType = StlFileType.NONE;

        /// <summary>
        /// Default constructor of STLData class.
        /// </summary>
        public StlData()
        {
            meshList = new List<TriangleMesh>();
        }
    }
}
