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

    public class STLReader
    {

        public string path; // file path
        private enum FileType { NONE, BINARY, ASCII }; // stl file type enumeration
        private bool processError;

        /**
        * @brief  Class instance constructor
        * @param  none
        * @retval none
        */
        public STLReader(string filePath = "")
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            path = filePath;
            processError = false;
        }


        /**
        * @brief  This function returns the process error value if its true there is an error on process
        * @param  none
        * @retval none
        */
        public bool Get_Process_Error()
        {
            return processError;
        }


        /**
        * @brief  *.stl file main read function
        * @param  none
        * @retval meshList
        */
        public TriangleMesh[] ReadFile()
        {
            TriangleMesh[] meshList;

            FileType stlFileType = GetFileType(path);
           
            if(stlFileType == FileType.ASCII)
            {
                meshList = ReadASCIIFile(path);
            }
            else if(stlFileType == FileType.BINARY)
            {
                meshList = ReadBinaryFile(path);
            }
            else
            {
                meshList = null;
            }

            return meshList;
        }

        /**
        * @brief  This function returns the min position of objects bounding box by checking
        *         all triangle meshes
        * @param  meshArray
        * @retval Vector3
        */
        public Vector3 GetMinMeshPosition(TriangleMesh[] meshArray)
        {
            Vector3 minVec = new Vector3();
            float[] minRefArray = new float[3];
            minRefArray[0] = meshArray.Min(j => j.vert1.x);
            minRefArray[1] = meshArray.Min(j => j.vert2.x);
            minRefArray[2] = meshArray.Min(j => j.vert3.x);
            minVec.x = minRefArray.Min();
            minRefArray[0] = meshArray.Min(j => j.vert1.y);
            minRefArray[1] = meshArray.Min(j => j.vert2.y);
            minRefArray[2] = meshArray.Min(j => j.vert3.y);
            minVec.y = minRefArray.Min();
            minRefArray[0] = meshArray.Min(j => j.vert1.z);
            minRefArray[1] = meshArray.Min(j => j.vert2.z);
            minRefArray[2] = meshArray.Min(j => j.vert3.z);
            minVec.z = minRefArray.Min();
            return minVec;
        }

        /**
        * @brief  This function returns the max position of objects bounding box by checking
        *         all triangle meshes
        * @param  meshArray
        * @retval Vector3
        */
        public Vector3 GetMaxMeshPosition(TriangleMesh[] meshArray)
        {
            Vector3 maxVec = new Vector3();
            float[] maxRefArray = new float[3];
            maxRefArray[0] = meshArray.Max(j => j.vert1.x);
            maxRefArray[1] = meshArray.Max(j => j.vert2.x);
            maxRefArray[2] = meshArray.Max(j => j.vert3.x);
            maxVec.x = maxRefArray.Max();
            maxRefArray[0] = meshArray.Max(j => j.vert1.y);
            maxRefArray[1] = meshArray.Max(j => j.vert2.y);
            maxRefArray[2] = meshArray.Max(j => j.vert3.y);
            maxVec.y = maxRefArray.Max();
            maxRefArray[0] = meshArray.Max(j => j.vert1.z);
            maxRefArray[1] = meshArray.Max(j => j.vert2.z);
            maxRefArray[2] = meshArray.Max(j => j.vert3.z);
            maxVec.z = maxRefArray.Max();
            return maxVec;
        }

        /**
        * @brief  This function checks the type of stl file binary or ascii, function is assuming
        *         given file as proper *.stl file 
        * @param  none
        * @retval stlFileType
        */
        private FileType GetFileType(string filePath)
        {
            FileType stlFileType = FileType.NONE;

            /* check path is exist */
            if (File.Exists(filePath))
            {
                int lineCount = 0;
                lineCount = File.ReadLines(filePath).Count(); // number of lines in the file

                string firstLine = File.ReadLines(filePath).First();

                string endLines = File.ReadLines(filePath).Skip(lineCount - 1).Take(1).First() +
                                  File.ReadLines(filePath).Skip(lineCount - 2).Take(1).First();

                /* check the file is ascii or not */
                if((firstLine.IndexOf("solid") != -1) &
                    (endLines.IndexOf("endsolid") != -1))
                {
                    stlFileType = FileType.ASCII;
                }
                else
                {
                    stlFileType = FileType.BINARY;
                }

            }
            else
            {
                stlFileType = FileType.NONE;
            }


            return stlFileType;
        }

        
        /**
        * @brief  *.stl file binary read function
        * @param  filePath
        * @retval meshList
        */
        private TriangleMesh[] ReadBinaryFile(string filePath)
        {
            List<TriangleMesh> meshList = new List<TriangleMesh>();
            int numOfMesh = 0;
            int i = 0;
            int byteIndex = 0;
            byte[] fileBytes = File.ReadAllBytes(filePath);

            byte[] temp = new byte[4];

            /* 80 bytes title + 4 byte num of triangles + 50 bytes (1 of triangular mesh)  */
            if (fileBytes.Length > 120)
            {

                temp[0] = fileBytes[80];
                temp[1] = fileBytes[81];
                temp[2] = fileBytes[82];
                temp[3] = fileBytes[83];

                numOfMesh = System.BitConverter.ToInt32(temp, 0);

                byteIndex = 84;

                for(i = 0; i < numOfMesh; i++)
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
                        processError = true;
                        break;
                    }

                    meshList.Add(newMesh);

                }

            }
            else
            {
                // nitentionally left blank
            }

            return meshList.ToArray();
        }


        /**
        * @brief  *.stl file ascii read function
        * @param  filePath
        * @retval meshList
        */
        private TriangleMesh[] ReadASCIIFile(string filePath)
        {
            List<TriangleMesh> meshList = new List<TriangleMesh>();

            StreamReader txtReader = new StreamReader(filePath);

            string lineString;
            
            while (!txtReader.EndOfStream)
            {
                lineString = txtReader.ReadLine().Trim(); /* delete whitespace in front and tail of the string */
                string[] lineData = lineString.Split(' ');

                if (lineData[0] == "solid")
                {
                    while (lineData[0] != "endsolid")
                    {
                        lineString = txtReader.ReadLine().Trim(); // facetnormal
                        lineData = lineString.Split(' ');

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
                            lineString = txtReader.ReadLine(); // Just skip the OuterLoop line
                            //----------------------------------------------------------------------

                            // Vertex1
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.vert1.x = float.Parse(lineData[1]); // x1
                            newMesh.vert1.y = float.Parse(lineData[2]); // y1
                            newMesh.vert1.z = float.Parse(lineData[3]); // z1

                            // Vertex2
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.vert2.x = float.Parse(lineData[1]); // x2
                            newMesh.vert2.y = float.Parse(lineData[2]); // y2
                            newMesh.vert2.z = float.Parse(lineData[3]); // z2

                            // Vertex3
                            lineString = txtReader.ReadLine().Trim();
                            /* reduce spaces until string has proper format for split */
                            while (lineString.IndexOf("  ") != -1) lineString = lineString.Replace("  ", " ");
                            lineData = lineString.Split(' ');

                            newMesh.vert3.x = float.Parse(lineData[1]); // x3
                            newMesh.vert3.y = float.Parse(lineData[2]); // y3
                            newMesh.vert3.z = float.Parse(lineData[3]); // z3
                        }
                        catch
                        {
                            processError = true;
                            break;
                        }

                        //----------------------------------------------------------------------
                        lineString = txtReader.ReadLine(); // Just skip the endloop
                        //----------------------------------------------------------------------
                        lineString = txtReader.ReadLine(); // Just skip the endfacet

                        meshList.Add(newMesh); // add mesh to meshList

                    } // while linedata[0]
                } // if solid
            } // while !endofstream

            return meshList.ToArray();
        }

    }
}
