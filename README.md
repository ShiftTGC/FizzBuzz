# FizzBuzz
Originally a small thing I made thanks to Tom Scott's FizzBuzz video (https://www.youtube.com/watch?v=QPZ0pIK_wsc)

I recommend that you do NOT use my source code or look at it. Not yet anyhow.
I recommend you first try and make your own version of a FizzBuzz generator. (I recommend watching the video I mentioned till 1:25)
Another reason I don't recommend looking at my code is... Well, it is messy to say the least.

# How to make true-single-file exe
For Visual Studio, open the project and in Developer PowerShell, write:
```PowerShell
dotnet publish -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "D:\Coding\Projects\C#\FizzBuzz\FizzBuzz\bin\publish\ShiftTGC"
```
Change what is after --output to where you want the exe to be saved.
It will generate 2 files, but you ONLY NEED THE EXE.

Doing it this way do make it a chunker of a file, but at least you get one, and only one, exe.
