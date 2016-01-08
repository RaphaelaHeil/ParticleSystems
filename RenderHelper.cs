using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace ParticleSystems
{
    class RenderHelper
    {
        //TODO: update docs !!!!!!!!!!!!!!!!!

        private IdHolder IdHolder;
        protected Matrix4 Projection = Matrix4.Identity;

        public RenderHelper(IdHolder idHolder)
        {
            IdHolder = idHolder;
            PrepareAttributes();
            PrepareBuffers();
            PrepareUniforms();
        }

        public void Render(Vector2d[] positions, Vector3d[] colours)
        {
            FillBuffers(positions, colours);
            FillUniforms();
            EnableArrays();
            GL.DrawArrays(PrimitiveType.Points, 0, positions.Length);

            DisableArrays();
            GL.Flush();
        }


        /// <summary>
        /// Fill the Buffer Objects with the previously generated values.
        /// </summary>
        private void FillBuffers(Vector2d[] positions, Vector3d[] colours)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, IdHolder.PositionBufferId); //bind buffer that will be modified
            //load data into selected buffer
            GL.BufferData<Vector2d>(BufferTarget.ArrayBuffer, (IntPtr)(positions.Length * Vector2d.SizeInBytes), positions, BufferUsageHint.StaticDraw);
            //assign shader attribute/variable to hold single buffer entries during rendering
            GL.VertexAttribPointer(IdHolder.VertexPositionID, 2, VertexAttribPointerType.Double, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, IdHolder.ColourBufferId);
            GL.BufferData<Vector3d>(BufferTarget.ArrayBuffer, (IntPtr)(colours.Length * Vector3d.SizeInBytes), colours, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(IdHolder.VertexColourID, 3, VertexAttribPointerType.Double, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0); //bind empty id to make sure no following calls modify any of the above buffers accidentally 
        }

        /// <summary>
        /// Fill the shader uniforms with the given values.
        /// </summary>
        private void FillUniforms()
        {
            //   Projection = Matrix4.CreateOrthographic(5, 5, 0.01f, 100f);
            //GL.UniformMatrix4(IdHolder.uniformModelViewMatrix, false, ref ModelView);
            Projection.M11 = 2f / (float)IdHolder.Width;
            Projection.M22 = 2f / (float)IdHolder.Height;
            Projection.M41 = -1f;
            Projection.M42 = -1f;
            GL.UniformMatrix4(IdHolder.uniformProjectionMatrix, false, ref Projection);
        }

        /// <summary>
        /// Enable the VertexArrays before rendering the respective shape
        /// </summary>
        private void EnableArrays()
        {
            GL.EnableVertexAttribArray(IdHolder.VertexPositionID);
            GL.EnableVertexAttribArray(IdHolder.VertexColourID);
        }

        /// <summary>
        /// Disable the VertexArrays after rendering the respective shape
        /// </summary>
        private void DisableArrays()
        {
            GL.DisableVertexAttribArray(IdHolder.VertexPositionID);
            GL.DisableVertexAttribArray(IdHolder.VertexColourID);
        }




        /// <summary> 
        /// Prepare shader attributes/variables, i.e. retrieve ids for them using the shader identifiers specified in IdHolder ("vTexture", "vPosition", ...)
        /// </summary>
        private void PrepareAttributes()
        {
            IdHolder.VertexPositionID = GL.GetAttribLocation(IdHolder.ProgId, IdHolder.VertexPositionVarName);
            IdHolder.VertexColourID = GL.GetAttribLocation(IdHolder.ProgId, IdHolder.VertexColourVarName);

            if (IdHolder.VertexPositionID == -1 || IdHolder.VertexColourID == -1)
            {
                Console.WriteLine(GL.GetError());
                Console.WriteLine("Error binding attributes");
                Console.Out.WriteLine(IdHolder.VertexPositionVarName + ": " + IdHolder.VertexPositionID);
                Console.Out.WriteLine(IdHolder.VertexColourVarName + ": " + IdHolder.VertexColourID);
            }
            else
            {
                Console.WriteLine("Successfully bound attributes");
                Console.Out.WriteLine(IdHolder.VertexPositionVarName + ": " + IdHolder.VertexPositionID);
                Console.Out.WriteLine(IdHolder.VertexColourVarName + ": " + IdHolder.VertexColourID);
            }

        }

        /// <summary>
        /// Prepare buffers, i.e. retrieve ids by generating buffers
        /// </summary>
        private void PrepareBuffers()
        {
            int position, colour;
            GL.GenBuffers(1, out position);
            GL.GenBuffers(1, out colour);

            IdHolder.PositionBufferId = position;
            IdHolder.ColourBufferId = colour;
        }

        /// <summary>
        /// Prepare uniform shader variables, i.e. retrieve ids for them using the shader identifiers specified in IdHolder
        /// </summary>
        private void PrepareUniforms()
        {
            
            IdHolder.uniformProjectionMatrix = GL.GetUniformLocation(IdHolder.ProgId, IdHolder.uni_projection);

       
            Console.Out.WriteLine(IdHolder.uni_projection + ": " + IdHolder.uniformProjectionMatrix);
        }
    }
}
