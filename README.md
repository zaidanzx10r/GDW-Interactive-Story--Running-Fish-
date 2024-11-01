# Intro to Computer Graphics Assignment 1

Given that we wanted to use this assignment to further develop our skills and resources for our GDW game we decided to use the same models and codebase we had created for the GDW game so that we could see how the graphics looked in context.

Nicholas Murray and Joseph Chahine are the two students working on the assignment itself and the implementation of all shaders, lighting, color grading, models, textures and movement/look scripts. 
Another student, Zaidan Van Graan, contributed to the movement script by adding audio for the footprints. He also contributed to the scripting for the Win/Lose condition which allows the player to enter a door and either win or lose the game and the menu. He did not contribute in any way to any of the graphical implementations added to the game scene. 

# Color Grading - Nicholas
I decided to play around with different ways to implement color grading. I had little success using the LUT tables and the code provided during lectures. I had modified the code to allow for the LUT 'contribution' slider to be accessible directly in the camera's inspector rather than having to change it through the shader itself. When implementing the color corrections I found them too strong as they overpowered the scene even with lower intensity so I tried changing the lighting mode in the projet settings from gamma to linear making things look less plastic. I also tried using the Post Processing Stack to create a Post Process Layer to overlay on the camera. This allowed for easier implementation of a vignette which helped darken the corners of the screen and give the game a more claustrophobic feel. I was also able to more effectively adjust the color grading filter by doing so directly in the inspector itself, saving time and resources from needing to pull a LUT into photoshop. This way also allowed me to see the changes made in real time in the context of the game which made for a more efficient workflow. With this I was able to desaturate the scene to give it an eerier, more bleached out and 'dead' look to the trees and grass. Without the color correction the greens and browns popped very brightly which contrasted too much with the dark and eerie nature of the scene's atmosphere. 

# Emissive Textures - Nicholas


# Toon Shaders - Joseph
For the metallic shader, first we set the base color to a grey (#c0c0c0) using a color variable, then connect a float named smoothness
To adjust the smoothness. Ambient occlusion is set to 1 to make the light affect it more directly (shaded where the light doesn't touch it and vice versa). A float called Metallic allows us to change how metallic and reflective it is. The emissions gives it a glow effect where the light shines.

# Void Shading - Joseph
For the void shade we have a gradient noise to create a randomized pattern going into a remap to keep its values small in the calculations. And a Simple noise to produces a sine wave of flashing to the gradient noise by multiplying sin time by a float value of 0.2 to control its speed.
Both of those are then multiplied together and fed into the unlit fragment base color.

# Metallic - Joseph
For the metallic shader, first we set the base color to a grey (#c0c0c0) using a color variable, then connect a float named smoothness
To adjust the smoothness. Ambient occlusion is set to 1 to make the light affect it more directly (shaded where the light doesn't touch it and vice versa). A float called Metallic allows us to change how metallic and reflective it is. The emissions gives it a glow effect where the light shines.
 # Movement & Look Scripts - Joseph
 # Textures & models - Nicholas
 
