$initialFolder = $pwd

cd src\TestsProject\bin\*\net452\

7z.exe a MyTest.zip "*.*" -r -x!"*.pdb"

cd $initialFolder