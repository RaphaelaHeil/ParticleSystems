#version 330

in vec3 vColour;
out vec4 outputColour;

//Fragment Shader
void main()
{
	outputColour = vec4(vColour, 0.0); //use the previously specified colour without any modification
}