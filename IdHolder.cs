namespace ParticleSystems
{
    class IdHolder
    {
        //TODO: DOCS

        public static string VertexPositionVarName = "vertexPosition";

        public static string VertexColourVarName = "vertexColour";

        public int VertexPositionID { get; set; }

        public int VertexColourID { get; set; }

        /// <summary>
        /// Program id
        /// </summary>
        public int ProgId { get; set; }

        /// <summary>
        /// Vertex Shader id
        /// </summary>
        public int VertexId { get; set; }

        /// <summary>
        /// Fragment Shader id
        /// </summary>
        public int FragmentId { get; set; }

        public int PositionBufferId { get; set; }

        public int ColourBufferId { get; set; }

        /// <summary>
        /// Window Width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Window Height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Id for uniform ProjectionMatrix
        /// </summary>
        public int uniformProjectionMatrix { get; set; }

        /// <summary>
        /// Shader identifier for uniform projection matrix ("mProjection")
        /// </summary>
        public static string uni_projection = "mProjection";
    }
}
