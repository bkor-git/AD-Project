## Running the Executables

In this folder, we provide the executable files for **Train Station** and **Bi-directional Corridor Collision**, along with two helper scripts provided as `.txt` files. These executables run the simulation and export agent information as CSV files to your computer. 

> **Note:** Both files are provided as `.txt` for GitHub hosting. They must be renamed before use:
> - Rename `launch_bat.txt` → `launch_bat.bat`  
> - Rename `launch_vbs.txt` → `launch_vbs.vbs`

## Instructions
1. **Rename the Scripts** as noted above
2. **Update file paths** inside the scripts if needed
   - In `launch_bat.bat`, set the correct executable file name and number of iterations (`N`).  
   - In `launch_vbs.vbs`, set the correct path to `launch_bat.bat`.  
3. **Run the scripts**
   - To see the batch file run in a terminal, double-click `launch_bat.bat`.  
   - To run the batch file silently, double-click `launch_vbs.vbs`.

## Exported Files Location
The scripts export generated files to your **AppData** folder. You can find them here:
`C:\Users<YourUsername>\AppData\Local<YourAppFolder>`
     
> **Disclaimer:** These are executable files designed for use on Windows systems. Use them at your own risk. The authors are not responsible for any damage, data loss, or other issues that may result from running these files.
