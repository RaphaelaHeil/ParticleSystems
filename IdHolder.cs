namespace ParticleSystems
{
    /// <summary>
    /// Holds various IDs needed for rendering.
    /// </summary>
    class IdHolder
    {
        /// <summary>
        /// Shader identifier for the attribute containing the vertex position.
        /// </summary>
        public static string VertexPositionVarName = "vertexPosition";

        /// <summary>
        /// Shader identifier for the attribute containing the vertex colour.
        /// </summary>
        public static string VertexColourVarName = "vertexColour";

        /// <summary>
        /// Id of the vertex array containing the positions.
        /// </summary>
        public int VertexPositionID { get; set; }

        /// <summary>
        /// Id of the vertex array containing the colours.
        /// </summary>
        public int VertexColourID { get; set; }

        /// <summary>
        /// Id of the vertex array containing the placeable positions.
        /// </summary>
        public int ObstaclePositionID { get; set; }

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

        /// <summary>
        /// Id for the position buffer.
        /// </summary>
        public int PositionBufferId { get; set; }

        /// <summary>
        /// Id for the colour buffer.
        /// </summary>
        public int ColourBufferId { get; set; }

        /// <summary>
        /// Id for the placeable position buffer.
        /// </summary>
        public int ObstacleBufferId { get; set; }

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
