As a quick notice; you'll need a custom shader for the model. I'd suggest using Rero's Standard Shader Hack with Ramp enabled and set to .9, as that's 
the one I feel helps provide the closest thing to the original Source Engine look in HL2 and Garry's mod. 

I've set the scene up with two different versions of the same model.

One that uses the bottom row textures for the shirt and sleeves, while the other uses the bottom row.
Just toggle between the models for whichever Shirt and Sleeve combo you want to use on Male07_Mike.

The model also comes with Blinking and Lip sync based on the original Face Flexes it came with. Also has Custom Eye Tracking that I did myself. 
If you want the lip sync to work however, you are required to keep a controller
in your animator tab, and use a duplicate model without the controller if you want to make a portrait without the model 
swaying back and forth on you.

In regards to the Male Citizen Template.psd file, (Which you will have to get from the link in the description since VRCMods doesn't like files over 100mb) that's where you can customize the textures you want to use from
a list of various HL2, G-Mod and CSS Mods.

Like the provided default texture and the example I left, the textures in the template are 4k.

I've provided 17 different outfits for you to choose from, (19 if you count the blanks you use for color mixing)
16 different faces and 2 different hands for a different skin color.

To mix and match the textures, you need any photo editing software that can read .psd files. 
(I used Photoshop CS2 to make it.)

Next you open up the folders I made, and toggle the visibility between the parts you want to be visible or invisible.

After that you can just save the texture as a .png file in the textures folder.

But if you want to have a custom colored shirt and pants like in Garry's mod, what you do is make the textures that have, 
"Blank" in the name visible, as well as the flat color I put there as a place holder, then go through the color wheel 
to choose whatever color you want the shirt and pants to be. I already set that flat color layer to multiply in 
blending options which mixes those flat colors in with the plain white texture, and then save it as a .png file.

Once you've saved it and you didn't replace one of the pre-existing textures there, select the texture in unity, without
opening it up, and change the max size to 4096, and click apply. That ensures the textures are high quality.

Finally go into the materials folder and select either combined_material_1733235817 or Combo Mix, and replace the texture
there with the one you made in your image editing software.

As a note though; Some of the textures I included rely on the normal maps they came with for the exact detail, but I only 
provided the ones made for the Default Male 07 citizen sheet and the FFCM v1 version, as they are the ones I already made 
myself.

Credit to all of the great people who did these face, hand and outfit textures.