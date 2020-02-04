using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using STL_Tools;
using OpenTK.Graphics.OpenGL;
using BatuGL;

namespace triangle_mesh_1
{
    public partial class Form1 : Form
    {
        bool monitorLoaded = false;
        Batu_GL.VAO_TRIANGLES modelVAO; // 3d model vertex array object

        float[] light_1 = new float[] { 0.15f, 0.15f, 0.15f, 1.0f };
        float[] light_2 = new float[] { 0.35f, 0.35f, 0.35f, 1.0f };
        float[] specref = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        float[] specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
        float[] lightPos = new float[] { 200f, 200f, -200.0f, 1.0f };
        float[] lightPos2 = new float[] { -200f, 200f, -200.0f, 1.0f };
        int rotation = 0; // model rotation for 3d demonstration

        public Form1()
        {
            /* dot/comma selection for floating point numbers */
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
        }

        private void fileSelectBt_Click(object sender, EventArgs e)
        {
            OpenFileDialog stldosyaSec = new OpenFileDialog();
            stldosyaSec.Filter = "STL Files|*.stl;*.txt;";

            if (stldosyaSec.ShowDialog() == DialogResult.OK)
            {
                STLReader stlReader = new STLReader(stldosyaSec.FileName);
                TriangleMesh[] meshArray = stlReader.ReadFile();
                modelVAO = new Batu_GL.VAO_TRIANGLES();
                modelVAO.parameterArray = STLExport.Get_Mesh_Vertices(meshArray);
                modelVAO.normalArray = STLExport.Get_Mesh_Normals(meshArray);
                modelVAO.color = Color.CadetBlue;

                if (!stlReader.Get_Process_Error())
                {
                    rotation = 0;
                    drawTimer.Enabled = true;
                    fileSelectBt.BackColor = Color.DeepSkyBlue;
                }
                else
                {
                    drawTimer.Enabled = false;
                    fileSelectBt.BackColor = Color.Tomato;

                    /* if there is an error, deinitialize the gl monitor to clear the screen */
                    Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
                    GL_Monitor.SwapBuffers();
                }

            }
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            GL_Monitor.Invalidate();
        }

        private void GL_Monitor_Load(object sender, EventArgs e)
        {
            monitorLoaded = true;
            GL.ClearColor(Color.Black);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
        }

        private void ConfigureBasicLighthing()
        {
            GL.Enable(EnableCap.Lighting);
            /* light 0 */
            GL.Light(LightName.Light0, LightParameter.Ambient, light_1);
            GL.Light(LightName.Light0, LightParameter.Diffuse, light_2);
            GL.Light(LightName.Light0, LightParameter.Specular, specular);
            GL.Light(LightName.Light0, LightParameter.Position, lightPos);
            GL.Enable(EnableCap.Light0);
            /* light 1 */
            GL.Light(LightName.Light1, LightParameter.Ambient, light_1);
            GL.Light(LightName.Light1, LightParameter.Diffuse, light_2);
            GL.Light(LightName.Light1, LightParameter.Specular, specular);
            GL.Light(LightName.Light1, LightParameter.Position, lightPos2);
            GL.Enable(EnableCap.Light1);
            /*material settings  */
            GL.Enable(EnableCap.ColorMaterial);
            GL.ColorMaterial(MaterialFace.Front, ColorMaterialParameter.AmbientAndDiffuse);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, specref);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, 10);
            GL.Enable(EnableCap.Normalize);
        }

        private void GL_Monitor_Paint(object sender, PaintEventArgs e)
        {
            if (!monitorLoaded)
                return;

            Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
            ConfigureBasicLighthing();
            GL.Rotate(-90, 1, 0, 0);
            GL.Scale(2, 2, 2);
            GL.Rotate(rotation, 0.7f, 1.0f, 0.2f);

            if(modelVAO != null) modelVAO.Draw();

            GL_Monitor.SwapBuffers();

            rotation++;
            rotation = rotation % 360;
        }
    }
}