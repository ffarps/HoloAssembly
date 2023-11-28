# HoloAssembly
an Augmented Reality Assembly guide App based on my Degree's final project

A unity 3D app for Android, capable of displaying information on an AR overlayed car.

Unity 2022.3.5f1

Vuforia v 10.17

Sounds from https://freesound.org/

### Future Work
- [ ] fix a bug that when the gaze hovers other object the outline stays on
- [ ] in starting the scene with the AR simulator verufy if any object is already marked as selected in the database so the outline is on
- [ ] fix the issue when there is no value stored in the database the connection to the database is not Working (it has something to do with the update method)
- [ ] fix "Not allowed to access vertices on mesh 'Windscreen washer reservoir' (isReadable is false; Read/Write must be enabled in import settings)"
- [ ] fix "Not allowed to access normals on mesh 'battery' (isReadable is false; Read/Write must be enabled in import settings)"
- [ ] improve UI scaling so that when the phone rotates, the width will be bigger than the heigh, so the ui must change, with the logo on the left, and the Buttons on the right.
- [ ] improve UI and Logo
- [ ] implement text mesh pro "loading... (finding Model/image)"
- [ ] implement a text mesh in the middle of the screen (above the Gaze) that says Looking for Image/Object (it varies whether it's an image or an object)


### Results:
#### App running in the Unity Editor:
[![IMAGE ALT TEXT](http://img.youtube.com/vi/8Fu11Rj5KjE/0.jpg)](https://youtu.be/8Fu11Rj5KjE "App running in the Unity Editor")
#### App running in an Android phone using a Image target (marker) 
[![IMAGE ALT TEXT](http://img.youtube.com/vi/hcyNxq3MUTk/0.jpg)](https://youtu.be/hcyNxq3MUTk "App running in an Android phone using a Image target (marker)")
#### App running in an Android phone using a Model target (Cad tracking) 
[![IMAGE ALT TEXT](http://img.youtube.com/vi/_uyqvXNGZjE/0.jpg)](https://youtu.be/_uyqvXNGZjE "App running in an Android phone using a Model target (Cad tracking)")
