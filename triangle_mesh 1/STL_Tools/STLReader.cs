/**
  ******************************************************************************
  * @file    STLReader.cs
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

            string line;

            while (!txtReader.EndOfStream)
            {
                line = txtReader.ReadLine().Trim().Replace(" ", "");

                switch (line)
                {
                    case "solid":

                        while (line != "endsolid")
                        {
                            line = txtReader.ReadLine().Trim().Replace(" ", ""); //facetnormal

                            if (line == "endsolid") // Son satır endsolid denetlemesi
                            {
                                break;
                            }

                            TriangleMesh newMesh = new TriangleMesh(); // define new mesh object

                            /* this try-catch block will be reviewed */
                            try
                            {
                                // FaceNormal 
                                newMesh.normal1.x = float.Parse(line.Substring(11, 14));
                                newMesh.normal1.y = float.Parse(line.Substring(25, 14));
                                newMesh.normal1.z = float.Parse(line.Substring(39, 14));

                                /* normals of vertex 2 and 3 equals to vertex 1's normals */
                                newMesh.normal2 = newMesh.normal1;
                                newMesh.normal3 = newMesh.normal1;

                                //----------------------------------------------------------------------
                                line = txtReader.ReadLine().Trim().Replace(" ", ""); // OuterLoop
                                //----------------------------------------------------------------------

                                // Vertex1
                                line = txtReader.ReadLine().Trim().Replace(" ", "");

                                newMesh.vert1.x = float.Parse(line.Substring(6, 14)); //x1
                                newMesh.vert1.y = float.Parse(line.Substring(20, 14)); // y1
                                newMesh.vert1.z = float.Parse(line.Substring(34, 14)); // z1

                                // Vertex2
                                line = txtReader.ReadLine().Trim().Replace(" ", "");
                                newMesh.vert2.x = float.Parse(line.Substring(6, 14)); //x1
                                newMesh.vert2.y = float.Parse(line.Substring(20, 14)); // y1
                                newMesh.vert2.z = float.Parse(line.Substring(34, 14)); // z1
                                // Vertex3
                                line = txtReader.ReadLine().Trim().Replace(" ", "");
                                newMesh.vert3.x = float.Parse(line.Substring(6, 14)); //x1
                                newMesh.vert3.y = float.Parse(line.Substring(20, 14)); // y1
                                newMesh.vert3.z = float.Parse(line.Substring(34, 14)); // z1
                            }
                            catch
                            {
                                processError = true;
                                break;
                            }

                            //----------------------------------------------------------------------
                            line = txtReader.ReadLine().Trim().Replace(" ", ""); // EndLoop
                            //----------------------------------------------------------------------
                            line = txtReader.ReadLine().Trim().Replace(" ", ""); // endfacet

                            meshList.Add(newMesh); // add mesh to meshList
                        }


                        break;

                    default:  
                        // intentionally left blank
                        break;


                }

            }

            return meshList.ToArray();
        }

    }


}
