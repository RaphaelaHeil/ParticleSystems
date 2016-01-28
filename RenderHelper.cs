using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace ParticleSystems
{
    /// <summary>
    /// Helper class that handles rendering of various elements. 
    /// </summary>
    class RenderHelper
    {
        private IdHolder IdHolder;
        protected Matrix4 Projection = Matrix4.Identity;

        public RenderHelper(IdHolder idHolder)
        {
            IdHolder = idHolder;
            PrepareAttributes();
            PrepareBuffers();
            PrepareUniforms();
        }

        /// <summary>
        /// Renders particles based on the given positions and colours, assuming a 1:1 relationship between entries in both arrays (i.e. colour 1 belongs to position 1, 2 to 2, etc.).
        /// </summary>
        /// <param name="positions">Positions of the particles</param>
        /// <param name="colours">Colours of the particles</param>
        public void RenderParticles(Vector2d[] positions, Vector3d[] colours)
        {
            FillParticleBuffers(positions, colours);
            FillUniforms();
            EnableParticleArrays();
            GL.DrawArrays(PrimitiveType.Points, 0, positions.Length);

            DisableParticleArrays();
            GL.Flush();
        }

        /// <summary>
        /// Renders placeables, i.e. e.g. obstacles or optimum indicators. Currently no colouring is supported.
        /// </summary>
        /// <param name="placeables">Objects to render</param>
        public void RenderPlaceables(Vector2d[] placeables)
        {
            FillPlaceableBuffers(placeables);
            FillUniforms();
            EnablePlaceableArrays();
            GL.DrawArrays(PrimitiveType.Quads, 0, placeables.Length);

            DisablePlaceableArrays();
            GL.Flush();
        }


        /// <summary>
        /// Fill the Buffer Objects with the previously generated values for particle positions and colours.
        /// </summary>
        private void FillParticleBuffers(Vector2d[] positions, Vector3d[] colours)
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
        /// Fill the Buffer Object for the placeables.
        /// </summary>
        /// <param name="vertices"></param>
        private void FillPlaceableBuffers(Vector2d[] vertices)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, IdHolder.ObstacleBufferId); //bind buffer that will be modified
            //load data into selected buffer
            GL.BufferData<Vector2d>(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * Vector2d.SizeInBytes), vertices, BufferUsageHint.StaticDraw);
            //assign shader attribute/variable to hold single buffer entries during rendering
            GL.VertexAttribPointer(IdHolder.ObstaclePositionID, 2, VertexAttribPointerType.Double, false, 0, 0);
        }

        /// <summary>
        /// Fill the shader uniforms with the given values.
        /// </summary>
        private void FillUniforms()
        {
            Projection.M11 = 2f / (float)IdHolder.Width;
            Projection.M22 = 2f / (float)IdHolder.Height;
            Projection.M41 = -1f;
            Projection.M42 = -1f;
            GL.UniformMatrix4(IdHolder.uniformProjectionMatrix, false, ref Projection);
        }

        

        /// <summary>
        /// Enable the VertexArrays before rendering the respective shape
        /// </summary>
        private void EnableParticleArrays()
        {
            GL.EnableVertexAttribArray(IdHolder.VertexPositionID);
            GL.EnableVertexAttribArray(IdHolder.VertexColourID);
        }

        /// <summary>
        /// Enable the VertexArray before rendering the placeables.
        /// </summary>
        private void EnablePlaceableArrays()
        {
            GL.EnableVertexAttribArray(IdHolder.ObstaclePositionID);
        }

        /// <summary>
        /// Disable the VertexArrays after rendering the respective shape
        /// </summary>
        private void DisableParticleArrays()
        {
            GL.DisableVertexAttribArray(IdHolder.VertexPositionID);
            GL.DisableVertexAttribArray(IdHolder.VertexColourID);
        }

        /// <summary>
        /// Disable the VertexArray after rendering the placeables.
        /// </summary>
        private void DisablePlaceableArrays()
        {
            GL.DisableVertexAttribArray(IdHolder.ObstaclePositionID);
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
            int position, colour, obstacles;
            GL.GenBuffers(1, out position);
            GL.GenBuffers(1, out colour);
            GL.GenBuffers(1, out obstacles);

            IdHolder.PositionBufferId = position;
            IdHolder.ColourBufferId = colour;
            IdHolder.ObstacleBufferId = obstacles;
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
