#version 330
in vec2 vertexPosition;
in vec3 vertexColour;
out vec3 vColour;
uniform mat4 mProjection;

// Vertex Shader  
void main()
{

gl_Position =  mProjection * vec4(vertexPosition, 0.0, 1.0);
//gl_Position = vec4(vertexPosition, 0.0, 1.0); //places all vertices in the same plane 
vColour = vertexColour;
}