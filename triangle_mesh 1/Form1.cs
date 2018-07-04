using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Tao.FreeGlut;
using System.IO;
using System.Globalization;
using System.Threading;
using STL_Tools;

namespace triangle_mesh_1
{
    public partial class Form1 : Form
    {

        float[] light_1 = new float[] { 0.15f, 0.15f, 0.15f, 1.0f };
        float[] light_2 = new float[] { 0.35f, 0.35f, 0.35f, 1.0f };
        float[] specref = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        float[] specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        float[] lightPos = new float[] { 200f, 200f, -200.0f, 1.0f };
        float[] lightPos2 = new float[] { -200f, 200f, -200.0f, 1.0f };

        public Form1()
        {
            /* dot/comma selection for floating point numbers */
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            InitializeComponent();
            monitor.InitializeContexts();
        }

        public void Draw()
        { 
            //--------------------------------------------
            Gl.glEnable(Gl.GL_LIGHTING);  // Işıklandırma aktif ediliyor  
            //--------------------------------------------
            //--Işık 1                               
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light_1); // Aydınlatma çeşidi ve ışık numarası belirleniyor ışık özellikleri "isik adlı diziden alınıyor"
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light_2); // Aydınlatma çeşitlerinden dağıtma seçilerek "isik2" de dağılmayı yapacak ışık özellikleri tanımlanıyor
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, specular); // Aydınlatma çeşitlerinden yansıtma seçiliyor "specular" dizisi ile yansıma ışığının özellikleri belirleniyor
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPos); // "0" numaralı ışığın konumu "lightpos" dizisinden alınıyor
            Gl.glEnable(Gl.GL_LIGHT0); // "0" numaralı ıuşık aktif hale gtiriliyor
            //-------------------------------------------
            //--Işık 2
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light_1); 
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light_2);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, specular);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, lightPos2);
            Gl.glEnable(Gl.GL_LIGHT1);
            //-------------------------------------------
            Gl.glEnable(Gl.GL_COLOR_MATERIAL); // Parça renk materyali aktif hale getiriliyor
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, specref);
            Gl.glMateriali(Gl.GL_FRONT, Gl.GL_SHININESS, 10); // Parlaklık seviyesi ayarla ("1" değerinin yansıması iyi)
            Gl.glEnable(Gl.GL_NORMALIZE); // Işık geçişini yumuşatma 
            //-------------------------------------------

 
            monitor.SwapBuffers();
        }


        private void fileSelectBt_Click(object sender, EventArgs e)
        {
            OpenFileDialog stldosyaSec = new OpenFileDialog();
            stldosyaSec.Filter = "STL Files|*.stl;*.txt;";

            if (stldosyaSec.ShowDialog() == DialogResult.OK)
            {
                dosyaSecTxb.Text = stldosyaSec.SafeFileName;

                STLReader stlReader = new STLReader(stldosyaSec.FileName);
                stlReader.ReadFile();
            }
            else
            {
                // intentionally left blank
            }
        }



        

        
     



    }
}