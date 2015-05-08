@Echo off

Color 1B
Cls

@Echo **************************************************
@Echo *                                                *
@Echo * NAnt Script and a Batch file by IndianGuru     *
@Echo * Visit http://www.bhattji.com                   *
@Echo *                                                *
@Echo **************************************************

@REM * Change to the Drive where DNN3 is Installed *
C:

@REM * Change to the Path where C:\DNN\JRC45\DesktopModules\bhattji_SalesReps\Installation is Installed *
CD\DNN\JRC45\DesktopModules\bhattji_SalesReps\Installation

@Echo *                                                *
@Echo *                                                *
@Echo *                                                *
@Echo * Building a New DNN Module PA                   *
@Echo *                                                *
@Echo * Module PA Builder is ready to create           *
@Echo *                                                *
@Echo * a Module_PA.zip                                *
@Echo *                                                *
@Echo *                                                *
@Echo *                                                *
@Echo * Press Ctrl+C if you want to abort              *
@Echo * any other key to proceed                       *
@Echo *                                                *
@Echo *                                                *
@Echo *                                                *
@Echo **************************************************

Pause

@REM * Use Correct path where NAnt is Installed *
"C:\NAnt\nant-0.85\bin\NAnt.exe" -buildfile:MakeModule.build

@Echo **************************************************
@Echo *                                                *
@Echo *                                                *
@Echo *                                                *
@Echo * Module PA Builder has created                  *
@Echo *                                                *
@Echo * a New Module_PA.zip                            *
@Echo *                                                *
@Echo * Press any key to finish                        *
@Echo *                                                *
@Echo *                                                *
@Echo **************************************************

Pause

Cls
Color

@Echo **************************************************
@Echo *                                                *
@Echo * NAnt Script and a Batch file by IndianGuru     *
@Echo * Visit http://www.bhattji.com                   *
@Echo *                                                *
@Echo **************************************************

