task default -depends Build


Framework "4.0"

properties {
    $unitTestAssembly = "NextDashboard.Test.Unit.dll"
    $projectConfig = "Debug"
    $base_dir = resolve-path .\
    $nunitPath = " $base_dir\packages\NUnit.Runners.2.6.3\Tools"
    $build_dir = "$base_dir\build"
    $test_dir = "$base_dir\Test.Unit\Bin\$projectConfig"
    $MSBuildArgs = '"/nologo" "/m" "/t:Build" "/p:VisualStudioVersion=10.0" "/p:Configuration=Debug" "/flp:NoSummary;logfile=msbuild.log" "/flp1:WarningsOnly;logfile=msbuildWarnings.log" "/flp2:ErrorsOnly;logfile=msbuildErrors.log" "/noconlog"'
}

task Setup {
	iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))
	exec {cmd.exe /c "SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"}
}

task Build {
  msbuild $MSBuildArgs NextDashboard.sln
}

task Build-CI -Alias CI -depends Build, Unit-Test

task Unit-Test  -Alias UT {
  Write-Host $nunitPath\nunit-console.exe
  exec {
		& $nunitPath\nunit-console.exe $test_dir\$unitTestAssembly /nologo /nodots /xml=TestResult.xml    
	}
  
}