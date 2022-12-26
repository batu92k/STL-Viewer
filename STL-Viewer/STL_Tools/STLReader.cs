/**
  ******************************************************************************
  * @file    STLReader.cs
  * @author  Ali Batuhan KINDAN
  * @version V1.0.0
  * @date    03.07.2018
  * @brief   
  ******************************************************************************
  */
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Threading;

namespace STL_Tools
{
    public enum StlFileType { NONE, BINARY, ASCII }; // stl file type enumeration
    public class StlReader
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public StlReader()
        {
            // To fix dot vs comma in floating point numbers
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }


        /// <summary>
        /// This method reads any (ascii or binary) stl file and detect the file type
        /// automatically.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public StlData ReadAnyStlFile(string filePath, out bool result)
        {
            StlFileType stlFileType = GetFileType(filePath);
            StlData stlData;

            if (stlFileType == StlFileType.ASCII)
            {
                stlData = ReadAsciiStlFile(filePath, out result);
            }
            else if(stlFileType == StlFileType.BINARY)
            {
                stlData = ReadBinaryStlFile(filePath, out result);
            }
            else
            {
                result = false;
                stlData = null;
            }

            return stlData;
        }

        
        /// <summary>
        /// This function returns the min position of objects 
        /// bounding box by checking all triangle meshes
        /// </summary>
        /// <param name="meshList"></param>
        /// <returns></returns>
        private Vector3 GetMinMeshPosition(List<TriangleMesh> meshList)
        {
            Vector3 minVec = new Vector3();
            float[] minRefArray = new float[3];
            minRefArray[0] = meshList.Min(j => j.vert1.x);
            minRefArray[1] = meshList.Min(j => j.vert2.x);
            minRefArray[2] = meshList.Min(j => j.vert3.x);
            minVec.x = minRefArray.Min();
            minRefArray[0] = meshList.Min(j => j.vert1.y);
            minRefArray[1] = meshList.Min(j => j.vert2.y);
            minRefArray[2] = meshList.Min(j => j.vert3.y);
            minVec.y = minRefArray.Min();
            minRefArray[0] = meshList.Min(j => j.vert1.z);
            minRefArray[1] = meshList.Min(j => j.vert2.z);
            minRefArray[2] = meshList.Min(j => j.vert3.z);
            minVec.z = minRefArray.Min();
            return minVec;
        }

        /// <summary>
        /// This function returns the max position of objects 
        /// bounding box by checking all triangle meshes
        /// </summary>
        /// <param name="meshList"></param>
        /// <returns></returns>
        private Vector3 GetMaxMeshPosition(List<TriangleMesh> meshList)
        {
            Vector3 maxVec = new Vector3();
            float[] maxRefArray = new float[3];
            maxRefArray[0] = meshList.Max(j => j.vert1.x);
            maxRefArray[1] = meshList.Max(j => j.vert2.x);
            maxRefArray[2] = meshList.Max(j => j.vert3.x);
            maxVec.x = maxRefArray.Max();
            maxRefArray[0] = meshList.Max(j => j.vert1.y);
            maxRefArray[1] = meshList.Max(j => j.vert2.y);
            maxRefArray[2] = meshList.Max(j => j.vert3.y);
            maxVec.y = maxRefArray.Max();
            maxRefArray[0] = meshList.Max(j => j.vert1.z);
            maxRefArray[1] = meshList.Max(j => j.vert2.z);
            maxRefArray[2] = meshList.Max(j => j.vert3.z);
            maxVec.z = maxRefArray.Max();
            return maxVec;
        }


        /// <summary>
        /// This function checks the type of stl file binary or ascii, 
        /// function is assuming given file as proper *.stl file 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private StlFileType GetFileType(string filePath)
        {
            StlFileType stlFileType = StlFileType.NONE;

            /* check path is exist */
            if (File.Exists(filePath))
            {
                int lineCount = File.ReadLines(filePath).Count(); // number of lines in the file
                string firstLine = File.ReadLines(filePath).First();
                string endLines = File.ReadLines(filePath).Skip(lineCount - 1).Take(1).First() +
                                  File.ReadLines(filePath).Skip(lineCount - 2).Take(1).First();

                /* check the file is ascii or not */
                if((firstLine.IndexOf("solid") != -1) &
                    (endLines.IndexOf("endsolid") != -1))
                {
                    stlFileType = StlFileType.ASCII;
                }
                else
                {
                    stlFileType = StlFileType.BINARY;
                }

            }
            else
            {
                stlFileType = StlFileType.NONE;
            }


            return stlFileType;
        }


        /// <summary>
        /// Reads given binary stl file and returns the stl data container class.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public StlData ReadBinaryStlFile(string filePath, out bool result)
        {
            StlData binaryStlData = new StlData();
            byte[] fileBytes = File.ReadAllBytes(filePath);

            /* 80 bytes title + 4 byte num of triangles + 50 bytes (1 of triangular mesh)  */
            if (fileBytes.Length <= 120)
            {
                result = false;
                binaryStlData = null;
                return binaryStlData;
            }

            int numOfMesh = System.BitConverter.ToInt32(
                new byte[] { fileBytes[80], fileBytes[81], fileBytes[82], fileBytes[83] }, 0);

            int byteIndex = 84;

            for (int i = 0; i < numOfMesh; i++)
            {
                TriangleMesh newMesh = new TriangleMesh();

                /* this try-catch block will be reviewed */
                try
                {
                    /* face normal */
                    newMesh.normal1.x = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;
                    newMesh.normal1.y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;
                    newMesh.normal1.z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;

                    /* normals of vertex 2 and 3 equals to vertex 1's normals */
                    newMesh.normal2 = newMesh.normal1;
                    newMesh.normal3 = newMesh.normal1;

                    /* vertex 1 */
                    newMesh.vert1.x = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;
                    newMesh.vert1.y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;
                    newMesh.vert1.z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;

                    /* vertex 2 */
                    newMesh.vert2.x = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;
                    newMesh.vert2.y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;
                    newMesh.vert2.z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;

                    /* vertex 3 */
                    newMesh.vert3.x = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;
                    newMesh.vert3.y = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;
                    newMesh.vert3.z = System.BitConverter.ToSingle(new byte[] { fileBytes[byteIndex], fileBytes[byteIndex + 1], fileBytes[byteIndex + 2], fileBytes[byteIndex + 3] }, 0);
                    byteIndex += 4;

                    byteIndex += 2; // Attribute byte count
                }
                catch
                {
                    result = false;
                    binaryStlData = null;
                    return binaryStlData;
                }

                binaryStlData.meshList.Add(newMesh);
            }

            // TODO: review this, methods cycling through the whole list again and again!
            binaryStlData.minVec = GetMinMeshPosition(binaryStlData.meshList);
            binaryStlData.maxVec = GetMaxMeshPosition(binaryStlData.meshList);
            binaryStlData.fileType = StlFileType.BINARY;

            result = true;
            return binaryStlData;
        }


        /// <summary>
        /// Reads given ascii stl file and returns the stl data container class.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public StlData ReadAsciiStlFile(string filePath, out bool result)
        {
            StlData asciiStlData = new StlData();
            StreamReader txtReader = new StreamReader(filePath);
            
            while (!txtReader.EndOfStream)
            {
                string line = txtReader.ReadLine().Trim(); /* delete whitespace in front and tail of the string */
                string[] lineData = line.Split(' ');

                if (lineData[0] == "solid")
                {
                    while (lineData[0] != "endsolid")
                    {
                        line = txtReader.ReadLine().Trim(); // facetnormal
                        lineData = line.Split(' ');

                        if (lineData[0] == "endsolid") // check if we reach at the end of file
                        {
                            break;
                        }

                        TriangleMesh newMesh = new TriangleMesh(); // define new mesh object

                        /* this try-catch block will be reviewed */
                        try
                        {
                            // FaceNormal 
                            newMesh.normal1.x = float.Parse(lineData[2]);
                            newMesh.normal1.y = float.Parse(lineData[3]);
                            newMesh.normal1.z = float.Parse(lineData[4]);

                            /* normals of vertex 2 and 3 equals to vertex 1's normals */
                            newMesh.normal2 = newMesh.normal1;
                            newMesh.normal3 = newMesh.normal1;

                            //----------------------------------------------------------------------
                            line = txtReader.ReadLine(); // Just skip the OuterLoop line
                            //----------------------------------------------------------------------

                            // Vertex1
                            line = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (line.IndexOf("  ") != -1) line = line.Replace("  ", " ");
                            lineData = line.Split(' ');

                            newMesh.vert1.x = float.Parse(lineData[1]); // x1
                            newMesh.vert1.y = float.Parse(lineData[2]); // y1
                            newMesh.vert1.z = float.Parse(lineData[3]); // z1

                            // Vertex2
                            line = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (line.IndexOf("  ") != -1) line = line.Replace("  ", " ");
                            lineData = line.Split(' ');

                            newMesh.vert2.x = float.Parse(lineData[1]); // x2
                            newMesh.vert2.y = float.Parse(lineData[2]); // y2
                            newMesh.vert2.z = float.Parse(lineData[3]); // z2

                            // Vertex3
                            line = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (line.IndexOf("  ") != -1) line = line.Replace("  ", " ");
                            lineData = line.Split(' ');

                            newMesh.vert3.x = float.Parse(lineData[1]); // x3
                            newMesh.vert3.y = float.Parse(lineData[2]); // y3
                            newMesh.vert3.z = float.Parse(lineData[3]); // z3
                        }
                        catch
                        {
                            result = false;
                            asciiStlData = null;
                            return asciiStlData;
                        }

                        //----------------------------------------------------------------------
                        line = txtReader.ReadLine(); // Just skip the endloop
                        //----------------------------------------------------------------------
                        line = txtReader.ReadLine(); // Just skip the endfacet

                        asciiStlData.meshList.Add(newMesh); // add mesh to meshList

                    } // while linedata[0]
                } // if solid
            } // while !endofstream

            // TODO: review this, methods cycling through the whole list again and again!
            asciiStlData.minVec = GetMinMeshPosition(asciiStlData.meshList);
            asciiStlData.maxVec = GetMaxMeshPosition(asciiStlData.meshList);
            asciiStlData.fileType = StlFileType.ASCII;

            result = true;
            return asciiStlData;
        }
    }
}
