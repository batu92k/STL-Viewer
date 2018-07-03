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
        private enum FileType { NONE, BINARY, ASCII };


        /**
        * @brief  Class instance constructor
        * @param  none
        * @retval none
        */
        public STLReader(string filePath = "")
        {
            path = filePath;
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



            return meshList.ToArray();
        }

    }


}
