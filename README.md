###  Your Practice Builder - NSS Backend Capstone
#### Intro

This is my final assignment for Nashville Software School! It's been a long year. 
This is an MVC app using C#, ASP.net, AngularJS, Bootstrap, Moq unit testing, and the Google API.

#### Who is this app for?
For practicioners of Yoga, yogis. I try to keep up a regular routine, which requires at-home practice at times.  
There are a number of videos and books and even podcasts that will outline an at-home practice for you, but sooner or later it becomes necessary to practice on your own. I sought to design an app that would help lay out and organize routines for the at-home practicioner.  

#### What does it do?
The database comes pre-seeded with 20 yoga poses, including images and instructions borrowed fom Wikipedia. 
Users can select from these poses and organize them into practices. Once added to a practice, a pose's duration and side can be edited. You may wish to hold a pose longer than the typical 5 breaths, and many poses are performed one side at a time.  

The poses seeded in the database are 'base poses', which are used to generate 'user poses' that point back to and draw information from the base pose.
User poses are kept in a list, or practice. Each user has a list of practices.  
ERD: https://github.com/ryan-b-writin/PracticeBuilder/blob/master/PracticeBuilderERD.png  

A practice can be viewed as a slideshow, ideally on a laptop in front of their mat.

#### How do you use it?

To create a practice, the user will navigate to the Practice Builder. There, they will enter the desired practice name into a textbox and slick 'create' or press enter.  

Once created, a new practice is automatically selected. While in the builder, the user can click 'add pose' to be presented with a searchable list of base poses. Each pose has an 'add' button that will generate a user pose and add it to the current practice.  

Each pose in a practice has a 'view/edit' button that will allow them to change the duration or change the side to perform the pose on.  

In the 'practice viewer' the user can select a practice and click 'view as slideshow' to move through the practice.   Pressing any key will advance the slideshow.  

#### Future Plans

When I return to this project in the future, I would like to:  
-Seed more poses in the database  
-Allow for users to change the order of poses in the list rather than deleting poses and adding them again  
-Allow for users to view other users and their practices.  
