$src = (Get-Item -Path ".\" -Verbose).FullName;

Get-ChildItem $src -directory | where {$_.PsIsContainer} | Select-Object -Property Name | ForEach-Object {
    $cdProjectDir = [string]::Format("cd /d {0}\{1}",$src, $_.Name);
	
	$params=@("/C"; $cdProjectDir; " && buildrun"; )
	Start-Process -Verb runas "cmd.exe" $params;
} 