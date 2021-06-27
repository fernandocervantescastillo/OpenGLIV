using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;

namespace OpenGLIV
{
    public abstract class IObjeto
    {

        private Matrix4 _view;
        private Vector3 centro;

        public IObjeto()
        {
            _view = Matrix4.Identity;
            centro = new Vector3(0, 0, 0);
        }


        public void trasladar(float x, float y, float z)
        {
            _view = Matrix4.CreateTranslation(new Vector3(x, y, z)) * _view;
        }

        public void rotar(float x, float y, float z)
        {
            _view = Matrix4.CreateRotationX(x) * _view;
            _view = Matrix4.CreateRotationY(y) * _view;
            _view = Matrix4.CreateRotationZ(z) * _view;
        }

        public void agrandar(float x, float y, float z)
        {
            _view = Matrix4.CreateScale(x, y, z) * _view;
        }



        public abstract void draw(Matrix4 matriz);


        public abstract void dispose();

    }
}