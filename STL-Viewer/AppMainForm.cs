using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using STL_Tools;
using OpenTK.Graphics.OpenGL;
using BatuGL;
using Mouse_Orbit;

namespace STLViewer
{
    public partial class AppMainForm : Form
    {
        bool monitorLoaded = false;
        Batu_GL.VAO_TRIANGLES modelVAO; // 3d model vertex array object
        private Orbiter orb;
        Vector3 minPos = new Vector3();
        Vector3 maxPos = new Vector3();

        public AppMainForm()
        {
            /* dot/comma selection for floating point numbers */
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
            orb = new Orbiter();
            GL_Monitor.MouseDown += orb.Control_MouseDownEvent;
            GL_Monitor.MouseUp += orb.Control_MouseUpEvent;
            GL_Monitor.MouseWheel += orb.Control_MouseWheelEvent;
            GL_Monitor.KeyPress += orb.Control_KeyPress_Event;
        }

        private void FileSelectBt_Click(object sender, EventArgs e)
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
                modelVAO.color = Color.Crimson;
                minPos = stlReader.GetMinMeshPosition(meshArray);
                maxPos = stlReader.GetMaxMeshPosition(meshArray);
                orb.Reset_Orientation();
                orb.Reset_Pan();
                orb.Reset_Scale();
                if (!stlReader.Get_Process_Error())
                {
                    DrawTimer.Enabled = true;
                    FileSelectBt.BackColor = Color.DeepSkyBlue;
                }
                else
                {
                    DrawTimer.Enabled = false;
                    FileSelectBt.BackColor = Color.Tomato;
                    /* if there is an error, deinitialize the gl monitor to clear the screen */
                    Batu_GL.Configure(GL_Monitor, Batu_GL.Ortho_Mode.CENTER);
                    GL_Monitor.SwapBuffers();
                }
            }
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            orb.UpdateOrbiter(MousePosition.X, MousePosition.Y);
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

        private void ConfigureBasicLighting(Color modelColor)
        {
            float[] light_1 = new float[] {
            0.2f * modelColor.R / 255.0f,
            0.2f * modelColor.G / 255.0f,
            0.2f * modelColor.B / 255.0f,
            1.0f };
            float[] light_2 = new float[] {
            3.0f * modelColor.R / 255.0f,
            3.0f * modelColor.G / 255.0f,
            3.0f * modelColor.B / 255.0f,
            1.0f };
            float[] specref = new float[] { 
                0.01f * modelColor.R / 255.0f, 
                0.01f * modelColor.G / 255.0f, 
                0.01f * modelColor.B / 255.0f, 
                1.0f };
            float[] specular_0 = new float[] { -1.0f, -1.0f, 1.0f, 1.0f };
            float[] specular_1 = new float[] { 1.0f, -1.0f, 1.0f, 1.0f };
            float[] lightPos_0 = new float[] { 1000f, 1000f, -200.0f, 1.0f };
            float[] lightPos_1 = new float[] { -1000f, 1000f, -200.0f, 1.0f };

            GL.Enable(EnableCap.Lighting);
            /* light 0 */
            GL.Light(LightName.Light0, LightParameter.Ambient, light_1);
            GL.Light(LightName.Light0, LightParameter.Diffuse, light_2);
            GL.Light(LightName.Light0, LightParameter.Specular, specular_0);
            GL.Light(LightName.Light0, LightParameter.Position, lightPos_0);
            GL.Enable(EnableCap.Light0);
            /* light 1 */
            GL.Light(LightName.Light1, LightParameter.Ambient, light_1);
            GL.Light(LightName.Light1, LightParameter.Diffuse, light_2);
            GL.Light(LightName.Light1, LightParameter.Specular, specular_1);
            GL.Light(LightName.Light1, LightParameter.Position, lightPos_1);
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
            if (modelVAO != null) ConfigureBasicLighting(modelVAO.color);
            GL.Translate(-minPos.x, -minPos.y, -minPos.z);
            GL.Translate(-(maxPos.x - minPos.x) / 2.0f, -(maxPos.y - minPos.y) / 2.0f, -(maxPos.z - minPos.z) / 2.0f);
            GL.Translate(orb.PanX, orb.PanY, 0);
            GL.Scale(orb.scaleVal, orb.scaleVal, orb.scaleVal);
            GL.Rotate(orb.orbitStr.angle, orb.orbitStr.ox, orb.orbitStr.oy, orb.orbitStr.oz);
            if (modelVAO != null) modelVAO.Draw();
            GL_Monitor.SwapBuffers();
        }
    }
}