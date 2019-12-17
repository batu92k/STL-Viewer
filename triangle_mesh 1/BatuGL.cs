using System.Drawing;
using Tao.OpenGl;
using Tao.Platform.Windows;
using Tao.FreeGlut;


namespace BatuGL
{
    public class Batu_GL
    {

        public enum Ortho_Mode { CENTER, BLEFT, CLEFT }; // GL monitoru icin eksen takimi yerlestirme secenegi

        /**
        * @brief  OpenGL sinifi constructor fonksiyonu, 
        * @param  yok  	
        * @retval yok
        */
        public Batu_GL()
        {
            // intentionally left blank
        }


        /* Daha sonra poligon triangle gibi GL elemanlarini da karsilayacak sekilde gelistirilecek */
        public class VAO_TRIANGLES
        {
            public float lineWidth { get; set; } // VAO dizisi cizgi uzunlugu
            public Color color { get; set; } // VAO dizisi rengi
            public float[] scale { get; set; }
            public float[] parameterArray { get; set; } // VAO koordinat parametreleri
            public float[] normalArray { get; set; } // VAO koordinat parametreleri

            /**
            * @brief  sinif constructor fonksiyonu 
            * @param  none  	
            * @retval none
            */
            public VAO_TRIANGLES()
            {
                lineWidth = 1.0f;
                color = Color.Red;
                scale = new float[3] { 1.0f, 1.0f, 1.0f };
            }


            public void Draw()
            {
                Gl.glPushMatrix();
                Gl.glLineWidth(lineWidth); // Çizgi kalınlığı

                Gl.glScaled(scale[0], scale[1], scale[2]);

                Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
                Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
                Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, parameterArray);
                Gl.glColor3d(color.R / 255.0, color.G / 255.0, color.B / 255.0);  
                Gl.glNormalPointer(Gl.GL_FLOAT, 0, normalArray);   // 12*sizeof(float)        
                Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, parameterArray.Length / 3); // Okunan dosyadaki her 3 nokta 1 vertex oluşturduğundan toplam nokta sayısı 3'e bölünür         
                Gl.glDisableClientState(Gl.GL_NORMAL_ARRAY);
                Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);

                Gl.glPopMatrix();
            }

        }


        /**
        * @brief  OpenGL ekrani initialize fonksiyonu
        * @param  MONITOR  	
        * @retval yok
        */
        public void initialize(SimpleOpenGlControl MONITOR)
        {
            MONITOR.InitializeContexts();
        }

        /**
        * @brief  Bu fonksiyon, OpenGL ekraninin koordinat duzlemini (ortho) ve pencerenin
        *         ne kadarinda goruntunun gosterilecegini (viewport) ayarlar. Aynı zamanda
        *         OpenGL ekranininin derinlik ve renk buffer'ini temizler
        * @param  glMonitor 	
        * @retval yok
        */
        public void glInit(SimpleOpenGlControl glMonitor, Ortho_Mode mode)
        {
            Gl.glClearColor(0, 0, 0, 0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glViewport(0, 0, glMonitor.Width, glMonitor.Height); // Görüntülenecek alan tanımlanıyor ve pencere boyutunun değişme durumuna göre open gl penceresinin parametreleri ayarlanıyor
            
            if (mode == Ortho_Mode.BLEFT)
            {
                Gl.glOrtho(0, glMonitor.Width, 0, glMonitor.Height, 4000, -4000); // Orijin tanımlanıyor
            }
            else if (mode == Ortho_Mode.CENTER)
            {
                Gl.glOrtho(-glMonitor.Width / 2, glMonitor.Width / 2, -glMonitor.Height / 2, glMonitor.Height / 2, 4000, -4000); // Orijin tanımlanıyor
            }
            else if (mode == Ortho_Mode.CLEFT)
            {
                Gl.glOrtho(0, glMonitor.Width, -glMonitor.Height / 2, glMonitor.Height / 2, 4000, -4000); // Orijin tanımlanıyor
            }
            else
            {
                // bilerek bos birakildi
            }

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearDepth(1.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LEQUAL);
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
            Glut.glutInit();
        }

        /**
        * @brief  Bu fonksiyon, bir programda asla 2 kez cagrilmamasi gereken
        *         glutInit() fonksiyonunun statik olarak tanimlanmasiyla, programin
        *         ana dongusu icerisinde gelistirici tarafindan cagrilmasi icin 
        *         yazilmistir.
        * @param  yok 	
        * @retval yok
        */
        public static void InitializeGlut()
        {
            Glut.glutInit();
        }

        /**
        * @brief  Bu fonksiyon OpenGL ekraninin, form penceresi boyutunun degisimine karsi 
         *        dinamik olarak tepki gostermesini saglar. Yani form penceresi eger boyut
         *        degistirirse OpenGL ekraninin buna uyum saglamasini saglar.
        * @param  glMonitor 	
        * @retval yok
        */
        public void glDinamik(SimpleOpenGlControl glMonitor, Ortho_Mode mode)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearDepth(1.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LEQUAL);
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glViewport(0, 0, glMonitor.Width, glMonitor.Height); // Görüntülenecek alan tanımlanıyor ve pencere boyutunun değişme durumuna göre open gl penceresinin parametreleri ayarlanıyor
           
            if (mode == Ortho_Mode.BLEFT)
            {
                Gl.glOrtho(0, glMonitor.Width, 0, glMonitor.Height, 4000, -4000); // Orijin tanımlanıyor
            }
            else if (mode == Ortho_Mode.CENTER)
            {
                Gl.glOrtho(-glMonitor.Width / 2, glMonitor.Width / 2, -glMonitor.Height / 2, glMonitor.Height / 2, 4000, -4000); // Orijin tanımlanıyor
            }
            else if (mode == Ortho_Mode.CLEFT)
            {
                Gl.glOrtho(0, glMonitor.Width, -glMonitor.Height / 2, glMonitor.Height / 2, 4000, -4000); // Orijin tanımlanıyor
            }
            else
            {
                // bilerek bos birakildi
            }
            
            //--------------- LINE SMOOTH ve ANTIALIASING ---------------
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_FASTEST);
            //-----------------------------------------------------------
        }


        /**
        * @brief  Bu fonksiyon OpenGL ekranina cizilen noktalari Pn seklinde isimlendirerek,
        *         ilgili text karakterlerinin OpenGL ekranina ciziminde kullanilir.
        * @param  glutPoints
        * @param  numberofPoints
        * @retval yok
        */
        public void drawFreeGlut(double[] glutPoints, int numberofPoints)
        {
            int i = 0;
            int j = 0;

            for (i = 0; i < numberofPoints; i++)
            {
                Gl.glColor3d(0, 0, 10);
                Gl.glRasterPos3d(glutPoints[j], glutPoints[j + 1], glutPoints[j + 2]);
                j += 3;
                Glut.glutBitmapString(Glut.GLUT_BITMAP_TIMES_ROMAN_24, "P" + i.ToString());
            }
        }

        /**
        * @brief  Bu fonksiyon OpenGL ekranindaki herhangi bir noktaya istenilen bir text'i 
        *         Times New Roman fontunda 24 punto ile basmak icin kullanilir.
        * @param  x
        * @param  y
        * @param  z
        * @param  text
        * @retval yok
        */
        public void drawText(double x, double y, double z, string text)
        {
            Gl.glColor3d(0.698f, 0.133f, 0.133f);
            Gl.glRasterPos3d(x, y, z);
            Glut.glutBitmapString(Glut.GLUT_BITMAP_TIMES_ROMAN_24, text);
        }


        /**
        * @brief  Bu fonksiyon OpenGL ekranindaki herhangi bir noktaya istenilen bir text'i 
        *         Times New Roman fontunda 10 punto ile basmak icin kullanilir.
        * @param  x
        * @param  y
        * @param  z
        * @param  text
        * @retval yok
        */
        public void drawTextSmall(double x, double y, double z, string text)
        {
            Gl.glColor3d(0.698f, 0.133f, 0.133f);
            Gl.glRasterPos3d(x, y, z);
            Glut.glutBitmapString(Glut.GLUT_BITMAP_TIMES_ROMAN_10, text);
        }

        /**
        * @brief  Bu fonksiyon OpenGL ekranina basit bir kup cizmek icin kullanilir
        * @param  yok
        * @retval yok
        */
       public void drawCube()
        {
            /* 1. yuz tanimlaniyor */
            Gl.glBegin(Gl.GL_POLYGON);   
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(50.0f, 50.0f, 50.0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(50.0f, -50.0f, 50.0f);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-50.0f, -50.0f, 50.0f);
            Gl.glColor3f(80.0f, 80.0f, 0.0f);
            Gl.glVertex3f(-50.0f, 50.0f, 50.0f);
            Gl.glEnd();
            /* 2. yuz tanimlaniyor */
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.0f, 50.0f);
            Gl.glVertex3f(50.0f, 50.0f, -50.0f);
            Gl.glVertex3f(50.0f, -50.0f, -50.0f);
            Gl.glVertex3f(-50.0f, -50.0f, -50.0f);
            Gl.glVertex3f(-50.0f, 50.0f, -50.0f);
            Gl.glEnd();
            /* 3. yuz tanimlaniyor */
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(100.0f, 100.0f, 0.0f);
            Gl.glVertex3f(50.0f, 50.0f, 50.0f);
            Gl.glVertex3f(50.0f, 50.0f, -50.0f);
            Gl.glVertex3f(50.0f, -50.0f, -50.0f);
            Gl.glVertex3f(50.0f, -50.0f, 50.0f);
            Gl.glEnd();
            /* 4. yuz tanimlaniyor */
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.50f, 0.0f, 0.50f);
            Gl.glVertex3f(-50.0f, 50.0f, 50.0f);
            Gl.glVertex3f(-50.0f, -50.0f, 50.0f);
            Gl.glVertex3f(-50.0f, -50.0f, -50.0f);
            Gl.glVertex3f(-50.0f, 50.0f, -50.0f);
            Gl.glEnd();
            /* 5. yuz tanimlaniyor */
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(50.0f, 50.0f, 50.0f);
            Gl.glVertex3f(50.0f, 50.0f, -50.0f);
            Gl.glVertex3f(-50.0f, 50.0f, -50.0f);
            Gl.glVertex3f(-50.0f, 50.0f, 50.0f);
            Gl.glEnd();
            /* 6. yuz tanimlaniyor */
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(0.0f, 0.50f, 0.50f);
            Gl.glVertex3f(50.0f, -50.0f, 50.0f);
            Gl.glVertex3f(50.0f, -50.0f, -50.0f);
            Gl.glVertex3f(-50.0f, -50.0f, -50.0f);
            Gl.glVertex3f(-50.0f, -50.0f, 50.0f);
            Gl.glEnd();
        }

       /**
       * @brief  Bu fonksiyon OpenGl ekranina istenilen renkte bir hedef kursoru cizmek icin kullanilir
       * @param  r
       * @param  g
       * @param  b
       * @retval yok
       */
       public void drawTargetCursor(float r, float g, float b)
       {
           Gl.glPushMatrix();
           Gl.glTranslated(0, 0, -1000); // cursorun arkada kalıp görünmemesini engellemek için çizim z ekseninde taşındı
           Gl.glBegin(Gl.GL_LINES);
           {
               Gl.glLineWidth(2.0f);
               Gl.glColor3f(r, g, b);
               Gl.glVertex3f(10, 0, 0);
               Gl.glVertex3f(50, 0, 0);
           }
           Gl.glEnd();
           Gl.glBegin(Gl.GL_LINES);
           {
               Gl.glLineWidth(2.0f);
               Gl.glColor3f(r, g, b);
               Gl.glVertex3f(-10, 0, 0);
               Gl.glVertex3f(-50, 0, 0);
           }
           Gl.glEnd();
           Gl.glBegin(Gl.GL_LINES);
           {
               Gl.glLineWidth(2.0f);
               Gl.glColor3f(r, g, b);
               Gl.glVertex3f(0, 10, 0);
               Gl.glVertex3f(0, 50, 0);
           }
           Gl.glEnd();
           Gl.glBegin(Gl.GL_LINES);
           {
               Gl.glLineWidth(2.0f);
               Gl.glColor3f(r, g, b);
               Gl.glVertex3f(0, -10, 0);
               Gl.glVertex3f(0, -50, 0);
           }
           Gl.glEnd();
           Gl.glPopMatrix();
       }

       /**
       * @brief  Bu fonksiyon OpenGL ekranina bir WCS eksen takimi cizmek icin kullanilir
       * @param  yok
       * @retval yok
       */
       public void drawWCS()
       {

           Gl.glPushMatrix();

           Gl.glScaled(0.2, 0.2, 0.2);

           //---------------------X-------------------------
           Gl.glLineWidth(2.5f);
           Gl.glBegin(Gl.GL_LINES);
           Gl.glColor3f(100, 0, 0);
           Gl.glVertex3f(0, 0, 0);
           Gl.glVertex3f(100, 0, 0);
           Gl.glEnd();
           Gl.glColor3d(0, 10, 10);
           Gl.glRasterPos3d(105, 0, 0);
           Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_TIMES_ROMAN_10, 'X');
           //---------------------Y-------------------------
           Gl.glBegin(Gl.GL_LINES);
           Gl.glColor3f(0, 100, 0);
           Gl.glVertex3f(0, 0, 0);
           Gl.glVertex3f(0, -100, 0);
           Gl.glEnd();
           Gl.glColor3d(0, 10, 10);
           Gl.glRasterPos3d(0, -105, 0);
           Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_TIMES_ROMAN_10, 'Y');
           //---------------------Z-------------------------
           Gl.glBegin(Gl.GL_LINES);
           Gl.glColor3f(0.3f, 0, 2000);
           Gl.glVertex3f(0, 0, 0);
           Gl.glVertex3f(0, 0, 100);
           Gl.glEnd();
           Gl.glColor3d(0, 10, 10);
           Gl.glRasterPos3d(0, 0, 105);
           Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_TIMES_ROMAN_10, 'Z');
           //---------------------KÜP-------------------------
           int a = 15; // küp yan yüz uzunluğu
           Gl.glBegin(Gl.GL_POLYGON);
           Gl.glColor3f(0.3f, 0, 2000);
           Gl.glVertex3f(a / 2, a / 2, a / 2);
           Gl.glVertex3f(a / 2, -a / 2, a / 2);
           Gl.glVertex3f(-a / 2, -a / 2, a / 2);
           Gl.glVertex3f(-a / 2, a / 2, a / 2);
           Gl.glEnd();
           Gl.glBegin(Gl.GL_POLYGON);
           Gl.glColor3f(0.3f, 0, 2000);
           Gl.glVertex3f(a / 2, a / 2, -a / 2);
           Gl.glVertex3f(a / 2, -a / 2, -a / 2);
           Gl.glVertex3f(-a / 2, -a / 2, -a / 2);
           Gl.glVertex3f(-a / 2, a / 2, -a / 2);
           Gl.glEnd();
           Gl.glBegin(Gl.GL_POLYGON);
           Gl.glColor3f(100, 0, 0);
           Gl.glVertex3f(a / 2, a / 2, a / 2);
           Gl.glVertex3f(a / 2, a / 2, -a / 2);
           Gl.glVertex3f(a / 2, -a / 2, -a / 2);
           Gl.glVertex3f(a / 2, -a / 2, a / 2);
           Gl.glEnd();
           Gl.glBegin(Gl.GL_POLYGON);
           Gl.glColor3f(100, 0, 0);
           Gl.glVertex3f(-a / 2, a / 2, a / 2);
           Gl.glVertex3f(-a / 2, -a / 2, a / 2);
           Gl.glVertex3f(-a / 2, -a / 2, -a / 2);
           Gl.glVertex3f(-a / 2, a / 2, -a / 2);
           Gl.glEnd();
           Gl.glBegin(Gl.GL_POLYGON);
           Gl.glColor3f(0, 100, 0);
           Gl.glVertex3f(a / 2, a / 2, a / 2);
           Gl.glVertex3f(a / 2, a / 2, -a / 2);
           Gl.glVertex3f(-a / 2, a / 2, -a / 2);
           Gl.glVertex3f(-a / 2, a / 2, a / 2);
           Gl.glEnd();
           Gl.glBegin(Gl.GL_POLYGON);
           Gl.glColor3f(0, 100, 0);
           Gl.glVertex3f(a / 2, -a / 2, a / 2);
           Gl.glVertex3f(a / 2, -a / 2, -a / 2);
           Gl.glVertex3f(-a / 2, -a / 2, -a / 2);
           Gl.glVertex3f(-a / 2, -a / 2, a / 2);
           Gl.glEnd();
           //---------------------OKLAR-------------------------
           //---------------------X-------------------------
           Gl.glBegin(Gl.GL_TRIANGLE_FAN);
           Gl.glColor3f(100, 0, 0);
           Gl.glVertex3f(100, 0, 0);
           Gl.glVertex3f(80, 5, 5);
           Gl.glVertex3f(80, -5, 5);
           Gl.glVertex3f(80, -5, -5);
           Gl.glVertex3f(80, 5, -5);
           Gl.glVertex3f(80, 5, 5);
           Gl.glEnd();
           //---------------------Y-------------------------
           Gl.glBegin(Gl.GL_TRIANGLE_FAN);
           Gl.glColor3f(0, 100, 0);
           Gl.glVertex3f(0, -100, 0);
           Gl.glVertex3f(5, -80, 5);
           Gl.glVertex3f(-5, -80, 5);
           Gl.glVertex3f(-5, -80, -5);
           Gl.glVertex3f(5, -80, -5);
           Gl.glVertex3f(5, -80, 5);
           Gl.glEnd();
           //---------------------Z-------------------------
           Gl.glBegin(Gl.GL_TRIANGLE_FAN);
           Gl.glColor3f(0.3f, 0, 2000);
           Gl.glVertex3f(0, 0, 100);
           Gl.glVertex3f(5, 5, 80);
           Gl.glVertex3f(-5, 5, 80);
           Gl.glVertex3f(-5, -5, 80);
           Gl.glVertex3f(5, -5, 80);
           Gl.glVertex3f(5, 5, 80);
           Gl.glEnd();

           Gl.glPopMatrix();
       }

    }
}
