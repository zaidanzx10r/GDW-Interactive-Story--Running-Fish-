# Intro to Computer Graphics Assignment 1

Given that we wanted to use this assignment to further develop our skills and resources for our GDW game we decided to use the same models and codebase we had created for the GDW game so that we could see how the graphics looked in context.

Nicholas Murray and Joseph Chahine are the two students working on the assignment itself and the implementation of all shaders, lighting, color grading, models, textures and movement/look scripts. 
Another student, Zaidan Van Graan, contributed to the movement script by adding audio for the footprints. He also contributed to the scripting for the Win/Lose condition which allows the player to enter a door and either win or lose the game and the menu. He did not contribute in any way to any of the graphical implementations added to the game scene. 

# Color Grading - Nicholas
I decided to play around with different ways to implement color grading. I had little success using the LUT tables and the code provided during lectures. I had modified the code to allow for the LUT 'contribution' slider to be accessible directly in the camera's inspector rather than having to change it through the shader itself. When implementing the color corrections I found them too strong as they overpowered the scene even with lower intensity so I tried changing the lighting mode in the projet settings from gamma to linear making things look less plastic. I also tried using the Post Processing Stack to create a Post Process Layer to overlay on the camera. This allowed for easier implementation of a vignette which helped darken the corners of the screen and give the game a more claustrophobic feel. I was also able to more effectively adjust the color grading filter by doing so directly in the inspector itself, saving time and resources from needing to pull a LUT into photoshop. This way also allowed me to see the changes made in real time in the context of the game which made for a more efficient workflow. With this I was able to desaturate the scene to give it an eerier, more bleached out and 'dead' look to the trees and grass. Without the color correction the greens and browns popped very brightly which contrasted too much with the dark and eerie nature of the scene's atmosphere. 

# Emissive Textures - Nicholas
For the emissive textures I used 3Dcoat to paint the word "Death" on a plane and gave it emissive properties through that software. It doesn't translate as well into Unity where I learned the importance of being able to use the shaders to achieve that in Unity itself. Doing so allowed me to create the effect I wanted by having "Death" be visible from far away even while not illuminated

# Toon Shaders - Joseph
For the metallic shader, first we set the base color to a grey (#c0c0c0) using a color variable, then connect a float named smoothness
To adjust the smoothness. Ambient occlusion is set to 1 to make the light affect it more directly (shaded where the light doesn't touch it and vice versa). A float called Metallic allows us to change how metallic and reflective it is. The emissions gives it a glow effect where the light shines.

# Void Shading - Joseph
For the void shade we have a gradient noise to create a randomized pattern going into a remap to keep its values small in the calculations. And a Simple noise to produces a sine wave of flashing to the gradient noise by multiplying sin time by a float value of 0.2 to control its speed.
Both of those are then multiplied together and fed into the unlit fragment base color.

# Metallic - Joseph
For the metallic shader, first we set the base color to a grey (#c0c0c0) using a color variable, then connect a float named smoothness
To adjust the smoothness. Ambient occlusion is set to 1 to make the light affect it more directly (shaded where the light doesn't touch it and vice versa). A float called Metallic allows us to change how metallic and reflective it is. The emissions gives it a glow effect where the light shines.

# Course Project - Final Assignment 

The following are the explanations required for each new implementation along with the updates and improvements made to the assignment 1 deliverables.

# Improvement
The first big improvement we made was to remake the model for the flashlight. The original model had too much additional, unnecessary, geometry which caused some issues with the normals. Entire faces of the prop would not appear. 

![image](https://github.com/user-attachments/assets/107ca32a-7a04-4b72-88ad-1ae008f7eb07)

The image above is the original model for the flashlight.

![image](https://github.com/user-attachments/assets/42768231-b9ec-4221-8546-8fcbac04ccb9)

Shown above is the updated model, with proper normals. The geometry is also cleaned up significantly.

Improvements were also made to preexisting textures.

The first was on the doors

![image](https://github.com/user-attachments/assets/e199c758-77aa-4d9e-bd52-2e20e11861fd)
![image](https://github.com/user-attachments/assets/3f0d573f-d3f6-4f53-ac8b-e60b3b2a8997)

The original door texture was very flat, lacking a normal map. It was entirely hand drawn by Nicholas. The bottom picture features our updated texture which was made in 3DCoat. A normal map was applied to add more depth to the wood planks and the metal of the frame, making the visuals much more interesting and fit in much better in an eerie world than a cartoonish hand drawn texture does. 

We made a similar change to the trees. Which, once having flat, solid colours as textures, are now complete with a more interesting texture that falls in line with the ambience of the game. It makes it easier to color grade as it isn't already made of bright colours. They feature normal maps as well. 

![image](https://github.com/user-attachments/assets/c8935bab-e6cb-4830-929f-2ed9672b6753)
![image](https://github.com/user-attachments/assets/a6957ebd-a959-44f5-84ac-6bdc9c3f9241)


# Texture
As previously mentioned, texturing was applied to the trees and doors. Textures were applied to every physical object in the game, with the player and the new flashlight being the only exceptions. This includes the water texture which was created using Substance Designer. I wanted to play around with the different resources that allow us to create our own textures. With 3DCoat I was afforded more precision to paint on textures directly onto the models which allowed me greater control over the look as I was able to see it applied immediately. Substance Designer allowed me to get more detailed with each attribute of the texture itself and make the normal mapping myself using the nodes. With these tools I was able to create multiple different textures in different ways and learned the value of each tool in the control it allows me. 
The blades of grass retain their original textures from Assignment 1. As do the large mountains and the grass plane the player walks on. Much of the texturing had already been completed in the first assignment, thus over 70% of the objects feature appropriate textures.

# Visual Effects
# Waves
A new addition to the scene was a small creek. We created a water shader that would not only apply waves but also featured a scrolling texture. This was a combination of two different shaders we went over in class. Combining the two allowed for a more dynamic creek as the texture moved with the waves themselves, making the illusion of downstream movement appear more convincingly. The shader was also made to be fully tileable, which allowed us to creat a creek that spans the length of the scene without needlessly stretching out the textures. The shader uses a sine function applied to each vertex of the plane to create the waves, this is why visually the waves actually look like a sine function.

![image](https://github.com/user-attachments/assets/43d6185c-0424-4816-9f74-8daa3fba1651)


# Glass

![image](https://github.com/user-attachments/assets/6899d0f6-64ae-4f22-87d2-cced2907c45c)

An example of the glass texture being used to create a glass door. 


# Particles

![image](https://github.com/user-attachments/assets/2d85558a-dacd-4b31-93c4-5da5df03c3cc)

