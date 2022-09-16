/**
  ******************************************************************************
  * @file    BatuGL.cs
  * @author  Ali Batuhan KINDAN
  * @date    01.02.2020
  * @brief   This file contains the methods for opengl graphics features
  ******************************************************************************
  */
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace BatuGL
{
    public static class Batu_GL
    {
        public enum Ortho_Mode { CENTER, BLEFT };

        public static void Configure(OpenTK.GLControl refGLControl, Ortho_Mode ortho)
        {
            GL.ClearColor(Color.Black);
            refGLControl.VSync = false;
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.ClearColor(Color.Black);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Viewport(refGLControl.Size);
            if(ortho == Ortho_Mode.CENTER)
            {
                GL.Ortho(-refGLControl.Width / 2, refGLControl.Width / 2, -refGLControl.Height / 2, refGLControl.Height / 2, -20000, +20000);
            }
            else
            {
                GL.Ortho(0, refGLControl.Width, 0, refGLControl.Height, -20000, +20000);
            }
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearDepth(1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
            GL.Enable(EnableCap.LineSmooth);
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
            /* Somehow had a bad effect on model rendering just comment out */
            //GL.Enable(EnableCap.PolygonSmooth);
            //GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        public static void Draw_WCS(float size = 1000.0f)
        {
            /* WCS for Debug X+ = Red, Y+ = Green, Z+ = Blue */
            float wcsSize = 1000.0f;
            GL.LineWidth(5.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(wcsSize, 0.0f, 0.0f);
            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, wcsSize, 0.0f);
            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, wcsSize);
            GL.End();
        }

        public class VAO_TRIANGLES
        {
            public Color color { get; set; }
            public float[] scale { get; set; }
            public float[] parameterArray { get; set; }
            public float[] normalArray { get; set; }

            public VAO_TRIANGLES()
            {
                color = Color.Red;
                scale = new float[3] { 1.0f, 1.0f, 1.0f };
            }

            public void Draw()
            {
                GL.PushMatrix();
                GL.Scale(scale[0], scale[1], scale[2]);
                GL.EnableClientState(ArrayCap.VertexArray);
                GL.EnableClientState(ArrayCap.NormalArray);
                GL.VertexPointer(3, VertexPointerType.Float, 0, parameterArray);
                GL.Color3(color.R / 255.0, color.G / 255.0, color.B / 255.0);  
                GL.NormalPointer(NormalPointerType.Float, 0, normalArray);       
                GL.DrawArrays(PrimitiveType.Triangles, 0, parameterArray.Length / 3); // Okunan dosyadaki her 3 nokta 1 vertex oluşturduğundan toplam nokta sayısı 3'e bölünür         
                GL.DisableClientState(ArrayCap.NormalArray);
                GL.DisableClientState(ArrayCap.VertexArray);
                GL.PopMatrix();
            }
        }
    }
}
