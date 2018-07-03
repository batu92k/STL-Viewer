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
using System.IO;
using System.Globalization;
using System.Threading;
using STL_Tools;

namespace triangle_mesh_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            /* dot/comma selection for floating point numbers */
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            InitializeComponent();
            monitor.InitializeContexts();

        }
        //--------------------------------------------------------------------------
        public static Int32 noktasayisi = 0;

        double[] triangle = new double[9000000];
        double[] normal = new double[9000000];
        //--------------------------------------------------------------------------
        int rotx = 0;
        int roty = 0;
        int rotz = 0;
        double scale = 1.5;
        double tx = 0;
        double ty = 0;
            
        //--------------------------------------------------------------------------

        //-------------------------------------------------------------------
        float[] isik = new float[] { 0.15f, 0.15f, 0.15f, 1.0f };
        float[] isik2 = new float[] { 0.35f, 0.35f, 0.35f, 1.0f };
        float[] specref = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        float[] specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        float[] lightPos = new float[] { 200f, 200f, -200.0f, 1.0f };
        float[] lightPos2 = new float[] { -200f, 200f, -200.0f, 1.0f };
        //-------------------------------------------------------------------

        public void draw(int rotx, int roty,int rotz,double scale ,double tx,double ty)
        {

            Gl.glClearColor(0, 0, 0, 0); // Ekran Temizleniyor
            Gl.glLoadIdentity();
            Gl.glViewport(0, 0, 640, 480); // Görüntülenecek alan tanımlanıyor
            Gl.glOrtho(-320, 320, -240, 240, 500, -500); // Orijin tanımlanıyor
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearDepth(1.0f);          // Set the Depth buffer value (ranges[0,1])
            Gl.glEnable(Gl.GL_DEPTH_TEST);  // Derinlik algsını aktif et 
            Gl.glDepthFunc(Gl.GL_LEQUAL);   // Eğer iki obje aynı koordinat üzerindeyse 
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST); 
            //--------------------------------------------
            Gl.glEnable(Gl.GL_LIGHTING);  // Işıklandırma aktif ediliyor  
            //--------------------------------------------
            //--Işık 1                               
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, isik); // Aydınlatma çeşidi ve ışık numarası belirleniyor ışık özellikleri "isik adlı diziden alınıyor"
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, isik2); // Aydınlatma çeşitlerinden dağıtma seçilerek "isik2" de dağılmayı yapacak ışık özellikleri tanımlanıyor
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, specular); // Aydınlatma çeşitlerinden yansıtma seçiliyor "specular" dizisi ile yansıma ışığının özellikleri belirleniyor
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPos); // "0" numaralı ışığın konumu "lightpos" dizisinden alınıyor
            Gl.glEnable(Gl.GL_LIGHT0); // "0" numaralı ıuşık aktif hale gtiriliyor
            //-------------------------------------------
            //--Işık 2
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, isik); 
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, isik2);
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
            Gl.glTranslated(tx, ty, 0);
            Gl.glScaled(scale, scale, scale);           
            Gl.glPushMatrix();
            Gl.glRotated(rotx, 1, 0, 0);
            Gl.glRotated(roty, 0, 1, 0);
            Gl.glRotated(rotz, 0, 0, 1);
            Gl.glColor3d(0, 0.4, 0.4);
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glVertexPointer(3, Gl.GL_DOUBLE, 0, triangle);                                 //  tria.oku(Application.StartupPath + "/kup.txt")    
            Gl.glNormalPointer(Gl.GL_DOUBLE, 0, normal);   // 12*sizeof(float)        
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, noktasayisi / 3); // Okunan dosyadaki her 3 nokta 1 vertex oluşturduğundan toplam nokta sayısı 3'e bölünür         
            Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glPopMatrix(); 
            monitor.Invalidate();
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