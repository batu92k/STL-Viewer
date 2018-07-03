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

namespace triangle_mesh_1
{
    public partial class Form1 : Form
    {
        OpenFileDialog stldosyaSec = new OpenFileDialog();
        string stldosyaIsmi;
        public Form1()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            
            InitializeComponent();
            simEkran.InitializeContexts();

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

        public double[] oku(string trdosyaYolu)
        {
            string stlSatir;
            int i = 0;
            int i2 = 0;


            StreamReader stlOkuyucu = new StreamReader(trdosyaYolu);
            while (!stlOkuyucu.EndOfStream)
            {
                stlSatir = stlOkuyucu.ReadLine().Trim().Replace(" ", "");

                switch (stlSatir)
                {
                    case "solid":

                        while (stlSatir != "endsolid")
                        {
                            stlSatir = stlOkuyucu.ReadLine().Trim().Replace(" ", ""); //facetnormal

                            if (stlSatir == "endsolid") // Son satır endsolid denetlemesi
                            {
                                break;
                            }

                            // FaceNormal     
                            normal[i2] = double.Parse(stlSatir.Substring(11, 14)); //x
                            normal[i2 + 1] = double.Parse(stlSatir.Substring(25, 14)); //y
                            normal[i2 + 2] = double.Parse(stlSatir.Substring(39, 14)); //z
                            normal[i2 + 3] = double.Parse(stlSatir.Substring(11, 14)); //x2
                            normal[i2 + 4] = double.Parse(stlSatir.Substring(25, 14)); //y2
                            normal[i2 + 5] = double.Parse(stlSatir.Substring(39, 14)); //z2
                            normal[i2 + 6] = double.Parse(stlSatir.Substring(11, 14)); //x3
                            normal[i2 + 7] = double.Parse(stlSatir.Substring(25, 14)); //y3
                            normal[i2 + 8] = double.Parse(stlSatir.Substring(39, 14)); //z3
                            //----------------------------------------------------------------------
                            stlSatir = stlOkuyucu.ReadLine().Trim().Replace(" ", ""); // OuterLoop
                            //----------------------------------------------------------------------
                            // Vertex1
                            stlSatir = stlOkuyucu.ReadLine().Trim().Replace(" ", "");
                            triangle[i] = double.Parse(stlSatir.Substring(6, 14)); //x1
                            triangle[i + 1] = double.Parse(stlSatir.Substring(20, 14)); //y1
                            triangle[i + 2] = double.Parse(stlSatir.Substring(34, 14)); //z1
                            // Vertex2
                            stlSatir = stlOkuyucu.ReadLine().Trim().Replace(" ", "");
                            triangle[i + 3] = double.Parse(stlSatir.Substring(6, 14)); //x2
                            triangle[i + 4] = double.Parse(stlSatir.Substring(20, 14)); //y2
                            triangle[i + 5] = double.Parse(stlSatir.Substring(34, 14)); //z2
                            // Vertex3
                            stlSatir = stlOkuyucu.ReadLine().Trim().Replace(" ", "");
                            triangle[i + 6] = double.Parse(stlSatir.Substring(6, 14)); //x3
                            triangle[i + 7] = double.Parse(stlSatir.Substring(20, 14)); //y3
                            triangle[i + 8] = double.Parse(stlSatir.Substring(34, 14)); //z3
                            //----------------------------------------------------------------------
                            stlSatir = stlOkuyucu.ReadLine().Trim().Replace(" ", ""); // EndLoop
                            //----------------------------------------------------------------------
                            stlSatir = stlOkuyucu.ReadLine().Trim().Replace(" ", ""); // endfacet

                            i += 9;
                            i2 += 9;
                        }


                        break;

                     default:  // Eğer hatalı dosya seçilir ve okuma metodundaki caselerden birine girilemesse program default case e girer ve hata verir
                       MessageBox.Show("Seçilen stl dosyası hatalı!\nProgram yeniden başlatılacak!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       Application.Restart();
                       Environment.Exit(0);               
                     break;


                }

            }
            noktasayisi = i; // i sayısı okunan dosyada kaç tane koordinat olduğunu gösterir bu sayı kullanılarak draw array yönteminin kaç nokta çizeceği belirlenir, böylece gereksiz işlem yükünden kaçınılır
            stlOkuyucu.Close();

            return triangle;

        }

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
            simEkran.Invalidate();
        }

        private void simEkran_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                timerW.Enabled = true;
            }
            if (e.KeyCode == Keys.S)
            {
                timerS.Enabled = true ;
            }
            if (e.KeyCode == Keys.D)
            {
                timerD.Enabled = true ;
            }
            if (e.KeyCode == Keys.A)
            {
              timerA.Enabled = true;
            }
            if (e.KeyCode == Keys.Q)
            {
                timerQ.Enabled = true;
            }
            if (e.KeyCode == Keys.E)
            {
                timerE.Enabled = true;
            }

            if (e.KeyCode == Keys.Add)
            {
                timerArti.Enabled = true;
            }

            if (e.KeyCode == Keys.Subtract)
            {
                timerEksi.Enabled = true;
            }
        }

        private void simEkran_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.W)
            {
                rotXBt.PerformClick();
            }
            if (e.KeyChar == (char)Keys.S)
            {
                rotXeksiBt.PerformClick();
            }
            if (e.KeyChar == (char)Keys.D)
            {
                rotZeksiBt.PerformClick();
            }
            if (e.KeyChar == (char)Keys.A)
            {
                rotZBt.PerformClick();
            }
            if (e.KeyChar == (char)Keys.Q)
            {
                rotYBt.PerformClick();
            }
            if (e.KeyChar == (char)Keys.E)
            {
                rotYeksiBt.PerformClick();
            }
            if (e.KeyChar == (char)Keys.Add)
            {
                zoominBt.PerformClick();
            }
            if (e.KeyChar == (char)Keys.Subtract)
            {
                zoomoutBt.PerformClick();
            }
        }

        private void simEkran_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                timerW.Enabled = false;
            }
            if (e.KeyCode == Keys.S)
            {
                timerS.Enabled = false;
            }
            if (e.KeyCode == Keys.D)
            {
                timerD.Enabled = false;
            }
            if (e.KeyCode == Keys.A)
            {
                timerA.Enabled = false;
            }
            if (e.KeyCode == Keys.Q)
            {
                timerQ.Enabled = false;
            }
            if (e.KeyCode == Keys.E)
            {
                timerE.Enabled = false;
            }
            if (e.KeyCode == Keys.Add)
            {
                timerArti.Enabled = false;
            }

            if (e.KeyCode == Keys.Subtract)
            {
                timerEksi.Enabled = false;
            }
        }

        private void rotXBt_Click(object sender, EventArgs e)
        {
            rotx += 3;
            draw(rotx,roty,rotz,scale,tx,ty);
        }

        private void rotXeksiBt_Click(object sender, EventArgs e)
        {
            rotx -= 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void rotYBt_Click(object sender, EventArgs e)
        {
            roty += 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void rotYeksiBt_Click(object sender, EventArgs e)
        {
            roty -= 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }


        private void rotZBt_Click(object sender, EventArgs e)
        {
            rotz += 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void rotZeksiBt_Click(object sender, EventArgs e)
        {
            rotz -= 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void zoominBt_Click(object sender, EventArgs e)
        {
      
            scale += 0.1;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void zoomoutBt_Click(object sender, EventArgs e)
        {
            if (scale > 0.1)
            {
                scale -= 0.1;
                draw(rotx, roty, rotz, scale, tx, ty);
            }
        }

        private void PanUpBt_Click(object sender, EventArgs e)
        {
            ty -= 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void PanDownBt_Click(object sender, EventArgs e)
        {
            ty += 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void panLeftBt_Click(object sender, EventArgs e)
        {
            tx += 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void PanRightBt_Click(object sender, EventArgs e)
        {
            tx -= 3;
            draw(rotx, roty, rotz, scale, tx, ty);
        }

        private void timerA_Tick(object sender, EventArgs e)
        {
            rotZBt.PerformClick();
        }

        private void timerD_Tick(object sender, EventArgs e)
        {
            rotZeksiBt.PerformClick();
        }

        private void timerW_Tick(object sender, EventArgs e)
        {
            rotXBt.PerformClick();
        }

        private void timerS_Tick(object sender, EventArgs e)
        {
            rotXeksiBt.PerformClick();
        }

        private void timerQ_Tick(object sender, EventArgs e)
        {
            rotYBt.PerformClick();
        }

        private void timerE_Tick(object sender, EventArgs e)
        {
            rotYeksiBt.PerformClick();
        }

        private void timerArti_Tick(object sender, EventArgs e)
        {
            zoominBt.PerformClick();
        }

        private void timerEksi_Tick(object sender, EventArgs e)
        {
            zoomoutBt.PerformClick();
        }

        private void dosyaSecBt_Click(object sender, EventArgs e)
        {
            stldosyaSec.Filter = "TXT|*.txt";
         
            if(stldosyaSec.ShowDialog() == DialogResult.OK)
            {
                dosyaSecTxb.Text = stldosyaSec.SafeFileName;               
                try
                {
                    oku(stldosyaSec.FileName);
                    draw(rotx, roty, rotz, scale, tx, ty);
                }
                catch
                {
                    MessageBox.Show("Seçilen stl dosyası hatalı!\nProgram yeniden başlatılacak!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                    Environment.Exit(0);
                   
                }
            }

        }

        private void dosyaSecTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // textbox a yazı girişi yasaklandı
        }


        

        
     



    }
}