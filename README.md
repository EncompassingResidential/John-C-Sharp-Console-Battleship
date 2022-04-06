John Console App Battleship

C# (C Sharp) Console App.  No web stuff, gasp.  Seriously, only ASCII characters.

It is run from the Command Line Interface (CLI) or double clicked from mouse.

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

### C# resources used

[Learning a LOT of the basics of C##](https://www.codecademy.com/courses/learn-c-sharp/lessons/csharp-inheritance/exercises/intro-inheritance)

https://aka.ms/new-console-template

[Checking for null from ReadLine](https://stackoverflow.com/questions/70291276/converting-null-literal-for-console-readline-for-string-input)

https://www.tutlane.com/tutorial/csharp/csharp-switch-case-statement-with-examples

https://www.csharp-examples.net/switch/

https://www.delftstack.com/howto/csharp/multiple-case-switch-in-csharp/

https://www.educba.com/2d-arrays-in-c-sharp/

https://www.programmersranch.com/2013/05/c-ascii-art-game-part-1.html
