using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;

namespace OpenGLIV
{
    class Silla : IObjeto
    {
        
        public List<Cubo> list;
        
        public Silla(float a, float b, float h1, float h2, float z, float posX, float posY, float posZ)
            : base()
        {
            Cubo pata1 = new Cubo(z, h1, z, 0 + posX, 0 + posY, 0 + posZ);
            Cubo pata2 = new Cubo(z, h2 - z, z, b - z + posX, 0 + posY, 0 + posZ);
            pata2.setCenter(new Vector3(b - z + posX, 0 + posY, 0 + posZ));
            Cubo pata3 = new Cubo(z, h1, z, 0 + posX, 0 + posY, a - z + posZ);
            Cubo pata4 = new Cubo(z, h2 - z, z, b - z + posX, 0 + posY, a - z + posZ);

            Cubo plataforma = new Cubo(b - z, z, a, z + posX, h2 - z + posY, 0 + posZ);
            Cubo horizontal = new Cubo(z, z, a - 2 * z, 0 + posX, h1 - z + posY, z + posZ);


            list = new List<Cubo>();

            list.Add(pata1);
            list.Add(pata2);
            list.Add(pata3);
            list.Add(pata4);
            list.Add(plataforma);
            list.Add(horizontal);

        }

        public override void draw(Matrix4 matriz)
        {
            //pata1.rotar(0.01f, 0, 0);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].draw(_view * matriz);
            }
        }

        public override void dispose()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].dispose();
            }
        }

    }
}
