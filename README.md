# Recipe Manager App - POE Submission

## Description
This is my final Portfolio of Evidence (POE) submission for my Recipe Manager app. It builds on the previous parts in the assignment, adding a graphical user interface (GUI) using Windows Presentation Foundation (WPF).

## New Features
- Graphical user interface (GUI) built with WPF in Visual Studio 
  - Recipe filtering by certain critera has been implemented 
  

## How to Run
1. Ensure you have Visual Studio 2022 installed with .NET 4.8 or newer (download link :https://visualstudio.microsoft.com/vs/community/)
2. Clone this repository
3. Open the solution file "PRO.sln" in Visual Studio
4. Build the solution (Build => Build Solution)
5. Run the application (Debug => Start Debug / press F5. The small "play" icon)

## Usage
Application Launch:
* Upon running the application, a GUI will be generated.

Creating a New Recipe:

Navigate to the "Recipe" tab at the top of the window and click it.
* A dropdown menu will appear with various option.
* Click the  "New Recipe" and follow the guided process to enter relevant data, including the recipe name, ingredient quantities, and calorie content.
* Press "Save" to add the data to local, volatile memory ( the data is not written to external storage as such when the program closes all data is lost).
* You will receive a notification that the data has been saved via a notification message box.
  
Manipulating Data:

* Go to the "Recipe" tab to access options for manipulating data.
* Recipes will appear under the "Recipe List" by default to aid in searching, filtering, and manipulating the data.
  
Scaling a Recipe:

* Select one of your pre-existing recipe you have created.
* Enter your scaling factor as a numerical input.
* The system will perform necessary calculations and alter the data accordingly.
  
Closing the Program:

* Option 1: Press the close icon (X) at the top right of the window.
* Option 2: Navigate to the "File" tab and select "Exit."

## Changes Based on Feedback
[Briefly describe (100-200 words) what you changed based on your lecturer's feedback from Part 2]

## GitHub Repository
https://github.com/Kashvir-Sewpersad/Prog-poe-part-3.git

## Additional Notes
- This submission includes a separate user manual PDF with more detailed usage instructions and screenshots.


## Known Issues
Challenges with foodGroup:
* Despite including the necessary functionality and methods for foodGroup, there are numerous runtime errors.
* Due to these issues, the foodGroup feature has been temporarily disabled.
* The rest of the program remains fully functional. 

## Thank you for making it to the end of my ReadMe
