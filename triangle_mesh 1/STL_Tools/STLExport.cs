/**
  ******************************************************************************
  * @file    STLExport.cs
  * @author  Ali Batuhan KINDAN
  * @version V1.0.0
  * @date    03.07.2018
  * @brief   
  ******************************************************************************
  */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;

namespace STL_Tools
{

    public class STLExport
    {

        /**
        * @brief  This function creates a vertice array for OpenGL vertex array object from gşven triangular mesh array
        * @param  meshArray
        * @retval vertices
        */
        public float[] Get_Mesh_Vertices(TriangleMesh[] meshArray)
        {
            List<float> vertices = new List<float>();

            int i = 0;

            for (i = 0; i < meshArray.Length; i++)
            {
                /* vertex 1 */
                vertices.Add(meshArray[i].vert1.x);
                vertices.Add(meshArray[i].vert1.y);
                vertices.Add(meshArray[i].vert1.z);
                /* vertex 2 */
                vertices.Add(meshArray[i].vert2.x);
                vertices.Add(meshArray[i].vert2.y);
                vertices.Add(meshArray[i].vert2.z);
                /* vertex 3 */
                vertices.Add(meshArray[i].vert3.x);
                vertices.Add(meshArray[i].vert3.y);
                vertices.Add(meshArray[i].vert3.z);
            }

                return vertices.ToArray();
        }


        /**
        * @brief  This function creates a normal array for OpenGL vertex array object from given triangular mesh array
        * @param  meshArray
        * @retval normals
        */
        public float[] Get_Mesh_Normals(TriangleMesh[] meshArray)
        {
            List<float> normals = new List<float>();

            int i = 0;

            for (i = 0; i < meshArray.Length; i++)
            {
                /* vertex 1 */
                normals.Add(meshArray[i].normal.x);
                normals.Add(meshArray[i].normal.y);
                normals.Add(meshArray[i].normal.z);
            }

            return normals.ToArray();
        }


    }

}
