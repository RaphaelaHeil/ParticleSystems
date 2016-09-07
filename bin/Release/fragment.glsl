#version 120

varying vec3 vColour;
//out vec4 outputColour;

//Fragment Shader
void main()
{
	gl_FragColor = vec4(vColour, 0.0); //use the previously specified colour without any modification
}