# John Ritz, Full Stack Programmer

BS in Computer Science
certified as a 2nd level Addiction Counselor (CADC II) in Oregon
certified as a Qualified Professional in Mental Health and Addiction in North Carolina

[You can find my CV Resume here at Linked In www](https://www.linkedin.com/in/johntritz/)

[Click here for my personal Life Coach website, specialty is Addiction after 5 years of addiction counseling in Oregon from 2016 to 2021](https://www.soberjourneycopilot.com/)

# John Console App Battleship

Hello Intrepid Explorer

Welcome to my C# (C Sharp) Console App. (Application)  You might not believe it, but this app has no web stuff, gasp.  Seriously, only ASCII characters. 
When I was growing up there was no handy mouse by the computers.  Only the keyboard.
There were no pictures on the screen.  Some creative people (bored? :-) would make an image
shown / drawn by only using the characters and numbers on the keyboard.  Here is an e.g. of a drawn "Hi" then converted to ASCII characters.

```
.lc.                                              
.:OO:.                          .:;               
  .c0k;                        ;OO:               
    .o0k;.                   .lKx.                
      .oOk:                 ,k0c                  
        .o0k,             .lKk'                   
          ;KO.           .cXd.              .,.   
           lXl          ,dKO.              cKWNx. 
           .OO.        .xWX:              .OMMMX; 
            dX;       .dK0c                'lxKd. 
           .k0'       lXl.                    ..  
           cXo       '0k.                .'.      
          .OO'       cNl                .dK:      
         .dNO:;;;;,.,kX;               'kKl.      
        .lXNOxxxxxkkON0'              '00;        
         '0k.      .cXx.             .xX:         
         cNl        dX:              lXo          
        .k0'       '0k.             cKd.          
        lXo        cNl             cKd.           
       ,0O.       .xX;            ;Xk.            
      .dX:        :Xx.            dX:             
      ;Kx.        dX:            ;Kx.             
     ;0O'         dX;           .dX:              
   'xKd.          cXd.           oX:     .,ll.    
   ;o,             lKk,          '0Kocldkkxd;.    
                    'c,           .:lll:'.        
```

The Battleship App is run from the Command Line Interface (CLI) or the .EXE can be double clicked from your mouse.
See instructions below to compile / build your executable to run.

## When the App comes up

### Initial Opening Screen

![Battle Ship Opening Screen](https://user-images.githubusercontent.com/94155021/164325773-49e6cd19-3373-41ed-bd93-aecf6959837c.png)

### Main Screen

![Battle Ship Main Screen - Initial screen after choosing your Call Sign Name](https://user-images.githubusercontent.com/94155021/164325679-63dd1a7c-4aba-446b-ac40-22592d972ace.png)

![Battle Ship Main Screen](https://user-images.githubusercontent.com/94155021/164325193-0dfa8440-0260-4291-ae65-5c1f0db23ea3.png)

### Sunk the Battleship screen

![Battle Ship Main Screen - Win screen Sunk the Battleship](https://user-images.githubusercontent.com/94155021/164325601-fe3aa19d-86fd-4ebf-bfe2-f343eb679e77.png)

### Easter Egg Screen

![Battle Ship Main Screen - Showing Easter Egg Radar option](https://user-images.githubusercontent.com/94155021/164325524-b5a073c0-bdb7-4d85-a428-40a05227a344.png)

# How to build and create the executable to run

### 1 - I used Visual Studio 2022 to compile then create an executable to run.

### 2 - Click on `Debug` or `Release` at the top of the screen:

![Visual Studio 2022 Debug or Release builds](https://user-images.githubusercontent.com/94155021/164475743-ef9aaafc-9b07-4365-8021-c24977bacb71.png)

### 3 - Then Choose `"Build Solution"` under the `"Build"` menu.

![Visual Studio 2022 Build Solution - Creating the executable to run](https://user-images.githubusercontent.com/94155021/164476311-9daae23c-0545-4cd4-8c77-4aec96a4b360.png)

### 4 - Then go to directory that is created by Visual Studio.  Such as:

```
    Directory: C:\Users\...\source\repos\John Console App Battleship\John Console App Battleship\bin\debug\net6.0

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a----         4/15/2022   6:28 AM            473 John Console App Battleship.deps.json
-a----         4/20/2022   2:05 PM          21504 John Console App Battleship.dll
-a----         4/20/2022   2:05 PM         148992 John Console App Battleship.exe
-a----         4/20/2022   2:05 PM          18084 John Console App Battleship.pdb
-a----         4/15/2022   6:28 AM            147 John Console App Battleship.runtimeconfig.json
```

### 5 - Once it is compiled 

`cd C:\Users\...\source\repos\John Console App Battleship\John Console App Battleship\bin\debug\net6.0`

or for Release / Production build go to

`cd C:\Users\...\source\repos\John Console App Battleship\John Console App Battleship\bin\Release\net6.0`

If you are in a Windows File manager then double click on `John Console App Battleship.exe`

If you are in your Command Line Interface (CLI) type in `John Console App Battleship.exe` and press Enter key (return key)


For PowerShell CLI see next section...


### In PowerShell how to run on command line:

'Found on https://www.delftstack.com/howto/powershell/running-executable-files-in-powershell/'

Start-Process -wait -FilePath '.\John Console App Battleship.exe'
~~~
or
The website said if you want "quiet mode" use this set of arguments '/s /v /qn'
~~~
'Start-Process -wait -FilePath '.\John Console App Battleship.exe' -ArgumentList '/s /v/qn' -PassThru'


~~~
PS C:\..\source\repos\John Console App Battleship\John Console App Battleship\bin\Debug\net6.0> Start-Process -wait -FilePath '.\John Console App Battleship.exe'
PS C:\..\source\repos\John Console App Battleship\John Console App Battleship\bin\Debug\net6.0> dir
  (use "git add <file>..." to include in what will be committed)
        .vscode/
    Directory: C:\..\source\repos\John Console App Battleship\John Console App Battleship\bin\Debug\net6.0
        John Console App Battleship/classes/
Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a----         3/23/2022   7:57 PM            473 John Console App Battleship.deps.json
-a----          4/1/2022   4:27 PM           8704 John Console App Battleship.dll
-a----          4/1/2022   4:27 PM         148992 John Console App Battleship.exe
-a----          4/1/2022   4:27 PM          11916 John Console App Battleship.pdb
-a----         3/23/2022   7:57 PM            147 John Console App Battleship.runtimeconfig.json
 ﻿namespace BattleShip
 {

PS C:\..\source\repos\John Console App Battleship\John Console App Battleship\bin\Debug\net6.0> Start-Process -wait -FilePath '.\John Console App Battleship.exe' -ArgumentList '/s /v/qn' -PassThru
-
Handles  NPM(K)    PM(K)      WS(K)     CPU(s)     Id  SI ProcessName
-------  ------    -----      -----     ------     --  -- -----------
     18       4      432       1984       0.02  28004   2 John Console App Battleship
     class Program
     {
~~~

## C# resources used

[Learning a LOT of the basics of C##](https://www.codecademy.com/courses/learn-c-sharp/lessons/csharp-inheritance/exercises/intro-inheritance)

https://aka.ms/new-console-template

[Checking for null from ReadLine](https://stackoverflow.com/questions/70291276/converting-null-literal-for-console-readline-for-string-input)

https://www.tutlane.com/tutorial/csharp/csharp-switch-case-statement-with-examples

https://www.csharp-examples.net/switch/

https://www.delftstack.com/howto/csharp/multiple-case-switch-in-csharp/

https://www.educba.com/2d-arrays-in-c-sharp/

https://www.programmersranch.com/2013/05/c-ascii-art-game-part-1.html

[For PowerShell checking if PowerShell (or script) is currently running with "Administor" privileges](https://serverfault.com/questions/95431/in-a-powershell-script-how-can-i-check-if-im-running-with-administrator-privil):
(New-Object System.Security.Principal.WindowsPrincipal([System.Security.Principal.WindowsIdentity]::GetCurrent())).IsInRole([System.Security.Principal.WindowsBuiltInRole]::Administrator)
