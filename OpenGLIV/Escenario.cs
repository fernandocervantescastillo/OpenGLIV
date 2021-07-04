using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

namespace OpenGLIV
{
    class Escenario : GameWindow
    {

        List<IObjeto> list;
        Silla silla, silla1, silla2, silla3;

        private Matrix4 _view;
        private Matrix4 _projection;
        private Matrix4 aux;

        public Escenario(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            list = new List<IObjeto>();

            silla = new Silla(0.5f, 0.5f, 0.8f, 0.4f, 0.05f, 0, 0, 0);
            silla1 = new Silla(0.5f, 0.5f, 0.8f, 0.4f, 0.05f, 1, 1, 1);
            silla1.setCenter(new Vector3(1,1,1));
            silla2 = new Silla(0.5f, 0.5f, 0.8f, 0.4f, 0.05f, 1, -1, 0);
            silla3 = new Silla(0.5f, 0.5f, 0.8f, 0.4f, 0.05f, -1, -1, 0);

            list.Add(silla);
            list.Add(silla1);
            list.Add(silla2);
            list.Add(silla3);

            _view = Matrix4.CreateTranslation(0.0f, 0.0f, -5.0f);
            setProjection(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            base.OnLoad();
        }

        public void setProjection(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            _projection = Matrix4.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);
            aux = _view * _projection;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            silla1.rotar(0, 0.01f, 0);
            silla1.list[1].rotar(0.01f, 0, 0);

            IObjeto objeto;
            for (int i=0;i<list.Count;i++)
            {
                objeto = list[i];
                objeto.draw(aux);
            }

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }

        protected override void OnUnload()
        {
            IObjeto objeto;
            for (int i = 0; i < list.Count; i++)
            {
                objeto = list[i];
                objeto.dispose();
            }

            base.OnUnload();
        }
    }
}
