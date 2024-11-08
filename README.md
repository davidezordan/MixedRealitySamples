# Mixed Reality Samples

My mixed reality playground using Unity, the Mixed Reality Toolkit (MRTK) and OpenVR.<br />

![](https://davidezordan.github.io/wp-content/uploads/2018/03/TwoHandsManipulations-04Device.jpg?raw=true)

Project uses models from:
- https://www.remix3d.com/details/G009SXJ40903?section=other-models

I’ve always been a big fan of manipulations, as in the past I worked on some multi-touch XAML Behaviors implementing rotate, translate and scale on 2D objects.

As I progress with my learning about HoloLens and Windows Mixed Reality, I had on my to-do list the task of exploring how to recreate this scenario in the 3D Mixed Reality context. Finally, during the weekend, I started some research while preparing a demo for some speaking engagements I’ll have over the next weeks.

<img class="aligncenter size-large wp-image-8277" src="https://davidezordan.github.io/wp-content/uploads/2018/03/TwoHandsManipulations-04Device-1024x576.jpg" alt="" width="660" height="371" />

As usual, the <a href="https://github.com/Microsoft/MixedRealityToolkit-Unity" target="_blank" rel="noopener">Mixed Reality Toolkit</a> is a fantastic help for speeding up development, so I started my investigation analysing the GitHub repo and found that the dev branch now contains a new <a href="https://github.com/Microsoft/MixedRealityToolkit-Unity/blob/Dev_Working_Branch/Assets/MixedRealityToolkit-Examples/Input/Readme/README_TwoHandManipulationTest.md" target="_blank" rel="noopener">readme</a> illustrating all the steps required to use a new Unity script <strong>TwoHandManipulatable.cs</strong> which enables rotate, translate and scale to 3D objects in Unity using two hands tap gestures with HoloLens and the Motion Controllers with the Immersive headsets.

I decided to give this a try using a model imported from the Remix 3D repository.
<h1>Importing the model from Remix 3D</h1>
I fired up <strong>Paint 3D</strong> and selected <strong>More models</strong> to explore the ones available online in <strong><a href="https://www.remix3d.com/" target="_blank" rel="noopener">Remix 3D</a></strong>: this is a great container of assets you can use in Mixed Reality apps. I chose to explore a model of the Mars Rover, so I selected and opened it.

Then I exported it as a <strong>3D FBX object</strong> to be able to import in Unity and saved it on my local machine as <strong>MarsRover.fbx</strong>.
<h1>Creating the Unity project</h1>
I started a new Unity Project, and copied the folder Assets\MixedRealityToolkit from the dev branch of the MRT GitHub repository.

After applying the <strong>Mixed Reality Project and Scene settings</strong> from the corresponding menu, I was ready to import the Mars Rover model and associate the manipulation script.

I selected <strong>Assets-&gt;Import New Asset</strong>, searched for the previously saved mode <strong>MarsRover.fbx</strong> and adjusted the scale to X:60, Y:60, Z:60 to have it correctly visualised in my scene. Then, I inserted a new <strong>Capsule Collider</strong> for enabling interaction with the object:

<img class="aligncenter size-large wp-image-8275" src="https://davidezordan.github.io/wp-content/uploads/2018/03/TwoHandsManipulations-02CapsuleCollider-1024x549.png" alt="" width="660" height="354" />
<h1>Adding the TwoHandManipulatable script</h1>
After selecting the imported model, I actioned the <strong>Add Component </strong>button from the inspector tab and searched for the <strong>Two Hand Manipulatable</strong> script in the toolkit and then added it to the asset together with a <strong>BoundingBoxBasic</strong> for showing the boundaries when applying manipulations.

<img class="aligncenter size-large wp-image-8276" src="https://davidezordan.github.io/wp-content/uploads/2018/03/TwoHandsManipulations-03TwoHandManipulatableScript-722x1024.png" alt="" width="660" height="936" />

And set the manipulation mode to <strong>Move Rotate Scale</strong>.

The scene was completed, so I only had to test it with the device: I selected the <strong>File-&gt;Build Settings</strong>, generated the package and deployed it to HoloLens, and I got the Mars Rover ready to be explored with two-handed manipulations. Amazing! <img class="aligncenter size-large wp-image-8277" src="https://davidezordan.github.io/wp-content/uploads/2018/03/TwoHandsManipulations-04Device-1024x576.jpg" alt="" width="660" height="371" />
